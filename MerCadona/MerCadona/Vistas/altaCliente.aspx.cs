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

        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            for (int año = 1950; año <= DateTime.Now.Year; año++) list_Año.Items.Add(new ListItem(año.ToString()));
            for (int mes = 1; mes <= 12; mes++) list_Mes.Items.Add(new ListItem(mes.ToString()));
            for (int dia = 1; dia <= 31; dia++) list_Dia.Items.Add(new ListItem(dia.ToString()));

            if (IsPostBack)
            {
                foreach (string key in Request.Params)
                {
                    if (key.Contains("button_BorrarTelefono"))
                    {
                        if (Request.Cookies["Telefono"] != null)
                        {
                            Request.Cookies["Telefono"].Values.Remove(list_Telefonos.SelectedItem.Text);
                            list_Telefonos.Items.Remove(list_Telefonos.SelectedItem);
                            if (Request.Cookies["Telefono"].Values.Count == 0)
                            {
                                Request.Cookies["Telefono"].Expires = DateTime.Now.AddHours(-1d);
                                list_Telefonos.Items.Add(new ListItem("No se han definido telefonos"));
                            }
                            Response.Cookies.Add(Request.Cookies["Telefono"]);
                        }                        
                    }

                    if (key.Contains("button_BorrarDireccion"))
                    {
                        if (Request.Cookies["Direccion"] != null)
                        {
                            Request.Cookies["Direccion"].Values.Remove(list_Direcciones.SelectedItem.Text);
                            cXml.borrarDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), list_Direcciones.SelectedItem.Value);
                            list_Direcciones.Items.Remove(list_Direcciones.SelectedItem);                            
                            if (Request.Cookies["Direccion"].Values.Count == 0)
                            {
                                Request.Cookies["Direccion"].Expires = DateTime.Now.AddHours(-1d);
                                list_Direcciones.Items.Add(new ListItem("No se han definido direcciones de entrega"));
                            }
                            Response.Cookies.Add(Request.Cookies["Direccion"]);
                        }
                    }
                }
            }
            else
            {
                list_Telefonos.Items.Clear();
                if (Request.Cookies["Telefono"] == null)
                    list_Telefonos.Items.Add(new ListItem("No se han definido telefonos"));
                else
                    foreach (string telefono in Request.Cookies["Telefono"].Values) list_Telefonos.Items.Add(telefono);

                list_Direcciones.Items.Clear();
                if (Request.Cookies["Direccion"] == null)
                    list_Direcciones.Items.Add(new ListItem("No se han definido direcciones de entrega"));
                else
                    foreach (string direccion in Request.Cookies["Direccion"].Values) list_Direcciones.Items.Add(new ListItem(direccion, Request.Cookies["Direccion"].Values[direccion]));
            }
        }
    }
}