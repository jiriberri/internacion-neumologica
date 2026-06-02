using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternacionNeumologica.Web
{
    public partial class UsuarioFormulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender,EventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario nuevo = new Usuario();

            nuevo.User = txtUsuario.Text;
            nuevo.Pass = txtPassword.Text;
            nuevo.Admin = chkAdmin.Checked;

            UsuarioNegocio negocio = new UsuarioNegocio();

            negocio.Agregar(nuevo);

            Response.Redirect("Administracion.aspx");

        }
    }
}