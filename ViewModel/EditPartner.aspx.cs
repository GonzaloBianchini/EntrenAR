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
    public partial class EditPartner : System.Web.UI.Page
    {
        ProvinceBusiness provinceBusiness;
        PartnerBusiness partnerBusiness;
        Partner partner;
        //StatusPartnerBusiness statusPartnerBusiness;
        //RoleBusiness roleBusiness;
        List<Province> provinceList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    provinceBusiness = new ProvinceBusiness();
                    provinceList = new List<Province>();
                    provinceList = provinceBusiness.List();
                    ddlProvince.DataSource = provinceList;
                    ddlProvince.DataBind();

                    int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());
                    partnerBusiness = new PartnerBusiness();

                    partner = partnerBusiness.Read(idPartner);

                    lblTxtOldUserName.Text = partner.userName;
                    lblTxtOldDni.Text = partner.dni.ToString();
                    lblTxtOldEmail.Text = partner.email;

                    preLoadPartner(partner);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void preLoadPartner(Partner partner)
        {
            try
            {
                txtIdPartner.Text = partner.idPartner.ToString();

                txtUserName.Text = partner.userName;
                txtPassWord.Text = partner.userPassword;

                txtFirstName.Text = partner.firstName;
                txtLastName.Text = partner.lastName;

                txtDni.Text = partner.dni.ToString();
                txtBirthDate.Text = partner.birthDate.ToString();

                if (!string.IsNullOrEmpty(partner.gender))
                {
                    ddlGender.SelectedValue = partner.gender;
                }

                txtPhone.Text = partner.phone;
                txtCountry.Text = partner.address.country;
                txtEmail.Text = partner.email;

                txtStreetName.Text = partner.address.streetName;
                txtStreetNumber.Text = partner.address.streetNumber.ToString();

                if (!string.IsNullOrEmpty(partner.address.flat))
                {
                    txtFlat.Text = partner.address.flat;
                }

                if (!string.IsNullOrEmpty(partner.address.details))
                {
                    txtDetails.Text = partner.address.details;
                }

                txtCity.Text = partner.address.city;
                ddlProvince.SelectedValue = partner.address.province.idProvince.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnEditPartner_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    provinceBusiness = new ProvinceBusiness();
                    partnerBusiness = new PartnerBusiness();
                    partner = new Partner();
                    //roleBusiness = new RoleBusiness();
                    //statusPartnerBusiness = new StatusPartnerBusiness();

                    partner = partnerBusiness.Read(int.Parse(txtIdPartner.Text));   //pre-cargo le Partner

                    partner.userName = txtUserName.Text;
                    partner.userPassword = txtPassWord.Text;
                    //partner.role = roleBusiness.Read(3);
                    //partner.status = statusPartnerBusiness.Read(1);

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

                    bool edited;

                    if (partnerBusiness.Update(partner))
                    {
                        edited = true;
                        Session.Add("edited", edited);
                        Response.Redirect("ViewPartners.aspx", false);
                    }
                    else
                    {
                        ucToast.ShowToast("Editar Partner", "Partner No se actualizo...", "bi-x-circle-fill", "text-danger");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            List<string> userNamesAlreadyUsed = new List<string>();

            userNamesAlreadyUsed = userBusiness.List().Select(u => u.userName).ToList();    //me quedo con los userName...
            userNamesAlreadyUsed.Remove(lblTxtOldUserName.Text);                            //saco de la lista de prohibidos, al User viejo...

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
            List<int> dniNumbersAlreadyUsed = new List<int>();

            dniNumbersAlreadyUsed = partnerBusiness.List().Select(u => u.dni).ToList();     //me quedo con los dni...
            dniNumbersAlreadyUsed.Remove(int.Parse(lblTxtOldDni.Text));                     //saco de la lista de prohibidos, al Dni viejo...

            if (dniNumbersAlreadyUsed.Contains(int.Parse(e.Value)))
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
            List<string> emailNamesAlreadyUsed = new List<string>();

            emailNamesAlreadyUsed = partnerBusiness.List().Select(u => u.email).ToList();   //me quedo con los email...
            emailNamesAlreadyUsed.Remove(lblTxtOldEmail.Text);

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