﻿using Business;
using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.ConstrainedExecution;

namespace ViewModel
{
    public partial class ViewTrainings : System.Web.UI.Page
    {
        private TrainerBusiness trainerBusiness;
        private PartnerBusiness partnerBusiness;
        private Partner partner;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());
                    lblIdPartner.Text = idPartner.ToString();

                    partnerBusiness = new PartnerBusiness();
                    partner = new Partner();
                    partner = partnerBusiness.Read(idPartner);

                    lblPartnerName.Text += partner.firstName + " " + partner.lastName;

                    if (hasAnyRequestSent(idPartner))
                    {
                        loadLabelRequestSent();
                    }
                    else if (canSendRequest(idPartner))
                    {
                        loadTrainers();
                    }
                    else /*if (partner.trainingList.Count >= 0)*/
                    {
                        enableTrainings(partner);
                    }
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Entrenamientos =(");
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
                Session.Add("error", "Problemas para ver Entrenamientos =(");
                Response.Redirect("Error.aspx", true);
                return false;
            }
            
        }

        protected void loadLabelRequestSent()
        {
            pnlSelectTrainers.Visible = false;
            pnlRequestSent.Visible = true;
            pnlTrainings.Visible = false;
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
                Session.Add("error", "Problemas para ver Trainers =(");
                Response.Redirect("Error.aspx", true);
                return false;
            }
            
        }

        protected void loadTrainers()
        {
            try
            {
                trainerBusiness = new TrainerBusiness();

                ddlTrainers.DataValueField = "idTrainer";
                ddlTrainers.DataTextField = "firstName";

                pnlSelectTrainers.Visible = true;
                pnlRequestSent.Visible = false;
                pnlTrainings.Visible = false;

                ddlTrainers.DataSource = trainerBusiness.List();
                ddlTrainers.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Entrenamientos =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void enableTrainings(Partner partner)
        {
            try
            {
                pnlSelectTrainers.Visible = false;
                pnlRequestSent.Visible = false;
                pnlTrainings.Visible = true;

                if (partner.trainingList.Count == 0)
                {
                    lblNoTrainings.Visible = true;
                    dgvTrainings.Visible = false;
                    enableRoutines(false);
                }
                else
                {
                    lblNoTrainings.Visible = false;
                    dgvTrainings.Visible = true;
                    dgvTrainings.DataSource = partner.trainingList;
                    dgvTrainings.DataBind();
                    enableRoutines(true);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Entrenamientos =(");
                Response.Redirect("Error.aspx", true);
            }
            
        }

        protected void enableRoutines(bool flag)
        {
            if (flag)
            {
                pnlRoutines.Visible = true;

            }
            else
            {
                pnlRoutines.Visible = false;
            }
            enableExercises(false);
        }

        protected void enableExercises(bool flag)
        {
            if (flag)
            {
                pnlExercises.Visible = true;
            }
            else
            {
                pnlExercises.Visible = false;
            }
        }

        //EVENTOS BOTONES
        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                Request request = new Request();
                RequestBusiness requestBusiness = new RequestBusiness();

                PartnerBusiness partnerBusiness = new PartnerBusiness();
                TrainerBusiness trainerBusiness = new TrainerBusiness();

                request.partner = partnerBusiness.Read(int.Parse(lblIdPartner.Text));
                request.trainer = trainerBusiness.Read(int.Parse(ddlTrainers.SelectedValue));
                request.creationDate = DateTime.Now.Date;   //OJO OJO OJO! ACA LE AGREGUE EL .DATE para ver si me limita a la fecha sin hora...

                requestBusiness.Create(request);

                loadLabelRequestSent();
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Entrenamientos =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void btnViewTraining_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idTraining = int.Parse(e.CommandArgument.ToString());

                DailyRoutineBusiness dailyRoutineBusiness = new DailyRoutineBusiness();
                List<DailyRoutine> dailyRoutinesList = new List<DailyRoutine>();

                dailyRoutinesList = dailyRoutineBusiness.ListByTraining(idTraining);

                enableRoutines(true);
                dgvRutines.DataSource = dailyRoutinesList;
                dgvRutines.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Entrenamientos =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        

        protected void btnRoutine_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idDailyRoutine = int.Parse(e.CommandArgument.ToString());

                ExerciseBusiness exerciseBusiness = new ExerciseBusiness();
                List<Exercise> exercisesList = new List<Exercise>();

                exercisesList = exerciseBusiness.ListByDailyRoutine(idDailyRoutine);

                enableExercises(true);
                dgvExercises.DataSource = exercisesList;
                dgvExercises.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas para ver Entrenamientos =(");
                Response.Redirect("Error.aspx", true);
            }
            
        }
    }
}