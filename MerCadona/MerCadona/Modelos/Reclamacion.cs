using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerCadona.Modelos
{
    public class Reclamacion
    {
        public int activo { get; set; }
        public string asunto { get; set; }
        public string usuario { get; set; }
        public string direccion { get; set; }
        public int mayor14 { get; set; }
        public int informacion { get; set; }
        public int firma { get; set; }
        public string mensaje { get; set; }

        public Reclamacion(string asunto, string mensaje, string nombre, string dni, string apellido1, string apellido2, string provincia, string localidad, string cp, string tipoVia, string nombreVia, string numero, string telefono, string email, bool mayor14, bool info, bool firma)
        {
            activo = 1;
            this.asunto = asunto;
            usuario = nombre + " " + apellido1 + " " + apellido2 + "&" + dni + "&" + telefono + "&" + email;
            direccion = provincia + "&" + localidad + "&" + cp + "&" + tipoVia + "&" + nombreVia + "&" + numero;
            if (mayor14) this.mayor14 = 1; else this.mayor14 = 0;
            if (info) informacion = 1; else informacion = 0;
            if (firma) this.firma = 1; else this.firma = 0;
            this.mensaje = mensaje;
        }

        public Reclamacion(string lineaDatos)
        {
            string[] datos = lineaDatos.Split(';');
            activo = int.Parse(datos[0]);
            asunto = datos[1];
            usuario = datos[2];
            direccion = datos[3];
            mayor14 = int.Parse(datos[4]);
            informacion = int.Parse(datos[5]);
            firma = int.Parse(datos[6]);
            mensaje = datos[7];
        }

        public string construirLineaDatos()
        {
            return activo + ";" + asunto + ";" + usuario + ";" + direccion + ";" + mayor14 + ";" + informacion + ";" + firma + ";" + mensaje;
        }
    }
}