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