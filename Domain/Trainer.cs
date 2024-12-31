using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Trainer : User
    {
        public int IdTrainer { get; set; }
        public List<Partner> PartnersList { get; set; }
    }
}
