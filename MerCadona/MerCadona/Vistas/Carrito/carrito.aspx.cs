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
    public partial class carrito : System.Web.UI.Page
    {
        private CXml cXml = new CXml();
        private string categoria;
        private Cesta cesta;
        private int cantidad = 1;
        private string queProducto = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cliente = cXml.fabricarCliente(Server.MapPath("~/ficheros/Clientes.xml"), Request.Cookies["Cliente"].Value);            

            if (IsPostBack)
            {               
                foreach (string key in Request.Params)
                {                   
                    if (key == "__EVENTARGUMENT" && Request.Params[key].Split('\\').Count() > 1)
                    {
                        ViewState["Categoria"] = Request.Params[key].Split('\\')[1];                        
                    }

                    if (key.Contains("imgButton_Productos_") && key.Contains("x"))
                    {
                       cXml.añadirProducto(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF, Server.MapPath("~/ficheros/SECCIONES_SUBSECCIONES.xml"), key.Split('_')[2], key.Split('_')[3].Split('.')[0]);
                    }

                    if (key.Contains("imgButton_BorrarProducto_") && key.Contains("x"))
                    {
                        cXml.borrarProducto(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF, key.Split('_')[2].Split('.')[0]);
                    }

                    if(key.Contains("imgButton_Formalizar") && key.Contains("x"))
                    {                        
                        Response.Redirect("~/Vistas/Carrito/formalizar.aspx");
                    }

                    if (key.Contains("button_SumarProducto_Cesta"))
                    {                        
                        cXml.añadirProducto(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF, Server.MapPath("~/ficheros/SECCIONES_SUBSECCIONES.xml"), key.Split('_')[3], "1");
                    }

                    if (key.Contains("button_RestarProducto_Cesta"))
                    {
                        cXml.añadirProducto(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF, Server.MapPath("~/ficheros/SECCIONES_SUBSECCIONES.xml"), key.Split('_')[3], "-1");
                    }

                    if (key.Contains("button_SumarProducto_Body_"))
                    {
                        queProducto = key.Split('_')[3];
                        cantidad = int.Parse(key.Split('_')[4]) + 1;
                    }

                    if (key.Contains("button_RestarProducto_Body_"))
                    {
                        queProducto = key.Split('_')[3];
                        int cuantos = int.Parse(key.Split('_')[4]);
                        cantidad = cuantos - 1 >= 1 ? cuantos - 1 : cuantos;
                    }

                    if (key.Contains("BotonModDatos"))
                    {
                        Session["cliente"] = cliente;
                        Response.Cookies.Add(new HttpCookie("lastPage", "~/Vistas/Carrito/carrito.aspx"));
                        Response.Redirect("~/Vistas/Popups/altaCliente.aspx");
                    }

                    if (key.Contains("BotonModPedido"))
                    {
                        Response.Cookies.Add(new HttpCookie("Cliente", cliente.NIF));
                        Response.Redirect("~/Vistas/Carrito/pedidos.aspx");
                    }
                }
            }
            else
            {                              
                rellenarTreeView();
            }            

            // Dibujo Categoria

            if (ViewState["Categoria"] != null)
            {
                categoria = ViewState["Categoria"].ToString();
                rellenarTableProductos();
            }
                   
            // Recupero Cliente
                
            if(Request.Cookies["Cliente"] != null)
            {
                cliente = cXml.fabricarCliente(Server.MapPath("~/ficheros/Clientes.xml"), Request.Cookies["Cliente"].Value);
            }

            // Recupero Cesta

            if (cXml.comprobarCestaAbierta(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF))
            {
                cesta = cXml.fabricarCesta(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF);
            }
            else
            {
                cesta = new Cesta();
                cesta.cliente = cliente.NIF;
                cXml.añadirCesta(Server.MapPath("~/ficheros/Cestas.xml"), cesta);
            }

            Label tx = (Label)Master.FindControl("LabelDireccion");
            tx.Text = "<b>Cliente: </b> " + cliente.nombre + " " + cliente.apellido + " " + cliente.apellido2 + "<b>&nbsp;NIF: </b>" + cliente.NIF;

            rellenarTablaCesta();                      
        }

        private void rellenarTablaCesta()
        {
            Table tabla = ((Table)Master.FindControl("tabla_Cesta"));
            TableRow fila;
            TableCell columna;
            Label label;
            Button button;
            TextBox textBox;
            ImageButton imgButton;
            Panel panel;

            foreach (string producto in cesta.listaProductos.Keys)
            {
                fila = new TableRow();
                fila.Height = 15;
                fila.Width = new Unit("100%");
                columna = new TableCell();
                columna.Width = new Unit("40%");
                label = new Label();
                label.Text = producto.Length > 6 ? producto.Substring(0, 6) + "..." : producto; 
                label.ToolTip = producto;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                columna.Width = new Unit("30%");
                panel = new Panel();
                panel.HorizontalAlign = HorizontalAlign.Center;                
                panel.Width = new Unit("100%");
                panel.Height = 30;
                button = new Button();                
                button.Width = 10;
                button.ID = "button_SumarProducto_Cesta_" + cesta.listaProductos.Keys.ToList().IndexOf(producto);
                button.Text = "+";              
                panel.Controls.Add(button);
                textBox = new TextBox();
                textBox.Width = 10;
                textBox.ReadOnly = true;
                textBox.Text = cesta.listaProductos[producto].Split('/')[0];
                panel.Controls.Add(textBox);
                button = new Button();
                button.Text = "-";
                button.Width = 10;
                button.ID = "button_RestarProducto_Cesta_" + cesta.listaProductos.Keys.ToList().IndexOf(producto);
                panel.Controls.Add(button);
                columna.Controls.Add(panel);                
                fila.Cells.Add(columna);

                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                columna.Width = new Unit("20%");
                label = new Label();
                label.Text = (double.Parse(cesta.listaProductos[producto].Split('/')[1]) * double.Parse(cesta.listaProductos[producto].Split('/')[0])).ToString();
                columna.Controls.Add(label);
                imgButton = new ImageButton();
                imgButton.ID = "imgButton_BorrarProducto_" + cesta.listaProductos.Keys.ToList().IndexOf(producto);
                imgButton.ImageUrl = "/imagenes/imagenes_CompraOnline/papelera.png";
                columna.Controls.Add(imgButton);
                fila.Cells.Add(columna);

                tabla.Rows.Add(fila);
            }

            fila = new TableRow();

            columna = new TableCell();
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "Coste de preparacion y envio";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "7,21 €";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "Total: ";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "0";
            for (int i = 1; i < tabla.Rows.Count-1; i++)
            {
                label.Text = (double.Parse(label.Text) + double.Parse(((Label)tabla.Rows[i].Cells[2].Controls[0]).Text)).ToString();
            }
            label.Text = (double.Parse(label.Text) + double.Parse(((Label)tabla.Rows[tabla.Rows.Count - 1].Cells[1].Controls[0]).Text.Split(' ')[0])).ToString() + " €";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            columna.ColumnSpan = 3;
            imgButton = new ImageButton();
            imgButton.ImageUrl = "/imagenes/imagenes_CompraOnline/botonCarritoFormalizar.png";
            imgButton.ID = "imgButton_Formalizar";
            columna.Controls.Add(imgButton);
            fila.Cells.Add(columna);

            tabla.Rows.Add(fila);

        }

        private void rellenarTableProductos()
        {
            label_Categoria.Text = categoria;
            Dictionary<string,string> listaProductos = cXml.lecturaXMLProductos(Server.MapPath("~/ficheros/SECCIONES_SUBSECCIONES.xml"), categoria);
            label_CantidadCategoria.Text = listaProductos.Count.ToString() + " productos encontrados";
            TableRow fila;
            TableCell columna;
            Label label;
            Button button;
            TextBox textBox;
            ImageButton imgButton;
            Panel panel;
            string posicion;

            foreach (string producto in listaProductos.Keys)
            {
                posicion = listaProductos.Keys.ToList().IndexOf(producto).ToString();
                fila = new TableRow();

                columna = new TableCell();
                columna.Width = new Unit("50%");
                label = new Label();
                label.Text = producto;                               
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                columna.Width = new Unit("20%");
                label = new Label();
                label.Text = listaProductos[producto];
                columna.Controls.Add(label);                
                fila.Cells.Add(columna);                                
                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                columna.Width = new Unit("15%");
                panel = new Panel();
                panel.Width = 100;
                button = new Button();
                button.ID = "button_SumarProducto_Body_" + posicion + "_" + (posicion == queProducto ? cantidad.ToString() : "1");
                button.Text = "+";
                panel.Controls.Add(button);
                textBox = new TextBox();
                textBox.Width = new Unit("30%");
                textBox.Text = posicion == queProducto ? cantidad.ToString() : "1";
                textBox.ID = "text_Body_" + listaProductos.Keys.ToList().IndexOf(producto);
                textBox.ReadOnly = true;                
                panel.Controls.Add(textBox);
                button = new Button();                
                button.ID = "button_RestarProducto_Body_" + posicion + "_" + (posicion == queProducto ? cantidad.ToString() : "1");
                button.Text = "-";
                panel.Controls.Add(button);
                columna.Controls.Add(panel);
                fila.Cells.Add(columna);
               
                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                columna.Width = new Unit("15%");
                imgButton = new ImageButton();
                imgButton.ID = "imgButton_Productos_" + listaProductos.Keys.ToList().IndexOf(producto) + "_" + (posicion == queProducto ? cantidad.ToString() : "1");
                imgButton.ImageUrl = "/imagenes/imagenes_CompraOnline/cesta.png";
                columna.Controls.Add(imgButton);
                fila.Cells.Add(columna);

                tabla_Productos.Rows.Add(fila);
            }
        }

        private void rellenarTreeView()
        {
            cXml.crearTreeProductos(Server.MapPath("~/ficheros/SECCIONES_SUBSECCIONES.xml"),(TreeView)Master.FindControl("tree_Productos"));            
        }
    }
}