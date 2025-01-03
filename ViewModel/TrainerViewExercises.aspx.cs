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
    public partial class TrainerViewExercises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExercisesBusiness exercisesBusiness = new ExercisesBusiness();
            List<Exercise> ExerciseList = exercisesBusiness.List();

            dgvExerciseList.DataSource = ExerciseList;
            dgvExerciseList.DataBind();


            //prueba Address
            AddressBusiness addressBusiness = new AddressBusiness();
            Address auxAddress = new Address();

            /*
            auxAddress.IdUser = 1;
            auxAddress.StreetName = "Besares";
            auxAddress.StreetNumber = 2370;
            auxAddress.Flat = "9B";
            auxAddress.Details = string.Empty;
            auxAddress.City = "Victoria";
            auxAddress.Province = "BSAS";
            auxAddress.Country = "Arg";

            addressBusiness.Create(auxAddress);
            */
            
            //auxAddress = addressBusiness.Read(7);
            //auxAddress.Details = "LA CASA LA CASA LA CASA";
            //addressBusiness.Update(auxAddress);
        }
    }
}