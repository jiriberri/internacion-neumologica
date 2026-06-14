using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
