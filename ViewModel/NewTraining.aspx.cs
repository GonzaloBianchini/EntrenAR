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


        protected void loadInitialData()
        {
            try
            {
                int idPartner = int.Parse(Request.QueryString["idPartner"].ToString());

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
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void loadTrainings()
        {
            try
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
                if (ddlTrainings.Items.Count > 0)
                {
                    enablePanelNewRoutine(true);
                }
                else
                {
                    enablePanelNewRoutine(false);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void enablePanelNewRoutine(bool flag)
        {
            try
            {
                if (flag)
                {
                    loadLabelsDatesLimit();
                    loadRoutines();
                    pnlNewDailyRoutine.Visible = true;
                }
                else
                {
                    pnlNewDailyRoutine.Visible = false;
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void loadRoutines()
        {
            try
            {
                //Si hay un solo elemento Training en la lista de Trainings, cargo este unico Training y vengo aca a cargar las rutinas
                dailyRoutineBusiness = new DailyRoutineBusiness();
                ddlDailyRoutines.DataSource = dailyRoutineBusiness.ListByTraining(int.Parse(ddlTrainings.SelectedValue));
                ddlDailyRoutines.DataBind();

                if (ddlDailyRoutines.Items.Count == 1)
                {
                    ddlDailyRoutines.SelectedIndex = 0;
                }
                if (ddlDailyRoutines.Items.Count > 0)
                {
                    enablePanelNewExercise(true);
                }
                else
                {
                    enablePanelNewExercise(false);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void enablePanelNewExercise(bool flag)
        {
            if (flag)
            {
                pnlNewExercise.Visible = true;
            }
            else
            {
                pnlNewExercise.Visible = false;
            }
        }

        protected void loadLabelsDatesLimit()
        {
            try
            {
                trainingBusiness = new TrainingBusiness();
                training = new Training();

                training = trainingBusiness.Read(int.Parse(ddlTrainings.SelectedValue));

                lblStartDateLimit.Text = "Fecha inicio: " + training.StartDate.ToShortDateString();
                lblEndDateLimit.Text = "Fecha fin: " + training.EndDate.ToShortDateString();
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }

        }

        //METODOS DEL VISUALIZADOR
        protected void loadVisualizer()
        {
            //CARGO EL VISUALIZADOR...

            loadTrainingsVisualizer();
            if (ddlTrainings.Items.Count > 0)
                loadRoutinesVisualizer();
        }

        protected void loadTrainingsVisualizer()
        {
            try
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
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void loadRoutinesVisualizer()
        {
            try
            {
                dailyRoutineBusiness = new DailyRoutineBusiness();
                int idTraining = int.Parse(ddlTrainingPrograms.SelectedValue);

                trainingBusiness = new TrainingBusiness();
                training = new Training();
                training = trainingBusiness.Read(idTraining);

                if (training.dailyRoutinesList.Count > 0)
                {
                    ddlRoutines.DataSource = dailyRoutineBusiness.ListByTraining(idTraining);
                    ddlRoutines.DataBind();

                    if (ddlRoutines.Items.Count == 1)
                    {
                        ddlRoutines.SelectedIndex = 0;
                    }

                    if (ddlRoutines.SelectedValue != "")
                        showRoutine();
                }
                else
                {
                    ddlRoutines.Items.Clear();
                    ddlRoutines.ClearSelection();
                    //ddlRoutines.DataBind();
                    gvRoutineExercises.Visible = false;
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void showRoutine()
        {
            try
            {
                gvRoutineExercises.Visible = true;
                dailyRoutineBusiness = new DailyRoutineBusiness();
                DailyRoutine dailyRoutineVisualizer = new DailyRoutine();
                dailyRoutineVisualizer = dailyRoutineBusiness.Read(int.Parse(ddlRoutines.SelectedValue));

                gvRoutineExercises.DataSource = dailyRoutineVisualizer.exercisesList;
                gvRoutineExercises.DataBind();
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        //EVENTOS DDL
        protected void ddlTrainings_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLabelsDatesLimit();
            loadRoutines();
        }

        protected void ddlTrainingPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRoutinesVisualizer();
        }

        protected void ddlRoutines_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRoutine();
        }

        //EVENTOS BOTONES
        protected void btnCreateTraining_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                createTraining();
                loadTrainings();
                loadVisualizer();
            }
        }

        protected void createTraining()
        {
            //TODO: IMPORTANTE! VALIDAR SI EL IdPartner QUE SE PASA EXISTE...SINO TIRAR EL ERROR CORRESPONDIENTE...
            //DONE: PARA LLEGAR ACA, SI O SI PASE POR EL PARTNER EN CUESTION....

            //TODO: TAMBIEN DEBO VALIDAR QUE LE PARTNER EN CUESTION TENGA TRAINER, SINO NO PUEDO CREAR UN TRAINING
            //DONE: SIN TRAINER ASIGNAD@ NO PUEDO GESTIONAR TRAININGS....


            try
            {
                int idPartner = int.Parse(lblIdPartner.Text);       // si es distinto de null, va bien...ojo

                trainingBusiness = new TrainingBusiness();
                trainingTypeBusiness = new TrainingTypeBusiness();
                training = new Training();

                training.idPartner = idPartner;
                training.Name = txtTrainingName.Text;
                training.Description = txtTrainingDescription.Text;
                training.Type = trainingTypeBusiness.Read(int.Parse(ddlTrainingTypes.SelectedValue));
                training.StartDate = DateTime.Parse(txtStartDate.Text);
                training.EndDate = DateTime.Parse(txtEndDate.Text);

                if (trainingBusiness.Create(training))
                {
                    clearFormNewTraining();
                    ucToast.ShowToast("Nuevo Entrenamiento", "Entrenamiento creado!", "bi-check-circle-fill", "text-success");
                    //enablePanelNewRoutine(true);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void clearFormNewTraining()
        {
            txtTrainingName.Text = string.Empty;
            txtTrainingDescription.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
        }


        protected void btnAddDailyRoutine_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                createDailyRoutine();
                loadRoutines();
                loadVisualizer();
            }
        }

        protected void createDailyRoutine()
        {
            try
            {
                dailyRoutineBusiness = new DailyRoutineBusiness();
                dailyRoutine = new DailyRoutine();
                dailyRoutine.idTraining = int.Parse(ddlTrainings.SelectedValue);
                dailyRoutine.dailyRoutineDate = DateTime.Parse(txtDailyRoutineDate.Text);

                //ACA VA UN IF WEY...
                if (dailyRoutineBusiness.Create(dailyRoutine))
                {
                    ucToast.ShowToast("Nueva Rutina", "Rutina creada!", "bi-check-circle-fill", "text-success");
                    //enablePanelNewExercise(true);
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
            
        }

        protected void btnAddExercise_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                addExerciseToDailyRoutine();
                loadVisualizer();
            }
        }

        protected void addExerciseToDailyRoutine()
        {
            try
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
                ucToast.ShowToast("Nuevo Ejercicio", "Ejercicio creado!", "bi-check-circle-fill", "text-success");
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        //CUSTOM VALIDATIONS
        protected void cvTrainingName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            trainingBusiness = new TrainingBusiness();

            try
            {
                List<string> trainingNamesAlreadyUsed = new List<string>();
                trainingNamesAlreadyUsed = trainingBusiness.ListByPartner(int.Parse(lblIdPartner.Text)).Select(u => u.Name).ToList();
                //Me quedo con los nombres de entrenamiento de PARTNER en cuestion...es decir, no se puede repetir nombre para mism@ PArtner

                if (trainingNamesAlreadyUsed.Contains(e.Value))
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
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }

        protected void cvEndDate_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
            {
                DateTime starDate = DateTime.Parse(txtStartDate.Text);

                DateTime endDate = DateTime.Parse(txtEndDate.Text);
                //int idTraining = int.Parse(ddlTrainings.SelectedValue);

                //TrainingBusiness trainingBusiness = new TrainingBusiness();
                //Training training = new Training();

                //training = trainingBusiness.Read(int.Parse(ddlTrainings.SelectedValue));

                if (endDate >= starDate)
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            } 
        }

        protected void cvDailyRoutineDate_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
            {
                int idTraining = int.Parse(ddlTrainings.SelectedValue);

                TrainingBusiness trainingBusiness = new TrainingBusiness();
                Training training = new Training();

                training = trainingBusiness.Read(int.Parse(ddlTrainings.SelectedValue));

                DateTime dailyRoutineDate = DateTime.Parse(txtDailyRoutineDate.Text);

                if ((dailyRoutineDate >= training.StartDate) && (dailyRoutineDate <= training.EndDate))
                {
                    e.IsValid = true;
                }
                else
                {
                    e.IsValid = false;
                }
            }
            catch (Exception)
            {
                Session.Add("error", "Problemas en la creacion de Entrenamiento =(");
                Response.Redirect("Error.aspx", true);
            }
        }
    }
}