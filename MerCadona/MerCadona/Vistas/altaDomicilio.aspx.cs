using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerCadona.Vistas
{
    public partial class altaDomicilio : System.Web.UI.Page
    {
        private string direccion;
        private string tipoVia, nombreVia, numero, piso, puerta, urba, bloque, escalera, observaciones, localidad, cp, habitual;
        private string datosCompletos;
        private bool modificar = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            direccion = Request.QueryString["direccion"];           
            tipoVia = text_TipoVia.Text;
            nombreVia = text_NombreVia.Text;
            numero = text_Numero.Text;
            piso = text_Piso.Text;
            puerta = text_Puerta.Text;
            urba = text_Urba.Text;
            bloque = text_Bloque.Text;
            escalera = text_Escalera.Text;
            observaciones = text_Observaciones.Text;
            localidad = text_Localdidad.Text;
            cp = text_CP.Text;
            habitual = check_Habitual.Checked ? "Si": "No";

            if (direccion != null)
            {
                datosCompletos = Request.Cookies["Direccion"].Values[direccion];
                text_TipoVia.Text = datosCompletos.Split(';')[0];
                text_NombreVia.Text = datosCompletos.Split(';')[1];
                text_Numero.Text = datosCompletos.Split(';')[2];
                text_Piso.Text = datosCompletos.Split(';')[3];
                text_Puerta.Text = datosCompletos.Split(';')[4];
                text_Urba.Text = datosCompletos.Split(';')[5];
                text_Bloque.Text = datosCompletos.Split(';')[6];
                text_Escalera.Text = datosCompletos.Split(';')[7];
                text_Observaciones.Text = datosCompletos.Split(';')[8];
                text_Localdidad.Text = datosCompletos.Split(';')[9];
                text_CP.Text = datosCompletos.Split(';')[10];
                check_Habitual.Checked = datosCompletos.Split(';')[10] == "Si" ? true : false;
                modificar = true;
            }
        }

        protected void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (Request.Cookies["Direccion"] != null)
                {
                    if (modificar)
                    {
                        Request.Cookies["Direccion"].Values.Remove(direccion);
                        Request.Cookies["Direccion"].Values.Add(nombreVia + "-" + localidad, camposConcatenados());
                    }
                    else
                    {
                        Request.Cookies["Telefono"].Values.Add(text_NombreVia.Text + "-" + text_Localdidad.Text, camposConcatenados());
                    }
                    Response.Cookies.Add(Request.Cookies["Direccion"]);
                }
                else
                {
                    HttpCookie miCookie = new HttpCookie("Direccion");
                    miCookie.Values.Add(text_NombreVia.Text + "-" + text_Localdidad.Text, camposConcatenados());
                    miCookie.Expires = DateTime.Now.AddHours(1d);
                    Response.Cookies.Add(miCookie);
                }
                Response.Write("<script>onunload=function(){opener.location='altaCliente.aspx';}</script>");
                Response.Write("<script>window.close();</script>");
            }
        }

        private string camposConcatenados()
        {
            return text_TipoVia.Text 
            + ";" + text_NombreVia.Text
            + ";" + text_Numero.Text
            + ";" + text_Piso.Text
            + ";" + text_Puerta.Text
            + ";" + text_Urba.Text
            + ";" + text_Bloque.Text
            + ";" + text_Escalera.Text
            + ";" + text_Observaciones.Text
            + ";" + text_Localdidad.Text
            + ";" + text_CP.Text
            + ";" + (check_Habitual.Checked ? "Si" : "No");
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }
    }
}