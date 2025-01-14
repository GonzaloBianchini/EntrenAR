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
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Prueba Address
            //AddressBusiness addressBusiness = new AddressBusiness();
            //List<Address> addressesList = new List<Address>();
            //addressesList = addressBusiness.List();

            //dgvAddressList.DataSource = addressesList;
            //dgvAddressList.DataBind();
        }
    }
}