using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace MerCadona
{
    public partial class donde : System.Web.UI.Page
    {
        private ListItem itemSeleccionado;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                itemSeleccionado = list_Provincias.SelectedItem;
                panel_body.Controls.Clear();
                generarBusquedaEspecifica();
            }

            rellenarDropDownList();
        }

        private void generarBusquedaEspecifica()
        {
            Table tabla = new Table();
            TableRow fila = new TableRow();
            TableCell columna = new TableCell();
            Label label = new Label();
            label.Text = "Ajuste su busqueda";
            columna.Controls.Add(label);
            columna.ColumnSpan = 2;
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);

            fila = new TableRow();
            columna = new TableCell();
            label = new Label();
            label.Text = "Provincia";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);
            columna = new TableCell();
            label = new Label();
            label.Text = "Localidad";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);

            fila = new TableRow();
            columna = new TableCell();
            DropDownList lista = new DropDownList();
            lista.Items.Add(""); 
            columna.Controls.Add(label);
            fila.Cells.Add(columna);
            columna = new TableCell();
            label = new Label();
            label.Text = "Localidad";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);
        }

        private void rellenarDropDownList()
        {
            //Metodo para generar el DropDown

            string[] listaProvincias = File.ReadAllLines(Server.MapPath("/ficheros/provincias.csv"));
            foreach (string provincia in listaProvincias)
            {
                list_Provincias.Items.Add(new ListItem(provincia.Split(';')[1]));
            }
        }
    }
}