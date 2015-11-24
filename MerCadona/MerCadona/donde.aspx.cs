﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using MerCadona.__Controles_Usuario__;

namespace MerCadona
{
    public partial class donde : System.Web.UI.Page
    {

        private List<Supermercado> listaSupermercados = new List<Supermercado>();
        string localidad = "";
        string horario = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            info.Text = "";            

            foreach (string key in Request.Params)
            {
                info.Text += "KEY: " + key + "---------------------- VALOR : " + Request.Params[key] + "\n";
            }

            if (IsPostBack)
            {
                if (Request.Params["ctl00$list_Localidad"] != null) localidad = Request.Params["ctl00$list_Localidad"];
                if (Request.Params["ctl00$list_Comercial"] != null) horario = Request.Params["ctl00$list_Comercial"];
                generarBusquedaEspecifica(Request.Params["ctl00$list_Provincias"]);
                generarDatosFiltrado("ctl00$list_Provincias", localidad, horario);
            }
            else
            {
                generarBusquedaPrincipal();                
            }            
        }        

        private void generarBusquedaPrincipal()
        {
            Panel panel = new Panel();
            panel.HorizontalAlign = HorizontalAlign.Center;
            panel.Width = new Unit("100%");

            Table tabla = new Table();
            tabla.Width = new Unit("70%");
            tabla.HorizontalAlign = HorizontalAlign.Center;
            tabla.BorderColor = System.Drawing.Color.DarkGreen;
            tabla.BorderWidth = 1;

            TableRow fila = new TableRow();
            TableCell columna = new TableCell();
            Label label = new Label();
            label.Text = "Situacion Geografica";
            label.BackColor = System.Drawing.Color.DarkGreen;
            label.ForeColor = System.Drawing.Color.White;
            columna.Controls.Add(label);
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);

