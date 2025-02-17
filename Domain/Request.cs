using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Request
    {
        public int idRequest {  get; set; }
        public RequestStatus requestStatus { get; set; }
        public Trainer trainer { get; set; }
        public Partner partner { get; set; }
        public DateTime creationDate { get; set; }

        public Request()
        {
            requestStatus = new RequestStatus();
        }
    }
}
