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
        protected void Page_Load(object sender, EventArgs e)
        {
            //Metodo para generar el DropDown

            string[] listaProvincias = File.ReadAllLines(Server.MapPath("/ficheros/provincias.csv"));
            foreach(string provincia in listaProvincias)
            {
                list_Provincias.Items.Add(new ListItem(provincia.Split(';')[1]));
            }

            if (IsPostBack)
            {
                generarBusquedaEspecifica();
            }
        }

        private void generarBusquedaEspecifica()
        {
            Table tableFiltro = new Table();
            TableRow fila = new TableRow();
            TableCell columna = new TableCell();
            columna.Controls.Add(null);
            fila.Cells.Add(columna);
            tableFiltro.Rows.Add(fila);
        }
    }
}