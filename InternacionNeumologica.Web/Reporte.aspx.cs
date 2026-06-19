using ClosedXML.Excel;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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

       
        // Obtiene el detalle del reporte según el filtro almacenado
        // en Session.
        // Se reutiliza para Excel, CSV y PDF.
        
        private DataTable ObtenerDatosReporte()
        {
            FiltroReporte filtro =
                Session["FiltroReporte"] as FiltroReporte;

            if (filtro == null)
                return null;

            ReporteNegocio negocio = new ReporteNegocio();

            return negocio.ObtenerDetalle(filtro);
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

        
        // Exporta el resultado del reporte a un archivo Excel.
        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            DataTable tabla = ObtenerDatosReporte();

            if (tabla == null)
            {
                Response.Redirect("Estadisticas.aspx");
                return;
            }

            // Crea el libro de Excel y agrega una hoja con los datos.

            using (XLWorkbook libro = new XLWorkbook())
            {
                var hoja = libro.Worksheets.Add("Internaciones");

                hoja.Cell(1, 1).Value = "Servicio de Clínica Neumonológica";

                hoja.Cell(2, 1).Value = "Reporte de Internaciones";

                hoja.Cell(3, 1).Value = "Fecha de emisión: " +
                                        DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                // Unimos las celdas del título
                hoja.Range("A1:J1").Merge();
                hoja.Range("A2:J2").Merge();

                // Centramos el texto
                hoja.Cell(1, 1).Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                hoja.Cell(2, 1).Style.Alignment.Horizontal =
                    XLAlignmentHorizontalValues.Center;

                hoja.Cell(1, 1).Style.Font.Bold = true;
                hoja.Cell(1, 1).Style.Font.FontSize = 18;

                hoja.Cell(2, 1).Style.Font.Bold = true;
                hoja.Cell(2, 1).Style.Font.FontSize = 14;
                hoja.Cell(3, 1).Style.Font.Italic = true;

                hoja.Cell(5, 1).InsertTable(tabla);

                hoja.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    libro.SaveAs(stream);

                    Response.Clear();

                    Response.ContentType =
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    Response.AddHeader(
                        "content-disposition",
                        "attachment;filename=ReporteInternaciones.xlsx");

                    Response.BinaryWrite(stream.ToArray());

                    Response.End();
                }
            }

        }

        protected void btnExportarCsv_Click(object sender, EventArgs e)
        {
            DataTable tabla = ObtenerDatosReporte();

            if (tabla == null)
            {
                Response.Redirect("Estadisticas.aspx");
                return;
            }
            StringBuilder csv = new StringBuilder();
            // Escribe los nombres de las columnas
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                csv.Append(tabla.Columns[i].ColumnName);

                if (i < tabla.Columns.Count - 1)
                    csv.Append(";");
            }

            csv.AppendLine();
            // Escribe los registros
            foreach (DataRow fila in tabla.Rows)
            {
                for (int i = 0; i < tabla.Columns.Count; i++)
                {
                    csv.Append(fila[i].ToString());

                    if (i < tabla.Columns.Count - 1)
                        csv.Append(";");
                }

                csv.AppendLine();
            }
            Response.Clear();

            Response.ContentType = "text/csv";

            Response.AddHeader(
                "content-disposition",
                "attachment;filename=ReporteInternaciones.csv");

            Response.ContentEncoding = Encoding.UTF8;

            Response.Write(csv.ToString());

            Response.End();
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