using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TrainerBusiness
    {
        private DataAccess data;
        private Trainer auxTrainer;
        private UserBusiness userBusiness;
        private User auxUser;
        //private Role role;
        //private RoleBusiness roleBusiness;

        public TrainerBusiness()
        {

        }

        public int Create(Trainer trainer)
        {
            data = new DataAccess();
            int lastIndex;
            try
            {
                data.SetStoredProcedure("insert_trainer");
                data.SetParameter("@UserName", trainer.userName);
                data.SetParameter("@UserPassword", trainer.userPassword);
                data.SetParameter("@IdRole", 2 /*trainer.role.IdRole*/);
                data.SetParameter("@FirstName", trainer.firstName);
                data.SetParameter("@LastName", trainer.lastName);

                data.ExecuteRead();

                data.Reader.Read();
                lastIndex = int.Parse(data.Reader["LastId"].ToString());
            }
            catch (Exception ex)
            {
                lastIndex = 0;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return lastIndex;
        }

        //public Partner Read(int id)
        //{
        //    data = new DataAccess();
        //    auxPartner = new Partner();
        //    statusPartnerBusiness = new StatusPartnerBusiness();
        //    userBusiness = new UserBusiness();
        //    auxUser = new User();
        //    addressBusiness = new AddressBusiness();

        //    try
        //    {
        //        data.SetQuery("select * from Partners Where IdPartner=@IdPartner");
        //        data.SetParameter("@IdPartner", id);
        //        data.ExecuteRead();

        //        if (data.Reader.Read())
        //        {
        //            auxPartner.idPartner = id;

        //            auxPartner.idUser = int.Parse(data.Reader["IdUser"].ToString());
        //            auxUser = userBusiness.Read(auxPartner.idUser);
        //            auxPartner.userName = auxUser.userName;
        //            auxPartner.userPassword = auxUser.userPassword;
        //            auxPartner.role = auxUser.role;

        //            auxPartner.status = statusPartnerBusiness.Read(int.Parse(data.Reader["IdStatus"].ToString()));
        //            auxPartner.activeStatus = bool.Parse(data.Reader["ActiveStatus"].ToString());
        //            auxPartner.dni = int.Parse(data.Reader["Dni"].ToString());
        //            auxPartner.firstName = data.Reader["FirstName"].ToString();
        //            auxPartner.lastName = data.Reader["LastName"].ToString();
        //            auxPartner.gender = data.Reader["Gender"].ToString();
        //            auxPartner.email = data.Reader["Email"].ToString();
        //            auxPartner.phone = data.Reader["Phone"].ToString();
        //            auxPartner.birthDate = DateTime.Parse(data.Reader["Phone"].ToString());

        //            auxPartner.address = addressBusiness.Read(int.Parse(data.Reader["IdAddress"].ToString()));

        //            //TODO: LEER TrainingList!!
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        data.CloseConnection();
        //    }

        //    return auxPartner;
        //}
        public Trainer GetTrainerByParterId(int idPartner)
        {
            data = new DataAccess();
            Trainer trainer = new Trainer();
            userBusiness = new UserBusiness();
            auxUser = new User();

            try
            {
                data.SetQuery("select * from Trainers T INNER join PartnersByTrainer P ON T.IdTrainer = P.IdTrainer WHERE P.IdPartner = @IdPartner");
                data.SetParameter("@IdPartner", idPartner);
                data.ExecuteRead();

                if (data.Reader.Read())
                {

                    trainer.idUser = int.Parse(data.Reader["IdUser"].ToString());

                    auxUser = userBusiness.Read(trainer.idUser);

                    trainer.userName = auxUser.userName;
                    trainer.userPassword = auxUser.userPassword;
                    trainer.role = auxUser.role;

                    trainer.idTrainer = int.Parse(data.Reader["IdTrainer"].ToString());
                    trainer.firstName = data.Reader["FirstName"].ToString();
                    trainer.lastName = data.Reader["LastName"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return trainer;
        }

        //public bool Update(Partner partner)
        //{
        //    //TODO: verificar return
        //    data = new DataAccess();
        //    int rows;
        //    //roleBusiness = new RoleBusiness();
        //    try
        //    {
        //        data.SetQuery("UPDATE Users SET IdUser = @IdRole, UserNickName = @UserNickName, UserPassword = @UserPassword WHERE IdUser =@IdUser;");
        //        data.SetParameter("@IdRole", roleBusiness.Read(user.role.IdRole));
        //        data.SetParameter("@UserNickName", user.userName);
        //        data.SetParameter("@UserPassword", user.userPassword);
        //        data.SetParameter("@IdUser", user.idUser);

        //        rows = data.ExecuteAction();
        //    }
        //    catch (Exception ex)
        //    {
        //        rows = 0;
        //        throw ex;
        //    }
        //    finally
        //    {
        //        data.CloseConnection();
        //    }

        //    return (rows > 0);
        //}

        //public bool Delete(int id)
        //{
        //    return true;
        //}


        /*
        public List<Partner> List()
        {
            Data = new DataAccess();
            List<Partner> partnerList = new List<Partner>();

            try
            {
                Data.SetQuery("select * from Users where IdRole = 3 and IsActive = 1 ");
                Data.ExecuteRead();

                while (Data.Reader.Read())
                {
                    Partner auxPartner = new Partner();
                    auxPartner.IdPartner = Data.Reader[""]
                        auxPartner.IdUser

                //TODO: LEER TrainingList!!
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

            
            return partnerList;
        }
        */
        public List<Trainer> List()
        {

            data = new DataAccess();
            List<Trainer> trainersList = new List<Trainer>();

            try
            {
                data.SetQuery("select * from Trainers");
                data.ExecuteRead();

                //levanto los Trainers de la BD, pero no cargo todos los campos,
                //si necesito seleccionar algun Trainer,
                //hago un READ completo luego....

                while (data.Reader.Read())
                {

                    Trainer auxTrainer = new Trainer();

                    auxTrainer.idTrainer = int.Parse(data.Reader["IdTrainer"].ToString());
                    auxTrainer.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxTrainer.firstName = data.Reader["FirstName"].ToString();
                    auxTrainer.lastName = data.Reader["LastName"].ToString();

                    trainersList.Add(auxTrainer);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }


            return trainersList;
        }
    }
}
