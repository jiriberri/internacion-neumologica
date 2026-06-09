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
        public int ObtenerTotalPacientes()
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerTotalPacientes();
        }

        public int ObtenerTotalInternaciones()
        {
            ReporteDatos datos = new ReporteDatos();
            return datos.ObtenerTotalInternaciones();
        }

        public int ObtenerTotalFallecidos()
        {
            ReporteDatos datos = new ReporteDatos();
            return datos.ObtenerTotalFallecidos();
        }

        public decimal ObtenerEstadiaPromedio()
        {
            ReporteDatos datos = new ReporteDatos();
            return datos.ObtenerEstadiaPromedio();
        }

        public List<ItemGrafico> ObtenerDistribucionEdades()
        {
            ReporteDatos datos = new ReporteDatos();

            return datos.ObtenerDistribucionEdades();
        }
    }
}
