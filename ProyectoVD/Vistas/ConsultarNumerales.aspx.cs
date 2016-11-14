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
            numeralesConsultados = controladoraBD.buscarNumerales(txtBuscar.Value);
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            int id = int.Parse(numeralesConsultados.Rows[i][0].ToString());
            //Response.Redirect("FormServicios");
        }
    }
}