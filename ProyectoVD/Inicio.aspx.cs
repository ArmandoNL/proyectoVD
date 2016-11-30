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
        public static String parametroBuscar;
        public static int buscarPor; //variable para identificar si estoy buscando un nombre =3; concurso = 1 o Cedula = 2.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                buscarPor = 3;
            }
        }

        public void clickBuscarNumeral(object sender, EventArgs e)
        {
            parametroBuscar = txtBuscarNumerales.Value;
            Response.Redirect("Vistas/ConsultarNumerales");
        }
        public void clickInsertarNumeral(object sender, EventArgs e)
        {
            estado = 3;
            Response.Redirect("Vistas/Numerales");
        }

        public void clickBuscarPersona(object sender, EventArgs e)
        {
            parametroBuscar = txtBuscarPersona.Value;
            if (rdbConcurso.Checked)
            {
                buscarPor = 1;
            }
            else if(rdbCedula.Checked)
            {
                buscarPor = 2;
            }
            Response.Redirect("Vistas/ConsultarPersonas");
        }

        public void clickInsertarPersona(object sender, EventArgs e)
        {
            estado = 3;
            Response.Redirect("Vistas/Personas");
        }

        public void cambiarEstado()
        {
            estado = 0;
        }

        public void cambiarBusquedaPersona()
        {
            buscarPor = 3;
        }
    }
}