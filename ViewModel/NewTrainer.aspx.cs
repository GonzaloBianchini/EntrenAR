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
    public partial class AdminNewTrainer : System.Web.UI.Page
    {
        private TrainerBusiness trainerBusiness;
        private Trainer auxTrainer;
        RoleBusiness roleBusiness;
        Role auxRole;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateTrainer_Click(object sender, EventArgs e)
        {
            trainerBusiness = new TrainerBusiness();
            auxTrainer = new Trainer();
            roleBusiness = new RoleBusiness();
            auxRole = new Role();
            if (Page.IsValid)
            {
                try
                {
                    auxRole = roleBusiness.Read(2);

                    auxTrainer.userName = txtUserName.Text;
                    auxTrainer.userPassword = txtUserPassword.Text;
                    auxTrainer.firstName = txtFirstName.Text;
                    auxTrainer.lastName = txtLastName.Text;
                    auxTrainer.dni = int.Parse(txtDni.Text);
                    auxTrainer.email = txtEmail.Text;
                    auxTrainer.phone = txtPhone.Text;

                    if(trainerBusiness.Create(auxTrainer))
                    {
                        Session.Add("created", true);
                        Response.Redirect("ViewTrainers.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
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
            trainerBusiness = new TrainerBusiness();
            PartnerBusiness partnerBusiness = new PartnerBusiness();

            List<int> dniNumbersAlreadyUsed = new List<int>();

            dniNumbersAlreadyUsed = trainerBusiness.List().Select(u => u.dni).ToList();     //me quedo con los DNI de Trainers
            dniNumbersAlreadyUsed.AddRange(partnerBusiness.List().Select(x => x.dni));      //le agrego los DNI de Partners

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
            trainerBusiness = new TrainerBusiness();
            PartnerBusiness partnerBusiness = new PartnerBusiness();

            List<string> emailNamesAlreadyUsed = new List<string>();

            emailNamesAlreadyUsed = trainerBusiness.List().Select(u => u.email).ToList();
            emailNamesAlreadyUsed.AddRange(partnerBusiness.List().Select(x => x.email));

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