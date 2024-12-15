using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Client : Person
    {
        public int IdClient { get; set; }
        public List<Training> TrainingList { get; set; }
        public StatusClient Status {  get; set; }

    }
}