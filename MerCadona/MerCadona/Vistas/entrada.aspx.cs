using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerCadona.Vistas
{
    public partial class entrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                foreach (string key in Request.Params)
                {
                    if (key.Contains("button_Entrar"))
                    {
                        HttpCookie miCookie = new HttpCookie("Cliente", text_NIF.Text);
                        miCookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(miCookie);
                    }
                }
            }
        }
    }
}