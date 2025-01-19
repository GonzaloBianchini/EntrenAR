using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ExerciseBusiness
    {   
        private DataAccess data;

        public ExerciseBusiness()
        {

        }
        public List<Exercise> List()
        {
            data = new DataAccess();
            List<Exercise> listExercises = new List<Exercise>();
            try
            {
                data.SetQuery("select * from Exercises Where ActiveStatus=1");
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    Exercise auxExercise = new Exercise();
                    auxExercise.IdExercise = int.Parse(data.Reader["IdExercise"].ToString());
                    auxExercise.ActiveStatus = bool.Parse(data.Reader["ActiveStatus"].ToString());
                    auxExercise.Name = data.Reader["ExerciseName"].ToString();
                    auxExercise.Description = data.Reader["ExerciseDescription"].ToString();
                    auxExercise.UrlExercise = data.Reader["UrlExercise"].ToString();

                    listExercises.Add(auxExercise);
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

            return listExercises;
        }

        public bool Create(Exercise exercise)
        {
            //TODO: verificar return
            //TODO: posiblemente convenga devolver el id creado, para la proxima...
            //TODO: HACER SP
            //TODO: grabar null en db donde corresponda
            data = new DataAccess();
            try
            {
                data.SetQuery("INSERT INTO Exercises (ExerciseName, ExerciseDescription, UrlExercise) VALUES (@ExerciseName, @ExerciseDescription, @UrlExercise)");
                data.SetParameter("@ExerciseName", exercise.Name);
                data.SetParameter("@ExerciseDescription", exercise.Description);
                data.SetParameter("@UrlExercise", exercise.UrlExercise);

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

        public Exercise Read(int id)
        {
            data = new DataAccess();
            Exercise auxExercise = new Exercise();

            try
            {
                data.SetQuery("SELECT * FROM Exercises WHERE IdExercise=@IdExercise");
                data.SetParameter("@IdExercise", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxExercise.IdExercise = id;
                    auxExercise.Name = data.Reader["ExerciseName"].ToString();
                    auxExercise.Description = data.Reader["ExerciseDescription"].ToString();
                    auxExercise.UrlExercise = data.Reader["UrlExercise"].ToString();
                    auxExercise.ActiveStatus = bool.Parse(data.Reader["ActiveStatus"].ToString());
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

            return auxExercise;
        }

        public bool Update(Exercise exercise)
        {
            data = new DataAccess();
            int rows;

            try
            {
                data.SetQuery("UPDATE Exercises SET ExerciseName =@ExerciseName, ExerciseDescription = @ExerciseDescription, UrlExercise = @UrlExercise, ActiveStatus = @ActiveStatus WHERE IdExercise =@IdExercise;");
                data.SetParameter("@IdExercise", exercise.IdExercise);
                data.SetParameter("@ExerciseName", exercise.Name);
                data.SetParameter("@ExerciseDescription", exercise.Description);
                data.SetParameter("@UrlExercise", exercise.UrlExercise);
                data.SetParameter("@IdExercise", exercise.IdExercise);
                data.SetParameter("@ActiveStatus", exercise.ActiveStatus);

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

        //TODO: ver si el delete debe tomar por parametro ID en vez de el propio EXERCISE...
        public bool Delete(Exercise exercise)
        {
            //TODO: verificar return
            data = new DataAccess();
            bool flag;

            try
            {
                exercise.ActiveStatus = false;
                flag = Update(exercise);
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return flag;
        }
    }
}
