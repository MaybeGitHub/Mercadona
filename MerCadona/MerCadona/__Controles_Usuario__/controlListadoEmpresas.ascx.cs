using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerCadona.__Controles_Usuario__
{
    public partial class controlListadoEmpresas : System.Web.UI.UserControl
    {
        private string __direccion, __cp, __telefono, __horario;
        private bool __parking;

        public string direccion
        {
            get
            {
                return __direccion;
            }
            set
            {
                __direccion = value;
                label_Direccion.Text = __direccion;
            }
        }

        public string cp {
            get
            {
                return __cp;
            }
            set
            {
                __cp = value;
                label_CP.Text = __cp;
            }
        }

        public string telefono
        {
            get
            {
                return __telefono;
            }
            set
            {
                __telefono = value;
                label_Telefono.Text = __telefono;
            }
        }

        public string horario
        {
            get
            {
                return __horario;
            }
            set
            {
                __horario = value;
                label_Horario.Text = __horario;
            }
        }

        public bool parking
        {
            get
            {
                return __parking;
            }
            set
            {
                __parking = value;
                label_Parking.Text = __parking.ToString();
            }
        }

    }
}