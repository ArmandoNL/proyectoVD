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
            Cargar();
        }

        public void Cargar()
        {
            DataTable unidades = bdnumeral.selectUA();
        
        }
    }
}