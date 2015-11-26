using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using MerCadona.Modelos;
using Spire.Pdf;
using System.Threading.Tasks;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace MerCadona.Controladores
{
    public class CEmail
    {
        private CXml cXml = new CXml();

        public void mandarEmail(Cliente cliente, string tipo, Cesta cesta, string tempPath)
        {
            string url, html = "", subject = "";

            if (tipo == "Recuperar contraseña")
            {
                url = "http://localhost:2243/Vistas/cambiopwd.aspx?email=" + cliente.email;
                html =
                    "<html>"
                      + "<body>"
                        + "<p>Estimado cliente" + cliente.nombre + " " + cliente.apellido + " " + cliente.apellido2 + "</p>"
                        + "<p>Este correo se le ha enviado como respuesta a su peticion de recordatorio de la password.</p>"
                        + "<p>Su usuario es: " + cliente.email + "</p>"
                        + "<br><p>Acceda al siguiente enlace para poder cambiar su contraseña:</p>"
                        + "<p><a href='" + url + "'>Link para cambiar la contraseña</a></p>"
                        + "<br><p>Mercadona - Supermercados de confianza</p></body></html>";

                subject = "Mercadona - Recuperacion de contraseña de cuenta";
            }

            if ( tipo == "Cesta")
            {
                html =
                    "<html>"
                    + "<body>"
                      + "<p>Estimado " + cliente.nombre + " " + cliente.apellido + " " + cliente.apellido2 + "</p>"
                      + "<p>Gracias por hacer su pedido en nuestra tienda Online.</p>"
                      + "<p>Le adjuntamos un pdf con el recibo de su compra, no dude en ponerse en contacto con nosotros si tiene algun problema o si hay algun dato erroneo al telefono: 900 500 103 o</p>"
                      + "<p>a nuestro departamento de <a href='~/Vistas/atencion.aspx'>Atencion al cliente</a> donde podra aprovechar tambien para darnos su opinion si lo desea y nuestros tecnicos la valoraran lo antes posible pudiendose llegar a poner en contacto con usted si asi lo desea.</p>"
                      + "<br><p>Muchas gracias por confiar en nosotros.</p> <br><br>Atentamente, equipo de post-venta de Mercadona";

                subject = "Mercadona - Recibo de compra de carrito con ID: " + cesta.id;
            }

            MailMessage nuevoCorreo = new MailMessage();
            nuevoCorreo.To.Add(new MailAddress(cliente.email));
            nuevoCorreo.From = new MailAddress("proyectos.clase.net@gmail.com");
            nuevoCorreo.Subject = subject;
            nuevoCorreo.IsBodyHtml = true;
            nuevoCorreo.Body = html;
            Task task = null;
            if (tipo == "Cesta")
            {
                task = new Task(() => crearPDF(cesta, cliente, "Cesta", tempPath));
                task.Start();
                task.Wait();
                nuevoCorreo.Attachments.Add(new Attachment(tempPath + "/ReciboCompra" + cesta.id + ".pdf"));
            }           

            SmtpClient servidor = new SmtpClient();
            servidor.Host = "smtp.gmail.com";
            servidor.Port = 587;
            servidor.EnableSsl = true;
            servidor.DeliveryMethod = SmtpDeliveryMethod.Network;
            servidor.Credentials = new NetworkCredential("proyectos.clase.net@gmail.com", "solosequenosenada");
            servidor.Timeout = 20000;
            
            servidor.Send(nuevoCorreo);
        }

        private void crearPDF(Cesta cesta, Cliente cliente, string tipo, string tempPath)
        {
            
            if (tipo == "Cesta")
            {
                PdfDocument pdf = new PdfDocument();
                PdfPageBase pagina = pdf.Pages.Add();
                string salida =
                        "Estimado " + cliente.nombre + " " + cliente.apellido + " " + cliente.apellido2
                      + "\n\nGracias por hacer su pedido en nuestra tienda Online"
                      + "\nNo dude en ponerse en contacto con nosotros si tiene algun problema o si hay algun dato erroneo al telefono: 900 500 103 o"
                      + "\na nuestro departamento de <a href='~/Vistas/atencion.aspx'>Atencion al cliente</a> donde podra aprovechar tambien para darnos su opinion si lo desea y nuestros tecnicos la valoraran lo antes posible pudiendose llegar a poner en contacto con usted si asi lo desea."
                      + "\nLos datos de su pedido son:"
                      + "\nCESTA"
                      + "\n  ID: " + cesta.id
                      + "\n  LISTA PRODUCTOS:\n";
                foreach (string producto in cesta.listaProductos.Keys)
                {
                    salida += "    " + cesta.listaProductos[producto].Split('/')[0] + "x " + producto + "\n";
                }
                salida +=
                        "\n\nCLIENTE"
                      + "\n  Nombre: " + cliente.nombre + " " + cliente.apellido + " " + cliente.apellido2
                      + "\n  NIF: " + cliente.NIF
                      + "\n  Telefonos: \n";
                foreach (string telefono in cliente.listaTelefonos) salida += "    " + telefono + "\n";
                salida += "\n  Direcciones: \n";
                foreach (string direccion in cliente.listaIdDirecciones.Values) salida += "    " + direccion + "\n";
                salida += "\nSu pedido saldra cuanto antes de nuestros almacenes."
                    + "\n\nMuchas gracias por confiar en nosotros. \n\n\nAtentamente, equipo de post-venta de Mercadona";
                
                pagina.Canvas.DrawString(salida, new PdfFont(PdfFontFamily.TimesRoman, 14), new PdfSolidBrush(Color.Black), 10, 10);
                
                pdf.SaveToFile(tempPath + "/ReciboCompra" + cesta.id + ".pdf");
                pdf.Close();
            }
        }
    }
}