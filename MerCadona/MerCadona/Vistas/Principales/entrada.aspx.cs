using MerCadona.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;

namespace MerCadona.Vistas
{
    public partial class entrada : System.Web.UI.Page
    {
        private CXml cXml = new CXml();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                foreach (string key in Request.Params)
                {
                    if (Request.Params[key].Contains("link_Registro"))
                    {
                        Session["Cliente"] = new Cliente();
                        Response.Cookies.Add(new HttpCookie("lastPage", "~/Vistas/Principales/entrada.aspx"));
                        Response.Redirect("~/Vistas/Popups/altaCliente.aspx");
                    }

                    if (key.Contains("button_Entrar"))
                    {
                        if (validar())
                        {
                            HttpCookie miCookie = new HttpCookie("Cliente", text_NIF.Text);
                            miCookie.Expires = DateTime.Now.AddDays(1d);
                            Response.Cookies.Add(miCookie);
                            Response.Redirect("~/Vistas/Carrito/carrito.aspx");
                        }
                    }
                }
            }
        }

        private bool validar()
        {
            if (cXml.comprobarCliente(Server.MapPath("~/ficheros/Clientes.xml"), text_NIF.Text, text_Contraseña.Text))
                return true;
            else
            {
                label_Error.Visible = true;
                return false;
            }
        }
    }
}