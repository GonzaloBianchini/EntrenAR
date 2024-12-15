using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Exercise
    {
        public int IdExercise { get; set; }
        public int Name {  get; set; }
        public string Description { get; set; }
        public int Sets {  get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public int RestTime { get; set; }
        public string UrlExercise { get; set; }
    }
}