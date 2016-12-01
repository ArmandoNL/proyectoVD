using System;
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
        Inicio inicio = new Inicio();
        static String idPersonaConsultada;

        static int estado = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCbxGrado();
                if (Inicio.estado != 0)
                {
                    estado = 3;
                    inicio.cambiarEstado();
                }
                else
                {
                    estado = ConsultarPersonas.estado;
                }

                idPersonaConsultada = ConsultarPersonas.idPersonaConsultada;
                prepararInterfaz();
            }
        }


        protected void prepararInterfaz()
        {
            switch (estado)
            {
                case 1://consultar un numeral
                    consultarPersona();
                    txtCedula.Disabled = true;
                    txtNombre.Disabled = true;
                    cbxGradoAcademico.Enabled = false;
                    txaDescripcion.Disabled = true;
                    txtTelefonos.Disabled = true;
                    txtCorreo.Disabled = true;
                    txtDireccion.Disabled = true;
                    btnInsertar.Disabled = false;
                    btnModificar.Disabled = false;
                    btnEliminar.Disabled = false;
                    break;
                case 2://modificar un numeral
                    consultarPersona();
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


        protected void cargarCbxGrado()
        {
            cbxGradoAcademico.Items.Add("Seleccionar");
            cbxGradoAcademico.Items.Add("Licenciatura");
            cbxGradoAcademico.Items.Add("Maestría académica");
            cbxGradoAcademico.Items.Add("Maestría profesional");
            cbxGradoAcademico.Items.Add("Doctorado");
        }

        protected void consultarPersona()
        {
            DataTable persona = controladoraPersona.buscarPersonaCedulaTodo(idPersonaConsultada);
            txtCedula.Value = persona.Rows[0][0].ToString();
            txtNombre.Value = persona.Rows[0][1].ToString();
            cbxGradoAcademico.SelectedValue = persona.Rows[0][2].ToString();
            txaDescripcion.Value = persona.Rows[0][3].ToString();
            txtTelefonos.Value = persona.Rows[0][4].ToString();
            txtCorreo.Value = persona.Rows[0][5].ToString();
            txtDireccion.Value = persona.Rows[0][6].ToString();
        }

        public void clickGuardar(object sender, EventArgs e)
        {

            switch (estado)
            {
                case 2:
                    modificarPersona();
                    break;
                case 3:
                    insertarPersona();
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
            switch (estado)
            {
                case 2:
                    modificarPersona();
                    break;
                case 3:
                    insertarPersona();
                    break;
                default:
                    insertarPersona();
                    break;
            }
            Response.Redirect("Vistas/AsociarNumerales");
        }

        public void clickInsertar(object sender, EventArgs e)
        {
            estado = 3;
            prepararInterfaz();
        }

        public void clickModificar(object sender, EventArgs e)
        {
            estado = 2;
            prepararInterfaz();
        }

        public void clickEliminar(object sender, EventArgs e)
        {
            eliminarPersona();
        }

        private void insertarPersona()
        {
            Object[] nuevaPersona = new Object[7];

            nuevaPersona[0] = txtCedula.Value;
            nuevaPersona[1] = txtNombre.Value;
            nuevaPersona[2] = cbxGradoAcademico.Text;
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
            nuevaPersona[2] = cbxGradoAcademico.Text;
            nuevaPersona[3] = txaDescripcion.Value;
            nuevaPersona[4] = txtTelefonos.Value;
            nuevaPersona[5] = txtCorreo.Value;
            nuevaPersona[6] = txtDireccion.Value;

            EntidadPersona persona = new EntidadPersona(nuevaPersona);
            controladoraPersona.modificarPersona(idPersonaConsultada, persona);
        }

        private void eliminarPersona()
        {
            controladoraPersona.eliminarPersona(idPersonaConsultada);
        }


    }
}