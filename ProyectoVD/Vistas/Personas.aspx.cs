﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVD
{
    public partial class Personas : System.Web.UI.Page
    {
        ControladoraBDNumeral controladora = new ControladoraBDNumeral();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        protected void cargarGrid(String concurso)
        {
            DataTable numeralesConsultados = controladora.numeralesDisponibles(concurso);
            numeralesConsultados.Columns.Remove("id");
            grvNumerales.DataSource = numeralesConsultados;
            grvNumerales.DataBind();
        }

        public void clickAceptar(object sender, EventArgs e)
        {
            /*
            switch (estado)
            {
                case 2:
                    modificarNumeral();
                    break;
                case 3:
                    eliminarNumeral();
                    break;
                default:
                    insertarNumeral();
                    break;
            }*/
        }

        public void clickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("/Inicio");
        }
        
        public void clickInsertar(object sender, EventArgs e)
        {
         
        }

        public void clickModificar(object sender, EventArgs e)
        {
          
        }

        public void clickEliminar(object sender, EventArgs e)
        {

        }

        public void clickConcursar(object sender, EventArgs e)
        {
            
        }

        public void clickAdjudicar(object sender, EventArgs e)
        {

        }

        public void clickBuscarNumerales(object sender, EventArgs e)
        {
            cargarGrid(txtConcurso.Value);
        }
    }
}