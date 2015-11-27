using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.Modelos
{
    [Serializable]
    public class Cesta
    {
        public string estado { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string id { get; set; }
        public string cliente { get; set; }
        public Dictionary<string, string> listaProductos { get; set; }

        public Cesta()
        {
            estado = "Abierta";
            id = new Random().Next(int.MaxValue).ToString();
            listaProductos = new Dictionary<string, string>();
        }            
    }
}