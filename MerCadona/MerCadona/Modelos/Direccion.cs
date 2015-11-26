using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.Modelos
{
    public class Direccion
    {
        public string id { get; set; }
        public string tipoVia { get; set; }
        public string nombreVia { get; set; }
        public string numero { get; set; }
        public string piso { get; set; }
        public string puerta { get; set; }
        public string urba { get; set; }
        public string bloque { get; set; }
        public string escalera { get; set; }
        public string observaciones { get; set; }
        public string localidad { get; set; }
        public string cp { get; set; }
        public string habitual { get; set; }

        public Direccion()
        {
            id = new Random().Next(1, int.MaxValue).ToString();
        }

        public Direccion(string id)
        {
            this.id = id;
        }
    }
}