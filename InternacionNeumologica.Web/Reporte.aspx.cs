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
                FiltroReporte filtro = Session["FiltroReporte"] as FiltroReporte;
                CargarFiltros(filtro);
                CargarDetalle(filtro);
            }
        }
         private void CargarDetalle(FiltroReporte filtro)
         {
                    ReporteNegocio negocio = new ReporteNegocio();

                    gvDetalle.DataSource = negocio.ObtenerDetalle(filtro);
                    gvDetalle.DataBind();
         }
        private string ObtenerTexto(int? id,string tabla,string columnaId)//metodo generico para obtener el texto de los filtros

        {
            if (id == null)
                return "No aplicado";

            DesplegableNegocio negocio = new DesplegableNegocio();

            return negocio.ObtenerDescripcion(tabla,columnaId,id.Value);
                
        }


        private void CargarFiltros(FiltroReporte filtro)
        {
            lblPeriodo.Text =
                (filtro.FechaDesde.HasValue && filtro.FechaHasta.HasValue)
                ? filtro.FechaDesde.Value.ToString("dd/MM/yyyy")
                  + " - "
                  + filtro.FechaHasta.Value.ToString("dd/MM/yyyy")
                : "Todos";

            lblSoporte.Text = ObtenerTexto(
                filtro.SoporteRespiratorio,
                "SOPORTE_RESPIRATORIO",
                "id_soporte");

            lblInsuficiencia.Text = ObtenerTexto(
                filtro.InsuficienciaRespiratoria,
                "INSUFICIENCIA_RESPIRATORIA",
                "id_insuficiencia");

            lblDestino.Text = ObtenerTexto(
                filtro.DestinoEgreso,
                "DESTINO_EGRESO",
                "id_destino");

            if (filtro.Infeccion.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Infeccion,
                    "DIAGNOSTICO_INFECCIONES",
                    "id_infeccion");

            else if (filtro.Obstructiva.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Obstructiva,
                    "DIAGNOSTICO_OBSTRUCTIVAS",
                    "id_obstructiva");

            else if (filtro.Intersticial.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Intersticial,
                    "DIAGNOSTICO_INTERSTICIALES",
                    "id_intersticial");

            else if (filtro.Pleura.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Pleura,
                    "DIAGNOSTICO_PLEURA",
                    "id_pleura");

            else if (filtro.Vascular.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Vascular,
                    "DIAGNOSTICO_VASCULARES",
                    "id_vascular");

            else if (filtro.Oncologica.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Oncologica,
                    "DIAGNOSTICO_ONCOLOGICAS",
                    "id_oncologica");

            else if (filtro.Otro.HasValue)
                lblDiagnostico.Text = ObtenerTexto(
                    filtro.Otro,
                    "DIAGNOSTICO_OTROS",
                    "id_otro");

            else
                lblDiagnostico.Text = "Todos";
        }

        protected void gvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)// permite paginado del gridview
        {
            gvDetalle.PageIndex = e.NewPageIndex;

            FiltroReporte filtro = Session["FiltroReporte"] as FiltroReporte;

            CargarDetalle(filtro);
        }


        //reservado para graficos psoteriores
        /* private void CargarIndicadores(FiltroReporte filtro)
         {
             ReporteNegocio negocio = new ReporteNegocio();

             lblPacientes.Text = negocio.ObtenerTotalPacientes(filtro).ToString();
             lblInternaciones.Text = negocio.ObtenerTotalInternaciones(filtro).ToString();
             lblFallecidos.Text = negocio.ObtenerTotalFallecidos(filtro).ToString();
             lblEstadiaPromedio.Text = negocio.ObtenerEstadiaPromedio(filtro).ToString("0.0");


         }

         /*private void CargarGraficoEdades(FiltroReporte filtro)
         {
             ReporteNegocio negocio = new ReporteNegocio();

             List<ItemGrafico> edades = negocio.ObtenerDistribucionEdades(filtro);

             LabelsEdades = string.Join(",",
                 edades.Select(x => "'" + x.Categoria + "'"));

             DatosEdades = string.Join(",",
                 edades.Select(x => x.Cantidad));
         }

         private void CargarGraficoSoporte(FiltroReporte filtro)
         {
             ReporteNegocio negocio = new ReporteNegocio();

             List<ItemGrafico> soporte = negocio.ObtenerDistribucionSoporte(filtro);

             LabelsSoporte = string.Join(",",
                 soporte.Select(x => "'" + x.Categoria + "'"));

             DatosSoporte = string.Join(",",
                 soporte.Select(x => x.Cantidad));
         }

         private void CargarGraficoDiagnosticos(FiltroReporte filtro)
         {
             ReporteNegocio negocio = new ReporteNegocio();

             List<ItemGrafico> diagnosticos = negocio.ObtenerDiagnosticos(filtro);

             LabelsDiagnosticos = string.Join(",",
                 diagnosticos.Select(x => "'" + x.Categoria + "'"));

             DatosDiagnosticos = string.Join(",",
                 diagnosticos.Select(x => x.Cantidad));
         }

         private void CargarGraficoComorbilidades(FiltroReporte filtro)
         {
             ReporteNegocio negocio = new ReporteNegocio();

             List<ItemGrafico> comorbilidades = negocio.ObtenerComorbilidades(filtro);

             LabelsComorbilidades = string.Join(",",
                 comorbilidades.Select(x => "'" + x.Categoria + "'"));

             DatosComorbilidades = string.Join(",",
                 comorbilidades.Select(x => x.Cantidad));
         }*/


    }
}