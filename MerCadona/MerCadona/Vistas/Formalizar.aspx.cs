using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Modelos;
using MerCadona.Controladores;
using System.Threading.Tasks;

namespace MerCadona.Vistas
{
    public partial class formalizar : System.Web.UI.Page
    {
        private CXml cXml = new CXml();
        private CEmail cEmail = new CEmail();
        private Cliente cliente;
        private Cesta cesta;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Recupero Cliente

            cliente = cXml.fabricarCliente(Server.MapPath("~/ficheros/Clientes.xml"), Request.Cookies["Cliente"].Value);

            // Recupero Cesta

            cesta = cXml.fabricarCesta(Server.MapPath("~/ficheros/Cestas.xml"), Request.Cookies["Cliente"].Value);

            if (IsPostBack)
            {
                foreach(string key in Request.Params)
                {
                    if (key.Contains("button_Finalizar"))
                    {                        
                        Task task = new Task(()=> cEmail.mandarEmail(cliente, "Cesta", cesta, Server.MapPath("~/Temp")));
                        task.Start();
                        cXml.cerrarCesta(Server.MapPath("~/ficheros/Cestas.xml"), cliente.NIF);
                        Response.Redirect("~/Vistas/index.aspx");
                    }
                }
            }

            rellenarTablaCesta();
            rellenarTablaCliente();
            equilibrarTablas();
        }

        private void rellenarTablaCliente()
        {
            rellenarTablaRowCliente();
            rellenarTablaRowPago();
            rellenarTablaRowEntrega();
        }

        private void rellenarTablaRowEntrega()
        {
            TableRow fila;
            TableCell columna;
            Label label;
            DropDownList list;

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "Direcciones:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            list = new DropDownList();
            foreach (string direccion in cliente.listaIdDirecciones.Keys)
            {
                list.Items.Add(new ListItem(direccion, cliente.listaIdDirecciones[direccion]));
            }
            columna.Controls.Add(list);
            fila.Cells.Add(columna);

            tabla_RowEntrega.Rows.Add(fila);
        }

        private void rellenarTablaRowPago()
        {
            TableRow fila;
            TableCell columna;
            Label label;
            TextBox tx;
            DropDownList list;
            Image imagen;

            fila = new TableRow();

            columna = new TableCell();
            imagen = new Image();
            imagen.Style.Add("margin-left", "20px");
            imagen.ImageUrl = "~/imagenes/imagenes_CompraOnline/tarjeta_mercadona.jpg";
            columna.Controls.Add(imagen);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            imagen = new Image();
            imagen.Style.Add("margin-left", "50px");
            imagen.ImageUrl = "~/imagenes/imagenes_CompraOnline/tarjetas_credito.jpg";
            columna.Controls.Add(imagen);
            fila.Cells.Add(columna);

            tabla_RowPago.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "Numero Tarjeta:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            tx = new TextBox();
            tx.Style.Add("text-align", "center");
            tx.MaxLength = 4;
            tx.Width = 40;
            columna.Controls.Add(tx);
            label = new Label();
            label.Text = "-";
            columna.Controls.Add(label);
            tx = new TextBox();
            tx.Style.Add("text-align", "center");
            tx.MaxLength = 4;
            tx.Width = 40;
            columna.Controls.Add(tx);
            label = new Label();
            label.Text = "-";
            columna.Controls.Add(label);
            tx = new TextBox();
            tx.Style.Add("text-align", "center");
            tx.MaxLength = 4;
            tx.Width = 40;
            columna.Controls.Add(tx);
            label = new Label();
            label.Text = "-";
            columna.Controls.Add(label);
            tx = new TextBox();
            tx.Style.Add("text-align", "center");
            tx.MaxLength = 4;
            tx.Width = 40;
            columna.Controls.Add(tx);
            fila.Cells.Add(columna);

            tabla_RowPago.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "Titular:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            tx = new TextBox();
            tx.Width = 300;
            tx.MaxLength = 40;
            columna.Controls.Add(tx);
            fila.Cells.Add(columna);

            tabla_RowPago.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "Fecha caducidad:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            list = new DropDownList();
            for(int i = 1; i <= 12; i++)
            {
                list.Items.Add(i.ToString());
            }
            columna.Controls.Add(list);
            label = new Label();
            label.Style.Add("margin-left", "5px");
            label.Text = "/";
            columna.Controls.Add(label);
            list = new DropDownList();
            list.Style.Add("margin-left", "5px");
            for (int i = DateTime.Now.Year - 4; i <= DateTime.Now.Year + 4; i++)
            {
                list.Items.Add(i.ToString());
            }
            columna.Controls.Add(list);
            fila.Cells.Add(columna);

            tabla_RowPago.Rows.Add(fila);
        }

