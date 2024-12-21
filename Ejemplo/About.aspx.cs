using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using Domain;

namespace Ejemplo
{
    public partial class About : Page
    {
        private ExercisesBusiness exercisesBusiness;
        private List<Exercise> exerciseList;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                exercisesBusiness = new ExercisesBusiness();
                exerciseList = new List<Exercise>();
                exerciseList = exercisesBusiness.List();

                dgvExercises.DataSource = exerciseList;
                dgvExercises.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}