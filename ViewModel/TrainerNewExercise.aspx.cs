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
    public partial class TrainerNewExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prueba READ OK
            ExerciseBusiness exercisesBusiness = new ExerciseBusiness();
            Exercise exercise = new Exercise();
            /*
            exercise = exercisesBusiness.Read(2);
            exercise.Name = "BENCH PRESS MODIFIED";
            exercise.IsActive = true;

            exercisesBusiness.UpdateExercise(exercise);
            */
            
            //
        }

        protected void btnCreateExercise_Click(object sender, EventArgs e)
        {
            ExerciseBusiness exercisesBusiness = new ExerciseBusiness();
            Exercise auxExercise = new Exercise();

            auxExercise.Name = txtExerciceName.Text;
            auxExercise.Description = txtExerciseDescription.Text;
            auxExercise.UrlExercise = txtUrlExercise.Text;

            try
            {
                exercisesBusiness.Create(auxExercise);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}