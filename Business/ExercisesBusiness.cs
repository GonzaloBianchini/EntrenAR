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
            Data = new DataAccess();
        }
        public List<Exercise> List()
        {
            List<Exercise> listExercises = new List<Exercise>();
            try
            {
                Data.SetQuery("select * from Exercises");
                Data.ExecuteRead();

                while (Data.Reader.Read())
                {
                    Exercise auxExercise = new Exercise();
                    auxExercise.IdExercise = int.Parse(Data.Reader["IdExercise"].ToString());
                    auxExercise.Name = Data.Reader["ExerciseName"].ToString();
                    auxExercise.Description = Data.Reader["ExerciseDescription"].ToString();
                    auxExercise.UrlExercise = Data.Reader["UrlExercise"].ToString();

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

        public bool CreateExercise(Exercise exercise)
        {
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
    }
}
