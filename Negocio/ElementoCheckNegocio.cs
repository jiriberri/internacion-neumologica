using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ElementoCheckNegocio
    {
        public List<AntecedenteRespiratorio> ListarAntecedentesRespActivo()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.ListarAntecedentesRespActivo();
        }


        public List<Secuela> ListarSecuelaActivo() {

            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.ListarSecuelaActivo();

        }



    }
}
