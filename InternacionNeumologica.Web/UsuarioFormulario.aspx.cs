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
                txtUsuario.Text = "";
                txtPassword.Text = "";
                chkAdmin.Checked = false;
                chkActivo.Checked = true;//si es nuevo y alo pone como activo

                if (Request.QueryString["id"] != null)
                {
                    lblTitulo.Text = "Editar Usuario";
                    btnGuardar.Text = "Actualizar";

                    int id = int.Parse(Request.QueryString["id"]);

                    UsuarioNegocio negocio = new UsuarioNegocio();

                    Usuario usuario = negocio.ObtenerPorId(id);

                    Session["PassActual"] = usuario.Pass;

                    txtUsuario.Text = usuario.User;
                    txtEmail.Text = usuario.Email;
                    txtPassword.Text = usuario.Pass;
                    txtConfirmarPassword.Text = usuario.Pass;
                    chkAdmin.Checked = usuario.Admin;
                    chkActivo.Checked = usuario.Activo;
                }
            }


        }

        protected void btnCancelar_Click(object sender,EventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                lblError.Text =
                    "Las contraseñas no coinciden.";

                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblError.Text =
                    "Debe ingresar un email.";

                return;
            }

            Usuario usuario = new Usuario();

            usuario.User = txtUsuario.Text;


            bool esEdicion = Request.QueryString["id"] != null;

            if (esEdicion && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                usuario.Pass = Session["PassActual"].ToString();
            }
            else
            {
                usuario.Pass = txtPassword.Text;
            }
            usuario.Email = txtEmail.Text;
            usuario.Admin = chkAdmin.Checked;
            usuario.Activo = chkActivo.Checked;

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