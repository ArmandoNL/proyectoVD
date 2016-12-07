using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class ConsultarPersonas : System.Web.UI.Page
    {
        ControladoraBDPersona controladoraBD = new ControladoraBDPersona();
        Inicio inicio = new Inicio();
        public static int estado;
        static DataTable personasConsultadas = new DataTable();
        public static String idPersonaConsultada;
        public static int bandera = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPersonas(Inicio.parametroBuscar, Inicio.buscarPor);
            }
        }

        public void cargarPersonas(String parametroBusqueda, int buscarPor)
        {
            switch (buscarPor)
            {
                case (1):
                    char[] delimitador = { '/', ' ' };
                    String[] factores = new String[2];
                    factores = parametroBusqueda.Split(delimitador);
                    personasConsultadas = controladoraBD.buscarPersonaConcurso(factores);
                    break;
                case (2):
                    personasConsultadas = controladoraBD.buscarPersonaCedula(parametroBusqueda);
                    break;
                case (3):
                    personasConsultadas = controladoraBD.buscarPersonaNombre(parametroBusqueda);
                    break;

            }

            grvPersonas.DataSource = personasConsultadas;
            grvPersonas.DataBind();
            txtBuscar.Value = parametroBusqueda;
        }

        protected void clickConsultar(object sender, EventArgs e)
        {
            estado = 1;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idPersonaConsultada = personasConsultadas.Rows[i][0].ToString();
            Response.Redirect("Personas");
        }

        protected void clickModificar(object sender, EventArgs e)
        {
            estado = 2;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idPersonaConsultada = personasConsultadas.Rows[i][0].ToString();
            Response.Redirect("Personas");
        }

        protected void clickEliminar(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idPersonaConsultada = personasConsultadas.Rows[i][0].ToString();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#modalEliminar').modal('show');</script>", false);

        }

        protected void clickEliminarBD(object sender, EventArgs e)
        {
            controladoraBD.eliminarPersona(idPersonaConsultada);
            cargarPersonas(txtBuscar.Value, Inicio.buscarPor);
        }

        protected void clickAsociarNumeral(object sender, EventArgs e)
        {
            bandera = 1;
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int i = Convert.ToInt32(row.RowIndex);
            idPersonaConsultada = personasConsultadas.Rows[i][0].ToString();
            Response.Redirect("AsociarNumerales");

        }

        public void limpiarBandera()
        {
            bandera = 0;
        }
    }
}