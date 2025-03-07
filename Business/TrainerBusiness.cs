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

        public bool Create(Trainer trainer)
        {
            data = new DataAccess();
            int lastIndex;
            bool flag;

            try
            {
                data.SetStoredProcedure("insert_trainer");
                data.SetParameter("@UserName", trainer.userName);
                data.SetParameter("@UserPassword", trainer.userPassword);
                data.SetParameter("@IdRole", 2 /*trainer.role.IdRole*/);
                data.SetParameter("@FirstName", trainer.firstName);
                data.SetParameter("@LastName", trainer.lastName);
                data.SetParameter("@Dni", trainer.dni);
                data.SetParameter("@Email", trainer.email);
                data.SetParameter("@Phone", trainer.phone);

                data.ExecuteRead();

                data.Reader.Read();
                lastIndex = int.Parse(data.Reader["LastId"].ToString());
                if (lastIndex > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception ex)
            {
                lastIndex = 0;
                flag = false;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return flag;
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
                    auxTrainer.dni = int.Parse(data.Reader["Dni"].ToString());
                    auxTrainer.email = data.Reader["Email"].ToString();
                    auxTrainer.phone = data.Reader["Phone"].ToString();

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

        public Trainer ReadByUser(int idUser)
        {
            data = new DataAccess();
            Trainer auxTrainer = new Trainer();

            userBusiness = new UserBusiness();
            partnerBusiness = new PartnerBusiness();

            try
            {
                data.SetQuery("select * from Trainers Where IdUser = @IdUser");
                data.SetParameter("@IdUser", idUser);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxTrainer.idTrainer = int.Parse(data.Reader["IdTrainer"].ToString());

                    auxTrainer.idUser = idUser;
                    auxUser = userBusiness.Read(idUser);
                    auxTrainer.userName = auxUser.userName;
                    auxTrainer.userPassword = auxUser.userPassword;
                    auxTrainer.role = auxUser.role;

                    auxTrainer.firstName = data.Reader["FirstName"].ToString();
                    auxTrainer.lastName = data.Reader["LastName"].ToString();
                    auxTrainer.dni = int.Parse(data.Reader["Dni"].ToString());
                    auxTrainer.email = data.Reader["Email"].ToString();
                    auxTrainer.phone = data.Reader["Phone"].ToString();

                    auxTrainer.partnersList = partnerBusiness.ListByTrainerId(auxTrainer.idTrainer);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                data.CloseConnection();
            }

            return auxTrainer;
        }

        public bool Update(Trainer trainer)
        {
            data = new DataAccess();
            int rows = 0;
            userBusiness = new UserBusiness();
            auxUser = new User();

            try
            {
                auxUser.idUser = trainer.idUser;
                auxUser.userName = trainer.userName;
                auxUser.userPassword = trainer.userPassword;
                auxUser.role = trainer.role;

                if (userBusiness.Update(auxUser))
                {
                    rows = 1;   //si actualiza User, lo detecto...
                }

                data.SetQuery("UPDATE Trainers SET FirstName = @FirstName, LastName = @LastName, Dni = @Dni, Email = @Email, Phone = @Phone WHERE IdTrainer = @IdTrainer;");
                data.SetParameter("@FirstName", trainer.firstName);
                data.SetParameter("@LastName", trainer.lastName);
                data.SetParameter("@Dni", trainer.dni);
                data.SetParameter("@Email", trainer.email);
                data.SetParameter("@Phone", trainer.phone);
                data.SetParameter("@IdTrainer", trainer.idTrainer);

                rows = rows + data.ExecuteAction();     //si actualiza Trainer, lo detecto...
            }
            catch (Exception ex)
            {
                rows = 0;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return (rows > 0);
        }

        public Trainer GetTrainerByParterId(int idPartner)
        {
            data = new DataAccess();
            Trainer trainer = new Trainer();
            userBusiness = new UserBusiness();
            auxUser = new User();

            partnerBusiness = new PartnerBusiness();

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
                    trainer.dni = int.Parse(data.Reader["Dni"].ToString());
                    trainer.email = data.Reader["Email"].ToString();
                    trainer.phone = data.Reader["Phone"].ToString();

                    trainer.partnersList = partnerBusiness.ListByTrainerId(trainer.idTrainer);
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

        public List<Trainer> List()
        {

            data = new DataAccess();
            List<Trainer> trainersList = new List<Trainer>();
            userBusiness = new UserBusiness();

            try
            {
                data.SetQuery("select * from Trainers");
                data.ExecuteRead();

                //levanto los Trainers de la BD, pero no cargo todos los campos de entrenamientos...solo los campos datos personales
                //si necesito seleccionar algun Trainer,
                //hago un READ completo luego....

                while (data.Reader.Read())
                {

                    Trainer auxTrainer = new Trainer();
                    User auxUser = new User();

                    auxUser = userBusiness.Read(int.Parse(data.Reader["IdUser"].ToString()));

                    auxTrainer.idUser = auxUser.idUser;
                    auxTrainer.userName = auxUser.userName;
                    auxTrainer.userPassword = auxUser.userPassword;
                    auxTrainer.role = auxUser.role;

                    auxTrainer.idTrainer = int.Parse(data.Reader["IdTrainer"].ToString());
                    auxTrainer.firstName = data.Reader["FirstName"].ToString();
                    auxTrainer.lastName = data.Reader["LastName"].ToString();
                    auxTrainer.dni = int.Parse(data.Reader["Dni"].ToString());
                    auxTrainer.email = data.Reader["Email"].ToString();
                    auxTrainer.phone = data.Reader["Phone"].ToString();

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
