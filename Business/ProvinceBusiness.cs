using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProvinceBusiness
    {
        private DataAccess data;

        public ProvinceBusiness()
        {

        }

        public Province Read(int id)
        {
            data = new DataAccess();
            Province auxProvince = new Province();

            try
            {
                data.SetQuery("SELECT * FROM Provinces WHERE IdProvince=@IdProvince");
                data.SetParameter("@IdProvince", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxProvince.idProvince = id;
                    auxProvince.name = data.Reader["ProvinceName"].ToString();
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

            return auxProvince;
        }

        public List<Province> List()
        {
            data = new DataAccess();
            List<Province> provincesList = new List<Province>();

            try
            {
                data.SetQuery("select * from Provinces");
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    Province auxProvince = new Province();
                    auxProvince.idProvince = int.Parse(data.Reader["IdProvince"].ToString());
                    auxProvince.name = data.Reader["ProvinceName"].ToString();

                    provincesList.Add(auxProvince);
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

            return provincesList;
        }
    }
}
