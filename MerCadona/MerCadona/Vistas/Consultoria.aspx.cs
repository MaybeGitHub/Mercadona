using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Modelos;
using MerCadona.Controladores;

namespace MerCadona.Vistas
{
    public partial class Consultoria : System.Web.UI.Page
    {
        private List<Reclamacion> listaReclamaciones = new List<Reclamacion>();
        private CXml cXml = new CXml();

        protected void Page_Load(object sender, EventArgs e)
        {
            int pos = list_Reclamaciones.SelectedIndex;
            string[] datosFicheroReclamaciones = CFicheros.leerFichero(Server.MapPath("~/ficheros/Reclamaciones.txt"));
            listaReclamaciones.AddRange(datosFicheroReclamaciones.Where(linea => linea.Split(';')[0] == "1").Select(linea => new Reclamacion(linea)).ToList());
            listaReclamaciones.OrderBy(reclamacion => reclamacion.asunto);

            if (IsPostBack)
            {
                foreach (string key in Request.Params)
                {
                    info.Text += "KEY: " + key + "---------------------- VALOR : " + Request.Params[key] + "\n";                    

                    if (key.Contains("button_Cerrar"))
                    {
                        CFicheros.cerrarReclamacion(Server.MapPath("~/ficheros/Reclamaciones.txt"), listaReclamaciones[pos]);
                        listaReclamaciones[pos].activo = 0;
                        pos = 0;
                        break;
                    }
                }
            }
            else
            {
                pos = 0;          
            }
            
            list_Reclamaciones.Items.Clear();
            listaReclamaciones.Where(reclamacion => reclamacion.activo == 1).ToList().ForEach(reclamacion => list_Reclamaciones.Items.Add(reclamacion.asunto + "   " + reclamacion.mensaje + "..."));
            list_Reclamaciones.SelectedIndex = pos;
            rellenarCampos(listaReclamaciones[pos]);
        }

        private void rellenarCampos(Reclamacion reclamacion)
        {
            label_Asunto.Text = reclamacion.asunto;
            textarea_Mensaje.Text = reclamacion.mensaje;
            label_Nombre.Text = reclamacion.usuario.Split('&')[0]; 
            label_DNI.Text = reclamacion.usuario.Split('&')[1];
            label_Email.Text = reclamacion.usuario.Split('&')[3];
            label_Telefono.Text = reclamacion.usuario.Split('&')[2];
            label_Provincia.Text = reclamacion.direccion.Split('&')[0];
            label_Localidad.Text = reclamacion.direccion.Split('&')[1];
            label_CP.Text = reclamacion.direccion.Split('&')[2];
            label_Domicilio.Text = reclamacion.direccion.Split('&')[3] + "  " + reclamacion.direccion.Split('&')[4] + "  " + reclamacion.direccion.Split('&')[5];
            label_Mayor14.Text = reclamacion.mayor14 == 1 ? "Si" : "No";
            label_Info.Text = reclamacion.informacion == 1 ? "Si" : "No";
            label_Firma.Text = reclamacion.firma == 1 ? "Si" : "No";
        }
    }
}