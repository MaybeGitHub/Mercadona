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
    public partial class altaCliente : System.Web.UI.Page
    {
        private CXml cXml = new CXml();
        private Cliente cliente;

        protected void Page_Load(object sender, EventArgs e)
        {            
            for (int año = 1950; año <= DateTime.Now.Year; año++) list_Año.Items.Add(new ListItem(año.ToString()));
            for (int mes = 1; mes <= 12; mes++) list_Mes.Items.Add(new ListItem(mes.ToString()));
            for (int dia = 1; dia <= 31; dia++) list_Dia.Items.Add(new ListItem(dia.ToString()));

            if (Session["cliente"] != null) cliente = (Cliente)Session["cliente"];

            if (IsPostBack)
            {
                foreach (string key in Request.Params)
                {
                    if (key.Contains("button_BorrarTelefono"))
                    {
                        cliente.listaTelefonos.Remove(list_Telefonos.SelectedItem.Text);
                        list_Telefonos.Items.Remove(list_Telefonos.SelectedItem);
                        if (list_Telefonos.Items.Count == 0) list_Telefonos.Items.Add(new ListItem("No se han definido telefonos"));
                    }

                    if (key.Contains("button_BorrarDireccion"))
                    {
                        cliente.listaIdDirecciones.Remove(list_Direcciones.SelectedItem.Text);
                        cXml.borrarDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), list_Direcciones.SelectedItem.Value);
                        list_Direcciones.Items.Remove(list_Direcciones.SelectedItem);
                        if (list_Direcciones.Items.Count == 0) list_Direcciones.Items.Add(new ListItem("No se han definido direcciones de entrega"));
                    }

                    if (key.Contains("button_Enviar"))
                    {
                        if (list_Direcciones.SelectedItem.Text != "No se han definido direcciones de entrega" && list_Telefonos.SelectedItem.Text != "No se han definido telefonos")
                        {
                            cXml.añadirCliente(Server.MapPath("~/ficheros/Clientes.xml"), cliente);
                            Session.Remove("cliente");
                            Response.Redirect("/Vistas/entrada.aspx");
                        }
                    }

                    if (key.Contains("Alta") || key.Contains("Borrar") || key.Contains("Modificar"))
                    {
                        rellenarCliente();
                        Session["cliente"] = cliente;
                    }
                }
            }
            else
            {
                if (cliente != null)
                {
                    rellenarCampos();
                }                
            }
        }

        private void rellenarCampos()
        {
            text_Nombre.Text = cliente.nombre;
            text_Apellido1.Text = cliente.apellido;
            text_Apellido2.Text = cliente.apellido2;
            text_TipoID.Text = cliente.tipoIdentificacion;
            text_NumeroID.Text = cliente.NIF;
            check_Info.Checked = cliente.info == "Si" ? true : false;
            text_Email.Text = cliente.email;
            text_Contraseña.Text = cliente.contraseña;
            list_FaltaProducto.SelectedIndex = list_FaltaProducto.Items.IndexOf(list_FaltaProducto.Items.FindByText(cliente.info));
            list_Dia.SelectedIndex = list_Dia.Items.IndexOf(list_Dia.Items.FindByText(cliente.dia));
            list_Mes.SelectedIndex = list_Mes.Items.IndexOf(list_Mes.Items.FindByText(cliente.mes));
            list_Año.SelectedIndex = list_Año.Items.IndexOf(list_Año.Items.FindByText(cliente.año));
            if (cliente.listaTelefonos.Count != 0)
            {
                list_Telefonos.Items.Clear();
                foreach (string telefono in cliente.listaTelefonos) list_Telefonos.Items.Add(telefono);
            }

            if (cliente.listaIdDirecciones.Count != 0)
            {
                list_Direcciones.Items.Clear();
                foreach (string direccion in cliente.listaIdDirecciones.Keys) list_Direcciones.Items.Add(new ListItem(direccion, cliente.listaIdDirecciones[direccion]));
            }
        }

        private void rellenarCliente()
        {           
            cliente.nombre = text_Nombre.Text;
            cliente.apellido = text_Apellido1.Text;
            cliente.apellido2 = text_Apellido2.Text;
            cliente.tipoIdentificacion = text_TipoID.Text;
            cliente.NIF = text_NumeroID.Text;
            cliente.info = check_Info.Checked ? "Si" : "No";
            cliente.email = text_Email.Text;
            cliente.contraseña = text_Contraseña.Text;
            cliente.faltaProducto = list_FaltaProducto.SelectedItem.Value;
            cliente.dia = list_Dia.SelectedItem.Value;
            cliente.mes = list_Mes.SelectedItem.Value;
            cliente.año = list_Año.SelectedItem.Value;
            foreach(ListItem item in list_Direcciones.Items)  cliente.listaIdDirecciones.Add(item.Text, item.Value);
            foreach (ListItem item in list_Telefonos.Items) cliente.listaTelefonos.Add(item.Value);            
        }
    }
}