using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;
using MerCadona.Modelos;

namespace MerCadona.Vistas
{
    public partial class atencion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            info.Text = "";

            foreach (string key in Request.Params)
            {
                info.Text += "KEY: " + key + "---------------------- VALOR : " + Request.Params[key] + "\n";
            }
        }

        protected void cv_Asunto_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ( radio_Felicitacion.Checked || radio_Informacion.Checked || radio_Reclamacion.Checked || radio_Sugerencia.Checked )
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void button_Consulta_Click(object sender, EventArgs e)
        {
            if( IsValid)
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
}