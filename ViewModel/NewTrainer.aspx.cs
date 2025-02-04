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
            //TrainerBusiness trainerBusiness = new TrainerBusiness();
            //Trainer auxTrainer = new Trainer();
            //RoleBusiness roleBusiness = new RoleBusiness();
            //Role auxRole = new Role();
            //auxRole = roleBusiness.Read(2);

            //auxTrainer.userName = "gonzofonzo1";
            //auxTrainer.userPassword = "paSsHarD12";
            //auxTrainer.role = auxRole;
            //auxTrainer.firstName = "Andres";
            //auxTrainer.lastName = "Bianchini";

            //trainerBusiness.Create(auxTrainer);



        }

        protected void btnCreateTrainer_Click(object sender, EventArgs e)
        {
            trainerBusiness = new TrainerBusiness();
            auxTrainer = new Trainer();
            roleBusiness = new RoleBusiness();
            auxRole = new Role();
            auxRole = roleBusiness.Read(2);

            auxTrainer.userName = txtUserName.Text;
            auxTrainer.userPassword = txtUserPassword.Text;
            auxTrainer.firstName = txtFirstName.Text;
            auxTrainer.lastName = txtLastName.Text;

            try
            {
                trainerBusiness.Create(auxTrainer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}