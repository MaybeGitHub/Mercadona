using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerCadona.Vistas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void link_Empleado_Click(object sender, EventArgs e)
        {
            Response.Redirect(Server.MapPath("~/Vistas/Principales/loginEmpleados.aspx"));
        }
    }
}