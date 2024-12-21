using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    //Cada instancia de Exercise, sera la de cada rutina en particular. Y sera leida de la BD mediante
    //la tabla Exercises y  ExercisesByDailyRoutine
    public class Exercise
    {
        public int IdExercise { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public int Sets {  get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public int RestTime { get; set; }
        public string UrlExercise { get; set; }
    }
}