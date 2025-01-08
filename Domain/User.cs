using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int idUser { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public Role role { get; set; }
        
    }
}
