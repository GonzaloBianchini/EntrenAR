﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RequestBusiness
    {
        private DataAccess data;
        private RequestStatusesBusiness requestStatusesBusiness;
        private TrainerBusiness trainerBusiness;
        private PartnerBusiness partnerBusiness;

        public RequestBusiness()
        {

        }

        public bool Create(Request request)
        {
            data = new DataAccess();
            //int lastIndex;

            try
            {
                data.SetStoredProcedure("insert_request");
                data.SetParameter("@IdRequestStatus", 1 /*request.requestStatus.idRequestStatus*/); //1 corresponde a EN REVISION...
                data.SetParameter("@IdTrainer", request.trainer.idTrainer);
                data.SetParameter("@IdPartner", request.partner.idPartner);
                data.SetParameter("@CreationDate", request.creationDate);

                data.ExecuteRead();

                data.Reader.Read();
                //lastIndex = int.Parse(data.Reader["LastId"].ToString());  LastId no definido en el SP
            }
            catch (Exception ex)
            {
                //lastIndex = 0;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return true;
        }

        public Request Read(int idRequest)
        {
            data = new DataAccess();
            Request auxRequest = new Request();

            requestStatusesBusiness = new RequestStatusesBusiness();
            trainerBusiness = new TrainerBusiness();
            partnerBusiness = new PartnerBusiness();

            try
            {
                data.SetQuery("select * from Requests Where IdRequest = @IdRequest");
                data.SetParameter("@IdRequest", idRequest);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxRequest.idRequest = idRequest;
                    auxRequest.requestStatus = requestStatusesBusiness.Read(int.Parse(data.Reader["IdRequestStatus"].ToString()));
                    auxRequest.trainer = trainerBusiness.Read(int.Parse(data.Reader["IdTrainer"].ToString()));
                    auxRequest.partner = partnerBusiness.Read(int.Parse(data.Reader["IdPartner"].ToString()));
                    auxRequest.creationDate = DateTime.Parse(data.Reader["CreationDate"].ToString());
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

            return auxRequest;
        }

        PORACAPORACA
            PORACAPORACA
            PORACAPORACA
            PORACAPORACA!!!!
        //SEGUIR CON READBYPARTNER AND READBYTRAINER


    }
}
