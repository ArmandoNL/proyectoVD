using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class consultarNumerales : System.Web.UI.Page
    {
        ControladoraBDNumeral controladoraBD = new ControladoraBDNumeral();
        static DataTable numeralesConsultados;
        public static int idNumeralConsultado;
        public static int estado = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarNumerales(Inicio.concursoSeleccionado);
        }

        public void cargarNumerales(String concurso)
        {
            numeralesConsultados = controladoraBD.buscarNumerales(concurso);
            numeralesConsultados.Columns.Remove("id");
            grvNumerales.DataSource = numeralesConsultados;
            grvNumerales.DataBind();
            txtBuscar.Value = concurso;
        }

        protected void clickConsultar(object sender, EventArgs e)
        {
            estado = 1;
            numeralesConsultados = controladoraBD.buscarNumerales(txtBuscar.Value);
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idNumeralConsultado = int.Parse(numeralesConsultados.Rows[i][0].ToString());
            Response.Redirect("Numerales");
        }

        protected void clickModificar(object sender, EventArgs e)
        {
            estado = 2;
            numeralesConsultados = controladoraBD.buscarNumerales(txtBuscar.Value);
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idNumeralConsultado = int.Parse(numeralesConsultados.Rows[i][0].ToString());
            Response.Redirect("Numerales");
        }

        protected void clickEliminar(object sender, EventArgs e)
        {
            numeralesConsultados = controladoraBD.buscarNumerales(txtBuscar.Value);
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idNumeralConsultado = int.Parse(numeralesConsultados.Rows[i][0].ToString());
            controladoraBD.eliminarNumeral(idNumeralConsultado);
        }
    }
}