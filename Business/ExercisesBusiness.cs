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
    }
}
