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
    public partial class ViewPartner : System.Web.UI.Page
    {
        private PartnerBusiness partnerBusiness;
        private Partner partner;
        private TrainerBusiness trainerBusiness;
        private Trainer trainer;
        //private TrainingBusiness trainingBusiness;
        //private Training training;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());

                trainer = new Trainer();
                trainerBusiness = new TrainerBusiness();

                partnerBusiness = new PartnerBusiness();
                partner = new Partner();
                partner = partnerBusiness.Read(idPartner);

                lblIdPartner.Text = idPartner.ToString();
                lblFirstName.Text = partner.firstName;
                lblLastName.Text = partner.lastName;
                lblDni.Text = partner.dni.ToString();
                lblBirthDate.Text = partner.birthDate.ToShortDateString();
                lblGender.Text = partner.gender.ToString();
                lblCountry.Text = partner.address.country;
                lblAddress.Text = partner.address.streetName + " " + partner.address.streetNumber;
                lblCity.Text = partner.address.city;
                lblProvince.Text = partner.address.province.name;
                lblEmail.Text = partner.email;
                lblPhone.Text = partner.phone;
                lblStatusPartner.Text = partner.status.Name;

                if (partner.trainingList.Count == 0)
                {
                    lblNoTrainings.Visible = true;
                    dgvTrainings.Visible = false;
                }
                else
                {
                    lblNoTrainings.Visible = false;
                    dgvTrainings.Visible = true;

                    dgvTrainings.DataSource = partner.trainingList;
                    dgvTrainings.DataBind();
                }

                trainer = trainerBusiness.GetTrainerByParterId(partner.idPartner);

                if (trainer.idTrainer == 0)
                {
                    lblNoTrainer.Visible = true;
                    dgvTrainer.Visible = false;
                }
                else
                {
                    lblNoTrainer.Visible = false;
                    dgvTrainer.Visible = true;
                    dgvTrainer.DataSource = new List<Trainer> { trainer };
                    dgvTrainer.DataBind();
                }
            }
        }

        protected void btnLetsGoTraining_Click(object sender, EventArgs e)
        {
            int idPartner = int.Parse(lblIdPartner.Text);
            Response.Redirect("ViewTrainings.aspx?idPartner=" + idPartner, false);
        }
    }
}