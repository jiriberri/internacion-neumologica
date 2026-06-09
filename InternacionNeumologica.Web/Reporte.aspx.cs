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
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIndicadores();
                CargarGraficoEdades();
            }

        }

        private void CargarIndicadores()
        {
            ReporteNegocio negocio = new ReporteNegocio();

            lblPacientes.Text = negocio.ObtenerTotalPacientes().ToString();
            lblInternaciones.Text = negocio.ObtenerTotalInternaciones().ToString();
            lblFallecidos.Text = negocio.ObtenerTotalFallecidos().ToString();
            lblEstadiaPromedio.Text = negocio.ObtenerEstadiaPromedio().ToString("0.0");
                       
        
        }

        private void CargarGraficoEdades()
        {
            ReporteNegocio negocio = new ReporteNegocio();

            List<ItemGrafico> edades = negocio.ObtenerDistribucionEdades();

            foreach (ItemGrafico item in edades)
            {
                Response.Write(item.Categoria + " - " + item.Cantidad + "<br/>");
            }

        }
    }
}