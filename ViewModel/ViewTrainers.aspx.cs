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
    public partial class ViewTrainers : System.Web.UI.Page
    {
        private TrainerBusiness trainerBusiness;
        private PartnerBusiness partnerBusiness;
        private Trainer trainer;
        private List<Trainer> trainersList;
        private RequestBusiness requestBusiness;
        private RequestStatusesBusiness requestStatusesBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                trainerBusiness = new TrainerBusiness();
                trainersList = new List<Trainer>();

                trainersList = trainerBusiness.List();

                dgvTrainersList.DataSource = trainersList;
                dgvTrainersList.DataBind();

                //loadPartners();
                //loadRequests();
            }

            //Pregunto si volvi de una edicion
            bool edited = (bool)(Session["edited"] ?? false);
            bool created = (bool)(Session["created"] ?? false);

            if (edited)
            {
                ucToast.ShowToast("Editar Trainer", "Trainer Actualizad@!", "bi-check-circle-fill", "text-success");
                Session["edited"] = false;
            }
            else if (created)
            {
                ucToast.ShowToast("Crear Trainer", "Trainer Cread@!", "bi-check-circle-fill", "text-success");
                Session["created"] = false;
            }
        }




        protected void btnViewTrainer_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                try
                {
                    int idTrainer = int.Parse(e.CommandArgument.ToString());
                    //Response.Redirect("ViewTrainer.aspx?idTrainer=" + idTrainer, false);

                    partnerBusiness = new PartnerBusiness();
                    //partner = partnerBusiness.Read(idPartner);

                    trainerBusiness = new TrainerBusiness();
                    trainer = new Trainer();

                    trainer = trainerBusiness.Read(idTrainer);

                    if (trainer != null)
                    {
                        loadPersonalInformation(trainer);

                        loadPartners();

                        loadRequests();

                        pnlTrainerDetails.Visible = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        protected void loadPersonalInformation(Trainer trainer)
        {
            lblIdTrainer.Text = trainer.idTrainer.ToString();
            lblFirstName.Text = trainer.firstName;
            lblLastName.Text = trainer.lastName;
            lblUserName.Text = trainer.userName;
            lblEmail.Text = trainer.email;
            lblPhone.Text = trainer.phone;
        }



        protected void loadPartners()
        {
            trainerBusiness = new TrainerBusiness();
            trainer = trainerBusiness.Read(int.Parse(lblIdTrainer.Text));

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
        }

        protected void loadRequests()
        {
            List<Request> requestList = new List<Request>();
            RequestBusiness requestBusiness = new RequestBusiness();

            requestList = requestBusiness.ListByTrainer(int.Parse(lblIdTrainer.Text));
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

        protected void manageRequest(int idRequest, int status)
        {
            requestStatusesBusiness = new RequestStatusesBusiness();
            requestBusiness = new RequestBusiness();
            Request request = requestBusiness.Read(idRequest);
            request.requestStatus = requestStatusesBusiness.Read(status);    //1: en revision, 2: aceptada, 3: rechazada
            requestBusiness.Update(request);

            loadPartners();
            loadRequests();
        }

        protected void btnCreateTrainer_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewTrainer.aspx", false);
        }

        protected void btnEditTrainer_Click(object sender, EventArgs e)
        {
            int idTrainer = int.Parse(lblIdTrainer.Text);
            Response.Redirect("EditTrainer.aspx?idTrainer=" + idTrainer, false);
        }

        protected void btnAceptar_Command(object sender, CommandEventArgs e)
        {
            //ACA SE ACEPTA LA REQUEST
            if (e.CommandName == "Aceptar")
            {
                //int idTrainer = int.Parse(lblIdTrainer.Text);
                string idRequest = e.CommandArgument.ToString();

                manageRequest(int.Parse(idRequest), 2);
            }
        }

        protected void btnRechazar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Rechazar")
            {
                //int idTrainer = int.Parse(lblIdTrainer.Text);
                string idRequest = e.CommandArgument.ToString();

                manageRequest(int.Parse(idRequest), 3);
            }
        }
    }
}