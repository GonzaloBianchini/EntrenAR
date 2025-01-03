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
        private DataAccess Data;

        public AddressBusiness()
        {

        }

        public List<Address> List()
        {
            Data = new DataAccess();
            List<Address> listAddresses = new List<Address>();

            try
            {
                Data.SetQuery("select * from Addresses");
                Data.ExecuteRead();

                while (Data.Reader.Read())
                {
                    Address auxAddress = new Address();
                    auxAddress.IdAddress = int.Parse(Data.Reader["IdAddress"].ToString());
                    auxAddress.StreetName = Data.Reader["StreetName"].ToString();
                    auxAddress.StreetNumber = int.Parse(Data.Reader["StreetNumber"].ToString());
                    //auxAddress.Flat = Data.Reader["Flat"] == null ? "" : Data.Reader["Flat"].ToString();
                    auxAddress.Flat = Data.Reader["Flat"].ToString();
                    //auxAddress.Details = Data.Reader["Details"] == null ? "" : Data.Reader["Details"].ToString();
                    auxAddress.Details = Data.Reader["Details"].ToString();
                    auxAddress.City = Data.Reader["City"].ToString();
                    auxAddress.Province = Data.Reader["Province"].ToString();
                    auxAddress.Country = Data.Reader["Country"].ToString();

                    listAddresses.Add(auxAddress);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return listAddresses;
        }
        public bool Create(Address address)
        {
            //TODO: verificar return
            //TODO: posiblemente convenga devolver el id creado, para la proxima...
            //TODO: ver como grabar null en db...
            Data = new DataAccess();
            try
            {
                Data.SetQuery("INSERT INTO Addresses (IdUser, StreetName, StreetNumber, Flat, Details, City, Province, Country) VALUES (@IdUser, @StreetName, @StreetNumber, @Flat, @Details, @City, @Province, @Country)");
                
                Data.SetParameter("@IdUser", address.IdUser);
                Data.SetParameter("@StreetName", address.StreetName);
                Data.SetParameter("@StreetNumber", address.StreetNumber.ToString());
                Data.SetParameter("@Flat", address.Flat);
                Data.SetParameter("@Details", address.Details);
                Data.SetParameter("@City", address.City);
                Data.SetParameter("@Province", address.Province);
                Data.SetParameter("@Country", address.Country);
                
                Data.ExecuteAction();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

            return true;
        }

        public Address Read(int id)
        {
            Data = new DataAccess();
            Address auxAddress = new Address();

            try
            {
                Data.SetQuery("SELECT * FROM Addresses WHERE IdAddress=@IdAddress");
                Data.SetParameter("@IdAddress", id);
                Data.ExecuteRead();

                if (Data.Reader.Read())
                {
                    auxAddress.IdAddress = id;
                    auxAddress.StreetName = Data.Reader["StreetName"].ToString();
                    auxAddress.StreetNumber= int.Parse(Data.Reader["StreetNumber"].ToString());
                    auxAddress.Flat = Data.Reader["Flat"].ToString();
                    auxAddress.Details = Data.Reader["Details"].ToString();
                    auxAddress.City = Data.Reader["City"].ToString();
                    auxAddress.Province = Data.Reader["Province"].ToString();
                    auxAddress.Country = Data.Reader["Country"].ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Data.CloseConnection();
            }

            return auxAddress;
        }

        public bool Update(Address address)
        {
            //TODO: verificar return
            Data = new DataAccess();
            int rows = 0;
            try
            {
                Data.SetQuery("UPDATE Addresses SET StreetName =@StreetName, StreetNumber = @StreetNumber, Flat = @Flat, Details = @Details, City = @City, Province = @Province, Country = @Country WHERE IdAddress =@IdAddress;");
                Data.SetParameter("@IdAddress", address.IdAddress);
                Data.SetParameter("@StreetName", address.StreetName);
                Data.SetParameter("@StreetNumber", address.StreetNumber.ToString());
                Data.SetParameter("@Flat", address.Flat);
                Data.SetParameter("@Details", address.Details);
                Data.SetParameter("@City", address.City);
                Data.SetParameter("@Province", address.Province);
                Data.SetParameter("@Country", address.Country);

                Data.ExecuteAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
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
