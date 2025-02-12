using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DaiyRoutineBusiness
    {
        private DataAccess data;
        private DailyRoutine auxDailyRoutine;
        private List<DailyRoutine> dailyRoutinesList;

        public bool Create(DailyRoutine dailyRoutine)
        {
            data = new DataAccess();

            try
            {
                data.SetQuery("INSERT INTO DailyRoutines(IdTraining,DailyRoutineDate) VALUES(@IdTraining, @DailyRoutineDate)");
                data.SetParameter("@IdTraining", dailyRoutine.idTraining);
                data.SetParameter("@DailyRoutineDate", dailyRoutine.dailyRoutineDate);

                data.ExecuteAction();

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

        public List<DailyRoutine> ListByTraining(int idTraining)
        {
            data = new DataAccess();
            dailyRoutinesList = new List<DailyRoutine>();
            ExerciseBusiness exerciseBusiness = new ExerciseBusiness();

            try
            {
                data.SetQuery("select * from DailyRoutines WHERE IdTraining = @IdTraining");
                data.SetParameter("@IdTraining", idTraining);
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    auxDailyRoutine = new DailyRoutine();

                    auxDailyRoutine.idDailyRoutine = int.Parse(data.Reader["IdDailyRoutine"].ToString());
                    auxDailyRoutine.idTraining = idTraining;
                    auxDailyRoutine.dailyRoutineDate = DateTime.Parse(data.Reader["DailyRoutineDate"].ToString());
                    auxDailyRoutine.exercisesList = exerciseBusiness.ListByDailyRoutine(auxDailyRoutine.idDailyRoutine);
                    
                    dailyRoutinesList.Add(auxDailyRoutine);
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

            return dailyRoutinesList;
        }

    }
}
