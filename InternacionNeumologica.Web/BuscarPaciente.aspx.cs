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
    public partial class BuscarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();

            Paciente paciente =
                negocio.BuscarPorDni(txtBusqueda.Text);

            if (paciente != null)
            {
                lblResultado.Text =
                    "Paciente encontrado: " +
                    paciente.Apellido + ", " +
                    paciente.Nombre +
                    " - DNI: " +
                    paciente.Dni;

                btnNuevaInternacion.Visible = true;
                btnNuevoPaciente.Visible = false;
            }
            else
            {
                lblResultado.Text =
                    "Paciente no encontrado";

                btnNuevaInternacion.Visible = false;
                btnNuevoPaciente.Visible = true;
            }
        }
    }
}