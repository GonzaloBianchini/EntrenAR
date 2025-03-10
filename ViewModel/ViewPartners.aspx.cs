﻿using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class ViewPartners : System.Web.UI.Page
    {
        private PartnerBusiness partnerBusiness;
        private List<Partner> partnersList;
        private Partner partner;
        private TrainerBusiness trainerBusiness;
        private Trainer trainer;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    partnerBusiness = new PartnerBusiness();
                    partnersList = new List<Partner>();

                    partnersList = partnerBusiness.List();

                    dgvPartnersList.DataSource = partnersList;
                    dgvPartnersList.DataBind();
                }

                //Pregunto si volvi de una edicion
                bool edited = (bool)(Session["edited"] ?? false);
                bool created = (bool)(Session["created"] ?? false);

                if (edited)
                {
                    ucToast.ShowToast("Editar Partner", "Partner Actualizad@!", "bi-check-circle-fill", "text-success");
                    Session["edited"] = false;
                }
                else if (created)
                {
                    ucToast.ShowToast("Crear Partner", "Partner Cread@!", "bi-check-circle-fill", "text-success");
                    Session["created"] = false;
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
            }

        }

        protected void btnViewPartner_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                try
                {
                    int idPartner = int.Parse(e.CommandArgument.ToString());
                    //Response.Redirect("ViewPartner.aspx?idPartner=" + idPartner, false);

                    partnerBusiness = new PartnerBusiness();
                    partner = partnerBusiness.Read(idPartner);

                    Trainer trainerBound = new Trainer();
                    trainerBusiness = new TrainerBusiness();

                    if (partner != null)
                    {
                        loadPersonalInformation(partner);

                        loadTrainingList(partner);

                        trainerBound = trainerBusiness.GetTrainerByParterId(partner.idPartner);

                        loadTrainerAndControls(partner, trainerBound);

                        pnlPartnerDetails.Visible = true;
                    }
                }
                catch (Exception)
                {
                    Session.Add("error", "Problemas para ver Partners =(");
                    Response.Redirect("Error.aspx", true);
                }
            }
        }

        protected void loadPersonalInformation(Partner partner)
        {
            try
            {
                lblIdPartner.Text = partner.idPartner.ToString();
                lblFirstName.Text = partner.firstName;
                lblLastName.Text = partner.lastName;
                lblDni.Text = partner.dni.ToString();
                lblBirthDate.Text = partner.birthDate.ToShortDateString();
                lblGender.Text = partner.gender.ToString();
                lblCountry.Text = partner.address.country;
                lblUserName.Text = partner.userName;
                lblAddress.Text = partner.address.streetName + " " + partner.address.streetNumber;
                lblCity.Text = partner.address.city;
                lblProvince.Text = partner.address.province.name;
                lblEmail.Text = partner.email;
                lblPhone.Text = partner.phone;
                lblStatusPartner.Text = partner.status.Name;
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void loadTrainingList(Partner partner)
        {
            if (partner.trainingList.Count == 0)
            {
                lblNoTrainings.Visible = true;
                dgvTrainings.Visible = false;
            }
            else
            {
                lblNoTrainings.Visible = false;
                dgvTrainings.Visible = true;

                dgvTrainings.DataSource = partner.trainingList;
                dgvTrainings.DataBind();
            }
        }

        protected void loadTrainerAndControls(Partner partner, Trainer trainer)
        {
            try
            {
                if (trainer.idTrainer == 0) //NO HAY PARTNER ASOCIAD@,ENTONCES MANDALE A BUSCAR TRAINER...
                {
                    btnManagePartner.Visible = false;   // NO TE DEJO METER ENTRENAMIENTOS SI NO HAY TRAINER ASOCIAD@

                    lblNoTrainer.Visible = true;
                    dgvTrainer.Visible = false;
                    lblRequestSent.Visible = false;

                    if (canSendRequest(partner.idPartner))
                    {
                        btnLetsGoTraining.Visible = true;
                        btnLetsGoTraining.Text = "SOLICITAR TRAINER";
                        lblRequestSent.Visible = false;
                    }
                    else if (hasAnyRequestSent(partner.idPartner))
                    {
                        btnLetsGoTraining.Visible = false;
                        lblRequestSent.Visible = true;
                    }
                }
                else //SI HAY PARTNER ASOCIAD@
                {
                    if (((User)Session["user"]).role.IdRole == 2)        //Si se logueo un Trainer...
                    {
                        Trainer trainerLoggedIn = new Trainer();
                        trainerBusiness = new TrainerBusiness();
                        trainerLoggedIn = trainerBusiness.ReadByUser(((User)Session["user"]).idUser);

                        if (trainerLoggedIn.idTrainer == trainer.idTrainer)     //Si le trainer en session es el trainerBound
                        {
                            btnManagePartner.Visible = true;
                        }
                        else
                        {
                            btnManagePartner.Visible = false;
                        }
                    }
                    else // POR ACA ENTRO SI ES ADMIN...no hay otra opcion de llegar hasta aca, siendo partner
                    {
                        btnManagePartner.Visible = true;   // TE DEJO METER ENTRENAMIENTOS SI HAY TRAINER ASOCIAD@, pero SOLO SI SOS ADMIN o TRAINER CORRECT@
                    }

                    lblNoTrainer.Visible = false;
                    dgvTrainer.Visible = true;
                    dgvTrainer.DataSource = new List<Trainer> { trainer };
                    dgvTrainer.DataBind();

                    lblRequestSent.Visible = false;

                    if (partner.trainingList.Count > 0) //tiene entrenamientos asociados, puede verlos...
                    {
                        btnLetsGoTraining.Visible = true;
                        btnLetsGoTraining.Text = "VER ENTRENAMIENTOS";
                    }
                    else //NO tiene entrenamientos asociados, no puede verlos...primero que gestione alguno
                    {
                        btnLetsGoTraining.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
            }

        }

        protected bool hasAnyRequestSent(int idPartner)
        {
            try
            {
                PartnerBusiness partnerBusiness = new PartnerBusiness();

                return partnerBusiness.hasAnyRequestSent(idPartner);
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
                return false;
            }

        }

        protected bool canSendRequest(int idPartner)
        {
            try
            {
                PartnerBusiness partnerBusiness = new PartnerBusiness();

                return partnerBusiness.canSendRequest(idPartner);
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
                return false;
            }

        }


        protected void btnLetsGoTraining_Click(object sender, EventArgs e)
        {
            try
            {
                int idPartner = int.Parse(lblIdPartner.Text);
                Response.Redirect("ViewTrainings.aspx?idPartner=" + idPartner, false);
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
            }
            
        }

        protected void btnCreatePartner_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPartner.aspx", false);
        }

        protected void btnEditPartner_Click(object sender, EventArgs e)
        {
            try
            {
                int idPartner = int.Parse(lblIdPartner.Text);
                Response.Redirect("EditPartner.aspx?idPartner=" + idPartner, false);
            }
            catch (Exception)
            {

                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
            }
            
        }

        protected void btnManagePartner_Click(object sender, EventArgs e)
        {
            try
            {
                int idPartner = int.Parse(lblIdPartner.Text);
                Response.Redirect("NewTraining.aspx?idPartner=" + idPartner, false);
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Partners =(");
                Response.Redirect("Error.aspx", true);
            }
        }


    }
}