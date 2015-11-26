using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.Modelos
{
    [Serializable]
    public class Cliente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }
        public string tipoIdentificacion { get; set; }
        public string NIF { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public Dictionary<string, string> listaIdDirecciones { get; set; }
        public List<string> listaTelefonos { get; set; }   
        public string faltaProducto { get; set; }   
        public string info { get; set; }
        public string dia { get; set; }
        public string mes { get; set; }
        public string año { get; set; }

        public Cliente()
        {
            listaIdDirecciones = new Dictionary<string, string>();
            listaTelefonos = new List<string>();
        }
    }

    
}