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
        protected void Page_Load(object sender, EventArgs e)
        {
            partnerBusiness = new PartnerBusiness();
            partnersList = new List<Partner>();

            partnersList = partnerBusiness.List();
            
            dgvPartnersList.DataSource = partnersList;
            dgvPartnersList.DataBind();

        }

        protected void btnViewPartner_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                string idPartner = e.CommandArgument.ToString();
                Response.Redirect("ViewPartner.aspx?idPartner=" + idPartner);
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
                Response.Redirect("NewTraining.aspx?idPartner=" + idPartner);
            }
        }
    }
}