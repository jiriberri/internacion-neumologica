using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace InternacionNeumologica.Web
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            
            try
            {
                Paciente NuevoPac = new Paciente();
                NuevoPac.Dni = txtDni.Text;
                NuevoPac.Nombre = txtNombre.Text;
                NuevoPac.Apellido = txtApellido.Text;
                NuevoPac.Domicilio = txtDomicilio.Text;
                NuevoPac.Telefono = txtTel.Text;
                NuevoPac.FechaNacimiento = DateTime.Parse(txtDate.Text);

                PacienteNegocio negocio = new PacienteNegocio();
                negocio.agregar(NuevoPac);

                Response.Redirect("BuscarPaciente.aspx?exito=1");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error inesperado al guardar: " + ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarPaciente.aspx");
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            lblError.Text = "";

            //Reseteo las clases de cada textbox
            txtDni.CssClass = "form-control";
            txtNombre.CssClass = "form-control";
            txtApellido.CssClass = "form-control";
            txtDate.CssClass = "form-control";

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                txtDni.CssClass = "form-control border border-danger";
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.CssClass = "form-control border border-danger";
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.CssClass = "form-control border border-danger";
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {
                txtDate.CssClass = "form-control border border-danger";
                valido = false;
            }


            PacienteNegocio negocio = new PacienteNegocio();
            string dniIngresado = txtDni.Text.Trim();
            Paciente pacienteExistente = negocio.BuscarPorDni(dniIngresado);

            if (pacienteExistente != null)
            {
                txtDni.CssClass = "form-control border border-danger";
                lblError.Text = "El paciente con DNI " + dniIngresado + " ya se encuentra registrado";
                return false;
            }

            return valido;
        }
    }
}