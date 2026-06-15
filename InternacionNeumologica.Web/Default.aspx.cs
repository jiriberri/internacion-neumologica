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

            if (!IsPostBack)//para fque la consulta se ejecute una sola vez y no cada vez que se hace click en un boton
            {
                ReporteNegocio negocio = new ReporteNegocio();
                FiltroReporte filtro = new FiltroReporte();

                lblPacientes.Text = negocio.ObtenerTotalPacientes(filtro).ToString();
                lblInternaciones.Text = negocio.ObtenerTotalInternaciones(filtro).ToString();
                lblFallecidos.Text = negocio.ObtenerTotalFallecidos(filtro).ToString();
                lblEstadia.Text = negocio.ObtenerEstadiaPromedio(filtro).ToString("0.0");
            }
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