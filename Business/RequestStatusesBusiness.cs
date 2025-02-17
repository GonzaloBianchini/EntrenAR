using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RequestStatusesBusiness
    {
        public DataAccess data;

        public RequestStatusesBusiness()
        {

        }

        public RequestStatus Read(int idRequestStatus)
        {
            data = new DataAccess();
            RequestStatus requestStatus = new RequestStatus();

            try
            {
                data.SetQuery("SELECT * FROM RequestStatuses WHERE IdRequestStatus = @IdRequestStatus");
                data.SetParameter("@IdRequestStatus", idRequestStatus);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    requestStatus.idRequestStatus = idRequestStatus;
                    requestStatus.requestStatusName = data.Reader["RequestStatusName"].ToString();
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

            return requestStatus;
        }
    }
}
