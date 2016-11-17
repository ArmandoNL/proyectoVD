﻿using System;
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
        ControladoraBDNumeral controladoraBDnumeral = new ControladoraBDNumeral();
         
        DataTable unidades;
        static int estado;
        static int idNumeralConsultado;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCbxUA();
            estado = consultarNumerales.estado;
            idNumeralConsultado = consultarNumerales.idNumeralConsultado;
            prepararInterfaz();
        }

        public void CargarCbxUA()
        {
            unidades = controladoraBDnumeral.selectUA();//se hace el llamado a la controladora de BD
            
            cbxUA.Items.Add("Seleccionar");//si incerta el valor predeterminado "Seleccionar" al Cbx

            if (unidades.Rows.Count > 0)//se agregan cada una de las unidades académecias. 
            {
                foreach (DataRow fila in unidades.Rows)
                {
                    cbxUA.Items.Add(fila[1].ToString());
                }
            }
        }

        protected void prepararInterfaz()
        {
            switch (estado)
            {
                case 1://consultar un numeral
                    consultarNumeral();
                    txtConcurso.Disabled = true;
                    cbxUA.Enabled = false;
                    txtJornada.Disabled = true;
                    txtCodNum.Disabled = true;
                    txaDescripcion.Disabled = true;
                    cbxEstado.Disabled = true;
                    break;
                case 2://modificar un numeral
                    consultarNumeral();
                    break;
            }
        }

        protected void consultarNumeral()
        {
            DataTable numeral = controladoraBDnumeral.consultarNumeral(idNumeralConsultado);

            txtConcurso.Value = numeral.Rows[0][5].ToString();
            cbxUA.SelectedValue = numeral.Rows[0][1].ToString();
            txtJornada.Value = numeral.Rows[0][3].ToString();
            txtCodNum.Value = numeral.Rows[0][0].ToString();
            cbxEstado.Value = numeral.Rows[0][4].ToString();
            txaDescripcion.Value = numeral.Rows[0][2].ToString();
        }

        public void clickAceptar(object sender, EventArgs e)
        {
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
            }
        }
        public void insertarNumeral()
        {
            Object[] nuevoNumeral = new Object[6];

            nuevoNumeral[0] = txtConcurso.Value;
            nuevoNumeral[1] = unidades.Rows[cbxUA.SelectedIndex-1][0];
            nuevoNumeral[2] = txtCodNum.Value;

            char[] delimitador = { '/' };
            String [] factores = new String[2];
            factores = txtJornada.Value.Split(delimitador);
            float jornada = float.Parse(factores[0]) / float.Parse(factores[1]);
            nuevoNumeral[3] = jornada;
            nuevoNumeral[4] = cbxEstado.Value;
            nuevoNumeral[5] = txaDescripcion.Value;

            EntidadNumerales entidadNumerales = new EntidadNumerales(nuevoNumeral);
            controladoraBDnumeral.insertarNumeral(entidadNumerales);
        }

        public void modificarNumeral()
        {
            Object[] nuevoNumeral = new Object[6];

            nuevoNumeral[0] = txtConcurso.Value;
            nuevoNumeral[1] = unidades.Rows[cbxUA.SelectedIndex - 1][0];
            nuevoNumeral[2] = txtCodNum.Value;

            char[] delimitador = { '/' };
            String[] factores = new String[2];
            factores = txtJornada.Value.Split(delimitador);
            float jornada = float.Parse(factores[0]) / float.Parse(factores[1]);
            nuevoNumeral[3] = jornada;
            nuevoNumeral[4] = cbxEstado.Value;
            nuevoNumeral[5] = txaDescripcion.Value;

            EntidadNumerales entidadNumerales = new EntidadNumerales(nuevoNumeral);
            controladoraBDnumeral.modificarNumerales(entidadNumerales, idNumeralConsultado);
        }
                public void eliminarNumeral()
        {

        }
    }
}