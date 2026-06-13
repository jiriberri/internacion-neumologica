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
            return datos.Listar<AntecedenteRespiratorio>("ANTECEDENTE_RESPIRATORIO", "id_antecedente", "descripcion");
        }

        public List<Secuela> ListarSecuelaActivo()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Secuela>("SECUELA", "id_secuela", "descripcion");
        }
        

        public List<Cirugia> ListarCirugiaActivo()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Cirugia>("CIRUGIA", "id_cirugia", "descripcion");
        }

        public List<ExposicionAmbiental> ListarExpoAmb()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<ExposicionAmbiental>("EXPOSICION_AMBIENTAL", "id_exposicion", "descripcion");
        }

    }
}
