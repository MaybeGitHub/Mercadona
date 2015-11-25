using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;

namespace MerCadona.Vistas
{
    public partial class altaTelefono : System.Web.UI.Page
    {
        private string telefono;
        private string telefonoNuevo;
        private bool modificar = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            telefono = Request.QueryString["telefono"];
            telefonoNuevo = text_Telefono.Text;

            if (telefono != null)
            {
                text_Telefono.Text = telefono;
                modificar = true;
            }
        }


        protected void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (Request.Cookies["Telefono"] != null)
                {                    
                    if (modificar)
                    {
                        Request.Cookies["Telefono"].Values.Remove(telefono);
                        Request.Cookies["Telefono"].Values.Add(telefonoNuevo, telefonoNuevo);
                    }
                    else
                    {
                        Request.Cookies["Telefono"].Values.Add(text_Telefono.Text, text_Telefono.Text);                       
                    }
                    Response.Cookies.Add(Request.Cookies["Telefono"]);
                }
                else
                {
                    HttpCookie miCookie = new HttpCookie("Telefono");
                    miCookie.Values.Add(text_Telefono.Text, text_Telefono.Text);
                    miCookie.Expires = DateTime.Now.AddHours(1d);
                    Response.Cookies.Add(miCookie);
                }                
                Response.Write("<script>onunload=function(){opener.location='altaCliente.aspx';}</script>"); 
                Response.Write("<script>window.close();</script>");
            }
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }
    }
}