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
        public List<Supermercado> lecturaXMLSupermercados(string path, string provincia)
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

        public Cesta fabricarCestaID(string path, string idCesta)
        {       
            Cesta cesta = null;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if (xNode.SelectSingleNode("ID").InnerText == idCesta)
                {
                    cesta = new Cesta();
                    cesta.estado = xNode.SelectSingleNode("Estado").InnerText;
                    cesta.id = xNode.SelectSingleNode("ID").InnerText;
                    cesta.cliente = xNode.SelectSingleNode("Cliente").InnerText;
                    cesta.direccion = xNode.SelectSingleNode("Direccion").InnerText;
                    cesta.telefono = xNode.SelectSingleNode("Telefono").InnerText;
                    foreach (XmlNode xxNode in xNode.SelectNodes("Producto"))
                    {
                        cesta.listaProductos.Add(xxNode.InnerText, xxNode.Attributes["Cantidad"].Value + "/" + xxNode.Attributes["Precio"].Value);
                    }
                }
            }
            return cesta;
        }
    

        public List<Cesta> lecturaXMLCestas(string path, string NIF)
        {
            List<Cesta> lista = new List<Cesta>();
            Cesta cesta;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);            

            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if(xNode.SelectSingleNode("Cliente").InnerText == NIF)
                {
                    cesta = new Cesta();
                    cesta.cliente = xNode.SelectSingleNode("Cliente").InnerText;
                    cesta.direccion = xNode.SelectSingleNode("Direccion").InnerText;
                    cesta.estado = xNode.SelectSingleNode("Estado").InnerText;
                    cesta.id = xNode.SelectSingleNode("ID").InnerText;
                    cesta.telefono = xNode.SelectSingleNode("Telefono").InnerText;
                    if (xNode.SelectNodes("Producto").Count > 0)
                    {
                        foreach (XmlNode xxNode in xNode.SelectNodes("Producto"))
                        {
                            cesta.listaProductos.Add(xxNode.InnerText, xxNode.Attributes["Precio"].Value);
                        }
                    }
                    lista.Add(cesta);                    
                }
            }            
            return lista;
        }

        public bool comprobarCliente(string path, string NIF, string contraseña)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
            {
                if (xNode.SelectSingleNode("NIF").InnerText == NIF && xNode.SelectSingleNode("Contraseña").InnerText == contraseña)
                {
                    return true;
                }
            }
            return false;
        }

        public bool comprobarDatos(string path, string nombre, string NIF, string departamento)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Empleados/Empleado"))
            {
                if (xNode.SelectSingleNode("Nombre").InnerText == nombre && xNode.SelectSingleNode("NIF").InnerText == NIF && xNode.SelectSingleNode("Departamento").InnerText == departamento)
                {
                    return true;
                }
            }
            return false;
        }

        public void lecturaXMLPuestos(string path, DropDownList list_Tipos)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            List<string> lista = new List<string>();

            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Empleados/Empleado/Departamento"))
            {
                lista.Add(xNode.InnerText);
            }

            lista = lista.Distinct().ToList();

            foreach (string dato in lista) list_Tipos.Items.Add(new ListItem(dato));
        }

        public void lecturaXMLDatos(string path, DropDownList list_TipoID, string dato)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            string ruta = dato == "Calle" ? "/Datos/TipoCalle/Calle" : "/Datos/TipoID/ID";
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes(ruta))
            {
                list_TipoID.Items.Add(new ListItem(xNode.InnerText));
            }
        }

        public void modificarTelefono(string path, string telefonoAntiguo, string telefonoNuevo, bool modificar)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
            {
                if (xNode.SelectNodes("Telefono") != null)
                {
                    foreach (XmlNode xxNode in xNode.SelectNodes("Telefono"))
                    {
                        if (xxNode.InnerText == telefonoAntiguo)
                        {
                            xxNode.InnerText = telefonoNuevo;
                            break;
                        }
                    }
                }
            }
            xDoc.Save(path);
        }

        public void modificarCliente(string path, Cliente cliente)
        {
            borrarCliente(path, cliente);           
            añadirCliente(path, cliente);
        }

        private void borrarCliente(string path, Cliente cliente)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
            {
                if (xNode.SelectSingleNode("NIF").InnerText == cliente.NIF )
                {
                    xDoc.DocumentElement.RemoveChild(xNode);
                    break;
                }
            }
            xDoc.Save(path);
        }

        public void cerrarCesta(string path, Cesta cesta)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if (xNode.SelectSingleNode("Estado").InnerText == "Abierta" && xNode.SelectSingleNode("Cliente").InnerText == cesta.cliente)
                {
                    xNode.SelectSingleNode("Direccion").InnerText = cesta.direccion;
                    xNode.SelectSingleNode("Telefono").InnerText = cesta.telefono;
                    xNode.SelectSingleNode("Estado").InnerText = "Cerrada";
                    xDoc.Save(path);
                    break;
                }
            }
        }

        public Cesta fabricarCesta(string path, string NIF)
        {
            Cesta cesta = null;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if (xNode.SelectSingleNode("Cliente").InnerText == NIF && xNode.SelectSingleNode("Estado").InnerText == "Abierta")
                {
                    cesta = new Cesta();
                    cesta.id = xNode.SelectSingleNode("ID").InnerText;
                    cesta.cliente = xNode.SelectSingleNode("Cliente").InnerText;
                    foreach(XmlNode xxNode in xNode.SelectNodes("Producto"))
                    {
                        cesta.listaProductos.Add(xxNode.InnerText, xxNode.Attributes["Cantidad"].Value + "/" + xxNode.Attributes["Precio"].Value);
                    }
                }
            }
            return cesta;
        }

        public void borrarProducto(string path, string NIF, string posicion)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if (xNode.SelectSingleNode("Cliente").InnerText == NIF && xNode.SelectSingleNode("Estado").InnerText == "Abierta")
                {
                    xNode.RemoveChild(xNode.SelectNodes("Producto")[int.Parse(posicion)]);
                    break;
                }
            }
            xDoc.Save(path);
        }

        public void añadirCesta(string path, Cesta cesta)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNode padre = xDoc.FirstChild;
            XmlNode hijo = xDoc.CreateNode(XmlNodeType.Element, "Cesta", null);

            XmlNode nuevo = xDoc.CreateNode(XmlNodeType.Element, "Estado", null);
            nuevo.InnerText = cesta.estado;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "ID", null);
            nuevo.InnerText = cesta.id;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Cliente", null);
            nuevo.InnerText = cesta.cliente;
            hijo.AppendChild(nuevo);

            foreach (string key in cesta.listaProductos.Keys)
            {
                nuevo = xDoc.CreateNode(XmlNodeType.Element, "Producto", null);                
                XmlAttribute attr = xDoc.CreateAttribute("Precio");
                attr.Value = cesta.listaProductos[key];
                nuevo.Attributes.Append(attr);
                attr = xDoc.CreateAttribute("Cantidad");
                attr.Value = "1";
                nuevo.Attributes.Append(attr);
                nuevo.InnerText = key;
                hijo.AppendChild(nuevo);                
            }

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Direccion", null);
            nuevo.InnerText = cesta.direccion;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Telefono", null);
            nuevo.InnerText = cesta.direccion;
            hijo.AppendChild(nuevo);

            padre.AppendChild(hijo);

            xDoc.Save(path);
        }

        public bool comprobarCestaAbierta(string path, string NIF)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if (xNode.SelectSingleNode("Cliente").InnerText == NIF && xNode.SelectSingleNode("Estado").InnerText == "Abierta")
                {
                    return true;
                }
            }
            return false;
        }

        public void añadirProducto(string pathCesta, string NIF, string pathProducto, string producto, string cuantos)
        {
            XmlDocument xDocCesta = new XmlDocument();
            xDocCesta.Load(pathCesta);
            XmlDocument xDocProducto = new XmlDocument();
            xDocProducto.Load(pathProducto);

            string elemento = null;
            string precio = null;
            XmlNodeList listaNodos = xDocProducto.DocumentElement.SelectNodes("/Secciones/Seccion/SubSeccion/Producto");
            XmlNode nodoProducto = listaNodos.Item(int.Parse(producto));

            elemento = nodoProducto.InnerText;
            precio = nodoProducto.Attributes["Precio"].Value;            

            bool duplicado = false;
            foreach (XmlNode xNode in xDocCesta.DocumentElement.SelectNodes("/Cestas/Cesta"))
            {
                if (xNode.SelectSingleNode("Cliente").InnerText == NIF)
                {                    
                    foreach(XmlNode xxNode in xNode.SelectNodes("Producto"))
                    {
                        if(xxNode.InnerText == elemento)
                        {
                            if ((int.Parse(xxNode.Attributes["Cantidad"].Value) + int.Parse(cuantos)) > 0)
                            {
                                xxNode.Attributes["Cantidad"].Value = (int.Parse(xxNode.Attributes["Cantidad"].Value) + int.Parse(cuantos)).ToString();
                            }
                            
                            duplicado = true;
                            break;
                        }
                    }

                    if (!duplicado)
                    {
                        XmlNode nuevo = xDocCesta.CreateNode(XmlNodeType.Element, "Producto", null);
                        nuevo.InnerText = elemento;
                        XmlAttribute attr = xDocCesta.CreateAttribute("Precio");
                        attr.Value = precio;
                        nuevo.Attributes.Append(attr);
                        attr = xDocCesta.CreateAttribute("Cantidad");
                        attr.Value = "1";
                        nuevo.Attributes.Append(attr);
                        xNode.AppendChild(nuevo);
                        break;
                    }
                }                
            }

            xDocCesta.Save(pathCesta);
        }

        public Dictionary<string, string> lecturaXMLProductos(string path, string categoria)
        {
            Dictionary<string, string> listaProductos = new Dictionary<string, string>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach(XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Secciones/Seccion/SubSeccion"))
            {
                if(xNode.Attributes["Nombre"].Value == categoria)
                {
                    foreach(XmlNode xxNode in xNode.SelectNodes("Producto"))
                    {
                        listaProductos.Add(xxNode.InnerText, xxNode.Attributes["Precio"].Value);
                    }
                }
            }
            return listaProductos;
        }

        public void crearTreeProductos(string path, TreeView tree_Productos)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            TreeNode hoja;
            XmlNode xNode, xxNode;
            for (int i = 0; i < xDoc.DocumentElement.SelectNodes("Seccion").Count; i++)
            {
                xNode = xDoc.DocumentElement.SelectNodes("Seccion")[i];
                hoja = new TreeNode(xNode.Attributes["Nombre"].Value, xNode.Attributes["Nombre"].Value);
                tree_Productos.Nodes.Add(hoja);
                for (int j = 0; j < xNode.SelectNodes("SubSeccion").Count; j++ )
                {
                    xxNode = xNode.SelectNodes("SubSeccion")[j];
                    hoja = new TreeNode(xxNode.Attributes["Nombre"].Value, xxNode.Attributes["Nombre"].Value);
                    tree_Productos.Nodes[i].ChildNodes.Add(hoja);
                }              
            }
        }

        public Direccion fabricarDireccion(string path, string idDireccion)
        {
            Direccion direccion = new Direccion(idDireccion);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Direcciones/Direccion"))
            {
                if (xNode.SelectSingleNode("ID").InnerText == idDireccion)
                {
                    direccion.tipoVia = xNode.SelectSingleNode("TipoVia").InnerText;
                    direccion.nombreVia = xNode.SelectSingleNode("NombreVia").InnerText;
                    direccion.numero = xNode.SelectSingleNode("Numero").InnerText;
                    direccion.piso = xNode.SelectSingleNode("Piso").InnerText;
                    direccion.puerta = xNode.SelectSingleNode("Puerta").InnerText;
                    direccion.urba = xNode.SelectSingleNode("Urba").InnerText;
                    direccion.escalera = xNode.SelectSingleNode("Escalera").InnerText;
                    direccion.bloque = xNode.SelectSingleNode("Bloque").InnerText;
                    direccion.observaciones = xNode.SelectSingleNode("Observaciones").InnerText;
                    direccion.localidad = xNode.SelectSingleNode("Localidad").InnerText;
                    direccion.cp = xNode.SelectSingleNode("CP").InnerText;
                    direccion.habitual = xNode.SelectSingleNode("Habitual").InnerText;                    
                    break;
                }
            }
            return direccion;
        }

        public void borrarDireccion(string pathDireccion, string id)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pathDireccion);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Direcciones/Direccion"))
            {
                if (xNode.SelectSingleNode("ID").InnerText == id)
                {
                    xDoc.DocumentElement.RemoveChild(xNode);
                    break;
                }
            }
            xDoc.Save(pathDireccion);
        }

        public void modificarDireccion(string pathDireccion, string pathCliente, Direccion dir, bool modificar)
        {
            XmlDocument xDoc = new XmlDocument();            
            if (modificar)
            {
                xDoc.Load(pathDireccion);
                foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Direcciones/Direccion"))
                {
                    if (xNode.SelectSingleNode("ID").InnerText == dir.id)
                    {
                        xNode.SelectSingleNode("TipoVia").InnerText = dir.tipoVia;
                        xNode.SelectSingleNode("NombreVia").InnerText = dir.nombreVia;
                        xNode.SelectSingleNode("Numero").InnerText = dir.numero;
                        xNode.SelectSingleNode("Piso").InnerText = dir.piso;
                        xNode.SelectSingleNode("Puerta").InnerText = dir.puerta;
                        xNode.SelectSingleNode("Urba").InnerText = dir.urba;
                        xNode.SelectSingleNode("Bloque").InnerText = dir.bloque;
                        xNode.SelectSingleNode("Escalera").InnerText = dir.escalera;
                        xNode.SelectSingleNode("Observaciones").InnerText = dir.observaciones;
                        xNode.SelectSingleNode("Localidad").InnerText = dir.localidad;
                        xNode.SelectSingleNode("CP").InnerText = dir.cp;
                        xNode.SelectSingleNode("Habitual").InnerText = dir.habitual;
                        xDoc.Save(pathDireccion);
                        break;
                    }
                }

                xDoc.Load(pathCliente);
                foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
                {                    
                    if (xNode.SelectNodes("Direccion") != null )
                    {
                        foreach(XmlNode xxNode in xNode.SelectNodes("Direccion"))
                        {
                            if(xxNode.Attributes["ID"].Value == dir.id)
                            {
                                xxNode.InnerText = dir.nombreVia + "-" + dir.localidad;
                                break;
                            }
                        }                                           
                    }                   
                }
                xDoc.Save(pathCliente);
            }
            else añadirDireccion(pathDireccion, dir);                      
        }

        public void añadirDireccion(string path, Direccion dir)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNode padre = xDoc.FirstChild;
            XmlNode hijo = xDoc.CreateNode(XmlNodeType.Element, "Direccion", null);

            XmlNode nuevo = xDoc.CreateNode(XmlNodeType.Element, "ID", null);
            nuevo.InnerText = dir.id;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "TipoVia", null);
            nuevo.InnerText = dir.tipoVia;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "NombreVia", null);
            nuevo.InnerText = dir.nombreVia;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Numero", null);
            nuevo.InnerText = dir.numero;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Piso", null);
            nuevo.InnerText = dir.piso;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Puerta", null);
            nuevo.InnerText = dir.puerta;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Urba", null);
            nuevo.InnerText = dir.urba;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Bloque", null);
            nuevo.InnerText = dir.bloque;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Escalera", null);
            nuevo.InnerText = dir.escalera;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Observaciones", null);
            nuevo.InnerText = dir.observaciones;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Localidad", null);
            nuevo.InnerText = dir.localidad;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "CP", null);
            nuevo.InnerText = dir.cp;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Habitual", null);
            nuevo.InnerText = dir.habitual;
            hijo.AppendChild(nuevo);

            padre.AppendChild(hijo);

            xDoc.Save(path);
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
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
            {
                if( xNode.SelectSingleNode("Email").InnerText == email) xNode.SelectSingleNode("Contraseña").InnerText = nuevaContraseña;
                xDoc.Save(path);
                break;
            }
        }

        public bool comprobarExistenciaNIF(string path, string NIF)
        {            
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach(XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
            {
               return xNode.SelectSingleNode("NIF").InnerText == NIF ? true : false;
            }
            return false;
        }

        public Cliente fabricarCliente(string path, string NIF)
        {
            Cliente cliente = null;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode xNode in xDoc.DocumentElement.SelectNodes("/Clientes/Cliente"))
            {
                if( xNode.SelectSingleNode("NIF").InnerText == NIF )
                {
                    cliente = new Cliente();
                    cliente.nombre = xNode.SelectSingleNode("Nombre").InnerText;
                    cliente.apellido = xNode.SelectSingleNode("Apellido").InnerText;
                    cliente.apellido2 = xNode.SelectSingleNode("Apellido2").InnerText;
                    cliente.tipoIdentificacion = xNode.SelectSingleNode("TipoID").InnerText;
                    cliente.NIF = xNode.SelectSingleNode("NIF").InnerText;
                    cliente.email = xNode.SelectSingleNode("Email").InnerText;
                    cliente.contraseña = xNode.SelectSingleNode("Contraseña").InnerText;
                    for(int i = 0; i < xNode.SelectNodes("Direccion").Count; i++) cliente.listaIdDirecciones.Add(xNode.SelectNodes("Direccion")[i].InnerText, xNode.SelectNodes("Direccion")[i].Attributes["ID"].Value);
                    for(int i = 0; i < xNode.SelectNodes("Telefono").Count; i++) cliente.listaTelefonos.Add(xNode.SelectNodes("Telefono")[i].InnerText);
                    cliente.faltaProducto = xNode.SelectSingleNode("FaltaProducto").InnerText;
                    cliente.info = xNode.SelectSingleNode("Info").InnerText;
                    cliente.dia = xNode.SelectSingleNode("Dia").InnerText;
                    cliente.mes = xNode.SelectSingleNode("Mes").InnerText;
                    cliente.año = xNode.SelectSingleNode("Año").InnerText;
                    break;
                }
            }
            return cliente;
        }

        private void añadirCliente(string path, Cliente cliente)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlNode padre = xDoc.FirstChild;
            XmlNode hijo = xDoc.CreateNode(XmlNodeType.Element, "Cliente", null);

            XmlNode nuevo = xDoc.CreateNode(XmlNodeType.Element, "Nombre", null);
            nuevo.InnerText = cliente.nombre;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Apellido", null);
            nuevo.InnerText = cliente.apellido;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Apellido2", null);
            nuevo.InnerText = cliente.apellido2;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "TipoID", null);
            nuevo.InnerText = cliente.tipoIdentificacion;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "NIF", null);
            nuevo.InnerText = cliente.NIF;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Email", null);
            nuevo.InnerText = cliente.email;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Contraseña", null);
            nuevo.InnerText = cliente.contraseña;
            hijo.AppendChild(nuevo);

            int cont = 1;
            foreach(string key in cliente.listaIdDirecciones.Keys)
            {
                nuevo = xDoc.CreateNode(XmlNodeType.Element, "Direccion", null);               
                XmlAttribute attr = xDoc.CreateAttribute("ID");
                attr.Value = cliente.listaIdDirecciones[key];
                nuevo.Attributes.Append(attr);
                nuevo.InnerText = key;
                hijo.AppendChild(nuevo);
                cont++;
            }

            for (int i = 0; i < cliente.listaTelefonos.Count; i++)
            {
                nuevo = xDoc.CreateNode(XmlNodeType.Element, "Telefono", null);                
                nuevo.InnerText = cliente.listaTelefonos[i];
                hijo.AppendChild(nuevo);
            }

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "FaltaProducto", null);
            nuevo.InnerText = cliente.faltaProducto;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Info", null);
            nuevo.InnerText = cliente.info;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Dia", null);
            nuevo.InnerText = cliente.dia;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Mes", null);
            nuevo.InnerText = cliente.mes;
            hijo.AppendChild(nuevo);

            nuevo = xDoc.CreateNode(XmlNodeType.Element, "Año", null);
            nuevo.InnerText = cliente.año;
            hijo.AppendChild(nuevo);

            hijo.AppendChild(nuevo); padre.AppendChild(hijo);

            xDoc.Save(path);
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