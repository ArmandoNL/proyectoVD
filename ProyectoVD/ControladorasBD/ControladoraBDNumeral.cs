using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

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
            String consulta = "select n.id,Codigo as 'Numeral', u.Nombre as 'Unidad Académica',Descripcion,Jornada,Estado from Numerales n join UnidadAcademica u on n.IdUA = u.id where CodConcurso='" + concurso + "' order by Codigo;";
            DataTable resp = adaptador.consultar(consulta);
            return resp;
        }

        public DataTable consultarNumeral(int id)
        {
            String consulta = "select Codigo,u.Nombre,Descripcion,Jornada,Estado,CodConcurso from Numerales n join UnidadAcademica u on n.IdUA = u.id where n.id =" + id + ";";
            DataTable numeral = adaptador.consultar(consulta);
            return numeral;
        }



        public void modificarNumerales(EntidadNumerales numeral, int idConsultado)
        {
            String consulta = "update Numerales set Codigo='" + numeral.Codigo + "',Jornada= " + numeral.Jornada + ",Estado='" + numeral.Estado + "',Descripcion='" + numeral.Descripcion + "',CodConcurso='" + numeral.Concurso + "',IdUA=" + numeral.IdUA + " where id=" + idConsultado + ";";
            adaptador.insertar(consulta);
        }


        public void eliminarNumeral(int id)
        {
            String consulta = "delete from Numerales where Id =" + id + ";";
            adaptador.insertar(consulta);
        }

        public DataTable numeralesDisponibles(String concurso)//trae los Numerales que están en espera de asignarse para poner a concursar personas.
        {
            String consulta = "select n.Id,n.Codigo,u.Nombre,n.Descripcion from Numerales n join UnidadAcademica u on n.IdUA = u.Id where n.Estado='En Espera' and n.CodConcurso='" + concurso + "' order by Codigo;";
            DataTable numerales = adaptador.consultar(consulta);
            return numerales;
        }


        public void asociarNumeral(int idNumeral, String idPersona, float puntajeUA, float puntajeReal)//asocia un numeral a una persona en la Base de Datos
        {
            String consulta = "insert into Concursa(IdNumeral,IdPersona,PuntajeReal,PuntajeUA) values(" + idNumeral + ",'" + idPersona + "'," + puntajeReal + "," + puntajeUA + ");";
            adaptador.insertar(consulta);
        }

        public void adjudicarNumeral(int idNumeral, string personaConsultada, string constancia, string fecha)
        {
            String consulta = "update Numerales set FechaResultado='" + fecha + "', Constancia='" + constancia + "', IdPersona='" + personaConsultada + "' where Id=" + idNumeral + ";";
            adaptador.insertar(consulta);
        }

        public DataTable reportePersonas(String concurso, int idNumeral)
        {
            String consulta = "select p.Nombre,P.Cedula,p.GradoAcademico as 'Grado Académico',n.Codigo as 'Numeral',n.Estado,c.PuntajeReal as 'Puntaje Real',c.PuntajeUA as 'Puntaje UA',p.NotifCorreo as 'Notifcación' from (Numerales n join Concursa c on n.Id=c.IdNumeral) join Persona p on c.IdPersona=p.Cedula where n.CodConcurso='" + concurso + "' and n.IdUA=" + idNumeral + "";
            return adaptador.consultar(consulta);
        }

        internal float[] reporteUAyConcurso(int idUA, String concurso)
        {
            float[] resp = new float[3];

            String consulta = "select sum(jornada) from Numerales where CodConcurso='" + concurso + "' and IdUA=" + idUA + ";";
            DataTable tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[0] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(jornada) from Numerales where CodConcurso='" + concurso + "' and IdUA=" + idUA + " and Estado='Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[1] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(jornada) from Numerales where CodConcurso='" + concurso + "' and IdUA=" + idUA + " and Estado='No Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[2] = float.Parse(tabla.Rows[0][0].ToString());
            }

            return resp;
        }

        internal float[] reporteUAyAnno(int idUA, String anno)
        {
            float[] resp = new float[3];

            String consulta = "select sum(n.Jornada) from Numerales n join Concurso c on n.CodConcurso=c.Codigo where c.Anno='" + anno + "' and IdUA=" + idUA + ";";
            DataTable tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[0] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(n.Jornada) from Numerales n join Concurso c on n.CodConcurso=c.Codigo where c.Anno='" + anno + "' and IdUA=" + idUA + " and Estado='Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[1] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(n.Jornada) from Numerales n join Concurso c on n.CodConcurso=c.Codigo where c.Anno='" + anno + "' and IdUA=" + idUA + " and Estado='No Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[2] = float.Parse(tabla.Rows[0][0].ToString());
            }

            return resp;
        }

        internal float[] reporteAnno(String anno)
        {
            float[] resp = new float[3];

            String consulta = "select sum(n.Jornada) from Numerales n join Concurso c on n.CodConcurso=c.Codigo where c.Anno='" + anno + "';";
            DataTable tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[0] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(n.Jornada) from Numerales n join Concurso c on n.CodConcurso=c.Codigo where c.Anno='" + anno + "' and Estado='Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[1] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(n.Jornada) from Numerales n join Concurso c on n.CodConcurso=c.Codigo where c.Anno='" + anno + "' and Estado='No Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[2] = float.Parse(tabla.Rows[0][0].ToString());
            }


            return resp;
        }

        internal float[] reporteConcurso(String concurso)
        {
            float[] resp = new float[3];

            String consulta = "select sum(jornada) from Numerales where CodConcurso='" + concurso + "';";
            DataTable tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[0] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(jornada) from Numerales where CodConcurso='" + concurso + "' and Estado='Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[1] = float.Parse(tabla.Rows[0][0].ToString());
            }

            consulta = "select sum(jornada) from Numerales where CodConcurso='" + concurso + "' and Estado='No Adjudicado';";
            tabla = adaptador.consultar(consulta);
            if (tabla.Rows[0][0].ToString() != "")
            {
                resp[2] = float.Parse(tabla.Rows[0][0].ToString());
            }

            return resp;
        }
    }
}