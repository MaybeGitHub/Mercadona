using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml;
using MerCadona.Modelos;

namespace MerCadona.Controladores
{
    public class CXml
    {
        public List<Supermercado> lecturaXMLSupermercados(string provincia, string path)
        {
            List<Supermercado> ret = new List<Supermercado>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Provincias/Provincia"))
            {
                if (xNode.Attributes["Nombre"].InnerText == provincia.ToUpper())
                {
                    foreach (XmlNode xxNode in xNode.SelectNodes("Localidad"))
                    {
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
                            ret.Add(super);
                        }
                    }
                    break;
                }
            }
            return ret;
        }

        public void cerrarReclamacion(string path, Reclamacion reclamacion)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Reclamaciones/Reclamacion"))
            {
                if (xNode.SelectSingleNode("Leido").InnerText == reclamacion.leido && xNode.SelectSingleNode("Nombre").InnerText == reclamacion.nombre && xNode.SelectSingleNode("Email").InnerText == reclamacion.email )
                {
                    xNode.SelectSingleNode("Leido").InnerText = "Si";
                    xDoc.Save(path);
                    break;
                }
            }           
        }

        public List<Reclamacion> reclamacionesNoLeidas(string path)
        {
            List<Reclamacion> ret = new List<Reclamacion>();
            Reclamacion reclamacion;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach ( XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Reclamaciones/Reclamacion")){
                if (xNode.SelectSingleNode("Leido").InnerText == "No")
                {
                    reclamacion = new Reclamacion();
                    reclamacion.leido = xNode.SelectSingleNode("Leido").InnerText;
                    reclamacion.asunto = xNode.SelectSingleNode("Asunto").InnerText;
                    reclamacion.nombre = xNode.SelectSingleNode("Nombre").InnerText;
                    reclamacion.dni = xNode.SelectSingleNode("DNI").InnerText;
                    reclamacion.telefono = xNode.SelectSingleNode("Telefono").InnerText;
                    reclamacion.email = xNode.SelectSingleNode("Email").InnerText;
                    reclamacion.provincia = xNode.SelectSingleNode("Provincia").InnerText;
                    reclamacion.localidad = xNode.SelectSingleNode("Localidad").InnerText;
                    reclamacion.cp = xNode.SelectSingleNode("CP").InnerText;
                    reclamacion.tipoVia = xNode.SelectSingleNode("TipoVia").InnerText;
                    reclamacion.nombreVia = xNode.SelectSingleNode("NombreVia").InnerText;
                    reclamacion.numero = xNode.SelectSingleNode("Numero").InnerText;
                    reclamacion.mayor14 = xNode.SelectSingleNode("Mayor14").InnerText;
                    reclamacion.informacion = xNode.SelectSingleNode("Informacion").InnerText;
                    reclamacion.firma = xNode.SelectSingleNode("Firma").InnerText;
                    reclamacion.mensaje = xNode.SelectSingleNode("Mensaje").InnerText;
                    ret.Add(reclamacion);
                }             
            }
            return ret;
        }

        public void modificarContraseña(string path, string email, string nuevaContraseña)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Usuarios/Usuario"))
            {
                if( xNode.SelectSingleNode("Email").InnerText == email) xNode.SelectSingleNode("Contraseña").InnerText = nuevaContraseña;
                xDoc.Save(path);
                break;
            }
        }

        public bool comprobarExistenciaNIF(string path, string NIF)
        {
            Cliente ret = new Cliente();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach(XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Usuarios/Usuario"))
            {
               return xNode.SelectSingleNode("NIF").InnerText == NIF ? true : false;
            }
            return false;
        }

        public Cliente fabricarUsuario(string path, string NIF)
        {
            Cliente usuario = null;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Usuarios/Usuario"))
            {
                if( xNode.SelectSingleNode("NIF").InnerText == NIF )
                {
                    usuario = new Cliente();
                    usuario.nombre = xNode.SelectSingleNode("Nombre").InnerText;
                    usuario.NIF = xNode.SelectSingleNode("NIF").InnerText;
                    usuario.telefono = xNode.SelectSingleNode("Telefono").InnerText;
                    usuario.email = xNode.SelectSingleNode("Email").InnerText;
                    break;
                }
            }
            return usuario;
        }

        public void añadirReclamacion(string path, Reclamacion reclamacion)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNode padre = xDoc.FirstChild;
            XmlNode hijo = xDoc.CreateNode(XmlNodeType.Element, "Reclamacion", null);

            XmlNode nuevo = xDoc.CreateNode(XmlNodeType.Element, "Leido", null);
            nuevo.InnerText = reclamacion.leido;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Asunto", null);
            nuevo.InnerText = reclamacion.asunto;
            hijo.AppendChild(nuevo);
            
            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Nombre", null);
            nuevo.InnerText = reclamacion.nombre;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "DNI", null);
            nuevo.InnerText = reclamacion.dni;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Telefono", null);
            nuevo.InnerText = reclamacion.telefono;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Email", null);
            nuevo.InnerText = reclamacion.email;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Provincia", null);
            nuevo.InnerText = reclamacion.provincia;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Localidad", null);
            nuevo.InnerText = reclamacion.localidad;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "CP", null);
            nuevo.InnerText = reclamacion.cp;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "TipoVia", null);
            nuevo.InnerText = reclamacion.tipoVia;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "NombreVia", null);
            nuevo.InnerText = reclamacion.nombreVia;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Numero", null);
            nuevo.InnerText = reclamacion.numero;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Mayor14", null);
            nuevo.InnerText = reclamacion.mayor14;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Informacion", null);
            nuevo.InnerText = reclamacion.informacion;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Firma", null);
            nuevo.InnerText = reclamacion.firma;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Mensaje", null);
            nuevo.InnerText = reclamacion.mensaje;
            hijo.AppendChild(nuevo);

            padre.AppendChild(hijo);

            xDoc.Save(path);           
        }
    }
}