using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoVD
{
    public class EntidadPersona
    {
        String cedula;
        String nombre;
        String gradoAcademico;
        String comentarios;
        String telefono;
        String correo;
        String direccion;

        public EntidadPersona(Object[] datos)
        {
            cedula = datos[0].ToString();
            nombre = datos[1].ToString();
            gradoAcademico = datos[2].ToString();
            comentarios = datos[3].ToString();
            telefono = datos[4].ToString();
            correo = datos[5].ToString();
            direccion = datos[6].ToString();
        }

        public String Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String GradoAcademico
        {
            get { return gradoAcademico; }
            set { gradoAcademico = value; }
        }

        public String Comentarios
        {
            get { return comentarios; }
            set { comentarios = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
    }
}