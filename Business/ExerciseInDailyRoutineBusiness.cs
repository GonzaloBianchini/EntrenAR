using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ExerciseInDailyRoutineBusiness
    {
        private DataAccess data;

        public ExerciseInDailyRoutineBusiness()
        {

        }

        public bool Create(int idDailyRoutine,Exercise exercise)
        {
            data = new DataAccess();

            try
            {
                data.SetStoredProcedure("insert_exercise_in_daily_routine");

                data.SetParameter("@IdDailyRoutine", idDailyRoutine);
                data.SetParameter("@IdExercise", exercise.IdExercise);
                data.SetParameter("@ExerciseSets", exercise.Sets);
                data.SetParameter("@ExerciseReps", exercise.Reps);
                data.SetParameter("@ExerciseWeight", exercise.Weight);
                data.SetParameter("@ExerciseRestTime", exercise.RestTime);

                data.ExecuteRead();

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

    }
}
