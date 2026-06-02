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
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    lblTitulo.Text = "Editar Usuario";
                    btnGuardar.Text = "Actualizar";

                    int id = int.Parse(Request.QueryString["id"]);

                    UsuarioNegocio negocio = new UsuarioNegocio();

                    Usuario usuario = negocio.ObtenerPorId(id);

                    txtUsuario.Text = usuario.User;
                    txtPassword.Text = usuario.Pass;
                    chkAdmin.Checked = usuario.Admin;
                }
            }


        }

        protected void btnCancelar_Click(object sender,EventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.User = txtUsuario.Text;
            usuario.Pass = txtPassword.Text;
            usuario.Admin = chkAdmin.Checked;

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (Request.QueryString["id"] == null)
            {
                negocio.Agregar(usuario);
            }
            else
            {
                usuario.IdUsuario =
                    int.Parse(Request.QueryString["id"]);

                negocio.Modificar(usuario);
            }

            Response.Redirect("Administracion.aspx");
        }
    }
}