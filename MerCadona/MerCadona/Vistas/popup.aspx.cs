using System;
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
    public partial class popup : System.Web.UI.Page
    {
        private CXml cXml = new CXml();
        private CEmail cEmail = new CEmail();

        protected void button_Enviar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {                
                Usuario usuario = cXml.fabricarUsuario(Server.MapPath("~/ficheros/Usuarios.xml"), text_Numero.Text);
                string pathLink = Server.MapPath("~/Vistas/cambiopwd.aspx");
                if (usuario != null)
                {
                    Task task = new Task(() => cEmail.mandarEmail(usuario, pathLink));
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