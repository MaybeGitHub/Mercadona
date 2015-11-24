using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.Modelos
{
    public class Supermercado
    {
        public string localidad { get; set; }
        public string direccion { get; set; }

        public string cp { get; set; }

        public string horario { get; set; }
        public string telefono { get; set; }
        public bool parking { get; set; }        
    }
}