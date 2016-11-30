using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoVD
{
    public class ControladoraBDPersona
    {
        AdaptadorBD adaptador = new AdaptadorBD();

        internal void insertarPersona(EntidadPersona persona)
        {
            String consulta = "insert into Persona (Cedula,Nombre,GradoAcademico,DescGrado,NotifTel, NotifCorreo,NotiFisica) values ('" + persona.Cedula + "','" + persona.Nombre + "','" + persona.GradoAcademico + "','" + persona.Comentarios + "','" + persona.Telefono + "','" + persona.Correo + "','"+ persona.Direccion + "');";
            adaptador.insertar(consulta);
        }

        internal void modificarPersona(EntidadPersona entidadConsultada, EntidadPersona persona)
        {
            String consulta = "update Persona set Cedula='" + persona.Cedula + "',Nombre='" + persona.Nombre + "',GradoAcademico='" + persona.GradoAcademico + "',DescGrado='" + persona.Comentarios + "',NotifTel='" + persona.Telefono + "', NotifCorreo='" + persona.Correo + "',NotiFisica='" + persona.Direccion + "' where Cedula='" + entidadConsultada.Cedula + "';";
            adaptador.insertar(consulta);
        }

        internal void eliminarPersona(String cedula)
        {
            String consulta = "delete from Persona where Cedula='" + cedula + "';";
            adaptador.insertar(consulta);
        }

        public DataTable buscarPersonaCedula(String cedula)
        {
            String consulta = "select Cedula,Nombre,GradoAcademico,DescGrado from Persona where Cedula='" + cedula + "';";
            DataTable personas = adaptador.consultar(consulta);
            return personas;
        }


        public DataTable buscarPersonaNombre(String nombre)
        {
            String consulta = "select Cedula,Nombre,GradoAcademico,DescGrado from Persona where nombre like '%" + nombre + "%';";
            DataTable personas = adaptador.consultar(consulta);
            return personas;
        }

        public DataTable buscarPersonaConcurso(String[] factores)
        {
            String consulta = "select Cedula,Nombre,GradoAcademico,DescGrado from (Numerales n join Concursa c on n.id=c.IdNumeral) join Persona p on c.IdPersona=p.Cedula where n.Codigo='" + factores[1] + "' and n.CodConcurso='" + factores[0] + "'";
            return adaptador.consultar(consulta);
        }
    }
}