        private void rellenarTablaRowCliente()
        {
            TableRow fila;
            TableCell columna;
            Label label;
            DropDownList list;

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "Nombre:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            label = new Label();
            label.Text = cliente.nombre + " " + cliente.apellido + " " + cliente.apellido2;
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla_RowCliente.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();            
            label.Text = "Telefono:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            list = new DropDownList();
            list.ID = "list_Telefonos";
            foreach (string telefono in cliente.listaTelefonos)
            {
                list.Items.Add(telefono);
            }
            columna.Controls.Add(list);
            fila.Cells.Add(columna);

            tabla_RowCliente.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "Email:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            label = new Label();
            label.Text = cliente.email;
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla_RowCliente.Rows.Add(fila);

            fila = new TableRow();

            columna = new TableCell();
            label = new Label();
            label.Text = "En caso de falta de producto:";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            
            label = new Label();
            label.Text = cliente.faltaProducto;
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla_RowCliente.Rows.Add(fila);
        }

        private void rellenarTablaCesta()
        {
            TableRow fila;
            TableCell columna;
            Label label;

            foreach (string producto in cesta.listaProductos.Keys)
            {
                fila = new TableRow();
                fila.Height = 15;
                fila.Width = new Unit("100%");
                columna = new TableCell();
                columna.Width = new Unit("40%");
                label = new Label();
                label.Text = producto;
                label.Font.Size = FontUnit.Smaller;
                label.ToolTip = producto;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                label = new Label();
                label.Text = cesta.listaProductos[producto].Split('/')[0];
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Right;
                columna.Width = new Unit("20%");
                label = new Label();
                label.Text = (double.Parse(cesta.listaProductos[producto].Split('/')[1]) * double.Parse(cesta.listaProductos[producto].Split('/')[0])).ToString() + " €";
                columna.Controls.Add(label);                
                fila.Cells.Add(columna);

                tabla_Cesta.Rows.Add(fila);
            }            

            fila = new TableRow();
            columna = new TableCell();
            columna.ColumnSpan = 3;
            columna.BackColor = System.Drawing.Color.DarkSeaGreen;
            fila.Cells.Add(columna);
            tabla_Cesta.Rows.Add(fila);

            fila = new TableRow();
            fila.BackColor = System.Drawing.Color.LightGreen;
            columna = new TableCell();
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "Coste de preparacion y envio";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);            

            columna = new TableCell();
            columna.HorizontalAlign = HorizontalAlign.Right;
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "7,21 €";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla_Cesta.Rows.Add(fila);

            fila = new TableRow();
            columna = new TableCell();
            columna.ColumnSpan = 3;
            columna.BackColor = System.Drawing.Color.DarkSeaGreen;
            fila.Cells.Add(columna);
            tabla_Cesta.Rows.Add(fila);

            fila = new TableRow();
            fila.BackColor = System.Drawing.Color.LightGreen;
            columna = new TableCell();
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "Total: ";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            columna.HorizontalAlign = HorizontalAlign.Right;
            columna.ColumnSpan = 2;
            label = new Label();
            label.Text = "0";
            for (int i = 0; i < cesta.listaProductos.Count; i++)
            {
                label.Text = (double.Parse(label.Text) + double.Parse(((Label)tabla_Cesta.Rows[3+i].Cells[2].Controls[0]).Text.Split(' ')[0])).ToString();
            }
            label.Text = (double.Parse(label.Text) + double.Parse(((Label)tabla_Cesta.Rows[tabla_Cesta.Rows.Count - 2].Cells[1].Controls[0]).Text.Split(' ')[0])).ToString() + " €";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla_Cesta.Rows.Add(fila);
        }

        private void equilibrarTablas()
        {
            if (tabla_Cesta.Height.Value > tabla_Cliente.Height.Value) tabla_Cliente.Height = tabla_Cesta.Height; else tabla_Cesta.Height = tabla_Cliente.Height;
        }

        protected void button_Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/carrito.aspx");
        }
    }
}