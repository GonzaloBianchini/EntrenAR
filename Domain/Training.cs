using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Training
    {
        public int idTraining { get; set; }
        public int idPartner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<DailyRoutine> dailyRoutinesList { get; set; }

        public Training()
        {
            Type = new TrainingType();
            dailyRoutinesList = new List<DailyRoutine>();
        }

    }
}
