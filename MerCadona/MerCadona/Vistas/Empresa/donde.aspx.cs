using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using MerCadona.__Controles_Usuario__;
using MerCadona.Modelos;
using MerCadona.Controladores;

namespace MerCadona.Vistas
{
    public partial class donde : System.Web.UI.Page
    {
        private List<Supermercado> listaSupermercados = new List<Supermercado>();
        private CXml cXml = new CXml();
        private string provincia, localidad, horario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                foreach(string key in Request.Params)
                {
                    if (key.Contains("list_Provincias") || key.Contains("list_Provincia")) provincia = Request.Params[key];                    

                    if (key.Contains("list_Localidad")) localidad = Request.Params[key];                    

                    if (key.Contains("list_Horarios")) horario = Request.Params[key];
                }
                tabla_Inicial.Visible = false;
                tabla_Filtrado.Visible = true;
                tabla_Filtrado2.Visible = true;
                generarListProvincia();                
                listaSupermercados = cXml.lecturaXMLSupermercados(Server.MapPath("~/ficheros/Supermercados.xml"), provincia);
                generarListLocalidad();
                generarListHorario();
                
                generarDatosFiltrados(); 
                                               
            }else generarListProvincia();
        }

        private void generarListHorario()
        {
            List<string> lista = listaSupermercados.Select(supermercado => supermercado.horario).Distinct().ToList();
            lista.ForEach(horario => list_Horarios.Items.Add(new ListItem(horario, horario)));
            list_Horarios.SelectedValue = horario;
        }

        private void generarListLocalidad()
        {
            List<string> lista = listaSupermercados.Select(supermercado => supermercado.localidad).Distinct().ToList();
            lista.ForEach(localidad => list_Localidad.Items.Add(new ListItem(localidad, localidad)));
            list_Localidad.SelectedValue = localidad;
        }

        private void generarListProvincia()
        {
            List<string> lista = File.ReadAllLines(Server.MapPath("~/ficheros/provincias.csv")).ToList();
            if(!IsPostBack)
                lista.ForEach(provincia => list_Provincias.Items.Add(new ListItem(provincia.Split(';')[1], provincia.Split(';')[1])));
            else
                lista.ForEach(provincia => list_Provincia.Items.Add(new ListItem(provincia.Split(';')[1], provincia.Split(';')[1])));

            list_Provincia.SelectedValue = provincia;
        }

        private void generarDatosFiltrados()
        {
            label_Provincia.Text = provincia;
            List<string> localidadesDeInteres = new List<string>();
            if ( localidad != null && horario != null) listaSupermercados = listaSupermercados.Where(super => super.localidad == localidad && super.horario == horario).ToList();
            else if (localidad != null) listaSupermercados = listaSupermercados.Where(super => super.localidad == localidad).Select(super => super).ToList();
            else if (horario != null) listaSupermercados = listaSupermercados.Where(super => super.horario == horario).ToList();
            
            localidadesDeInteres = listaSupermercados.Select(super => super.localidad).ToList();

            TableRow fila;
            TableCell columna;
            Label label;
            Image imagen;

            localidadesDeInteres = localidadesDeInteres.Distinct().ToList();

            foreach (string localidad in localidadesDeInteres)
            {
                fila = new TableRow();
                columna = new TableCell();
                columna.ColumnSpan = 5;
                label = new Label();
                label.Text = localidad;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);
                tabla_Filtrado2.Rows.Add(fila);

                foreach ( Supermercado super in listaSupermercados)
                {
                    if ( super.localidad == localidad)
                    {
                        fila = new TableRow();
                        fila.HorizontalAlign = HorizontalAlign.Center;
                                                                                              
                        columna = new TableCell();
                        columna.BackColor = System.Drawing.Color.White;
                        label = new Label();
                        label.Text = super.direccion;
                        columna.Controls.Add(label);                        
                        fila.Cells.Add(columna);

                        columna = new TableCell();
                        columna.BackColor = System.Drawing.Color.White;
                        label = new Label();
                        label.Text = super.cp;
                        columna.Controls.Add(label);
                        fila.Cells.Add(columna);

                        columna = new TableCell();
                        columna.BackColor = System.Drawing.Color.White;
                        label = new Label();
                        label.Text = super.telefono;
                        columna.Controls.Add(label);
                        fila.Cells.Add(columna);

                        columna = new TableCell();
                        columna.BackColor = System.Drawing.Color.White;
                        label = new Label();
                        label.Text = super.horario;
                        columna.Controls.Add(label);
                        fila.Cells.Add(columna);

                        columna = new TableCell();
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.White;
                        if (super.parking)
                        {
                            imagen = new Image();
                            imagen.ImageUrl = "/imagenes/imagenes_NuestraEmpresa/parking.gif";
                            panel.Controls.Add(imagen);
                        }
                        columna.Controls.Add(panel);                 
                        fila.Cells.Add(columna);

                        tabla_Filtrado2.Rows.Add(fila);
                    }
                }
            }
        }              

        private void rellenarDropDownList(DropDownList lista, List<string> contenido)
        {
            //Metodo para generar el DropDownList

            string valor;
            foreach (string dato in contenido)
            {
                if (dato.Split(';').Count() > 1) valor = dato.Split(';')[1]; else valor = dato;
                lista.Items.Add(new ListItem(valor, valor));
            }
        }
    }
}