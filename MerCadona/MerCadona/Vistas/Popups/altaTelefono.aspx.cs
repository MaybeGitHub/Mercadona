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
    public partial class altaTelefono : System.Web.UI.Page
    {
        private CXml cXml = new CXml();        
        private bool modificar = false;
        private string telefono;
        private Cliente cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            telefono = Request.QueryString["telefono"];
            cliente = (Cliente)Session["Cliente"];
            modificar = telefono != null;            

            if (IsPostBack)
            {
                if (valido())
                {
                    if (!cliente.listaTelefonos.Contains(text_Telefono.Text)) cliente.listaTelefonos.Add(text_Telefono.Text);
                    if (cliente.listaTelefonos.Contains(telefono)) cliente.listaTelefonos.Remove(telefono);
                    Session["Cliente"] = cliente;
                    Response.Write("<script>onunload=function(){opener.location='altaCliente.aspx';}</script>");
                    Response.Write("<script>window.close();</script>");
                }
            }

            if (modificar)
            {
                text_Telefono.Text = telefono;
            }
        }

        private bool valido()
        {
            if (text_Telefono.Text.Length != 9)
            {
                label_Error.Visible = true;
                return false;
            }

            // Metodo guarro de validar si solo tiene numeros

            foreach (char c in text_Telefono.Text)
            {
                if (!"0123456789 ".Contains(c))
                {
                    label_Error.Visible = true;
                    return false;
                }
            }
            return true;
        }

        protected void button_Cancelar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }
    }
}