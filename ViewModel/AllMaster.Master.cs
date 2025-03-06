using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ViewModel
{
    public partial class AllMaster : System.Web.UI.MasterPage
    {
        private UserBusiness userBusiness;
        private User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            checkAndLoadUser();
        }

        protected void checkAndLoadUser()
        {
            userBusiness = new UserBusiness();
            user = new User();

            if (Session["user"] != null)
            {
                user = (User)Session["user"];
                lblUserType.Text = user.role.Name;
                lblUserName.Text = user.userName;
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("Login.aspx",false);
        }
    }
}