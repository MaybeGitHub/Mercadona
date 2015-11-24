using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MerCadona.Modelos;

namespace MerCadona.Controladores
{   
    public class CFicheros
    {
        public static void añadirLinea(string path, string linea, bool sobrescribir)
        {
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Append));
            sw.WriteLine(linea);
            sw.Close();
        }

        public static string[] leerFichero(string path)
        {
            return File.ReadAllLines(path);
        }

        public static void cerrarReclamacion(string path, Reclamacion reclamacionActiva)
        {
            List<string> datosFichero = File.ReadAllLines(path).ToList();
            string lineaBorrar = datosFichero.Where(linea => linea == reclamacionActiva.construirLineaDatos()).SingleOrDefault();
            int pos = datosFichero.IndexOf(lineaBorrar);
            datosFichero.Remove(lineaBorrar);
            string lineaCambiada = "0" + lineaBorrar.Substring(1);
            datosFichero.Insert(pos, lineaCambiada);
            limpiarFichero(path);
            foreach (string linea in datosFichero)
            {
                añadirLinea(path, linea, true);
            }
        }

        private static void limpiarFichero(string path)
        {
            StreamWriter sw = new StreamWriter(File.Create(path));
            sw.Write(string.Empty);
            sw.Close();
        }
    }
}