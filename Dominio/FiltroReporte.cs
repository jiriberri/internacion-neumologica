using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class FiltroReporte
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        public int? EdadMinima { get; set; }
        public int? EdadMaxima { get; set; }

        public string Sexo { get; set; }

        // Diagnóstico de ingreso
        public int? Infeccion { get; set; }
        public int? Obstructiva { get; set; }
        public int? Intersticial { get; set; }
        public int? Pleura { get; set; }
        public int? Vascular { get; set; }
        public int? Oncologica { get; set; }
        public int? Otro { get; set; }

        // Antecedentes
        public int? InsuficienciaRespiratoria { get; set; }
        public int? SoporteRespiratorio { get; set; }
        public int? DestinoEgreso { get; set; }

        // Comorbilidades (por ahora)
        public int? Cardiovascular { get; set; }
        public int? Metabolica { get; set; }
        public int? Neurologica { get; set; }
        public int? Inmunologica { get; set; }
        public int? OncologicaComorbilidad { get; set; }
        public int? Sueno { get; set; }
    }
}

