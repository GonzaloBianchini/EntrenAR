using Business;
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

            if (edited)
            {
                ucToast.ShowToast("Editar Partner", "Partner Actualizad@!", "bi-check-circle-fill", "text-success");
                Session["edited"] = false;
            }
        }

        protected void btnViewPartner_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int idPartner = int.Parse(e.CommandArgument.ToString());
                //Response.Redirect("ViewPartner.aspx?idPartner=" + idPartner, false);

                partnerBusiness = new PartnerBusiness();
                partner = partnerBusiness.Read(idPartner);

                trainer = new Trainer();
                trainerBusiness = new TrainerBusiness();

                if (partner != null)
                {
                    lblIdPartner.Text = idPartner.ToString();
                    lblFirstName.Text = partner.firstName;
                    lblLastName.Text = partner.lastName;
                    lblDni.Text = partner.dni.ToString();
                    lblBirthDate.Text = partner.birthDate.ToShortDateString();
                    lblGender.Text = partner.gender.ToString();
                    lblCountry.Text = partner.address.country;
                    lblAddress.Text = partner.address.streetName + " " + partner.address.streetNumber;
                    lblCity.Text = partner.address.city;
                    lblProvince.Text = partner.address.province.name;
                    lblEmail.Text = partner.email;
                    lblPhone.Text = partner.phone;
                    lblStatusPartner.Text = partner.status.Name;

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

                    trainer = trainerBusiness.GetTrainerByParterId(partner.idPartner);

                    if (trainer.idTrainer == 0)
                    {
                        lblNoTrainer.Visible = true;
                        dgvTrainer.Visible = false;
                    }
                    else
                    {
                        lblNoTrainer.Visible = false;
                        dgvTrainer.Visible = true;
                        dgvTrainer.DataSource = new List<Trainer> { trainer };
                        dgvTrainer.DataBind();
                    }

                    pnlPartnerDetails.Visible = true;
                }
            }
        }

        protected void btnEditPartner_Command(object sender, CommandEventArgs e)
        {

        }

        protected void btnManageTrainings_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Gestionar")
            {
                string idPartner = e.CommandArgument.ToString();
                Response.Redirect("NewTraining.aspx?idPartner=" + idPartner, false);
            }
        }

        protected void btnLetsGoTraining_Click(object sender, EventArgs e)
        {
            int idPartner = int.Parse(lblIdPartner.Text);
            Response.Redirect("ViewTrainings.aspx?idPartner=" + idPartner, false);
        }

        protected void btnCreatePartner_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditPartner_Click(object sender, EventArgs e)
        {

        }

        protected void btnManagePartner_Click(object sender, EventArgs e)
        {

        }
    }
}