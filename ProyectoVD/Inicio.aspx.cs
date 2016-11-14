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
        public static String concursoSeleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void clickBuscar(object sender, EventArgs e)
        {
            concursoSeleccionado = txtBuscar.Value;
            Response.Redirect("Vistas/ConsultarNumerales");
        }
    }
}