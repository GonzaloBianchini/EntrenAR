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
            //UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                provinceBusiness = new ProvinceBusiness();
                provinceList = new List<Province>();
                provinceList = provinceBusiness.List();
                ddlProvince.DataSource = provinceList;
                ddlProvince.DataBind();
            }
        }

        protected void btnCreatePartner_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    provinceBusiness = new ProvinceBusiness();
                    partnerBusiness = new PartnerBusiness();
                    partner = new Partner();
                    roleBusiness = new RoleBusiness();
                    statusPartnerBusiness = new StatusPartnerBusiness();

                    partner.userName = txtUserName.Text;
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
                    partner.address.streetNumber = txtStreetNumber.Text;
                    partner.address.country = txtCountry.Text;
                    partner.address.flat = txtFlat.Text;
                    partner.address.details = txtDetails.Text;
                    partner.address.city = txtCity.Text;

                    partner.address.province = provinceBusiness.Read(int.Parse(ddlProvince.SelectedValue));

                    if (partnerBusiness.Create(partner))
                    {
                        cleanForm();
                        ucToast.ShowToast("Alta Partner", "Partner Cread@!", "bi-check-circle-fill", "text-success");
                    }
                    else
                    {
                        ucToast.ShowToast("Alta Partner", "Partner No se guardo...", "bi-x-circle-fill", "text-danger");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void cleanForm()
        {
            txtUserName.Text = string.Empty;
            txtPassWord.Text = string.Empty;

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;

            txtDni.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            //gender

            txtPhone.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtEmail.Text = string.Empty;

            txtStreetName.Text = string.Empty;
            txtStreetNumber.Text = string.Empty;
            txtFlat.Text = string.Empty;

            txtDetails.Text = string.Empty;
            txtCity.Text = string.Empty;
            //province
        }

        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            List<string> userNamesAlreadyUsed = new List<string>();

            userNamesAlreadyUsed = userBusiness.List().Select(u => u.userName).ToList();    //me quedo con los userName...

            if (userNamesAlreadyUsed.Contains(e.Value))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected void cvDni_ServerValidate(object source, ServerValidateEventArgs e)
        {
            partnerBusiness = new PartnerBusiness();
            TrainerBusiness trainerBusiness = new TrainerBusiness();

            List<int> dniNumbersAlreadyUsed = new List<int>();

            dniNumbersAlreadyUsed = partnerBusiness.List().Select(u => u.dni).ToList();
            dniNumbersAlreadyUsed.AddRange(trainerBusiness.List().Select(x => x.dni));

            if(dniNumbersAlreadyUsed.Contains(int.Parse(e.Value)))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs e)
        {
            partnerBusiness = new PartnerBusiness();
            TrainerBusiness trainerBusiness = new TrainerBusiness();

            List<string> emailNamesAlreadyUsed = new List<string>();

            emailNamesAlreadyUsed = partnerBusiness.List().Select(u => u.email).ToList();
            emailNamesAlreadyUsed.AddRange(trainerBusiness.List().Select(x => x.email));

            if (emailNamesAlreadyUsed.Contains(e.Value))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
    }
}