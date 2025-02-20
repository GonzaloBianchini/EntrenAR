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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());
                lblIdPartner.Text = idPartner.ToString();

                if (!hasAnyRequest(idPartner))
                {
                    loadTrainers();
                }
                else
                {
                    loadLabelRequestSent();
                }

            }
        }

        protected bool hasAnyRequest(int idPartner)
        {
            PartnerBusiness partnerBusiness = new PartnerBusiness();

            return partnerBusiness.hasAnyRequest(idPartner);
        }

        protected void loadTrainers()
        {
            trainerBusiness = new TrainerBusiness();

            ddlTrainers.DataValueField = "idTrainer";
            ddlTrainers.DataTextField = "firstName";

            pnlSelectTrainers.Visible = true;
            pnlRequestSent.Visible = false;

            ddlTrainers.DataSource = trainerBusiness.List();
            ddlTrainers.DataBind();
        }

        protected void loadLabelRequestSent()
        {
            pnlSelectTrainers.Visible = false;
            pnlRequestSent.Visible = true;
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            Request request = new Request();
            RequestBusiness requestBusiness = new RequestBusiness();

            PartnerBusiness partnerBusiness = new PartnerBusiness();
            TrainerBusiness trainerBusiness = new TrainerBusiness();

            request.partner = partnerBusiness.Read(int.Parse(lblIdPartner.Text));
            request.trainer = trainerBusiness.Read(int.Parse(ddlTrainers.SelectedValue));
            request.creationDate = DateTime.Now;

            requestBusiness.Create(request);

            loadLabelRequestSent();
        }
    }
}