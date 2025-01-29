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
        //public string modalBodyText
        //{
        //    get { return txtModalBody.Text; }
        //    set { txtModalBody.Text = value; }
        //}

        //public string modalTitleText
        //{
        //    get { return txtModalTitle.Text; }
        //    set { txtModalTitle.Text = value; }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/DashBoard.aspx", false);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DashBoard.aspx", false);
        }
    }
}