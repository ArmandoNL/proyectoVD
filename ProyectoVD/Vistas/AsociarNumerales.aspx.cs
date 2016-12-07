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
        ConsultarPersonas persona = new ConsultarPersonas();
        int[] idsConsultados;
        String personaConsultada;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ConsultarPersonas.bandera != 0)
                {
                    personaConsultada = ConsultarPersonas.idPersonaConsultada;
                    persona.limpiarBandera();
                }
                else
                {
                    personaConsultada = Personas.idPersonaConsultada;
                }
            }
        }

        protected void cargarGrid(String concurso)
        {
            DataTable numeralesConsultados = controladora.numeralesDisponibles(concurso);

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
        }

        public void clickBuscarNumerales(object sender, EventArgs e)
        {
            cargarGrid(txtConcurso.Value);
        }

        public void clickConcursar(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            controladora.asociarNumeral(idsConsultados[i], personaConsultada, float.Parse(txtPuntajeReal.Value), float.Parse(txtPuntajeUA.Value));

        }

        public void clickAdjudicar(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            controladora.adjudicarNumeral(idsConsultados[i], personaConsultada, txtConstancia.Value, txtFecha.Value);
        }

        public void clickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("/Inicio");
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