using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;

namespace MerCadona.Vistas
{
    public partial class loginEmpleados : System.Web.UI.Page
    {
        private CXml cXml = new CXml();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                foreach(string key in Request.Params)
                {
                    if (key.Contains("button_Entrar"))
                    {
                        if (cXml.comprobarDatos(Server.MapPath("~/ficheros/Empleados.xml"), text_Nombre.Text, text_NIF.Text, list_Tipos.SelectedItem.Text))
                        {
                            Response.Redirect("~/Vistas/Principales/consultoria.aspx?nombre=" + text_Nombre.Text);
                        }
                        else
                        {
                            error();
                        }
                    }
                }

            }else
            {
                cXml.lecturaXMLPuestos(Server.MapPath("~/ficheros/Empleados.xml"), list_Tipos);
            }
        }

        private void error()
        {
            label_Error.Visible = true;
            text_NIF.Text = "";            
        }
    }
}