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
               /* if (!IsPostBack)
                {
                    txtUsuario.Text = "";
                    txtPassword.Text = "";

                    return;
                }*/

                txtUsuario.Text = "";
                txtPassword.Text = "";
                chkAdmin.Checked = false;
                chkActivo.Checked = true;//si es nuevo y alo pone com0a ctivo

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

            /*throw new Exception("PRUEBA");*/
            Usuario usuario = new Usuario();

            usuario.User = txtUsuario.Text;
            usuario.Pass = txtPassword.Text;
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

                /*Response.Write("ENTRO EN MODIFICAR");
                return;*/
            }

            Response.Redirect("Administracion.aspx");
        }
    }
}