using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;

namespace MerCadona.Vistas
{    
    public partial class cambiopwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            text_Email.Text = Request.QueryString["email"];
        }

        protected void button_Enviar_Click(object sender, EventArgs e)
        {
            if (valido() && IsValid) {
                CXml cXml = new CXml();
                cXml.modificarContraseña(Server.MapPath("~/ficheros/Clientes.xml"), text_Email.Text, text_contraseña.Text);
                Response.Redirect("/Vistas/Principales/index.aspx");
            }
        }

        private bool valido()
        {
            if(text_contraseña.Text != "" && text_contraseña2.Text != "")
            {
                label_Error.Visible = false;
                return true;
            }
            label_Error.Visible = true;
            return false;
        }
    }
}