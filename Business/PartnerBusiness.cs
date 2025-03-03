using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PartnerBusiness
    {
        private DataAccess data;
        private Partner auxPartner;
        private StatusPartnerBusiness statusPartnerBusiness;
        private AddressBusiness addressBusiness;
        private Address auxAddress;
        private UserBusiness userBusiness;
        private User auxUser;
        private TrainingBusiness trainingBusiness;
        public PartnerBusiness()
        {

        }

        public bool Create(Partner partner)
        {
            data = new DataAccess();
            int lastIndex;
            int addressIndex;
            bool success;

            addressBusiness = new AddressBusiness();
            try
            {
                data.SetStoredProcedure("insert_partner");
                data.SetParameter("@UserName", partner.userName);
                data.SetParameter("@UserPassword", partner.userPassword);
                data.SetParameter("@IdRole", 3 /*partner.role.IdRole*/);
                data.SetParameter("@IdStatus", partner.status.IdStatus);
                data.SetParameter("@Dni", partner.dni);
                data.SetParameter("@FirstName", partner.firstName);
                data.SetParameter("@LastName", partner.lastName);
                data.SetParameter("@Gender", partner.gender);
                data.SetParameter("@Email", partner.email);
                data.SetParameter("@Phone", partner.phone);
                data.SetParameter("@BirthDate", partner.birthDate);

                addressIndex = addressBusiness.Create(partner.address);
                data.SetParameter("@IdAddress", addressIndex);

                data.ExecuteRead();

                data.Reader.Read();
                lastIndex = int.Parse(data.Reader["LastId"].ToString());
                if(lastIndex != 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                lastIndex = 0;
                addressIndex = 0;
                success = false;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return success;
        }

        public Partner Read(int id)
        {
            data = new DataAccess();
            auxPartner = new Partner();
            statusPartnerBusiness = new StatusPartnerBusiness();
            userBusiness = new UserBusiness();
            auxUser = new User();
            addressBusiness = new AddressBusiness();
            trainingBusiness = new TrainingBusiness();

            try
            {
                data.SetQuery("select * from Partners Where IdPartner = @IdPartner");
                data.SetParameter("@IdPartner", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxPartner.idPartner = id;

                    auxPartner.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxUser = userBusiness.Read(auxPartner.idUser);
                    auxPartner.userName = auxUser.userName;
                    auxPartner.userPassword = auxUser.userPassword;
                    auxPartner.role = auxUser.role;

                    auxPartner.status = statusPartnerBusiness.Read(int.Parse(data.Reader["IdStatus"].ToString()));
                    auxPartner.activeStatus = bool.Parse(data.Reader["ActiveStatus"].ToString());
                    auxPartner.dni = int.Parse(data.Reader["Dni"].ToString());
                    auxPartner.firstName = data.Reader["FirstName"].ToString();
                    auxPartner.lastName = data.Reader["LastName"].ToString();
                    auxPartner.gender = data.Reader["Gender"].ToString();
                    auxPartner.email = data.Reader["Email"].ToString();
                    auxPartner.phone = data.Reader["Phone"].ToString();
                    auxPartner.birthDate = DateTime.Parse(data.Reader["BirthDate"].ToString());

                    auxPartner.address = addressBusiness.Read(int.Parse(data.Reader["IdAddress"].ToString()));

                    auxPartner.trainingList = trainingBusiness.List(auxPartner.idPartner);
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

            return auxPartner;
        }

        public bool Update(Partner partner)
        {
            data = new DataAccess();
            int rows = 0;
            userBusiness = new UserBusiness();
            addressBusiness = new AddressBusiness();
            auxUser = new User();

            try
            {
                auxUser.idUser = partner.idUser;
                auxUser.userName = partner.userName;
                auxUser.userPassword = partner.userPassword;
                auxUser.role = partner.role;

                if(userBusiness.Update(auxUser))
                {
                    rows = 1;   //si actualiza User, lo detecto...
                }

                auxAddress = partner.address;

                if(addressBusiness.Update(auxAddress))
                {
                    rows = rows + 1;   //si actualiza Address, lo detecto...
                }

                data.SetQuery("UPDATE Partners SET ActiveStatus = @ActiveStatus, Dni = @Dni, FirstName = @FirstName, LastName = @LastName, Gender = @Gender, Email = @Email, Phone = @Phone, BirthDate = @Birthdate WHERE IdPartner =@IdPartner;");
                data.SetParameter("@ActiveStatus", partner.activeStatus);
                data.SetParameter("@Dni", partner.dni);
                data.SetParameter("@FirstName", partner.firstName);
                data.SetParameter("@LastName", partner.lastName);
                data.SetParameter("@Gender", partner.gender);
                data.SetParameter("@Email", partner.email);
                data.SetParameter("@Phone", partner.phone);
                data.SetParameter("@BirthDate", partner.birthDate);
                data.SetParameter("@IdPartner", partner.idPartner);

                rows = rows + data.ExecuteAction();     //si actualiza Partner, lo detecto...
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

        public bool Delete(int id)
        {
            return true;
        }


        public List<Partner> List()
        {
            data = new DataAccess();
            List<Partner> partnersList = new List<Partner>();

            try
            {
                data.SetQuery("select * from Partners where ActiveStatus = 1");
                data.ExecuteRead();

                //levanto los partners de la BD, pero no cargo todos los campos,
                //si necesito seleccionar algun partner,
                //hago un READ completo luego....

                while (data.Reader.Read())
                {
                    statusPartnerBusiness = new StatusPartnerBusiness();

                    Partner auxPartner = new Partner();
                    auxPartner.idPartner = int.Parse(data.Reader["IdPartner"].ToString());
                    auxPartner.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxPartner.status = statusPartnerBusiness.Read(int.Parse(data.Reader["IdStatus"].ToString()));

                    auxPartner.dni = int.Parse(data.Reader["Dni"].ToString());
                    auxPartner.firstName = data.Reader["FirstName"].ToString();
                    auxPartner.lastName = data.Reader["LastName"].ToString();
                    auxPartner.gender = data.Reader["Gender"].ToString();
                    auxPartner.email = data.Reader["Email"].ToString();
                    auxPartner.phone = data.Reader["Phone"].ToString();
                    auxPartner.birthDate = DateTime.Parse(data.Reader["BirthDate"].ToString());
                    //no leo Address
                    //no leo training list
                    partnersList.Add(auxPartner);
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
            return partnersList;
        }

        public List<Partner> ListByTrainerId(int idTrainer)
        {
            data = new DataAccess();

            List<Partner> partnersList = new List<Partner>();

            try
            {
                //data.SetQuery("SELECT * from PartnersByTrainer where IdTrainer = @IdTrainer");
                data.SetQuery("SELECT P.IdPartner, P.IdUser, P.IdStatus, P.ActiveStatus, P.Dni, P.FirstName, P.LastName, P.Gender, P.Email, P.Phone, P.BirthDate from PartnersByTrainer PBT INNER JOIN Partners P ON PBT.IdPartner = P.IdPartner WHERE IdTrainer = @IdTrainer");
                data.SetParameter("@IdTrainer", idTrainer);
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    statusPartnerBusiness = new StatusPartnerBusiness();

                    Partner auxPartner = new Partner();
                    auxPartner.idPartner = int.Parse(data.Reader["IdPartner"].ToString());
                    auxPartner.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxPartner.status = statusPartnerBusiness.Read(int.Parse(data.Reader["IdStatus"].ToString()));

                    auxPartner.dni = int.Parse(data.Reader["Dni"].ToString());
                    auxPartner.firstName = data.Reader["FirstName"].ToString();
                    auxPartner.lastName = data.Reader["LastName"].ToString();
                    auxPartner.gender = data.Reader["Gender"].ToString();
                    auxPartner.email = data.Reader["Email"].ToString();
                    auxPartner.phone = data.Reader["Phone"].ToString();
                    auxPartner.birthDate = DateTime.Parse(data.Reader["BirthDate"].ToString());
                    //no leo Address
                    //no leo training list

                    partnersList.Add(auxPartner);
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

            return partnersList;
        }
        //TODO PONER TRY CATCH Y PONER LOS RETURN LUEGO DEL DATACLOSECONECCTION
        public bool hasAnyRequestSent(int idPartner)
        {
            data = new DataAccess();
            bool flag;
            try
            {
                data.SetQuery("SELECT * from Requests where IdPartner = @IdPartner And (IdRequestStatus = 1)");
                data.SetParameter("@IdPartner", idPartner);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            return flag;
        }

        public bool canSendRequest(int idPartner)
        {
            data = new DataAccess();
            bool flag;

            try
            {
                data.SetQuery("SELECT * from Requests where IdPartner = @IdPartner And (IdRequestStatus = 1 or IdRequestStatus = 2)");
                data.SetParameter("@IdPartner", idPartner);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    //si leo algo aca, es porque NO puede mandar una REQUEST, es decir, me sirve el estado 3(cancelada) o ningun registro generado =)
                    flag = false;
                }
                else
                {
                    flag = true;
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

            return flag;
        }
    }
}
