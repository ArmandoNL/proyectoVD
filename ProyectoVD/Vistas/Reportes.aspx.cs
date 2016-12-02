using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class Reportes : System.Web.UI.Page
    {
        ControladoraBDNumeral controladoraBDnumeral = new ControladoraBDNumeral();
        Inicio inicio = new Inicio();

        static DataTable unidades;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCbxUA();
            }
        }

        public void CargarCbxUA()
        {
            unidades = controladoraBDnumeral.selectUA();//se hace el llamado a la controladora de BD

            cbxUA1.Items.Add("Seleccionar");//si incerta el valor predeterminado "Seleccionar" al Cbx
            cbxUA2.Items.Add("Seleccionar");

            if (unidades.Rows.Count > 0)//se agregan cada una de las unidades académecias. 
            {
                foreach (DataRow fila in unidades.Rows)
                {
                    cbxUA1.Items.Add(fila[1].ToString());
                    cbxUA2.Items.Add(fila[1].ToString());
                }
            }
        }

        public void clickBuscar1(object sender, EventArgs e)
        {
            txtOfrecido.Visible = true;
            txtAdjudicado.Visible = true;
            txtNoAdjudicado.Visible = true;

            int[] resp;

            if (rdbUAyC.Checked)
            {
               resp = controladoraBDnumeral.reporteUAyConcurso(int.Parse(unidades.Rows[cbxUA2.SelectedIndex - 1][0].ToString()), txtConcurso1.Value);
            }
            else if (rdbUAyA.Checked)
            {
                resp = controladoraBDnumeral.reporteUAyAnno(int.Parse(unidades.Rows[cbxUA2.SelectedIndex - 1][0].ToString()), txtConcurso1.Value);
            }
            else
            {
                if (txtConcurso1.Value != "")
                {
                    resp = controladoraBDnumeral.reporteConcurso(txtConcurso1.Value);
                }
                else
                {
                    resp = controladoraBDnumeral.reporteAnno(txtAnno.Value);
                }
            }
        }
        public void clickBuscar2(object sender, EventArgs e)
        {
            DataTable tabla = controladoraBDnumeral.reportePersonas(txtConcurso2.Value, int.Parse(unidades.Rows[cbxUA2.SelectedIndex - 1][0].ToString()));
            grvReporte.DataSource = tabla;
            grvReporte.DataBind();
        }

    }
}