            fila = new TableRow();
            columna = new TableCell();
            label = new Label();
            label.Text = "Haga clic sobre el nombre de la provincia de la cual desea obtener información acerca de sus supermercados.";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);

            fila = new TableRow();
            columna = new TableCell();
            label = new Label();
            label.Text = "Elija Provincia";
            columna.Controls.Add(label);

            DropDownList lista = new DropDownList();
            lista.ID = "list_Provincias";
            lista.Width = new Unit("50%");
            columna.Controls.Add(lista);

            Button boton = new Button();
            boton.ID = "button_Aceptar";
            boton.Text = "Aceptar";
            columna.Controls.Add(boton);

            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);
            panel.Controls.Add(tabla);
            Master.FindControl("panel_Content").Controls.Add(panel);
            rellenarDropDownList(lista, File.ReadAllLines(Server.MapPath("/ficheros/provincias.csv")).ToList());
        }

        private void generarBusquedaEspecifica(string provincia)
        {
            Panel panel = new Panel();
            panel.HorizontalAlign = HorizontalAlign.Center;
            panel.Width = new Unit("100%");

            Label label = new Label();
            label.Text = "Ajuste su busqueda";
            panel.Controls.Add(label);

            Table tabla = new Table();
            tabla.Width = new Unit("70%");
            tabla.HorizontalAlign = HorizontalAlign.Center;
            tabla.BorderColor = System.Drawing.Color.DarkGreen;
            tabla.BorderWidth = 1;

            TableRow fila = new TableRow();
            TableCell columna = new TableCell();
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
            lista.ID = "list_Provincias";
            lista.Width = new Unit("30%");            
            columna.Controls.Add(lista);
            fila.Cells.Add(columna);
            rellenarDropDownList(lista, File.ReadAllLines(Server.MapPath("/ficheros/provincias.csv")).ToList());
            lista.SelectedValue = provincia;

            columna = new TableCell();
            lista = new DropDownList();
            lista.ID = "list_Localidad";
            lista.Items.Add(new ListItem(""));
            lista.Width = new Unit("30%");
            columna.Controls.Add(lista);
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);
            rellenarDropDownList(lista, lecturaXML(provincia));

            fila = new TableRow();
            columna = new TableCell();
            label = new Label();
            label.Text = "Horario Comercial";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);            

            fila = new TableRow();
            columna = new TableCell();
            lista = new DropDownList();
            lista.ID = "list_Comercial";
            lista.Items.Add(new ListItem(""));
            lista.Width = new Unit("30%");
            columna.Controls.Add(lista);
            fila.Cells.Add(columna);
            List<string> horarios = listaSupermercados.Where(super => super.localidad == localidad).Select(super => super.horario).Distinct().ToList();
            horarios.ForEach(horario => lista.Items.Add(horario));        
            tabla.Rows.Add(fila);
            
            columna = new TableCell();
            Button boton = new Button();
            boton.ID = "button_Filtro";
            boton.Text = "Buscar";
            columna.Controls.Add(boton);
            fila.Cells.Add(columna);
            tabla.Rows.Add(fila);

            panel.Controls.Add(tabla);
            Master.FindControl("panel_Content").Controls.Add(panel);
        }

        private void generarDatosFiltrado(string provincia, string localidad, string horario)
        {
            Panel panel = new Panel();
            panel.HorizontalAlign = HorizontalAlign.Center;
            panel.Width = new Unit("100%");

            Label label = new Label();
            label.Text = provincia;
            panel.Controls.Add(label);

            Table tabla = new Table();
            tabla.Width = new Unit("70%");
            tabla.HorizontalAlign = HorizontalAlign.Center;
            tabla.BorderColor = System.Drawing.Color.DarkGreen;
            tabla.BorderWidth = 1;

            TableRow fila = new TableRow();
            TableCell columna = new TableCell();
            label = new Label();
            label.Text = "DIRECCION";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            label = new Label();
            label.Text = "CODIGO POSTAL";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            label = new Label();
            label.Text = "TELEFONO";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            label = new Label();
            label.Text = "HORARIO COMERCIAL";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            columna = new TableCell();
            label = new Label();
            label.Text = "PARKING";
            columna.Controls.Add(label);
            fila.Cells.Add(columna);

            tabla.Rows.Add(fila);

            List<string> localidadesDeInteres = new List<string>();
            if ( localidad != "" && horario != "" ) listaSupermercados = listaSupermercados.Where(super => super.localidad == localidad && super.horario == horario).Select(super => super).Distinct().ToList();
            else if ( localidad != "" ) listaSupermercados = listaSupermercados.Where(super => super.localidad == localidad).Select(super => super).Distinct().ToList();
            else if ( horario != "") listaSupermercados = listaSupermercados.Where(super => super.horario == horario).Select(super => super).Distinct().ToList();
            else listaSupermercados = listaSupermercados.Select(super => super).Distinct().ToList();
            
            localidadesDeInteres = listaSupermercados.Select(super => super.localidad).Distinct().ToList();

            foreach (string localidadDistinta in localidadesDeInteres)
            {
                fila = new TableRow();
                columna = new TableCell();
                columna.ColumnSpan = 5;
                columna.BackColor = System.Drawing.Color.Aqua;
                label = new Label();
                label.Text = localidadDistinta;
                columna.Controls.Add(label);
                fila.Cells.Add(columna);
                tabla.Rows.Add(fila);

                foreach ( Supermercado super in listaSupermercados)
                {
                    if ( super.localidad == localidadDistinta)
                    {
                        fila = new TableRow();                                                                       
                        columna = new TableCell();
                        columna.ColumnSpan = 5;                       
                        controlListadoEmpresas miControl = LoadControl("~/__Controles_Usuario__/controlListadoEmpresas.ascx") as controlListadoEmpresas;
                        miControl.direccion = super.direccion;
                        miControl.cp = super.cp;
                        miControl.telefono = super.telefono;
                        miControl.horario = super.horario;
                        miControl.parking = super.parking;                        
                        columna.Controls.Add(miControl);                        
                        fila.Cells.Add(columna);
                        tabla.Rows.Add(fila);
                    }
                }
            }

            panel.Controls.Add(tabla);
            Master.FindControl("panel_Content").Controls.Add(panel);
        }

        private List<string> lecturaXML(string provincia)
        {
            List<string> ret = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Server.MapPath("~/ficheros/Supermercados.xml"));            
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Provincias/Provincia"))
            {                
                if ( xNode.Attributes["Nombre"].InnerText == provincia.ToUpper() )
                {            
                    foreach (XmlNode xxNode in xNode.SelectNodes("Localidad"))
                    {                        
                        ret.Add(xxNode.Attributes["Nombre"].InnerText);

                        Supermercado super;
                        foreach (XmlNode supermercado in xxNode.ChildNodes)
                        {
                            super = new Supermercado();
                            super.localidad = xxNode.Attributes["Nombre"].InnerText;
                            super.direccion = supermercado.SelectSingleNode("Direccion").InnerText;
                            super.cp = supermercado.SelectSingleNode("CP").InnerText;
                            super.telefono = supermercado.SelectSingleNode("Telefono").InnerText;
                            super.horario = supermercado.SelectSingleNode("Horario").InnerText;
                            if (supermercado.SelectSingleNode("Parking") == null || supermercado.SelectSingleNode("Parking").InnerText.ToLower() == "si") super.parking = true;
                            listaSupermercados.Add(super);
                        }

                    }
                    break;
                }
            }            
            return ret.Distinct().ToList();
        }

        private void rellenarDropDownList(DropDownList lista, List<string> contenido)
        {
            //Metodo para generar el DropDown

            string valor;
            foreach (string dato in contenido)
            {
                if (dato.Split(';').Count() > 1) valor = dato.Split(';')[1]; else valor = dato;
                lista.Items.Add(new ListItem(valor, valor));
            }
        }
    }
}