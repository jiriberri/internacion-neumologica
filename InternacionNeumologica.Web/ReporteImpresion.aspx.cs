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

                gvDetalle.DataSource = negocio.ObtenerDetalle(filtro);
                gvDetalle.DataBind();
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