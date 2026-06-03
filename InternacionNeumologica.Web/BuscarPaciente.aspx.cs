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
            if (!IsPostBack && Request.QueryString["exito"] != null)
            {
                pnlMensaje.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();

            if (ddlBusqueda.SelectedValue == "DNI")
            {
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
            else
            {
                foreach (char c in txtBusqueda.Text)
                {
                    if (char.IsDigit(c))
                    {
                        lblResultado.Text =
                            "El apellido no puede contener números.";

                        btnNuevaInternacion.Visible = false;
                        btnNuevoPaciente.Visible = false;

                        return;
                    }
                }

                List<Paciente> lista =
                                 negocio.BuscarPorApellido(txtBusqueda.Text);

                if (lista.Count > 0)
                {
                    Paciente paciente = lista[0];

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

                    btnNuevoPaciente.Visible = true;
                    btnNuevaInternacion.Visible = false;
                }
            }
        }
        protected void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text;

            if (ddlBusqueda.SelectedValue == "DNI" && filtro != "")
            {
                Response.Redirect("RegistrarPaciente.aspx?dni=" + filtro);
            }
            else if (ddlBusqueda.SelectedValue == "Apellido" && filtro != "")
            {
                Response.Redirect("RegistrarPaciente.aspx?apellido=" + filtro);
            }
            else
            {
                Response.Redirect("RegistrarPaciente.aspx");
            }
        }

        protected void btnNuevaInternacion_Click(object sender, EventArgs e) {

            Response.Redirect("Internacion.aspx");
        
        }





    }
}