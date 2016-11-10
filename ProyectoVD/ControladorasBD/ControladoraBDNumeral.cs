using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoVD
{
    public class ControladoraBDNumeral
    {
        AdaptadorBD adaptador = new AdaptadorBD();
        public DataTable selectUA()
        {
            String consulta = "select id, Nombre from UnidadAcademica order by Nombre";
            DataTable resp = adaptador.consultar(consulta);
            return resp;
        }
    }
}