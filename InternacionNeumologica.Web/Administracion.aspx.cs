using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace InternacionNeumologica.Web
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];//el usuario esta guardado en sesion y si no es admin enonces no se muestra el panel de administracion)por si quieren entrar con url gaurdada

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!usuario.Admin)
            {
                Response.Redirect("Default.aspx");
                return;
            }
        }
    }
}