using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StatusPartnerBusiness
    {
        private DataAccess data;

        public StatusPartnerBusiness() 
        {

        }

        public StatusPartner Read(int id)
        {
            data = new DataAccess();
            StatusPartner auxStatusPartner = new StatusPartner();

            try
            {
                data.SetQuery("SELECT * FROM StatusesPartner WHERE IdStatus=@IdStatus");
                data.SetParameter("@IdStatus", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxStatusPartner.IdStatus = id;
                    auxStatusPartner.Name = data.Reader["StatusName"].ToString();
                    auxStatusPartner.Description = data.Reader["StatusDescription"].ToString();
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


            return auxStatusPartner;
        }
    }
}
