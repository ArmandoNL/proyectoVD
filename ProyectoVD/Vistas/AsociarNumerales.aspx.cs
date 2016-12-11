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
        static int[] idsConsultados;
        static String personaConsultada;
        static int indiceConsultado;
        public static int estado;

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

        public void clickConcursarModal(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            indiceConsultado = Convert.ToInt32(row.RowIndex);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalAsociar').modal('show');</script>", false);
        }

        public void clickConcursar(object sender, EventArgs e)
        {
            float puntajeReal = 0;
            float puntajeUA = 0;

            if (txtPuntajeReal.Value != "")
            {
                puntajeReal = float.Parse(txtPuntajeReal.Value);
            }
            if (txtPuntajeUA.Value != "")
            {
                puntajeUA = float.Parse(txtPuntajeUA.Value);
            }

            controladora.asociarNumeral(idsConsultados[indiceConsultado], personaConsultada, puntajeUA, puntajeReal);
        }

        public void clickAdjudicarModal(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            indiceConsultado = Convert.ToInt32(row.RowIndex);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalAdjudicar').modal('show');</script>", false);
        }

        public void clickAdjudicar(object sender, EventArgs e)
        {
            controladora.adjudicarNumeral(idsConsultados[indiceConsultado], personaConsultada, txtConstancia.Value, txtFecha.Value);
        }

        public void clickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("/Inicio");
        }

        public void clickInsertarPersona(object sender, EventArgs e)
        {
            estado = 3;
            Response.Redirect("Personas");
        }

        public void limpiarEstado()
        {
            estado = 0;
        }
    }
}