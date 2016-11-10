using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoVD
{
    public class EntidadNumerales
    {
        private String concurso;
        private int idUA;
        private String codigo;
        private float jornada;
        private String estado;
        private String descripcion;

        public EntidadNumerales(Object[] datos)
        {

        }

        public String Concurso
        {
            get { return concurso; }
            set { concurso = value; }
        }

        public int IdUA
        {
            get { return idUA; }
            set { idUA = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public float Jornada
        {
            get { return jornada; }
            set { jornada = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}