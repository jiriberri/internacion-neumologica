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
        private void CargarGrillaCompleta()
        {
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.ListarPaciente();
            dgvPacientes.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["exito"] != null)
                {
                    pnlMensaje.Visible = true;
                }
                CargarGrillaCompleta();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = txtBusqueda.Text.Trim();
            PacienteNegocio negocio = new PacienteNegocio();

            if (string.IsNullOrEmpty(filtro))
            {
                CargarGrillaCompleta();
            }
            else
            {
                dgvPacientes.DataSource = negocio.BuscarPorDNIoApellido(filtro);
                dgvPacientes.DataBind();
            }
        }
        protected void btnNuevoPaciente_Click(object sender, EventArgs e)
        {
                Response.Redirect("RegistrarPaciente.aspx");
        }

        protected void btnSeleccionarPaciente_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idPaciente = int.Parse(btn.CommandArgument);
            
            Session["IdPacienteActual"] = idPaciente;

            Response.Redirect("Internacion.aspx");
        }
    }
}