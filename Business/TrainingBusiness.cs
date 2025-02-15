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

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return true;
        }

        public List<Training> List(int id)
        {
            data = new DataAccess();
            List<Training> trainingList = new List<Training>();

            try
            {
                data.SetQuery("select * from Trainings where IdPartner = @IdPartner");
                data.SetParameter("@IdPartner", id);
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    trainingTypeBusiness = new TrainingTypeBusiness();
                    Training auxTraining = new Training();

                    auxTraining.idTraining = int.Parse(data.Reader["IdTraining"].ToString());
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
    }
}
