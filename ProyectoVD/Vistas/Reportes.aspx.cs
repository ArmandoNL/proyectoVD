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
            txtEnEspera.Visible = true;
            lblOfrecido.Visible = true;
            lblAdjudicado.Visible = true;
            lblNoAdjudicado.Visible = true;
            lblEnEspera.Visible = true;

            float[] resp;

            if (rdbUAyC.Checked)
            {
               resp = controladoraBDnumeral.reporteUAyConcurso(int.Parse(unidades.Rows[cbxUA1.SelectedIndex - 1][0].ToString()), txtConcurso1.Value);
            }
            else if (rdbUAyA.Checked)
            {
                resp = controladoraBDnumeral.reporteUAyAnno(int.Parse(unidades.Rows[cbxUA1.SelectedIndex - 1][0].ToString()), txtConcurso1.Value);
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

            txtOfrecido.Value = resp[0].ToString();
            txtAdjudicado.Value = resp[1].ToString();
            txtNoAdjudicado.Value = resp[2].ToString();
            txtEnEspera.Value = (resp[0] - (resp[1] + resp[2])).ToString();
        }
        public void clickBuscar2(object sender, EventArgs e)
        {

            txtOfrecido.Visible = false;
            txtAdjudicado.Visible = false;
            txtNoAdjudicado.Visible = false;
            txtEnEspera.Visible = false;
            lblOfrecido.Visible = false;
            lblAdjudicado.Visible = false;
            lblNoAdjudicado.Visible = false;
            lblEnEspera.Visible = false;

            DataTable tabla = controladoraBDnumeral.reportePersonas(txtConcurso2.Value, int.Parse(unidades.Rows[cbxUA2.SelectedIndex - 1][0].ToString()));
            grvReporte.DataSource = tabla;
            grvReporte.DataBind();
            
        }


        public void clickChecked(object sender, EventArgs e)
        {
            txtConcurso1.Value = "";
            txtAnno.Value = "";
        }


        protected void mostrarMensaje(String tipoAlerta, String alerta, String mensaje)
        {
            alertAlerta.Attributes["class"] = "alert alert-" + tipoAlerta + " alert-dismissable fade in";
            labelTipoAlerta.Text = alerta + " ";
            labelAlerta.Text = mensaje;
            alertAlerta.Attributes.Remove("hidden");
            this.SetFocus(alertAlerta);
        }
    }
}