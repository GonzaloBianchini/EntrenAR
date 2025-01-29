using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();

            if (!IsPostBack)
            {
                user = (User)(Session["user"]);
                //TODO: PONER MACROS EN EL ID ROLE
                AdminPanel.Visible = user.role.IdRole == 1 ;
                TrainerPanel.Visible = user.role.IdRole == 2;
                PartnerPanel.Visible = user.role.IdRole == 3;
            }
        }
    }
}