using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;
using MerCadona.Modelos;
using System.Text.RegularExpressions;

namespace MerCadona.Vistas
{
    public partial class atencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string key in Request.Params)
            {
                if (key.Contains("button_Consulta"))
                {
                    if(validar()) rellenarReclamacion();
                    limpiarCampos();                 
                }
            }
        }

        private void limpiarCampos()
        {
            radio_Felicitacion.Checked = false;
            radio_Informacion.Checked = false;
            radio_Reclamacion.Checked = false;
            radio_Sugerencia.Checked = false;
            textarea_Mensaje.Text = "";
            text_Apellido1.Text = "";
            text_Apellido2.Text = "";
            text_Cp.Text = "";
            text_Dni.Text = "";
            text_Email.Text = "";
            text_Localidad.Text = "";
            text_Nombre.Text = "";
            text_NombreVia.Text = "";
            text_Numero.Text = "";
            text_Provincia.Text = "";
            text_Telefono.Text = "";
            text_TipoVia.Text = "";
            check_Autorizacion.Checked = false;
            check_Edad.Checked = false;
            check_Firma.Checked = false;
        }

        private bool validar()
        {
            // Habria que validar todos los campos... 

            if (textarea_Mensaje.Text == "" ) 
            {
                label_ErrorMensaje.Visible = true;
                return false;
            }
            if (!radio_Felicitacion.Checked && !radio_Informacion.Checked && !radio_Reclamacion.Checked && !radio_Sugerencia.Checked)
            {
                label_ErrorAsunto.Visible = true;
                return false;
            }
            return true;            
        }

        private void rellenarReclamacion()
        {
            string asunto = Request.Params["ctl00$contentPanel_body$asunto"].Split('_')[1];
            string mensaje = Request.Params["ctl00$contentPanel_body$textarea_Mensaje"];
            string nombre = Request.Params["ctl00$contentPanel_body$text_Nombre"];
            string dni = Request.Params["ctl00$contentPanel_body$text_Dni"];
            string apellido1 = Request.Params["ctl00$contentPanel_body$text_Apellido1"];
            string apellido2 = Request.Params["ctl00$contentPanel_body$text_Apellido2"];
            string provincia = Request.Params["ctl00$contentPanel_body$text_Provincia"];
            string localidad = Request.Params["ctl00$contentPanel_body$text_Localidad"];
            string cp = Request.Params["ctl00$contentPanel_body$text_Cp"];
            string tipoVia = Request.Params["ctl00$contentPanel_body$text_TipoVia"];
            string nombreVia = Request.Params["ctl00$contentPanel_body$text_NombreVia"];
            string numero = Request.Params["ctl00$contentPanel_body$text_Numero"];
            string telefono = Request.Params["ctl00$contentPanel_body$text_Telefono"];
            string email = Request.Params["ctl00$contentPanel_body$text_Email"];
            bool mayor14 = Request.Params["ctl00$contentPanel_body$check_Edad"] == "on" ? true : false ;
            bool info = Request.Params["ctl00$contentPanel_body$check_Autorizacion"] == "on" ? true : false;
            bool firma = Request.Params["ctl00$contentPanel_body$check_Firma"] == "on" ? true : false;
            Reclamacion reclamacion = new Reclamacion(asunto, mensaje, nombre, dni, apellido1, apellido2, provincia, localidad, cp, tipoVia, nombreVia, numero, telefono, email, mayor14, info, firma);
            new CXml().añadirReclamacion(Server.MapPath("~/ficheros/Reclamaciones.xml"), reclamacion);            
        }
        
        
    }
}