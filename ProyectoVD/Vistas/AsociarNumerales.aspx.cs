using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class AsociarNumerales : System.Web.UI.Page
    {
        ControladoraBDNumeral controladora = new ControladoraBDNumeral();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cargarGrid(String concurso)
        {
            DataTable numeralesConsultados = controladora.numeralesDisponibles(concurso);
            numeralesConsultados.Columns.Remove("id");
            grvNumerales.DataSource = numeralesConsultados;
            grvNumerales.DataBind();
        }

        public void clickBuscarNumerales(object sender, EventArgs e)
        {
            cargarGrid(txtConcurso.Value);
        }

        public void clickConcursar(object sender, EventArgs e)
        {

        }

        public void clickAdjudicar(object sender, EventArgs e)
        {

        }

        protected void fechaDeEntradaCalendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Value = fechaDeEntradaCalendario.SelectedDate.ToString("MM/dd/yyyy");
            fechaDeEntradaCalendario.Visible = false;
        }

        protected void fechaDeEntrada_ServerClick(object sender, EventArgs e)
        {
            fechaDeEntradaCalendario.Visible = !fechaDeEntradaCalendario.Visible;
        }
    }
}