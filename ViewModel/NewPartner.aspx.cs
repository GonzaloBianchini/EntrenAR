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
    public partial class TrainerNewClient : System.Web.UI.Page
    {
        ProvinceBusiness provinceBusiness;
        PartnerBusiness partnerBusiness;
        Partner partner;
        StatusPartnerBusiness statusPartnerBusiness;
        RoleBusiness roleBusiness;
        List<Province> provinceList;
        protected void Page_Load(object sender, EventArgs e)
        {
            provinceBusiness = new ProvinceBusiness();
            provinceList = new List<Province>();
            provinceList = provinceBusiness.List();
            ddlProvince.DataSource = provinceList;
            //ddlProvince.DataTextField = "name";
            //ddlProvince.DataValueField = "idProvince";
            ddlProvince.DataBind();
        }

        protected void btnCreatePartner_Click(object sender, EventArgs e)
        {
            provinceBusiness = new ProvinceBusiness();
            partnerBusiness = new PartnerBusiness();
            partner = new Partner();
            roleBusiness = new RoleBusiness();
            statusPartnerBusiness = new StatusPartnerBusiness();

            partner.userName = txtUser.Text;
            partner.userPassword = txtPassWord.Text;
            partner.role = roleBusiness.Read(3);

            partner.status = statusPartnerBusiness.Read(1);

            partner.firstName = txtFirstName.Text;
            partner.lastName = txtLastName.Text;
            partner.dni = int.Parse(txtDni.Text);
            partner.birthDate = DateTime.Parse(txtBirthDate.Text);
            partner.gender = ddlGender.SelectedValue;
            partner.phone = txtPhone.Text;
            partner.email = txtEmail.Text;

            partner.address.streetName = txtStreetName.Text;
            partner.address.streetNumber = int.Parse(txtStreetNumber.Text);
            partner.address.country = txtCountry.Text;
            partner.address.flat = txtFlat.Text;
            partner.address.details = txtDetails.Text;
            partner.address.city = txtCity.Text;

            partner.address.province = provinceBusiness.Read(int.Parse(ddlProvince.SelectedValue));

            partnerBusiness.Create(partner);
        }
    }
}