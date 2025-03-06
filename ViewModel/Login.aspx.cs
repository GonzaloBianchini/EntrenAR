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
            if (Page.IsValid)
            {
                Session.Add("firstTimeLoggedIn", true);
                Response.Redirect("~/Dashboard.aspx", false);
            }
            else
            {
                ucToast.ShowToast("LOG IN","LOG IN INCORRECTO", "bi-x-circle-fill", "text-danger");
            }
        }

        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            userBusiness = new UserBusiness();
            List<string> userNamesAlreadyUsed = new List<string>();

            userNamesAlreadyUsed = userBusiness.List().Select(u => u.userName).ToList();    //me quedo con los userName...

            if (userNamesAlreadyUsed.Contains(e.Value))
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }

        }

        protected void cvUserPassword_ServerValidate(object source, ServerValidateEventArgs e)
        {
            userBusiness = new UserBusiness();
            user = new User();

            try
            {
                user = userBusiness.ValidateCredential(txtUserName.Text, e.Value);

                if (user != null)
                {
                    e.IsValid = true;
                    Session.Add("user", user);
                }
                else
                {
                    e.IsValid = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx", false); // Redirige a la página de error
                //throw;
            }
        }
    }
}