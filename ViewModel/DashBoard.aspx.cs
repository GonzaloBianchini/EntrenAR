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
    public partial class DashBoard : System.Web.UI.Page
    {
        private PartnerBusiness partnerBusiness;
        private TrainerBusiness trainerBusiness;
        private TrainingBusiness trainingBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();

            if (!IsPostBack)
            {
                //PARA MOSTRAR EL MENSAJE "LOGIN EXITOSO" SOLO UNA VEZ...
                if (Session["firstTimeLoggedIn"] != null && (bool)Session["firstTimeLoggedIn"] == true)
                {
                    ucToast.ShowToast("Log in", "LOGIN EXITOSO", "bi-check-circle-fill", "text-success");
                    Session.Remove("firstTimeLoggedIn");
                }

                user = (User)(Session["user"]);
                //TODO: PONER MACROS EN EL ID ROLE
                AdminPanel.Visible = user.role.IdRole == 1;
                TrainerPanel.Visible = user.role.IdRole == 2;
                PartnerPanel.Visible = user.role.IdRole == 3;

                loadMetrics();
                loadChartsData();
            }
        }

        private void loadMetrics()
        {
            partnerBusiness = new PartnerBusiness();
            trainerBusiness = new TrainerBusiness();

            int totalPartners = partnerBusiness.List().Count;
            int partnersAvailable = partnerBusiness.List().Where(p => p.status.IdStatus == 1).ToList().Count;    // me quedo con los partners AVAILABLE
            int partnersPending = partnerBusiness.List().Where(p => p.status.IdStatus == 2).ToList().Count;       // me quedo con los partners PENDING
            int partnersAssigned = partnerBusiness.List().Where(p => p.status.IdStatus == 3).ToList().Count;      // me quedo con los partners ASSIGNED

            lblTotalPartners.Text = totalPartners.ToString();
            lblPartnersAvailable.Text = partnersAvailable.ToString();
            lblPartnersPending.Text = partnersPending.ToString();
            lblPartnersAssigned.Text = partnersAssigned.ToString();

            int totalTrainers = trainerBusiness.List().Count;
            int partnersFemale = partnerBusiness.List().Where(p => p.gender == "Female" || p.gender == "Femenino").ToList().Count;                                         // me quedo con los partners Female
            int partnersMale = partnerBusiness.List().Where(p => p.gender == "Male" || p.gender == "Masculino").ToList().Count;                                            // me quedo con los partners Male
            int partnersNotInformed = partnerBusiness.List().Where(p => p.gender == "No informado" || p.gender == string.Empty || p.gender == null).ToList().Count;        // me quedo con los partners NOT INFORMED

            lblTrainers.Text = totalTrainers.ToString();
            lblPartnersFemale.Text = partnersFemale.ToString();
            lblPartnersMale.Text = partnersMale.ToString();
            lblPartnersNotInformed.Text = partnersNotInformed.ToString();
        }

        private void loadChartsData()
        {
            partnerBusiness = new PartnerBusiness();
            trainingBusiness = new TrainingBusiness();

            var partnersByProvince = partnerBusiness.getPartnersByProvince();
            var trainingsByType = trainingBusiness.getTrainingsByType();

            var partnersData = new
            {
                labels = partnersByProvince.Keys.ToArray(),
                values = partnersByProvince.Values.ToArray(),
                colors = GenerateColors(partnersByProvince.Count) // Colores dinámicos
            };

            var trainingsData = new
            {
                labels = trainingsByType.Keys.ToArray(),
                values = trainingsByType.Values.ToArray(),
                colors = GenerateColors(trainingsByType.Count) // Colores dinámicos
            };

            // Paso los datos a formato JSON
            string jsonPartners = Newtonsoft.Json.JsonConvert.SerializeObject(partnersData);
            string jsonTrainings = Newtonsoft.Json.JsonConvert.SerializeObject(trainingsData);

            // Paso los datos al front...
            ScriptManager.RegisterStartupScript(this, GetType(), "cargarGraficos",
                $"loadChartTraining({jsonTrainings}); loadChartPartners({jsonPartners});", true);
        }



        // Genero colores
        private string[] GenerateColors(int count)
        {
            string[] colorPalette = {
        "#FF6384", "#36A2EB", "#FFCE56", "#4CAF50", "#FF9800", "#9C27B0",
        "#03A9F4", "#E91E63", "#00BCD4", "#8BC34A", "#FF5722", "#795548"
            };

            // Si hay más provincias que colores en la lista, se repiten colores
            return Enumerable.Range(0, count).Select(i => colorPalette[i % colorPalette.Length]).ToArray();
        }
    }
}