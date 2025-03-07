using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class AddressBusiness
    {
        private DataAccess data;
        private ProvinceBusiness provinceBusiness;
        public AddressBusiness()
        {

        }

        //TODO: revisar list...
        public List<Address> List()
        {
            data = new DataAccess();
            List<Address> listAddresses = new List<Address>();

            try
            {
                data.SetQuery("select * from Addresses");
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    Address auxAddress = new Address();
                    auxAddress.idAddress = int.Parse(data.Reader["IdAddress"].ToString());
                    auxAddress.streetName = data.Reader["StreetName"].ToString();
                    auxAddress.streetNumber = data.Reader["StreetNumber"].ToString();
                    //auxAddress.Flat = Data.Reader["Flat"] == null ? "" : Data.Reader["Flat"].ToString();
                    auxAddress.flat = data.Reader["Flat"].ToString();
                    //auxAddress.Details = Data.Reader["Details"] == null ? "" : Data.Reader["Details"].ToString();
                    auxAddress.details = data.Reader["Details"].ToString();
                    auxAddress.city = data.Reader["City"].ToString();
                    auxAddress.province.idProvince = int.Parse(data.Reader["Province"].ToString());
                    auxAddress.country = data.Reader["Country"].ToString();

                    listAddresses.Add(auxAddress);
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

            return listAddresses;
        }
        public int Create(Address address)
        {
            data = new DataAccess();
            int lastIndex;

            try
            {
                //data.SetQuery("INSERT INTO Addresses (IdUser, StreetName, StreetNumber, Flat, Details, City, Province, Country) VALUES (@IdUser, @StreetName, @StreetNumber, @Flat, @Details, @City, @Province, @Country)");
                data.SetStoredProcedure("insert_address");

                data.SetParameter("@IdProvince", address.province.idProvince);
                data.SetParameter("@StreetName", address.streetName);
                data.SetParameter("@StreetNumber", address.streetNumber);
                //data.SetParameter("@Flat", address.flat ?? (object)DBNull.Value);
                data.SetParameter("@Flat", string.IsNullOrEmpty(address.flat) ? (object)DBNull.Value : address.flat );
                //data.SetParameter("@Details", address.details ?? (object)DBNull.Value);
                data.SetParameter("@Details", string.IsNullOrEmpty(address.details) ? (object)DBNull.Value : address.details);
                data.SetParameter("@City", address.city);
                data.SetParameter("@Country", address.country);
                
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
        
        public Address Read(int id)
        {
            data = new DataAccess();
            provinceBusiness = new ProvinceBusiness();
            Address auxAddress = new Address();
            
            try
            {
                data.SetQuery("SELECT * FROM Addresses WHERE IdAddress=@IdAddress");
                data.SetParameter("@IdAddress", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxAddress.idAddress = id;
                    auxAddress.streetName = data.Reader["StreetName"].ToString();
                    auxAddress.streetNumber= data.Reader["StreetNumber"].ToString();
                    auxAddress.flat = data.Reader["Flat"].ToString();
                    auxAddress.details = data.Reader["Details"].ToString();
                    auxAddress.city = data.Reader["City"].ToString();
                    auxAddress.province = provinceBusiness.Read(int.Parse(data.Reader["IdProvince"].ToString()));
                    auxAddress.country = data.Reader["Country"].ToString();
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

            return auxAddress;
        }
        
        public bool Update(Address address)
        {
            data = new DataAccess();
            int rows;
            try
            {
                data.SetQuery("UPDATE Addresses SET IdProvince = @IdProvince, StreetName =@StreetName, StreetNumber = @StreetNumber, Flat = @Flat, Details = @Details, City = @City, Country = @Country WHERE IdAddress =@IdAddress;");
                data.SetParameter("@IdAddress", address.idAddress);
                data.SetParameter("@IdProvince", address.province.idProvince);
                data.SetParameter("@StreetName", address.streetName);
                data.SetParameter("@StreetNumber", address.streetNumber); 
                data.SetParameter("@Flat", string.IsNullOrEmpty(address.flat) ? (object) DBNull.Value : address.flat); 
                data.SetParameter("@Details", string.IsNullOrEmpty(address.details) ? (object)DBNull.Value : address.details);
                data.SetParameter("@City", address.city);
                data.SetParameter("@Country", address.country); 

                rows = data.ExecuteAction();
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

        public bool Delete(Address address)
        {
            //TODO: NO DEBERIA HABER DELETE...o si?
            return true;
        }
    }
}
