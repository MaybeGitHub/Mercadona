using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}