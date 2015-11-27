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

            if (modificar && !IsPostBack)
            {
                text_Telefono.Text = telefono;
            }
        }


        protected void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {                
                if(!cliente.listaTelefonos.Contains(text_Telefono.Text)) cliente.listaTelefonos.Add(text_Telefono.Text);
                if (cliente.listaTelefonos.Contains(telefono)) cliente.listaTelefonos.Remove(telefono);
                Session["Cliente"] = cliente;
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