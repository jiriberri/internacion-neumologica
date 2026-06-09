using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Internacion
    {
        public int IdInternacion { get; set; } 

        public int IdPaciente { get; set; }
        
        public DateTime FechaIngreso { get; set; }

        public DateTime FechaEgreso { get; set; }


        public Origen Origen { get; set; }

        public DestinoEgreso Destino { get; set; }

        public Infeccion Infecciom { get; set; }

        public Obstructiva Obstructiva { get; set; }

        public Intersticiales Intersticial { get; set; }

        public Pleura Pleura { get; set; }

        public Vascular Vascular { get; set; }

        public Oncologica Oncologica { get; set; }

        public Otros Otro { get; set; } 

        public InsuficienciaRespiratoria insuficiencia { get; set; }
         
        public SoporteRespiratorio Soporte { get; set; }

        public Tabaquismo tabaquismo { get; set; }

        public int paquetes_anio { get; set; }
    }
}
