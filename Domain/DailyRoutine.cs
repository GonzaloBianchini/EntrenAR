using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DailyRoutine
    {
        public int idDailyRoutine { get; set; }
        public int idTraining {  get; set; }
        public DateTime dailyRoutineDate { get; set; }
        public List<Exercise> exercisesList { get; set; }

        public DailyRoutine() 
        {
            exercisesList = new List<Exercise>();
        }
    }
}
