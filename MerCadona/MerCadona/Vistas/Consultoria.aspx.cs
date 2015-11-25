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
    public partial class consultoria : System.Web.UI.Page
    {
        private List<Reclamacion> listaReclamaciones = new List<Reclamacion>();
        private CXml cXml = new CXml();

        protected void Page_Load(object sender, EventArgs e)
        {
            int pos = list_Reclamaciones.SelectedIndex;
            listaReclamaciones = cXml.reclamacionesNoLeidas(Server.MapPath("~/ficheros/Reclamaciones.xml"));            
            listaReclamaciones.OrderBy(reclamacion => reclamacion.asunto);

            if (IsPostBack)
            {
                foreach (string key in Request.Params)
                {
                    info.Text += "KEY: " + key + "---------------------- VALOR : " + Request.Params[key] + "\n";                    

                    if (key.Contains("button_Cerrar") && listaReclamaciones.Count > 0)
                    {
                        cXml.cerrarReclamacion(Server.MapPath("~/ficheros/Reclamaciones.xml"), listaReclamaciones[pos]);
                        listaReclamaciones[pos].leido = "Si";
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
            listaReclamaciones.Where(reclamacion => reclamacion.leido == "No").ToList().ForEach(reclamacion => list_Reclamaciones.Items.Add(reclamacion.asunto + " ---- Mensaje: " + (reclamacion.mensaje.Length > 50 ? reclamacion.mensaje.Substring(0,50) + "..." : reclamacion.mensaje)));            if (listaReclamaciones.Count > 0 && list_Reclamaciones.SelectedIndex >= 0)
            {
                list_Reclamaciones.SelectedIndex = pos;
                rellenarCampos(listaReclamaciones[pos]);
            }
            else
            {
                rellenarCampos(new Reclamacion());
                list_Reclamaciones.Items.Add(new ListItem("No quedan mas reclamaciones"));
            }
        }        

        private void rellenarCampos(Reclamacion reclamacion)
        {
            label_Asunto.Text = reclamacion.asunto;
            textarea_Mensaje.Text = reclamacion.mensaje;
            label_Nombre.Text = reclamacion.nombre; 
            label_DNI.Text = reclamacion.dni;
            label_Email.Text = reclamacion.email;
            label_Telefono.Text = reclamacion.telefono;
            label_Provincia.Text = reclamacion.provincia;
            label_Localidad.Text = reclamacion.localidad;
            label_CP.Text = reclamacion.cp;
            label_Domicilio.Text = reclamacion.tipoVia + "  " + reclamacion.nombreVia + "  " + reclamacion.numero;
            label_Mayor14.Text = reclamacion.mayor14;
            label_Info.Text = reclamacion.informacion;
            label_Firma.Text = reclamacion.firma;
        }
    }
}