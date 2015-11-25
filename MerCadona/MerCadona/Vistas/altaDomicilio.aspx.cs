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
    public partial class altaDomicilio : System.Web.UI.Page
    {
        private string direccion;
        private string tipoVia, nombreVia, numero, piso, puerta, urba, bloque, escalera, observaciones, localidad, cp, habitual;
        private bool modificar = false;
        private Direccion dir = new Direccion();
        private CXml cXml = new CXml();

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
                dir = cXml.fabricarDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), Request.Cookies["Direccion"].Values[direccion]);
                text_TipoVia.Text = dir.tipoVia;
                text_NombreVia.Text = dir.nombreVia;
                text_Numero.Text = dir.numero;
                text_Piso.Text = dir.piso;
                text_Puerta.Text = dir.puerta;
                text_Urba.Text = dir.urba;
                text_Bloque.Text = dir.bloque;
                text_Escalera.Text = dir.escalera;
                text_Observaciones.Text = dir.observaciones;
                text_Localdidad.Text = dir.localidad;
                text_CP.Text = dir.cp;
                check_Habitual.Checked = dir.habitual == "Si" ? true : false;
                modificar = true;
            }
        }

        protected void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                rellenarDireccion();
                if (Request.Cookies["Direccion"] != null)
                {                    
                    if (modificar)
                    {                        
                        Request.Cookies["Direccion"].Values.Remove(Request.Cookies["Direccion"].Values[direccion]);
                    }                    
                    Request.Cookies["Direccion"].Values.Add(dir.nombreVia + "-" + dir.localidad, dir.id);
                    Response.Cookies.Add(Request.Cookies["Direccion"]);
                }
                else
                {
                    cXml.modificarDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), dir, modificar);
                    HttpCookie miCookie = new HttpCookie("Direccion");                    
                    miCookie.Values.Add(dir.nombreVia + "-" + dir.localidad, dir.id);
                    miCookie.Expires = DateTime.Now.AddHours(1d);
                    Response.Cookies.Add(miCookie);
                }
                Response.Write("<script>onunload=function(){opener.location='altaCliente.aspx';}</script>");
                Response.Write("<script>window.close();</script>");
            }
        }

        private void rellenarDireccion()
        {
            dir.tipoVia = text_TipoVia.Text;
            dir.nombreVia = text_NombreVia.Text;
            dir.numero = text_Numero.Text;
            dir.piso = text_Piso.Text;
            dir.puerta = text_Puerta.Text;
            dir.urba = text_Urba.Text;
            dir.bloque = text_Bloque.Text;
            dir.escalera = text_Escalera.Text;
            dir.observaciones = text_Observaciones.Text;
            dir.localidad = text_Localdidad.Text;
            dir.cp = text_CP.Text;
            dir.habitual = check_Habitual.Checked ? "Si" : "No";
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }
    }
}