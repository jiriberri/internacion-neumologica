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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            Usuario usuario =
                negocio.Loguear(
                    txtUsuario.Text,
                    txtPassword.Text);

            if (usuario != null)//se guarda al usuario en sesion
            {
                Session["usuario"] = usuario;

                Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Text =
                    "Usuario o contraseña incorrectos";
            }
        }
    }
}