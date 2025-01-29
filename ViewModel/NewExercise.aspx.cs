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
    public partial class NewExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                //El modal se encarga del Redirect al DashBoard...
                //Response.Redirect("~/ViewExercises.aspx", false);
                //Response.Redirect("~/DashBoard.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}