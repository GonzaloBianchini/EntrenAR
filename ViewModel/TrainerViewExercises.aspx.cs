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

            //prueba user
            //UserBusiness userBusiness = new UserBusiness();
            //User auxUser = new User();

            //auxUser.FirstName = "Pepe";
            //auxUser.LastName = "Bian";
            //auxUser.BirthDate = DateTime.Parse("1988-11-02");
            //auxUser.Dni = 16416555;
            //auxUser.Phone = "47459806";
            //auxUser.Email = "pepe@uolsinectis.com";
            //auxUser.UserNickName = "peponio77";
            //auxUser.UserPassword = "pepelapeste";  

            //userBusiness.Create(auxUser);

            UserBusiness userBusiness = new UserBusiness();
            PartnerBusiness partnerBusiness = new PartnerBusiness();   
            RoleBusiness roleBusiness = new RoleBusiness();
            User user = new User();

            Partner partner = new Partner();
            partner.userName = "FONZOuSer";
            partner.userPassword = "passwordDificil";
            partner.role = roleBusiness.Read(2);
            //TODO: StatusPartner Business
            StatusPartner statusPartner = new StatusPartner();
            statusPartner.IdStatus = 1;
            statusPartner.Name = "Available";
            statusPartner.Description = "No tiene trainer y está buscando, puede enviar solicitudes";
            
            auxAddress.IdAddress = 1;
            auxAddress.StreetName = "Besares";
            auxAddress.StreetNumber = 2370;
            auxAddress.Flat = "9B";
            auxAddress.Details = string.Empty;
            auxAddress.City = "Victoria";
            auxAddress.Province = "BSAS";
            auxAddress.Country = "Arg";

            partner.status = statusPartner;
            partner.firstName = "Andres";
            partner.lastName = "Bianchinosky";
            partner.gender = "masculine";
            partner.birthDate = DateTime.Now;
            partner.dni = 124;
            partner.phone = "47459806";
            partner.email = "gonzamail@.com";
            partner.activeStatus = true;
            partner.address= auxAddress;

            
            partnerBusiness.Create(partner);
            //user.userName = "Fonzalo22";
            //user.userPassword = "Holaqtalco12";
            //user.role = roleBusiness.Read(2);

            //user.idUser = userBusiness.Create(user);

            lblIndex.Text = lblIndex.Text + partner.idUser.ToString();
        }
    }
}