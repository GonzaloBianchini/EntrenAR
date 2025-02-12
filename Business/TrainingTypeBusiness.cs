using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TrainingTypeBusiness
    {
        private DataAccess data;
        private TrainingType auxTrainingType;
        public TrainingTypeBusiness()
        {

        }

        public TrainingType Read(int id)
        {
            data = new DataAccess();
            auxTrainingType = new TrainingType();

            try
            {
                data.SetQuery("select * from TrainingTypes Where IdType=@IdType");
                data.SetParameter("@IdType", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxTrainingType.Id = id;
                    auxTrainingType.Name = data.Reader["TrainingTypeName"].ToString();
                    auxTrainingType.Description = data.Reader["TrainingTypeDescription"].ToString();

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

            return auxTrainingType;
        }

        public List<TrainingType> List()
        {
            data = new DataAccess();
            List<TrainingType> trainingTypesList = new List<TrainingType>();

            try
            {
                data.SetQuery("select * from TrainingTypes");
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    TrainingType auxTrainingType = new TrainingType();
                    auxTrainingType.Id = int.Parse(data.Reader["IdType"].ToString());
                    auxTrainingType.Name = data.Reader["TrainingTypeName"].ToString();
                    auxTrainingType.Description = data.Reader["TrainingTypeDescription"].ToString();

                    trainingTypesList.Add(auxTrainingType);
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

            return trainingTypesList;
        }

    }
}
