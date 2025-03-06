using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TrainingBusiness
    {
        public DataAccess data;
        public TrainingTypeBusiness trainingTypeBusiness;
        public TrainingType trainingType;

        public TrainingBusiness()
        {

        }

        public bool Create(Training training)
        {
            data = new DataAccess();
            trainingTypeBusiness = new TrainingTypeBusiness();
            int lastIndex;
            bool success;

            try
            {
                data.SetStoredProcedure("insert_training");
                data.SetParameter("@IdPartner", training.idPartner);
                data.SetParameter("@TrainingName", training.Name);
                data.SetParameter("@TrainingDescription", training.Description);
                data.SetParameter("@IdType", training.Type.Id);
                data.SetParameter("@StartDate", training.StartDate);
                data.SetParameter("@EndDate", training.EndDate);

                data.ExecuteRead();

                data.Reader.Read();
                lastIndex = int.Parse(data.Reader["LastId"].ToString());

                if (lastIndex != 0)
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
                success = false;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return success;
        }

        public Training Read(int idTraining)
        {
            data = new DataAccess();
            Training auxTraining = new Training();
            trainingTypeBusiness = new TrainingTypeBusiness();
            DailyRoutineBusiness dailyRoutineBusiness = new DailyRoutineBusiness();

            try
            {
                data.SetQuery("select * from Trainings Where IdTraining = @IdTraining");
                data.SetParameter("@IdTraining", idTraining);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxTraining.idTraining = idTraining;

                    auxTraining.idPartner = int.Parse(data.Reader["IdPartner"].ToString());
                    auxTraining.Name = data.Reader["TrainingName"].ToString();
                    auxTraining.Description = data.Reader["TrainingDescription"].ToString();
                    auxTraining.Type = trainingTypeBusiness.Read(int.Parse(data.Reader["IdType"].ToString()));
                    auxTraining.StartDate = DateTime.Parse(data.Reader["StartDate"].ToString());
                    auxTraining.EndDate = DateTime.Parse(data.Reader["EndDate"].ToString());

                    auxTraining.dailyRoutinesList = dailyRoutineBusiness.ListByTraining(idTraining);  
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

            return auxTraining;
        }


        public List<Training> ListByPartner(int idPartner)
        {
            data = new DataAccess();
            List<Training> trainingList = new List<Training>();

            try
            {
                data.SetQuery("select * from Trainings where IdPartner = @IdPartner");
                data.SetParameter("@IdPartner", idPartner);
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    trainingTypeBusiness = new TrainingTypeBusiness();
                    Training auxTraining = new Training();

                    auxTraining.idTraining = int.Parse(data.Reader["IdTraining"].ToString());
                    auxTraining.idPartner = idPartner;
                    auxTraining.Name = data.Reader["TrainingName"].ToString();
                    auxTraining.Description = data.Reader["TrainingDescription"].ToString();
                    auxTraining.Type = trainingTypeBusiness.Read(int.Parse(data.Reader["IdType"].ToString()));
                    auxTraining.StartDate = DateTime.Parse(data.Reader["StartDate"].ToString());
                    auxTraining.EndDate = DateTime.Parse(data.Reader["EndDate"].ToString());

                    trainingList.Add(auxTraining);
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

            return trainingList;
        }

        public Dictionary<string,int> getTrainingsByType()
        {
            data = new DataAccess();
            Dictionary<string, int> auxDict = new Dictionary<string, int>();

            string key;
            int value;

            try
            {
                data.SetQuery("SELECT TT.TrainingTypeName, COUNT(T.IdTraining) AS TrainingsQty FROM Trainings T INNER JOIN TrainingTypes TT ON T.IdType = TT.IdType GROUP BY TT.TrainingTypeName");
                data.ExecuteRead();

                while(data.Reader.Read())
                {
                    key = data.Reader["TrainingTypeName"].ToString();
                    value = int.Parse(data.Reader["TrainingsQty"].ToString());

                    auxDict.Add(key, value);
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

            return auxDict;
        }
    }
}
