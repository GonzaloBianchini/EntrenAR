using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Trainer : User
    {
        public int idTrainer { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public List<Partner> partnersList { get; set; }

        public Trainer() 
        {
            partnersList = new List<Partner>();
        }
    }
}
