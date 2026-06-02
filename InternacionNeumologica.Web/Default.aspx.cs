using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace InternacionNeumologica.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];//el usuario esta guardado en sesion y si no es admin enonces no se muestra el panel de administracion

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            pnlAdministracion.Visible = usuario.Admin;
        }

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarPaciente.aspx");
        }

        protected void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Estadisticas.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administracion.aspx");
        }
    }
}