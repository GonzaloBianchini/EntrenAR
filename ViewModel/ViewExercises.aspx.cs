using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using Domain;


namespace ViewModel
{
    public partial class ViewExercises : System.Web.UI.Page
    {
        private ExerciseBusiness exerciseBusiness;
        private Exercise exercise;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExerciseBusiness exerciseBusiness = new ExerciseBusiness();
                List<Exercise> ExerciseList = exerciseBusiness.List();

                dgvExerciseList.DataSource = ExerciseList;
                dgvExerciseList.DataBind();
            }
            //Pregunto si volvi de una edicion
            bool edited = (bool)(Session["edited"] ?? false);

            if (edited)
            {
                ucToast.ShowToast("Editar Ejercicio", "Ejercicio Actualizado!", "bi-check-circle-fill", "text-success");
                Session["edited"] = false;
            }
        }

        protected void btnViewExercise_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int idExercise = int.Parse(e.CommandArgument.ToString());

                exerciseBusiness = new ExerciseBusiness();
                exercise = new Exercise();

                exercise = exerciseBusiness.Read(idExercise);

                if (exercise != null)
                {
                    lblExerciseName.Text = exercise.Name;
                    lblExerciseDescription.Text = exercise.Description;
                    imgExercise.ImageUrl = ((exercise.ImageUrl == (object)DBNull.Value) || (exercise.ImageUrl == string.Empty)) ? "~/Images/notfound.jpg" : "~/Images/" + exercise.ImageUrl;
                    lnkExerciseUrl.Text = exercise.UrlExercise;
                    lnkExerciseUrl.NavigateUrl = exercise.UrlExercise;

                    pnlExerciseDetails.Visible = true;
                }
            }
        }

        protected void btnEditExercise_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string idExercise = e.CommandArgument.ToString();
                Response.Redirect("EditExercise.aspx?idExercise=" + idExercise, false);
            }
        }

        protected void btnCreateExercise_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewExercise.aspx", false);
        }
    }
}