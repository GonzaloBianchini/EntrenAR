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
        private AddressBusiness addressBusiness;
        public PartnerBusiness()
        {

        }

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
                data.SetParameter("@IdRole", partner.role.IdRole);
                data.SetParameter("@IdStatus",partner.status.IdStatus);
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
        //public bool Create(Partner partner)
        //{
        //    //TODO: verificar return
        //    //TODO: posiblemente convenga devolver el id creado, para la proxima...
        //    //TODO: ver como grabar null en db...
        //    Data = new DataAccess();
        //    UserBusiness userBusiness = new UserBusiness();

        //    User auxUser = new User();
        //    auxUser = partner;
        //    try
        //    {
        //        userBusiness.Create(auxUser);
        //        //debo traer de la BD el idUser de este auxUserCreado
        //        //debo traer el id de address(primero hay que hacer un create de address...
        //        Data.SetQuery()

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        Data.CloseConnection();
        //    }

        //    return true;
        //}
    }
}
