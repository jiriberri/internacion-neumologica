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

        // ==========================================================
        // Arma el texto de las comorbilidades seleccionadas.
        // Solo muestra las categorías que tienen filtros aplicados.
        // ==========================================================
        private string ArmarTextoComorbilidades(FiltroReporte filtro)
        {
            ReporteNegocio negocio = new ReporteNegocio();

            List<string> resultado = new List<string>();

            if (filtro.Cardiovasculares != null && filtro.Cardiovasculares.Count > 0)
            {
                resultado.Add(
                    "<b>Cardiovasculares:</b> " +
                    negocio.ObtenerDescripcionesPorIds(
                        filtro.Cardiovasculares,
                        "COMORBILIDAD_CARDIOVASCULAR",
                        "id_cardiovascular"));
            }

            if (filtro.Metabolicas != null && filtro.Metabolicas.Count > 0)
            {
                resultado.Add(
                    "<b>Metabólicas:</b> " +
                    negocio.ObtenerDescripcionesPorIds(
                        filtro.Metabolicas,
                        "COMORBILIDAD_METABOLICA",
                        "id_metabolica"));
            }

            if (filtro.Neurologicas != null && filtro.Neurologicas.Count > 0)
            {
                resultado.Add(
                    "<b>Neurológicas:</b> " +
                    negocio.ObtenerDescripcionesPorIds(
                        filtro.Neurologicas,
                        "COMORBILIDAD_NEUROLOGICA",
                        "id_neurologico"));
            }

            if (filtro.Inmunologicas != null && filtro.Inmunologicas.Count > 0)
            {
                resultado.Add(
                    "<b>Inmunológicas:</b> " +
                    negocio.ObtenerDescripcionesPorIds(
                        filtro.Inmunologicas,
                        "COMORBILIDAD_INMUNOLOGICA",
                        "id_inmunologica"));
            }

            if (filtro.Oncologicas != null && filtro.Oncologicas.Count > 0)
            {
                resultado.Add(
                    "<b>Oncológicas:</b> " +
                    negocio.ObtenerDescripcionesPorIds(
                        filtro.Oncologicas,
                        "COMORBILIDAD_ONCOLOGICA",
                        "id_oncologica"));
            }

            if (filtro.Sueño != null && filtro.Sueño.Count > 0)
            {
                resultado.Add(
                    "<b>Patología del sueño:</b> " +
                    negocio.ObtenerDescripcionesPorIds(
                        filtro.Sueño,
                        "COMORBILIDAD_SUEÑO",
                        "id_sueño"));
            }

            if (resultado.Count == 0)
                return "Sin filtro";

            return string.Join("<br/><br/>", resultado);
        }




        private void CargarFiltros(FiltroReporte filtro)
        {

            ReporteNegocio negocio = new ReporteNegocio();
            lblPeriodo.Text =
                (filtro.FechaDesde.HasValue && filtro.FechaHasta.HasValue)
                ? filtro.FechaDesde.Value.ToString("dd/MM/yyyy")
                  + " - "
                  + filtro.FechaHasta.Value.ToString("dd/MM/yyyy")
                : "Todos";

            lblSoporte.Text = negocio.ObtenerTexto(
                filtro.SoporteRespiratorio,
                "SOPORTE_RESPIRATORIO",
                "id_soporte");

            lblInsuficiencia.Text = negocio.ObtenerTexto(
                filtro.InsuficienciaRespiratoria,
                "INSUFICIENCIA_RESPIRATORIA",
                "id_insuficiencia");

            lblDestino.Text = negocio.ObtenerTexto(
                filtro.DestinoEgreso,
                "DESTINO_EGRESO",
                "id_destino");

            if (filtro.Infeccion.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Infeccion,
                    "DIAGNOSTICO_INFECCIONES",
                    "id_infeccion");

            else if (filtro.Obstructiva.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Obstructiva,
                    "DIAGNOSTICO_OBSTRUCTIVAS",
                    "id_obstructiva");

            else if (filtro.Intersticial.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Intersticial,
                    "DIAGNOSTICO_INTERSTICIALES",
                    "id_intersticial");

            else if (filtro.Pleura.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Pleura,
                    "DIAGNOSTICO_PLEURA",
                    "id_pleura");

            else if (filtro.Vascular.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Vascular,
                    "DIAGNOSTICO_VASCULARES",
                    "id_vascular");

            else if (filtro.Oncologica.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Oncologica,
                    "DIAGNOSTICO_ONCOLOGICAS",
                    "id_oncologica");

            else if (filtro.Otro.HasValue)
                lblDiagnostico.Text = negocio.ObtenerTexto(
                    filtro.Otro,
                    "DIAGNOSTICO_OTROS",
                    "id_otro");

            else
                lblDiagnostico.Text = "Todos";
            //comorbilidades

            //Response.Write(string.Join(",", filtro.Cardiovasculares));
            //Response.End();//sirve para verificar si pasan los ids correctamente

            

            lblComorbilidades.Text = negocio.ArmarTextoComorbilidades(filtro);


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