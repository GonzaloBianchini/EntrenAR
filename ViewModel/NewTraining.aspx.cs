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
    public partial class NewTraining : System.Web.UI.Page
    {
        private TrainingBusiness trainingBusiness;
        private TrainingTypeBusiness trainingTypeBusiness;
        private List<TrainingType> trainingTypeList;
        private ExerciseBusiness exerciseBusiness;
        private Training training;
        private PartnerBusiness partnerBusiness;
        private Partner partner;
        private DaiyRoutineBusiness daiyRoutineBusiness;
        private DailyRoutine dailyRoutine;

        protected void Page_Load(object sender, EventArgs e)
        {
            //VALIDACION!! SI NO TIENE TRAINER, NO DEBE PODER AGREGAR TRAINING, ARROJAR MENSAJE DE ERROR,
            //LE PARTNER DEBE SOLICITAR TRAINER Y LA REQUEST DEBE SER ACEPTADA ANTES DE PONER UN TRAINING!!
            //cleanForm();

            if (!IsPostBack)
            {
                partnerBusiness = new PartnerBusiness();
                partner = new Partner();
                int idPartner = Request.QueryString["idPartner"].ToString() == null ? int.Parse(lblIdPartner.Text) : int.Parse(Request.QueryString["idPartner"].ToString());
                //int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());

                lblIdPartner.Text = idPartner.ToString();

                partner = partnerBusiness.Read(idPartner);

                lblPartnerName.Text = lblPartnerName.Text + partner.firstName + " " + partner.lastName;

                trainingTypeBusiness = new TrainingTypeBusiness();
                trainingTypeList = trainingTypeBusiness.List();
                ddlTrainingTypes.DataSource = trainingTypeList;
                ddlTrainingTypes.DataBind();

                exerciseBusiness = new ExerciseBusiness();
                ddlExercises.DataSource = exerciseBusiness.List();
                ddlExercises.DataBind();

                List<int> series = new List<int>();
                List<int> reps = new List<int>();
                series = Enumerable.Range(1, 10).ToList();
                reps = Enumerable.Range(1, 30).ToList();

                ddlSeries.DataSource = series;
                ddlSeries.DataBind();
                ddlReps.DataSource = reps;
                ddlReps.DataBind();
            }
            loadDdlTrainings();
            
        }

        protected void btnCreateTraining_Click(object sender, EventArgs e)
        {
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...

            //TAMBIEN DEBO VALIDAR QUE LE PARTNER EN CUESTION TENGA TRAINER, SINO NO PUEDO CREAR UN TRAINING

            //int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());
            int idPartner = int.Parse(lblIdPartner.Text);       // si es distinto de null, va bien...

            trainingBusiness = new TrainingBusiness();
            trainingTypeBusiness = new TrainingTypeBusiness();
            training = new Training();

            training.idPartner = idPartner;
            training.Name = txtTrainingName.Text;
            training.Description = txtTrainingDescription.Text;
            training.Type = trainingTypeBusiness.Read(int.Parse(ddlTrainingTypes.SelectedValue));
            training.StartDate = DateTime.Parse(txtStartDate.Text);
            training.EndDate = DateTime.Parse(txtEndDate.Text);

            trainingBusiness.Create(training);
        }
        protected void btnAddDailyRoutine_Click(object sender, EventArgs e)
        {
            DaiyRoutineBusiness daiyRoutineBusiness = new DaiyRoutineBusiness();
            dailyRoutine = new DailyRoutine();

            dailyRoutine.idTraining = int.Parse(ddlTrainingPrograms.SelectedValue);
            dailyRoutine.dailyRoutineDate = DateTime.Parse(txtDailyRoutineDate.ToString());

            daiyRoutineBusiness.Create(dailyRoutine);
        }

        protected void btnAddExercise_Click(object sender, EventArgs e)
        {

        }

        private void cleanForm()
        {
            txtTrainingName.Text = string.Empty;
            txtTrainingDescription.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
        }

        protected void ddlTrainings_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Si hay un solo elemento Trainingn en la lista de Trainings, cargo este unico Training y vengo aca a cargar las rutinas
            daiyRoutineBusiness = new DaiyRoutineBusiness();
            ddlDailyRoutines.DataSource = daiyRoutineBusiness.ListByTraining(int.Parse(ddlTrainings.SelectedValue));
        }

        protected void loadDdlTrainings()
        {
            partner = new Partner();
            partnerBusiness = new PartnerBusiness();
            partner = partnerBusiness.Read(int.Parse(lblIdPartner.Text));
            ddlTrainings.DataSource = partner.trainingList;
            ddlTrainings.DataBind();

            if (ddlTrainings.Items.Count == 1)
            {
                ddlTrainings_SelectedIndexChanged(ddlTrainings, EventArgs.Empty);
            }
        }
    }
}