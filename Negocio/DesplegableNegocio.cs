using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class DesplegableNegocio
    {

        public List<Origen> ListarOrigenes() {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.ListarOrigenes();
        }
            


    }
}
