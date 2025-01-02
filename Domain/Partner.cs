using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Partner
    {
        public int IdPartner { get; set; }
        public StatusPartner Status { get; set; }
        public List<Training> TrainingList { get; set; }
    }
}
