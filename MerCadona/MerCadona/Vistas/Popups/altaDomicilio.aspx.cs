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
        private Direccion dir;
        private Cliente cliente;
        private CXml cXml = new CXml();
        private bool modificar;

        protected void Page_Load(object sender, EventArgs e)
        {
            direccion = Request.QueryString["direccion"];
            modificar = direccion != null;
            cliente = (Cliente)Session["Cliente"];
            cXml.lecturaXMLDatos(Server.MapPath("~/ficheros/datosInteres.xml"), list_TipoVia, "Calle");

            if (IsPostBack)
            {
                dir = new Direccion();
                if(modificar) dir.id = direccion;
                rellenarDireccion();
            }
            else
            {
                if (modificar)
                {
                    dir = cXml.fabricarDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), direccion);
                    list_TipoVia.SelectedIndex = list_TipoVia.Items.IndexOf(list_TipoVia.Items.FindByText(dir.tipoVia));                    
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
                }
            }
        }

        protected void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (valido())
            {
                cXml.añadirDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), dir);
                if (!cliente.listaIdDirecciones.Values.Contains(dir.id)) cliente.listaIdDirecciones.Add(dir.nombreVia + "-" + dir.localidad, dir.id);
                Session["Cliente"] = cliente;
                Response.Write("<script>onunload=function(){opener.location='altaCliente.aspx';}</script>");
                Response.Write("<script>window.close();</script>");
            }
        }

        private bool valido()
        {
            if (text_NombreVia.Text == ""
            || text_Numero.Text == ""
            || text_Localdidad.Text == ""
            || text_CP.Text == "")
            {
                label_ErrorVacio.Visible = true;
                return false;
            }
            else
            {
                label_ErrorVacio.Visible = false;
            }
            return true;
        }

        private void rellenarDireccion()
        {
            dir.tipoVia = list_TipoVia.SelectedItem.Value;
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