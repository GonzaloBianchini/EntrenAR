using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ExercisesBusiness
    {
        private DataAccess Data;

        public ExercisesBusiness()
        {
            //Data = new DataAccess();
        }
        public List<Exercise> List()
        {
            Data = new DataAccess();
            List<Exercise> listExercises = new List<Exercise>();
            try
            {
                Data.SetQuery("select * from Exercises Where IsActive=1");
                Data.ExecuteRead();

                while (Data.Reader.Read())
                {
                    Exercise auxExercise = new Exercise();
                    auxExercise.IdExercise = int.Parse(Data.Reader["IdExercise"].ToString());
                    auxExercise.Name = Data.Reader["ExerciseName"].ToString();
                    auxExercise.Description = Data.Reader["ExerciseDescription"].ToString();
                    auxExercise.UrlExercise = Data.Reader["UrlExercise"].ToString();
                    auxExercise.IsActive = bool.Parse(Data.Reader["IsActive"].ToString());

                    listExercises.Add(auxExercise);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

            return listExercises;
        }

        public bool Create(Exercise exercise)
        {
            //TODO: verificar return
            //TODO: posiblemente convenga devolver el id creado, para la proxima...
            //TODO: ver como grabar null en db...
            Data = new DataAccess();
            try
            {
                Data.SetQuery("INSERT INTO Exercises (ExerciseName, ExerciseDescription, UrlExercise) VALUES (@ExerciseName, @ExerciseDescription, @UrlExercise)");
                Data.SetParameter("@ExerciseName", exercise.Name);
                Data.SetParameter("@ExerciseDescription", exercise.Description);
                Data.SetParameter("@UrlExercise", exercise.UrlExercise);

                Data.ExecuteAction();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

            return true;
        }

        public Exercise Read(int id)
        {
            Data = new DataAccess();
            Exercise auxExercise = new Exercise();

            try
            {
                Data.SetQuery("SELECT * FROM Exercises WHERE IdExercise=@IdExercise");
                Data.SetParameter("@IdExercise", id);
                Data.ExecuteRead();

                if (Data.Reader.Read())
                {
                    auxExercise.IdExercise = id;
                    auxExercise.Name = Data.Reader["ExerciseName"].ToString();
                    auxExercise.Description= Data.Reader["ExerciseDescription"].ToString();
                    auxExercise.UrlExercise=Data.Reader["UrlExercise"].ToString();
                    auxExercise.IsActive = bool.Parse(Data.Reader["IsActive"].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Data.CloseConnection();
            }

            return auxExercise;
        }

        public bool Update(Exercise exercise)
        {
            //TODO: verificar return
            Data = new DataAccess();
            int rows = 0;
            try
            {
                Data.SetQuery("UPDATE Exercises SET ExerciseName =@ExerciseName, ExerciseDescription = @ExerciseDescription, UrlExercise = @UrlExercise, IsActive = @IsActive WHERE IdExercise =@IdExercise;");
                Data.SetParameter("@IdExercise", exercise.IdExercise);
                Data.SetParameter("@ExerciseName", exercise.Name);
                Data.SetParameter("@ExerciseDescription", exercise.Description);
                Data.SetParameter("@UrlExercise", exercise.UrlExercise);
                Data.SetParameter("@IdExercise", exercise.IdExercise);
                Data.SetParameter("@IsActive", exercise.IsActive);

                Data.ExecuteAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }

            return (rows > 0);
        }

        public bool Delete(Exercise exercise)
        {
            //TODO: verificar return
            Data = new DataAccess();
            int rows = 0;

            try
            {
                exercise.IsActive = false;
                Update(exercise);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Data.CloseConnection();
            }
            return (rows > 0);
        }
    }
}
