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

        private Trainer trainer;
        private Partner partner;
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = new User();
            try
            {
                if (!IsPostBack)
                {
                    //PARA MOSTRAR EL MENSAJE "LOGIN EXITOSO" SOLO UNA VEZ...
                    if (Session["firstTimeLoggedIn"] != null && (bool)Session["firstTimeLoggedIn"] == true)
                    {
                        ucToast.ShowToast("Log in", "LOGIN EXITOSO", "bi-check-circle-fill", "text-success");
                        Session.Remove("firstTimeLoggedIn");
                    }

                    user = (User)(Session["user"]);

                    switch (user.role.IdRole)
                    {
                        case 1:     //ADMIN
                            loadAdminDashBoard(user);
                            break;
                        case 2:     //TRAINER
                            loadTrainerDashBoard(user);
                            break;
                        case 3:     //PARTNER
                            loadPartnerDashBoard(user);
                            break;
                        default:    //Si no es ningun Rol conocido, te pateo.
                            Session.Remove("user");
                            Response.Redirect("Login.aspx", false);
                            break;
                    }
                }
            }
            catch (Exception)
            {

                Session.Add("error", "Problemas en el DashBoard =(");
                Response.Redirect("Error.aspx", true);
            }

        }

        protected void loadAdminDashBoard(User user)
        {
            AdminPanel.Visible = true;
            TrainerPanel.Visible = false;
            PartnerPanel.Visible = false;

            loadMetrics();
            loadChartsData();
        }

        protected void loadMetrics()
        {
            partnerBusiness = new PartnerBusiness();
            trainerBusiness = new TrainerBusiness();

            try
            {
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
            catch (Exception)
            {

                throw;
            }

        }

        protected void loadChartsData()
        {
            partnerBusiness = new PartnerBusiness();
            trainingBusiness = new TrainingBusiness();

            try
            {
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
            catch (Exception)
            {

                throw;
            }
        }

        // Genero colores
        protected string[] GenerateColors(int count)
        {
            string[] colorPalette = {
        "#FF6384", "#36A2EB", "#FFCE56", "#4CAF50", "#FF9800", "#9C27B0",
        "#03A9F4", "#E91E63", "#00BCD4", "#8BC34A", "#FF5722", "#795548"
            };

            // Si hay más provincias que colores en la lista, se repiten colores
            return Enumerable.Range(0, count).Select(i => colorPalette[i % colorPalette.Length]).ToArray();
        }

        protected void loadTrainerDashBoard(User user)
        {
            AdminPanel.Visible = false;
            TrainerPanel.Visible = true;
            PartnerPanel.Visible = false;

            trainerBusiness = new TrainerBusiness();
            trainer = new Trainer();

            try
            {
                trainer = trainerBusiness.ReadByUser(user.idUser);

                loadPersonalInformation(trainer);

                loadPartners(trainer);

                loadRequests(trainer);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void loadPersonalInformation(Trainer trainer)
        {
            lblIdTrainer.Text = trainer.idTrainer.ToString();
            lblFirstName.Text = trainer.firstName;
            lblLastName.Text = trainer.lastName;
            lblUserName.Text = trainer.userName;
            lblEmail.Text = trainer.email;
            lblPhone.Text = trainer.phone;
        }

        protected void loadPartners(Trainer trainer)
        {

            if (trainer.partnersList.Count == 0)
            {
                lblNoPartners.Visible = true;
                dgvPartners.Visible = false;
            }
            else
            {
                lblNoPartners.Visible = false;
                dgvPartners.Visible = true;

                dgvPartners.DataSource = trainer.partnersList;
                dgvPartners.DataBind();
            }
        }

        protected void loadRequests(Trainer trainer)
        {
            List<Request> requestList = new List<Request>();
            RequestBusiness requestBusiness = new RequestBusiness();

            try
            {
                requestList = requestBusiness.ListByTrainer(trainer.idTrainer);
                //Pregunto por solicitudes en REVISION, descarto ACEPTADAS y RECHAZADAS
                requestList = requestList.Where(x => x.requestStatus.idRequestStatus == 1).ToList();

                if (requestList.Count == 0)
                {
                    lblNoRequests.Visible = true;
                    dgvRequests.Visible = false;
                }
                else
                {
                    lblNoRequests.Visible = false;
                    dgvRequests.Visible = true;

                    dgvRequests.DataSource = requestList;
                    dgvRequests.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAceptar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                //ACA SE ACEPTA LA REQUEST
                if (e.CommandName == "Aceptar")
                {
                    //int idTrainer = int.Parse(lblIdTrainer.Text);
                    string idRequest = e.CommandArgument.ToString();

                    manageRequest(int.Parse(idRequest), 2);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnRechazar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Rechazar")
            {
                //int idTrainer = int.Parse(lblIdTrainer.Text);
                string idRequest = e.CommandArgument.ToString();

                manageRequest(int.Parse(idRequest), 3);
            }
        }

        protected void manageRequest(int idRequest, int status)
        {
            RequestStatusesBusiness requestStatusesBusiness = new RequestStatusesBusiness();
            RequestBusiness requestBusiness = new RequestBusiness();
            Request request = new Request();

            request = requestBusiness.Read(idRequest);
            request.requestStatus = requestStatusesBusiness.Read(status);    //1: en revision, 2: aceptada, 3: rechazada
            requestBusiness.Update(request);

            trainerBusiness = new TrainerBusiness();

            int idUser = ((User)(Session["user"])).idUser;

            loadPartners(trainerBusiness.ReadByUser(idUser));
            loadRequests(trainerBusiness.ReadByUser(idUser));
        }

        protected void loadPartnerDashBoard(User user)
        {
            AdminPanel.Visible = false;
            TrainerPanel.Visible = false;
            PartnerPanel.Visible = true;

            partnerBusiness = new PartnerBusiness();
            partner = new Partner();

            try
            {
                partner = partnerBusiness.ReadByUser(((User)Session["user"]).idUser);

                if (hasAnyRequestSent(partner.idPartner))
                {
                    loadLabelRequestSent();
                }
                else if (canSendRequest(partner.idPartner))
                {
                    loadTrainers();
                }
                else /*if (partner.trainingList.Count >= 0)*/
                {
                    enableTrainings(partner);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected bool hasAnyRequestSent(int idPartner)
        {
            PartnerBusiness partnerBusiness = new PartnerBusiness();
            try
            {
                return partnerBusiness.hasAnyRequestSent(idPartner);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void loadLabelRequestSent()
        {
            pnlSelectTrainers.Visible = false;
            pnlRequestSent.Visible = true;
            pnlTrainings.Visible = false;
        }

        protected bool canSendRequest(int idPartner)
        {
            PartnerBusiness partnerBusiness = new PartnerBusiness();

            try
            {
                return partnerBusiness.canSendRequest(idPartner);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        protected void loadTrainers()
        {
            try
            {
                trainerBusiness = new TrainerBusiness();

                ddlTrainers.DataValueField = "idTrainer";
                ddlTrainers.DataTextField = "firstName";

                pnlSelectTrainers.Visible = true;
                pnlRequestSent.Visible = false;
                pnlTrainings.Visible = false;

                ddlTrainers.DataSource = trainerBusiness.List();
                ddlTrainers.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void enableTrainings(Partner partner)
        {

            pnlSelectTrainers.Visible = false;
            pnlRequestSent.Visible = false;
            pnlTrainings.Visible = true;

            if (partner.trainingList.Count == 0)
            {
                lblNoTrainings.Visible = true;
                dgvTrainings.Visible = false;
                enableRoutines(false);
            }
            else
            {
                lblNoTrainings.Visible = false;
                dgvTrainings.Visible = true;
                dgvTrainings.DataSource = partner.trainingList;
                dgvTrainings.DataBind();
                enableRoutines(true);
            }
        }

        protected void enableRoutines(bool flag)
        {
            if (flag)
            {
                pnlRoutines.Visible = true;

            }
            else
            {
                pnlRoutines.Visible = false;
            }
            enableExercises(false);
        }

        protected void enableExercises(bool flag)
        {
            if (flag)
            {
                pnlExercises.Visible = true;
            }
            else
            {
                pnlExercises.Visible = false;
            }
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            try
            {
                Request request = new Request();
                RequestBusiness requestBusiness = new RequestBusiness();

                partnerBusiness = new PartnerBusiness();
                trainerBusiness = new TrainerBusiness();

                request.partner = partnerBusiness.ReadByUser(((User)Session["user"]).idUser);
                request.trainer = trainerBusiness.Read(int.Parse(ddlTrainers.SelectedValue));
                request.creationDate = DateTime.Now.Date;   //OJO OJO OJO! ACA LE AGREGUE EL .DATE para ver si me limita a la fecha sin hora...

                requestBusiness.Create(request);

                loadLabelRequestSent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnViewTraining_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idTraining = int.Parse(e.CommandArgument.ToString());

                DailyRoutineBusiness dailyRoutineBusiness = new DailyRoutineBusiness();
                List<DailyRoutine> dailyRoutinesList = new List<DailyRoutine>();

                dailyRoutinesList = dailyRoutineBusiness.ListByTraining(idTraining);

                enableRoutines(true);
                dgvRutines.DataSource = dailyRoutinesList;
                dgvRutines.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnRoutine_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int idDailyRoutine = int.Parse(e.CommandArgument.ToString());

                ExerciseBusiness exerciseBusiness = new ExerciseBusiness();
                List<Exercise> exercisesList = new List<Exercise>();

                exercisesList = exerciseBusiness.ListByDailyRoutine(idDailyRoutine);

                enableExercises(true);
                dgvExercises.DataSource = exercisesList;
                dgvExercises.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}