using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class ReporteNegocio
    {
        public int ObtenerTotalPacientes(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerTotalPacientes(filtro);
        }

        public int ObtenerTotalInternaciones(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();
            return datos.ObtenerTotalInternaciones(filtro);
        }

        public int ObtenerTotalFallecidos(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();
            return datos.ObtenerTotalFallecidos(filtro);
        }

        public decimal ObtenerEstadiaPromedio(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();
            return datos.ObtenerEstadiaPromedio(filtro);
        }

        public List<ItemGrafico> ObtenerDistribucionEdades(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerDistribucionEdades(filtro);
        }

        public List<ItemGrafico> ObtenerDistribucionSoporte(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerDistribucionSoporte(filtro);
        }

        public List<ItemGrafico> ObtenerDiagnosticos(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerDiagnosticos(filtro);
        }
        public List<ItemGrafico> ObtenerComorbilidades(FiltroReporte filtro)
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerComorbilidades(filtro);
        }

        public DataTable ObtenerDetalle(FiltroReporte filtro)


        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerDetalle(filtro);
        }

        public string ObtenerTexto(int? id, string tabla, string campoId)
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerTexto(id, tabla, campoId);
        }

        public string ObtenerDescripcionesPorIds(List<int> ids,string tabla,string campoId)
           
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerDescripcionesPorIds(ids, tabla, campoId);
        }

        public string ArmarTextoComorbilidades(FiltroReporte filtro)
        {
            

            string texto = "";

            if (filtro.Cardiovasculares != null && filtro.Cardiovasculares.Count > 0)
            {
                texto += "<b>Cardiovasculares:</b> ";
                texto += ObtenerDescripcionesPorIds(
                    filtro.Cardiovasculares,
                    "COMORBILIDAD_CARDIOVASCULAR",
                    "id_cardiovascular");

                texto += "<br/>";
            }

            if (filtro.Metabolicas != null && filtro.Metabolicas.Count > 0)
            {
                texto += "<b>Metabólicas:</b> ";
                texto += ObtenerDescripcionesPorIds(
                    filtro.Metabolicas,
                    "COMORBILIDAD_METABOLICA",
                    "id_metabolica");

                texto += "<br/><br/>";
            }

            if (filtro.Neurologicas != null && filtro.Neurologicas.Count > 0)
            {
                texto += "<b>Neurológicas:</b> ";
                texto += ObtenerDescripcionesPorIds(
                    filtro.Neurologicas,
                    "COMORBILIDAD_NEUROLOGICA",
                    "id_neurologico");

                texto += "<br/><br/>";
            }

            if (filtro.Inmunologicas != null && filtro.Inmunologicas.Count > 0)
            {
                texto += "<b>Inmunológicas:</b> ";
                texto += ObtenerDescripcionesPorIds(
                    filtro.Inmunologicas,
                    "COMORBILIDAD_INMUNOLOGICA",
                    "id_inmunologica");

                texto += "<br/><br/>";
            }

            if (filtro.Oncologicas != null && filtro.Oncologicas.Count > 0)
            {
                texto += "<b>Oncológicas:</b> ";
                texto += ObtenerDescripcionesPorIds(
                    filtro.Oncologicas,
                    "COMORBILIDAD_ONCOLOGICA",
                    "id_oncologica");

                texto += "<br/><br/>";
            }

            if (filtro.Sueño != null && filtro.Sueño.Count > 0)
            {
                texto += "<b>Patología del sueño:</b> ";
                texto += ObtenerDescripcionesPorIds(
                    filtro.Sueño,
                    "COMORBILIDAD_SUEÑO",
                    "id_sueño");

                texto += "<br/><br/>";
            }

            if (texto == "")
                texto = "No se seleccionaron comorbilidades.";

            return texto;
        }
    }
}
