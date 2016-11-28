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
        ControladoraBDPersona controladoraPersona = new ControladoraBDPersona();
        EntidadPersona entidadConsultada;

        static int estado = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prepararInterfaz();
            }
        }


        protected void prepararInterfaz()
        {
            switch (estado)
            {
                case 1://consultar un numeral
                    txtCedula.Disabled = true;
                    txtNombre.Disabled = true;
                    cbxGrado.Disabled = true;
                    txaDescripcion.Disabled = true;
                    txtTelefonos.Disabled = true;
                    txtCorreo.Disabled = true;
                    txtDireccion.Disabled = true;
                    btnInsertar.Disabled = false;
                    btnModificar.Disabled = false;
                    btnEliminar.Disabled = false;
                    break;
                case 2://modificar un numeral
                    
                    btnInsertar.Disabled = true;
                    btnModificar.Disabled = true;
                    btnEliminar.Disabled = false;
                    break;
                case 3://insertar un numeral
                    btnEliminar.Disabled = true;
                    btnInsertar.Disabled = true;
                    btnModificar.Disabled = true;
                    break;
            }
        }

        public void clickGuardar(object sender, EventArgs e)
        {
            
            switch (estado)
            {
                case 2:
                    modificarPersona();
                    break;
                case 3:
                    eliminarPersona();
                    break;
                default:
                    insertarPersona();
                    break;
            }
        }
        
        public void clickCancelar(object sender, EventArgs e)
        {
            Response.Redirect("/Inicio");
        }

        public void clickGuardarAsociar(object sender, EventArgs e)
        {
            
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

        private void insertarPersona()
        {
            Object[] nuevaPersona = new Object[7];

            nuevaPersona[0] = txtCedula.Value;
            nuevaPersona[1] = txtNombre.Value;
            nuevaPersona[2] = cbxGrado.Value;
            nuevaPersona[3] = txaDescripcion.Value;
            nuevaPersona[4] = txtTelefonos.Value;
            nuevaPersona[5] = txtCorreo.Value;
            nuevaPersona[6] = txtDireccion.Value;

            EntidadPersona persona = new EntidadPersona(nuevaPersona);
            controladoraPersona.insertarPersona(persona);
        }

        private void modificarPersona()
        {
            Object[] nuevaPersona = new Object[7];

            nuevaPersona[0] = txtCedula.Value;
            nuevaPersona[1] = txtNombre.Value;
            nuevaPersona[2] = cbxGrado.Value;
            nuevaPersona[3] = txaDescripcion.Value;
            nuevaPersona[4] = txtTelefonos.Value;
            nuevaPersona[5] = txtCorreo.Value;
            nuevaPersona[6] = txtDireccion.Value;

            EntidadPersona persona = new EntidadPersona(nuevaPersona);
            controladoraPersona.modificarPersona(entidadConsultada, persona);
        }

        private void eliminarPersona()
        {
            controladoraPersona.eliminarPersona(entidadConsultada.Cedula);
        }


    }
}