using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;
using MerCadona.Modelos;

namespace MerCadona.Vistas.Carrito
{
    public partial class pedidos : System.Web.UI.Page
    {
        private CXml cXml = new CXml();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            TableRow fila;
            TableCell columna;
            Label label;
            ImageButton imgButton;
            List<Cesta> lista = cXml.lecturaXMLCestas(Server.MapPath("~/ficheros/Cestas.xml"), Request.Cookies["Cliente"].Value);
            lista.ForEach(cesta =>
            {
                fila = new TableRow();
                fila.HorizontalAlign = HorizontalAlign.Center;

                columna = new TableCell();
                columna.HorizontalAlign = HorizontalAlign.Center;
                label = new Label();
                label.Text = cesta.id;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                label = new Label(); 
                Direccion direccion = cXml.fabricarDireccion(Server.MapPath("~/ficheros/Direcciones.xml"), cesta.direccion);
                string dir;
                if (direccion.id != "")
                {
                    dir = direccion.tipoVia + "\\ " + direccion.nombreVia + " , " + direccion.localidad;
                }
                else
                {
                    dir = "La cesta aun esta en abierta";
                    columna.ColumnSpan = 2;
                }

                label.Text = dir;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                label = new Label();
                label.Text = cesta.telefono;
                columna.Controls.Add(label);
                if (direccion.id != "") fila.Cells.Add(columna);

                columna = new TableCell();
                label = new Label();
                label.Text = cesta.estado;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);

                columna = new TableCell();
                imgButton = new ImageButton();
                imgButton.ImageUrl = "~/imagenes/imagenes_CompraOnline/botonCarritoGuardar.png";
                imgButton.PostBackUrl = "~/Vistas/Carrito/formalizar.aspx?Cesta=" + cesta.id;
                columna.Controls.Add(imgButton);
                fila.Cells.Add(columna);

                columna = new TableCell();
                imgButton = new ImageButton();
                imgButton.ImageUrl = "~/imagenes/imagenes_CompraOnline/botonCarritoGuardar.png";                
                columna.Controls.Add(imgButton);
                fila.Cells.Add(columna);

                columna = new TableCell();
                imgButton = new ImageButton();
                imgButton.ImageUrl = "~/imagenes/imagenes_CompraOnline/botonCarritoGuardar.png";
                columna.Controls.Add(imgButton);
                fila.Cells.Add(columna);

                tabla_Pedidos.Rows.Add(fila);
            });
        }
    }
}