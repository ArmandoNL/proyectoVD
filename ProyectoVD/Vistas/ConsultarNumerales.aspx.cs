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
        int[] idsConsultados;
        public static int idNumeralConsultado;
        public static int estado = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarNumerales(Inicio.parametroBuscar);
        }

        public void cargarNumerales(String concurso)
        {
            numeralesConsultados = controladoraBD.buscarNumerales(concurso);

            if (numeralesConsultados.Rows.Count > 0)//guardo la columna de ids para luego eliminarla
            {
                int tamaño = numeralesConsultados.Rows.Count;
                idsConsultados = new int[tamaño];
                for (int i = 0; i < tamaño; i++)
                {
                    idsConsultados[i] = int.Parse(numeralesConsultados.Rows[i][0].ToString());
                }
            }

            numeralesConsultados.Columns.Remove("id");
            grvNumerales.DataSource = numeralesConsultados;
            grvNumerales.DataBind();
            txtBuscar.Value = concurso;
        }

        protected void clickConsultar(object sender, EventArgs e)
        {
            estado = 1;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idNumeralConsultado = idsConsultados[i];
            Response.Redirect("Numerales");
        }

        protected void clickModificar(object sender, EventArgs e)
        {
            estado = 2;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idNumeralConsultado = idsConsultados[i];
            Response.Redirect("Numerales");
        }

        protected void clickEliminar(object sender, EventArgs e)//toma el id del numeral a eliminar y despliega el modal de confirmación.
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idNumeralConsultado = idsConsultados[i];
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalEliminar').modal('show');</script>", false);

        }

        protected void clickEliminarNumeralBD(object sender, EventArgs e)//solicita a la controladora de base de datos que elimine el numeral. 
        {
            controladoraBD.eliminarNumeral(idNumeralConsultado);
            cargarNumerales(txtBuscar.Value);
        }
    }
}