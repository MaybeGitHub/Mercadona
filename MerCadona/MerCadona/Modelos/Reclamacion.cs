using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.Modelos
{
    public class Reclamacion
    {
        public string leido { get; set; }
        public string asunto { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string provincia { get; set; }
        public string localidad { get; set; }
        public string cp { get; set; }
        public string tipoVia { get; set; }
        public string nombreVia { get; set; }
        public string numero { get; set; }
        public string mayor14 { get; set; }
        public string informacion { get; set; }
        public string firma { get; set; }
        public string mensaje { get; set; }

        public Reclamacion() { }

        public Reclamacion(string asunto, string mensaje, string nombre, string dni, string apellido1, string apellido2, string provincia, string localidad, string cp, string tipoVia, string nombreVia, string numero, string telefono, string email, bool mayor14, bool info, bool firma)
        {
            leido = "No";
            this.asunto = asunto;
            this.nombre = nombre + " " + apellido1 + " " + apellido2;
            this.dni = dni;
            this.telefono = telefono;
            this.email = email;
            this.provincia = provincia;
            this.localidad = localidad;
            this.cp = cp;
            this.tipoVia = tipoVia;
            this.nombreVia = nombreVia;
            this.numero = numero;
            this.mayor14 = mayor14 ? "Si" : "No";
            this.informacion = info ? "Si" : "No";
            this.firma = firma ? "Si" : "No";
            this.mensaje = mensaje;
        }        
    }
}