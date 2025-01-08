using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Address
    {
        public int IdAddress { get; set; }
        //public int IdUser { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Flat { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        
    }
}
