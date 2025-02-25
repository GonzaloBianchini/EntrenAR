using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class Toast : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowToast(string title, string message, string icon = "bi-check-circle-fill", string textColor = "text-success")
        {
            string script = $"showToast('{title}', '{message}', '{icon}', '{textColor}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowToastScript", script, true);
        }
    }
}