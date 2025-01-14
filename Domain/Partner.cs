using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Partner : User
    {
        public int idPartner { get; set; }
        public StatusPartner status { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public int dni { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool activeStatus { get; set; }
      
        public Address address { get; set; }
        public List<Training> trainingList { get; set; }

        public Partner()
        {
            role = new Role();
            status = new StatusPartner();
            address = new Address();
            trainingList = new List<Training>();
        }
    }
}
