using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class StatusClient
    {
        //Seran:
        //Available: No tiene trainer y esta buscando , puede enviar solicitudes
        //Pending: Envio solicitud y espera respuesta
        //Assigned: Fue asignad@ y esta bajo supervision de Trainer
        public int IdStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}