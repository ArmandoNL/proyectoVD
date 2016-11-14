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

        public void insertarNumeral(EntidadNumerales datos)
        {
            String consulta = "insert into Numerales(Codigo, Jornada, Estado, Descripcion, CodConcurso, IdUA) values('" + datos.Codigo + "'," + datos.Jornada + ",'" + datos.Estado + "','" + datos.Descripcion + "','" + datos.Concurso + "'," + datos.IdUA + ");";
            adaptador.insertar(consulta);
        }

        public DataTable buscarNumerales(String concurso)
        {
            String consulta = "select n.id,Codigo as 'Numeral', u.Nombre as 'Unidad Académica',Descripcion,Jornada,Estado from Numerales n join UnidadAcademica u on n.IdUA = u.id where CodConcurso='" + concurso + "'order by Codigo;";
            DataTable resp = adaptador.consultar(consulta);
            return resp;
        }
    }
}