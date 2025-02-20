using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class AllMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void btnAceptar_Click(object sender, EventArgs e)
        //{
        //    //Response.Redirect("~/DashBoard.aspx", false);
        //}

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DashBoard.aspx", false);
        }

        protected void btnTraining_Click(object sender, EventArgs e)
        {
            //hace falta este redirect?debuggear y ver si es necesario o al venir al postback ya actualizo todo...
            //Response.Redirect("~/NewTraining.aspx", false);
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/ViewTrainer.aspx", false);
        }
    }
}