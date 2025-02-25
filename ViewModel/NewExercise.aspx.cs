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
        private ExerciseBusiness exerciseBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateExercise_Click(object sender, EventArgs e)
        {
            exerciseBusiness = new ExerciseBusiness();
            Exercise auxExercise = new Exercise();

            if (Page.IsValid)
            {

                try
                {
                    auxExercise.Name = txtExerciceName.Text;
                    auxExercise.Description = txtExerciseDescription.Text;
                    auxExercise.UrlExercise = txtUrlExercise.Text;

                    string path = Server.MapPath("./Images/");
                    if (txtImagen.HasFile)
                    {
                        txtImagen.PostedFile.SaveAs(path + auxExercise.Name + ".jpg");
                        auxExercise.ImageUrl = auxExercise.Name + ".jpg";
                    }
                    else
                    {
                        auxExercise.ImageUrl = string.Empty;
                    }

                    if (exerciseBusiness.Create(auxExercise))
                    {
                        cleanForm();
                        ucToast.ShowToast("Alta Ejercicio", "Ejercicio Guardado!", "bi-check-circle-fill", "text-success");
                    }
                    else
                    {
                        ucToast.ShowToast("Alta Ejercicio", "El Ejercicio No se guardo...", "bi-x-circle-fill", "text-danger");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void cleanForm()
        {
            txtExerciceName.Text = string.Empty;
            txtExerciseDescription.Text = string.Empty;
            txtUrlExercise.Text = string.Empty;
        }

        protected void cvExerciseName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            exerciseBusiness = new ExerciseBusiness();
            List<string> exerciseNamesAlreadyUsed = new List<string>();

            exerciseNamesAlreadyUsed = exerciseBusiness.List().Select(u => u.Name).ToList();    //me quedo con los exerciseName...

            if (exerciseNamesAlreadyUsed.Contains(e.Value))
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
    }
}