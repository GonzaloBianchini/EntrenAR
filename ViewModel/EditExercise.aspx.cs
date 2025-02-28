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
    public partial class EditExercise : System.Web.UI.Page
    {
        private ExerciseBusiness exerciseBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                exerciseBusiness = new ExerciseBusiness();
                Exercise auxExercise = new Exercise();

                try
                {
                    int idExercise = int.Parse(Request.QueryString["idExercise"].ToString());

                    auxExercise = exerciseBusiness.Read(idExercise);

                    lblTxtOldName.Text = auxExercise.Name;
                    
                    txtIdExercise.Text = idExercise.ToString();
                    txtExerciceName.Text = auxExercise.Name;
                    txtExerciseDescription.Text = ((auxExercise.Description == string.Empty) || (auxExercise.Description is null)) ? string.Empty : auxExercise.Description;
                    txtUrlExercise.Text = (auxExercise.UrlExercise == string.Empty) || (auxExercise.UrlExercise is null) ? string.Empty : auxExercise.UrlExercise;

                    imgPreview.Src = ((auxExercise.ImageUrl == (object)DBNull.Value) || (auxExercise.ImageUrl == string.Empty)) ? "~/Images/notfound.jpg" : "~/Images/" + auxExercise.ImageUrl;
                    imgPreview.Style["display"] = "block";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnUpdateExercise_Click(object sender, EventArgs e)
        {
            exerciseBusiness = new ExerciseBusiness();
            Exercise auxExercise = new Exercise();

            if (Page.IsValid)
            {
                try
                {
                    //Preseteo el ejercicio en cuestion...
                    auxExercise = exerciseBusiness.Read(int.Parse(txtIdExercise.Text));

                    auxExercise.Name = txtExerciceName.Text;
                    auxExercise.Description = txtExerciseDescription.Text;
                    auxExercise.UrlExercise = txtUrlExercise.Text;

                    string path = Server.MapPath("./Images/");
                    if (txtImagen.HasFile)
                    {
                        string pictureName = auxExercise.Name + DateTime.Now.Ticks.ToString() + ".jpg";
                        txtImagen.PostedFile.SaveAs(path + pictureName);
                        auxExercise.ImageUrl = pictureName;
                    }


                    if (exerciseBusiness.Update(auxExercise))
                    {
                        Session.Add("edited",true);
                        Response.Redirect("ViewExercises.aspx",false);
                    }
                    else
                    {
                        ucToast.ShowToast("Actualizar Ejercicio", "El Ejercicio No se actualizo...", "bi-x-circle-fill", "text-danger");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        
        protected void cvExerciseName_ServerValidate(object source, ServerValidateEventArgs e)
        {
            exerciseBusiness = new ExerciseBusiness();
            List<string> exerciseNamesAlreadyUsed = new List<string>();

            exerciseNamesAlreadyUsed = exerciseBusiness.List().Select(u => u.Name).ToList();    //me quedo con los exerciseName...
            exerciseNamesAlreadyUsed.Remove(lblTxtOldName.Text);                                //saco de la lista de prohibidos, al nombre viejo...

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
