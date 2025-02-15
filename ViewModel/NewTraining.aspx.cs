using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewModel
{
    public partial class NewTraining : System.Web.UI.Page
    {
        private TrainingBusiness trainingBusiness;
        private TrainingTypeBusiness trainingTypeBusiness;
        private List<TrainingType> trainingTypeList;
        private Training training;
        private PartnerBusiness partnerBusiness;
        private Partner partner;
        private DailyRoutineBusiness dailyRoutineBusiness;
        private DailyRoutine dailyRoutine;
        private ExerciseBusiness exerciseBusiness;
        private ExerciseInDailyRoutineBusiness exerciseInDailyRoutineBusiness;
        private Exercise exercise;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadInitialData();
            }
        }

        //SEGUIR PORACAAAA!!!! REFRESCAR TRAININGS Y RUTINAS EN VISUALIZER MIENTRAS VOY AGREGAAAANDOOO!
        //    PORACAAAA!!!! REFRESCAR TRAININGS Y RUTINAS EN VISUALIZER MIENTRAS VOY AGREGAAAANDOOO!
        //    PORACAAAA!!!! REFRESCAR TRAININGS Y RUTINAS EN VISUALIZER MIENTRAS VOY AGREGAAAANDOOO!
        //    PORACAAAA!!!! REFRESCAR TRAININGS Y RUTINAS EN VISUALIZER MIENTRAS VOY AGREGAAAANDOOO!
        //    PORACAAAA!!!! REFRESCAR TRAININGS Y RUTINAS EN VISUALIZER MIENTRAS VOY AGREGAAAANDOOO!


        protected void loadInitialData()
        {
            int idPartner = /*Request.QueryString["idPartner"].ToString() == null ? int.Parse(lblIdPartner.Text) :*/ int.Parse(Request.QueryString["idPartner"].ToString());

            partnerBusiness = new PartnerBusiness();
            partner = new Partner();

            partner = partnerBusiness.Read(idPartner);

            lblIdPartner.Text = idPartner.ToString();
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

            loadTrainings();
            loadVisualizer();
        }

        protected void loadTrainings()
        {
            Partner partner = new Partner();
            partnerBusiness = new PartnerBusiness();
            partner = partnerBusiness.Read(int.Parse(lblIdPartner.Text));

            ddlTrainings.DataSource = partner.trainingList;
            ddlTrainings.DataBind();

            if (ddlTrainings.Items.Count == 1)
            {
                ddlTrainings.SelectedIndex = 0;
            }
            if(ddlTrainings.Items.Count > 0)
                loadRoutines();
        }

        protected void loadVisualizer()
        {
            //CARGO EL VISUALIZADOR...

            loadTrainingsVisualizer();
            if(ddlTrainingPrograms.Items.Count > 0)
                loadRoutinesVisualizer();
        }

        protected void loadTrainingsVisualizer()
        {
            Partner partner = new Partner();
            partnerBusiness = new PartnerBusiness();
            partner = partnerBusiness.Read(int.Parse(lblIdPartner.Text));

            ddlTrainingPrograms.DataSource = partner.trainingList;
            ddlTrainingPrograms.DataBind();

            if (ddlTrainingPrograms.Items.Count == 1)
            {
                ddlTrainingPrograms.SelectedIndex = 0;
            }
        }

        protected void loadRoutinesVisualizer()
        {
            dailyRoutineBusiness = new DailyRoutineBusiness();
            int idTraining = int.Parse(ddlTrainingPrograms.SelectedValue);

            ddlRoutines.DataSource = dailyRoutineBusiness.ListByTraining(idTraining);
            ddlRoutines.DataBind();

            if (ddlRoutines.Items.Count == 1)
            {
                ddlRoutines.SelectedIndex = 0;
            }

            if(ddlRoutines.SelectedValue != "")
                showRoutine();
        }

        protected void ddlTrainings_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRoutines();
        }

        protected void loadRoutines()
        {
            //Si hay un solo elemento Training en la lista de Trainings, cargo este unico Training y vengo aca a cargar las rutinas
            dailyRoutineBusiness = new DailyRoutineBusiness();
            ddlDailyRoutines.DataSource = dailyRoutineBusiness.ListByTraining(int.Parse(ddlTrainings.SelectedValue));
            ddlDailyRoutines.DataBind();

            if (ddlDailyRoutines.Items.Count == 1)
            {
                ddlDailyRoutines.SelectedIndex = 0;
            }
        }

        protected void btnCreateTraining_Click(object sender, EventArgs e)
        {
            createTraining();
            loadTrainings();
        }


        protected void createTraining()
        {
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...

            //TAMBIEN DEBO VALIDAR QUE LE PARTNER EN CUESTION TENGA TRAINER, SINO NO PUEDO CREAR UN TRAINING

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
            createDailyRoutine();
            loadRoutines();
        }

        protected void createDailyRoutine()
        {
            dailyRoutineBusiness = new DailyRoutineBusiness();
            dailyRoutine = new DailyRoutine();
            dailyRoutine.idTraining = int.Parse(ddlTrainings.SelectedValue);
            dailyRoutine.dailyRoutineDate = DateTime.Parse(txtDailyRoutineDate.Text);

            dailyRoutineBusiness.Create(dailyRoutine);
        }

        protected void btnAddExercise_Click(object sender, EventArgs e)
        {
            addExerciseToDailyRoutine();
        }

        protected void addExerciseToDailyRoutine()
        {
            exerciseInDailyRoutineBusiness = new ExerciseInDailyRoutineBusiness();
            exercise = new Exercise();
            int idDailyRoutine = int.Parse(ddlDailyRoutines.SelectedValue);

            exercise.IdExercise = int.Parse(ddlExercises.SelectedValue);
            exercise.Sets = int.Parse(ddlSeries.SelectedValue);
            exercise.Reps = int.Parse(ddlReps.SelectedValue);
            exercise.Weight = decimal.Parse(txtWeight.Text);
            exercise.RestTime = int.Parse(txtRestTime.Text);

            exerciseInDailyRoutineBusiness.Create(idDailyRoutine, exercise);
        }

        protected void ddlTrainingPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRoutinesVisualizer();
        }

        protected void ddlRoutines_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRoutine();
        }

        protected void showRoutine()
        {
            dailyRoutineBusiness = new DailyRoutineBusiness();
            DailyRoutine dailyRoutineVisualizer = new DailyRoutine();
            dailyRoutineVisualizer = dailyRoutineBusiness.Read(int.Parse(ddlRoutines.SelectedValue));

            gvRoutineExercises.DataSource = dailyRoutineVisualizer.exercisesList;
            gvRoutineExercises.DataBind();
        }
    }
}