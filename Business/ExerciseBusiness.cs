﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                data.SetQuery("select * from Exercises");
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    Exercise auxExercise = new Exercise();
                    auxExercise.IdExercise = int.Parse(data.Reader["IdExercise"].ToString());
                    //auxExercise.ActiveStatus = bool.Parse(data.Reader["ActiveStatus"].ToString());
                    auxExercise.Name = data.Reader["ExerciseName"].ToString();
                    auxExercise.Description = data.Reader["ExerciseDescription"].ToString();
                    auxExercise.ImageUrl = data.Reader["ImageUrl"].ToString();
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

        public List<Exercise> ListByDailyRoutine(int idDailyRoutine)
        {
            data = new DataAccess();
            List<Exercise> listExercises = new List<Exercise>();

            try
            {
                data.SetQuery("select ED.IdExercise, E.ExerciseName, E.ExerciseDescription, ED.ExerciseSets, ED.ExerciseReps , ED.ExerciseWeight, ED.ExerciseRestTime, E.ImageUrl, E.UrlExercise from Exercises E INNER JOIN ExercisesInDailyRoutine ED ON E.IdExercise = ED.IdExercise WHERE ED.IdDailyRoutine = @IdDailyRoutine");
                data.SetParameter("@IdDailyRoutine",idDailyRoutine);
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    Exercise auxExercise = new Exercise();
                    auxExercise.IdExercise = int.Parse(data.Reader["IdExercise"].ToString());
                    auxExercise.Name = data.Reader["ExerciseName"].ToString();
                    auxExercise.Description = data.Reader["ExerciseDescription"].ToString();
                    auxExercise.Sets= int.Parse(data.Reader["ExerciseSets"].ToString());
                    auxExercise.Reps = int.Parse(data.Reader["ExerciseReps"].ToString());
                    auxExercise.Weight = decimal.Parse(data.Reader["ExerciseWeight"].ToString());
                    auxExercise.RestTime= int.Parse(data.Reader["ExerciseRestTime"].ToString());
                    auxExercise.ImageUrl = data.Reader["ImageUrl"].ToString();
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
            int rows;

            try
            {
                data.SetQuery("INSERT INTO Exercises (ExerciseName, ExerciseDescription, ImageUrl, UrlExercise) VALUES (@ExerciseName, @ExerciseDescription, @ImageUrl, @UrlExercise)");
                data.SetParameter("@ExerciseName", exercise.Name);
                data.SetParameter("@ExerciseDescription", (exercise.Description == string.Empty) || (exercise.Description is null) ? (object)DBNull.Value : exercise.Description);
                data.SetParameter("@ImageUrl", (exercise.ImageUrl == string.Empty) || (exercise.ImageUrl is null) ? (object)DBNull.Value : exercise.ImageUrl);
                data.SetParameter("@UrlExercise", (exercise.UrlExercise == string.Empty) || (exercise.UrlExercise is null) ? (object)DBNull.Value : exercise.UrlExercise);

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
                    auxExercise.ImageUrl = data.Reader["ImageUrl"].ToString();
                    auxExercise.UrlExercise = data.Reader["UrlExercise"].ToString();
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
                data.SetQuery("UPDATE Exercises SET ExerciseName =@ExerciseName, ExerciseDescription = @ExerciseDescription,ImageUrl = @ImageUrl, UrlExercise = @UrlExercise WHERE IdExercise =@IdExercise;");
                data.SetParameter("@IdExercise", exercise.IdExercise);
                data.SetParameter("@ExerciseName", exercise.Name);
                data.SetParameter("@ExerciseDescription", (exercise.Description == string.Empty) || (exercise.Description is null) ? (object)DBNull.Value : exercise.Description);
                data.SetParameter("@ImageUrl", (exercise.ImageUrl == string.Empty) || (exercise.ImageUrl is null) ? (object)DBNull.Value : exercise.ImageUrl);
                data.SetParameter("@UrlExercise", (exercise.UrlExercise == string.Empty) || (exercise.UrlExercise is null) ? (object)DBNull.Value : exercise.UrlExercise);

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

        public Exercise ReadByName(string exerciseName)
        {
            data = new DataAccess();
            Exercise auxExercise = new Exercise();

            try
            {
                data.SetQuery("SELECT * FROM Exercises WHERE ExerciseName = @exerciseName");
                data.SetParameter("@exerciseName", exerciseName);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxExercise.IdExercise = int.Parse(data.Reader["IdExercise"].ToString());
                    auxExercise.Name = exerciseName;
                    auxExercise.Description = data.Reader["ExerciseDescription"].ToString();
                    auxExercise.ImageUrl = data.Reader["ImageUrl"].ToString();
                    auxExercise.UrlExercise = data.Reader["UrlExercise"].ToString();
                    //auxExercise.ActiveStatus = bool.Parse(data.Reader["ActiveStatus"].ToString());
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

        public bool ValidateExerciseName(String exerciseName)
        {
            Exercise exercise = new Exercise();

            bool isValid;

            try
            {
                exercise = ReadByName(exerciseName);
                if (exercise == null)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
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

            return isValid;
        }
    }
}
