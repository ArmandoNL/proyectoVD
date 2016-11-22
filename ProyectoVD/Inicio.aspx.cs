using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class Inicio : Page
    {
        public static int estado = 0;
        public static String concursoSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void clickBuscar(object sender, EventArgs e)
        {
            concursoSeleccionado = txtBuscar.Value;
            Response.Redirect("Vistas/ConsultarNumerales");
        }
        public void clickInsertar(object sender, EventArgs e)
        {
            estado = 3;
            Response.Redirect("Vistas/Numerales");
        }

        public void cambiarEstado()
        {
            estado = 0;
        }
    }
}