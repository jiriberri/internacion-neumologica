using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Data;


namespace InternacionNeumologica.Web
{
    public partial class ReporteImpresion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                FiltroReporte filtro =
                    Session["FiltroReporte"] as FiltroReporte;

                if (filtro == null)
                {
                    Response.Redirect("Estadisticas.aspx");
                    return;
                }

                ReporteNegocio negocio = new ReporteNegocio();

                DataTable dt = negocio.ObtenerDetalle(filtro);

                // Formatear fechas
                foreach (DataRow fila in dt.Rows)
                {
                    fila["Ingreso"] = Convert.ToDateTime(fila["Ingreso"]).ToString("dd/MM/yyyy");
                    fila["Egreso"] = Convert.ToDateTime(fila["Egreso"]).ToString("dd/MM/yyyy");
                }

                gvDetalle.DataSource = dt;
                gvDetalle.DataBind();
                lblCantidad.Text = dt.Rows.Count.ToString();

                if (gvDetalle.Rows.Count > 0)
                {
                    gvDetalle.UseAccessibleHeader = true;
                    gvDetalle.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                // Centrar algunas columnas
                foreach (GridViewRow fila in gvDetalle.Rows)
                {
                    fila.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    fila.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                    fila.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                    fila.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                    fila.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                }

                if (gvDetalle.Rows.Count > 0)// para repetir el encabezado
                {
                    gvDetalle.UseAccessibleHeader = true;
                    gvDetalle.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                CargarFiltrosImpresion(filtro);
            }
        }
    

        //no uso el cargar filtros porque no se muestra el panel de filtros en esta página, solo el detalle.
        private void CargarFiltrosImpresion(FiltroReporte filtro)
        {
                        ReporteNegocio negocio = new ReporteNegocio();

                        string texto = "";
                        

                        texto += "<b>Período:</b> ";

                        texto += (filtro.FechaDesde.HasValue && filtro.FechaHasta.HasValue)
                            ? filtro.FechaDesde.Value.ToString("dd/MM/yyyy")
                                + " - "
                                + filtro.FechaHasta.Value.ToString("dd/MM/yyyy")
                            : "Todos";

                        texto += "<br/><br/>";

                        texto += "<b>Soporte respiratorio:</b> "
                            + negocio.ObtenerTexto(
                                filtro.SoporteRespiratorio,
                                "SOPORTE_RESPIRATORIO",
                                "id_soporte");

                        texto += "<br/><br/>";

                        texto += "<b>Insuficiencia respiratoria:</b> "
                            + negocio.ObtenerTexto(
                                filtro.InsuficienciaRespiratoria,
                                "INSUFICIENCIA_RESPIRATORIA",
                                "id_insuficiencia");

                        texto += "<br/><br/>";

                        texto += "<b>Destino de egreso:</b> "
                            + negocio.ObtenerTexto(
                                filtro.DestinoEgreso,
                                "DESTINO_EGRESO",
                                "id_destino");

                        texto += "<br/><br/>";

                        texto += "<b>Diagnóstico:</b> ";

                        if (filtro.Infeccion.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Infeccion,
                                "DIAGNOSTICO_INFECCIONES",
                                "id_infeccion");

                        else if (filtro.Obstructiva.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Obstructiva,
                                "DIAGNOSTICO_OBSTRUCTIVAS",
                                "id_obstructiva");

                        else if (filtro.Intersticial.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Intersticial,
                                "DIAGNOSTICO_INTERSTICIALES",
                                "id_intersticial");

                        else if (filtro.Pleura.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Pleura,
                                "DIAGNOSTICO_PLEURA",
                                "id_pleura");

                        else if (filtro.Vascular.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Vascular,
                                "DIAGNOSTICO_VASCULARES",
                                "id_vascular");

                        else if (filtro.Oncologica.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Oncologica,
                                "DIAGNOSTICO_ONCOLOGICAS",
                                "id_oncologica");

                        else if (filtro.Otro.HasValue)
                            texto += negocio.ObtenerTexto(filtro.Otro,
                                "DIAGNOSTICO_OTROS",
                                "id_otro");

                        else
                            texto += "Todos";

                        litFiltros.Text = texto;

            // Reutilizamos el método que ya esta hecho para mostrar las comorbilidades, aunque en este caso no se muestran como filtros sino como parte de la información del reporte.
            

            litComorbilidades.Text = negocio.ArmarTextoComorbilidades(filtro);
        }

       

    }
}