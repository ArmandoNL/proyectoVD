using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class Numerales : System.Web.UI.Page
    {
        ControladoraBDNumeral controladoraBDnumeral = new ControladoraBDNumeral();
         
        DataTable unidades;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCbxUA();
        }

        public void CargarCbxUA()
        {
            unidades = controladoraBDnumeral.selectUA();//se hace el llamado a la controladora de BD
            
            cbxUA.Items.Add("Seleccionar");//si incerta el valor predeterminado "Seleccionar" al Cbx

            if (unidades.Rows.Count > 0)//se agregan cada una de las unidades académecias. 
            {
                foreach (DataRow fila in unidades.Rows)
                {
                    cbxUA.Items.Add(fila[1].ToString());
                }
            }
        }

        public void insertarNumeral(object sender, EventArgs e)
        {
            Object[] nuevoNumeral = new Object[6];

            nuevoNumeral[0] = txtConcurso.Value;
            nuevoNumeral[1] = unidades.Rows[cbxUA.SelectedIndex-1][0];
            nuevoNumeral[2] = txtCodNum.Value;

            char[] delimitador = { '/' };
            String [] factores = new String[2];
            factores = txtJornada.Value.Split(delimitador);
            float jornada = float.Parse(factores[0]) / float.Parse(factores[1]);
            nuevoNumeral[3] = jornada;
            nuevoNumeral[4] = cbxEstado.Value;
            nuevoNumeral[5] = txaDescripcion.Value;

            EntidadNumerales entidadNumerales = new EntidadNumerales(nuevoNumeral);
            controladoraBDnumeral.insertarNumeral(entidadNumerales);
        }
    }
}