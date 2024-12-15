using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TrainingType Type { get; set; }
        public DateTime StartTime { get; set; }
        //public DateTime EstimatedDateTime { get; set; }
        public DateTime EndTime { get; set; }


    }
}