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
        private PartnerBusiness partnerBusiness;
        private UserBusiness userBusiness;
        private User auxUser;

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

        public Trainer Read(int idTrainer)
        {
            data = new DataAccess();
            auxTrainer = new Trainer();
            
            userBusiness = new UserBusiness();
            auxUser = new User();

            partnerBusiness = new PartnerBusiness();

            try
            {
                data.SetQuery("select * from Trainers Where IdTrainer = @IdTrainer");
                data.SetParameter("@IdTrainer", idTrainer);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxTrainer.idTrainer = idTrainer;

                    auxTrainer.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxUser = userBusiness.Read(auxTrainer.idUser);
                    auxTrainer.userName = auxUser.userName;
                    auxTrainer.userPassword = auxUser.userPassword;
                    auxTrainer.role = auxUser.role;

                    auxTrainer.firstName = data.Reader["FirstName"].ToString();
                    auxTrainer.lastName = data.Reader["LastName"].ToString();

                    auxTrainer.partnersList = partnerBusiness.ListByTrainerId(idTrainer);
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

            return auxTrainer;
        }

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
