using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class DailyRoutine
    {
        public int IdDailyRoutine { get; set; }
        public DateTime Date {  get; set; }
        public List<Exercise> ExercisesList { get; set; }
    }
}