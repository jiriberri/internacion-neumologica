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

                NuevoPac.Tabaquismo = new Tabaquismo();
                NuevoPac.Tabaquismo.IdTabaquismo = int.Parse(ddlTabaquismo.SelectedValue);

                if (ddlTabaquismo.SelectedValue == "2" || ddlTabaquismo.SelectedValue == "3")
                {
                    NuevoPac.Paquetes = int.Parse(txtPaquetesAnio.Text);
                }
                else
                {
                    NuevoPac.Paquetes = null; // Si nunca fumo, es null
                }

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

        protected void ddlTabaquismo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSeleccionado = ddlTabaquismo.SelectedValue;

            if (valorSeleccionado == "2" || valorSeleccionado == "3")
            {
                divPaquetesAnio.Visible = true;
            }
            else
            {
                divPaquetesAnio.Visible = false;
                txtPaquetesAnio.Text = "";
            }
        }
    }
}