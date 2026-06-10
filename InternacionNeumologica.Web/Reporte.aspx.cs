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
        public string LabelsEdades { get; set; }//puente entre C# y JS para pasar los datos al gráfico

        public string DatosEdades { get; set; }
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

            LabelsEdades = string.Join(",",
                edades.Select(x => "'" + x.Categoria + "'"));

            DatosEdades = string.Join(",",
                edades.Select(x => x.Cantidad));
        }
    }
}