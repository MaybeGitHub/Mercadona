﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MerCadona.Controladores;
using System.Threading.Tasks;
using MerCadona.Modelos;

namespace MerCadona.Vistas
{
    public partial class cambioContraseña : System.Web.UI.Page
    {
        private CXml cXml = new CXml();
        private CEmail cEmail = new CEmail();

        protected void button_Enviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {                
                Cliente usuario = cXml.fabricarCliente(Server.MapPath("~/ficheros/Usuarios.xml"), text_Numero.Text);
                if (usuario != null)
                {
                    Task task = new Task(() => cEmail.mandarEmail(usuario, "Recuperar contraseña", null, null));
                    task.Start();
                }
                Response.Write("<script>window.close();</script>");
            }
        }        

        protected void cv_Numero_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = cXml.comprobarExistenciaNIF(Server.MapPath("~/ficheros/Usuarios.xml"), text_Numero.Text);
        }

        protected void buton_Cerrar_Click(object sender, EventArgs e)
        {
             Response.Write("<script>window.close();</script>");
        }
    }
}