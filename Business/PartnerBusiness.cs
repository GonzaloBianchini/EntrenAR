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
        private UserBusiness userBusiness;
        private User auxUser;
        private TrainingBusiness trainingBusiness;
        public PartnerBusiness()
        {

        }

        public int Create(Partner partner)
        {
            data = new DataAccess();
            int lastIndex;
            int addressIndex;
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
            }
            catch (Exception ex)
            {
                lastIndex = 0;
                addressIndex = 0;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return lastIndex;
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
                data.SetQuery("SELECT * from PartnersByTrainer where IdTrainer = @IdTrainer");
                data.SetParameter("@IdTrainer", idTrainer);
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    auxPartner = new Partner();
                    auxPartner = Read(int.Parse(data.Reader["IdPartner"].ToString()));

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

    }
}
