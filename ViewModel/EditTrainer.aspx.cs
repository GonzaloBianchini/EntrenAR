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
    public partial class EditTrainer : System.Web.UI.Page
    {
        private TrainerBusiness trainerBusiness;
        private Trainer trainer;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int idTrainer = int.Parse(Request.QueryString["idTrainer"].ToString());
                    trainerBusiness = new TrainerBusiness();
                    trainer = new Trainer();
                    trainer = trainerBusiness.Read(idTrainer);

                    lblTxtOldUserName.Text = trainer.userName;
                    lblTxtOldDni.Text = trainer.dni.ToString();
                    lblTxtOldEmail.Text = trainer.email;

                    preLoadTrainer(trainer);
                }
                catch (Exception)
                {
                    Session.Add("error", "Problemas en Edicion de Trainer =(");
                    Response.Redirect("Error.aspx", true);
                }
            }
        }

        protected void preLoadTrainer(Trainer trainer)
        {
            try
            {
                txtIdTrainer.Text = trainer.idTrainer.ToString();
                txtUserName.Text = trainer.userName;
                txtUserPassword.Text = trainer.userPassword;

                txtFirstName.Text = trainer.firstName;
                txtLastName.Text = trainer.lastName;

                txtDni.Text = trainer.dni.ToString();
                txtPhone.Text = trainer.phone;
                txtEmail.Text = trainer.email;
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en Edicion de Trainer =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void btnEditTrainer_Click(object sender, EventArgs e)
        {
            
            if (Page.IsValid)
            {
                try
                {
                    trainerBusiness = new TrainerBusiness();
                    trainer = new Trainer();

                    trainer = trainerBusiness.Read(int.Parse(txtIdTrainer.Text));   //pre cargo le trainer...

                    trainer.userName = txtUserName.Text;
                    trainer.userPassword = txtUserPassword.Text;

                    trainer.firstName = txtFirstName.Text;
                    trainer.lastName = txtLastName.Text;

                    trainer.dni = int.Parse(txtDni.Text);
                    trainer.phone = txtPhone.Text;
                    trainer.email = txtEmail.Text;

                    if (trainerBusiness.Update(trainer))
                    {
                        Session.Add("edited", true);
                        Response.Redirect("ViewTrainers.aspx", false);
                    }
                    else
                    {
                        ucToast.ShowToast("Editar Trainer", "Trainer No se actualizo...", "bi-x-circle-fill", "text-danger");
                    }
                }
                catch (Exception)
                {
                    Session.Add("error", "Problemas en Edicion de Trainer =(");
                    Response.Redirect("Error.aspx", true);
                }
            }
        }

        protected void cvUserName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
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
            catch (Exception)
            {
                Session.Add("error", "Problemas en Edicion de Trainer =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void cvDni_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
            {
                trainerBusiness = new TrainerBusiness();
                List<int> dniNumbersAlreadyUsed = new List<int>();

                dniNumbersAlreadyUsed = trainerBusiness.List().Select(u => u.dni).ToList();     //me quedo con los dni...
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
            catch (Exception)
            {
                Session.Add("error", "Problemas en Edicion de Trainer =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
            {
                trainerBusiness = new TrainerBusiness();
                List<string> emailNamesAlreadyUsed = new List<string>();

                emailNamesAlreadyUsed = trainerBusiness.List().Select(u => u.email).ToList();   //me quedo con los email...
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
            catch (Exception)
            {
                Session.Add("error", "Problemas en Edicion de Trainer =(");
                Response.Redirect("Error.aspx", true);
            }
        }
    }
}