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
    public partial class Login : System.Web.UI.Page
    {
        User user;
        UserBusiness userBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarme_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            userBusiness = new UserBusiness();
            user = new User();

            string username = txtUserName.Text;
            string userPassword = txtUserPassword.Text;

            user = userBusiness.ValidateCredential(username, userPassword);

            if (user != null)
            {
                lblMessage.CssClass = "text-success";
                lblMessage.Visible = true;
                lblMessage.Text = "LOGIN COOORREEEECCCTOOO";
            }
            else
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Visible = true;
                lblMessage.Text = "LOGIN MAL MAL MAL";
            }
        }
    }
}