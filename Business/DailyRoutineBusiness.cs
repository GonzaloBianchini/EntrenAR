using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DailyRoutineBusiness
    {
        private DataAccess data;
        private DailyRoutine auxDailyRoutine;
        private List<DailyRoutine> dailyRoutinesList;

        public bool Create(DailyRoutine dailyRoutine)
        {
            data = new DataAccess();
            int rows;
            try
            {
                data.SetQuery("INSERT INTO DailyRoutines(IdTraining,DailyRoutineDate) VALUES(@IdTraining, @DailyRoutineDate)");
                data.SetParameter("@IdTraining", dailyRoutine.idTraining);
                data.SetParameter("@DailyRoutineDate", dailyRoutine.dailyRoutineDate);

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

        public DailyRoutine Read(int idDailyRoutine)
        {
            data = new DataAccess();

            DailyRoutine dailyRoutine = new DailyRoutine();
            ExerciseBusiness exerciseBusiness = new ExerciseBusiness();

            try
            {
                data.SetQuery("SELECT * FROM DailyRoutines WHERE IdDailyRoutine = @IdDailyRoutine");
                data.SetParameter("@IdDailyRoutine", idDailyRoutine);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    dailyRoutine.idDailyRoutine = idDailyRoutine;
                    dailyRoutine.idTraining = int.Parse(data.Reader["IdTraining"].ToString());
                    dailyRoutine.dailyRoutineDate = DateTime.Parse(data.Reader["DailyRoutineDate"].ToString());

                    dailyRoutine.exercisesList = exerciseBusiness.ListByDailyRoutine(idDailyRoutine);
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
            return dailyRoutine;
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
                    auxDailyRoutine.idTraining = int.Parse(data.Reader["IdTraining"].ToString());
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
