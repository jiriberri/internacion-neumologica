using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;



// Esta página solo recopila los criterios de búsqueda.
// La generación del reporte se realiza en Reporte.aspx.
namespace InternacionNeumologica.Web
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarCombos();
                CargarResumen();
            }
        }
        private void CargarCombos()
        { // TODO: 
            // Cargar Diagnósticos 
            // Cargar Comorbilidades 
            // Cargar Tipo de Insuficiencia Respiratoria 
            // Cargar Soporte Respiratorio 
            // Cargar Destino de Egreso }
        }

        private void CargarResumen()
        { // TODO: 
            // Mostrar: 
            // - Total de pacientes 
            // - Total de internaciones 
            // - Total de fallecidos 
            // Ejemplo: 
            // lblPacientes.Text = negocio.ContarPacientes().ToString(); 
            // lblInternaciones.Text = negocio.ContarInternaciones().ToString(); 
            // lblFallecidos.Text = negocio.ContarFallecidos().ToString();
            //
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reporte.aspx");
        }
    }
}