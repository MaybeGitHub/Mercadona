using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using MerCadona.Modelos;
using System.Threading.Tasks;

namespace MerCadona.Controladores
{
    public class CEmail
    {
        public void mandarEmail(Usuario usuario, string link)
        {
            string url = "http://localhost:2243/Vistas/cambiopwd.aspx?email=" + usuario.email;
            string html = 
                "<html>"
                  + "<body>"
                    + "<p>Estimado " + usuario.nombre + "</p>"
                    + "<p>Este correo se le ha enviado como respuesta a su peticion de recordatorio de la password.</p>"
                    + "<p>Su usuario es: " + usuario.email + "</p>"
                    + "<br \\><p>Acceda al siguiente enlace para poder cambiar su contraseña:</p>"
                    + "<p><a href='" + url + "'>Link para cambiar la contraseña</a></p>"
                    + "<br \\><p>Mercadona - Supermercados de confianza</p>";
            
            MailMessage nuevoCorreo = new MailMessage();
            nuevoCorreo.To.Add(new MailAddress(usuario.email));
            nuevoCorreo.From = new MailAddress("proyectos.clase.net@gmail.com");
            nuevoCorreo.Subject = "Recuperacion de contraseña de Mercadona";
            nuevoCorreo.IsBodyHtml = true;
            nuevoCorreo.Body = html;

            SmtpClient servidor = new SmtpClient();
            servidor.Host = "smtp.gmail.com";
            servidor.Port = 587;
            servidor.EnableSsl = true;
            servidor.DeliveryMethod = SmtpDeliveryMethod.Network;
            servidor.Credentials = new NetworkCredential("proyectos.clase.net@gmail.com", "solosequenosenada");
            servidor.Timeout = 20000;            
            servidor.Send(nuevoCorreo);
        }
    }
}