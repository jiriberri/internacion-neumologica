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
            if (!IsPostBack)
            {
                if (Request.QueryString["dni"] != null)
                {
                    txtDni.Text = Request.QueryString["dni"].ToString();
                    txtDni.ReadOnly = true;
                }

                if (Request.QueryString["apellido"] != null)
                {
                    txtApellido.Text = Request.QueryString["apellido"].ToString();
                    txtApellido.ReadOnly = true;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
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

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarPaciente.aspx");
        }
    }
}