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
        ControladoraBDNumeral bdnumeral = new ControladoraBDNumeral();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCbxUA();
        }

        public void CargarCbxUA()
        {
            DataTable unidades = bdnumeral.selectUA();//se hace el llamado a la controladora de BD
            
            cbxUA.Items.Add("Seleccionar");//si incerta el valor predeterminado "Seleccionar" al Cbx

            if (unidades.Rows.Count > 0)//se agregan cada una de las unidades académecias. 
            {
                foreach (DataRow fila in unidades.Rows)
                {
                    cbxUA.Items.Add(fila[1].ToString());
                }
            }
        }

        public void InsertarNumeral()
        {

        }
    }
}