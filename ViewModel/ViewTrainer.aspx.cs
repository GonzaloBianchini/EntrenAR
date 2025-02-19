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
    public partial class ViewTrainer : System.Web.UI.Page
    {
        private Trainer trainer;
        private TrainerBusiness trainerBusiness;
        private RequestBusiness requestBusiness;
        private RequestStatusesBusiness requestStatusesBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idTrainer = int.Parse(Request.QueryString["idTrainer"].ToString());

                trainerBusiness = new TrainerBusiness();
                //trainer = new Trainer();
                trainer = trainerBusiness.Read(idTrainer);

                lblIdTrainer.Text = idTrainer.ToString();
                lblFirstName.Text = trainer.firstName;
                lblLastName.Text = trainer.lastName;
                lblUser.Text = trainer.userName;

                if (trainer.partnersList.Count == 0)
                {
                    lblNoPartners.Visible = true;
                    dgvPartners.Visible = false;
                }
                else
                {
                    lblNoPartners.Visible = false;
                    dgvPartners.Visible = true;

                    dgvPartners.DataSource = trainer.partnersList;
                    dgvPartners.DataBind();
                }

                List<Request> requestList = new List<Request>();
                RequestBusiness requestBusiness = new RequestBusiness();

                requestList = requestBusiness.ListByTrainer(idTrainer);
                //Pregunto por solicitudes en REVISION, descarto ACEPTADAS y RECHAZADAS
                requestList = requestList.Where(x => x.requestStatus.idRequestStatus == 1).ToList();

                if (requestList.Count == 0)
                {
                    lblNoRequests.Visible = true;
                    dgvRequests.Visible = false;
                }
                else
                {
                    lblNoRequests.Visible = false;
                    dgvRequests.Visible = true;

                    dgvRequests.DataSource = requestList;
                    dgvRequests.DataBind();
                }
            }
        }

        protected void btnAceptar_Command(object sender, CommandEventArgs e)
        {
            //ACA SE ACEPTA LA REQUEST
            if (e.CommandName == "Aceptar")
            {
                string idRequest = e.CommandArgument.ToString();
                //VERCOMO HACER PARA ACTUALIZAR LAS REQUEST O REDIRIGIR QUIZAS
                //Response.Redirect("ViewPartner.aspx?idPartner=" + idPartner);

                manageRequest(int.Parse(idRequest), 2);
            }
        }


        protected void btnRechazar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Rechazar")
            {
                string idRequest = e.CommandArgument.ToString();
                //VERCOMO HACER PARA ACTUALIZAR LAS REQUEST O REDIRIGIR QUIZAS
                //Response.Redirect("ViewPartner.aspx?idPartner=" + idPartner);

                manageRequest(int.Parse(idRequest), 3);
            }
        }
        protected void manageRequest(int idRequest,int status)
        {
            requestStatusesBusiness = new RequestStatusesBusiness();
            requestBusiness = new RequestBusiness();
            Request request = requestBusiness.Read(idRequest);
            request.requestStatus = requestStatusesBusiness.Read(status);    //1: en revision, 2: aceptada, 3: rechazada
            requestBusiness.Update(request);
        }
    }
}