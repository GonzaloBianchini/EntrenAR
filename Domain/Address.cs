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
        public int idAddress { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string flat { get; set; }
        public string details { get; set; }
        public string city { get; set; }
        public Province province { get; set; }
        public string country { get; set; }

        public Address()
        {
            this.province = new Province();
        }
        
    }
}
