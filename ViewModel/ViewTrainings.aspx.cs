using Business;
using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class ViewTrainings : System.Web.UI.Page
    {
        private TrainerBusiness trainerBusiness;
        private PartnerBusiness partnerBusiness;
        private Partner partner;
        protected void Page_Load(object sender, EventArgs e)
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
                else if (partner.trainingList.Count >= 0)
                {
                    loadTrainings(partner);
                }
            }
        }

        protected bool hasAnyRequestSent(int idPartner)
        {
            PartnerBusiness partnerBusiness = new PartnerBusiness();

            return partnerBusiness.hasAnyRequestSent(idPartner);
        }

        protected bool canSendRequest(int idPartner)
        {
            PartnerBusiness partnerBusiness = new PartnerBusiness();

            return partnerBusiness.canSendRequest(idPartner);
        }

        protected void loadTrainers()
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

        protected void loadTrainings(Partner partner)
        {
            if(partner.trainingList.Count == 0)
            {
                lblNoTrainings.Visible = true;
                pnlSelectTrainers.Visible = false;
            }
            else
            {
                lblNoTrainings.Visible = false;
                pnlTrainings.Visible = true;

                dgvTrainings.DataSource = partner.trainingList;
                dgvTrainings.DataBind();
            }
        }

        protected void loadLabelRequestSent()
        {
            pnlSelectTrainers.Visible = false;
            pnlRequestSent.Visible = true;
            pnlTrainings.Visible = false;
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
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

        protected void btnViewTraining_Click(object sender, EventArgs e)
        {
            //ACA DEBO CARGAR TODAS LAS RUTINAS EN TARJETAS PROBABLEMENTE...
        }
    }
}