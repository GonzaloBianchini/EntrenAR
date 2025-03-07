using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.IsNullOrEmpty(Session["error"].ToString()) ? "Ocurrio un Error desconocido" : Session["error"].ToString();
            Session.Remove("user");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",false); // Redirige a la página principal
        }
    }
}