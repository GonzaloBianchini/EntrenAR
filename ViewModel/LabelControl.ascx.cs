using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class LabelControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblPRUEBE.Text = "BIENVENDE AL USER CONTROL PRUEBE";
            }
        }

        //protected void btnPRUEBE_Click(object sender, EventArgs e)
        //{
        //    lblPRUEBE.Text = "HICISTE CLICK EN PRUEBEEE";
        //}

        public void CambiarMensaje(string msg)
        {
            lblPRUEBE.Text = msg;   
        }


    }
}