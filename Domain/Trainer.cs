using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Trainer : User
    {
        public int IdTrainer { get; set; }
        public List<Client> ClientsList { get; set; }
    }
}