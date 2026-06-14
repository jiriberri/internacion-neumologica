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

        public List<Cardiovascular> ListarCardioVasActivo()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Cardiovascular>("COMORBILIDAD_CARDIOVASCULAR", "id_cardiovascular", "descripcion");
        }

        public List<Neurologico> ListarNeurologicos()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Neurologico>("COMORBILIDAD_NEUROLOGICA", "id_neurologico", "descripcion");

        }
        public List<Metabolica> ListarMetabolicas()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Metabolica>("COMORBILIDAD_METABOLICA", "id_metabolica", "descripcion");

        }
        public List<Sueño> ListarSueños()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Sueño>("COMORBILIDAD_SUEÑO", "id_sueño", "descripcion");

        }
        public List<Inmunologica> ListarInmunologicas()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<Inmunologica>("COMORBILIDAD_INMUNOLOGICA", "id_inmunologica", "descripcion");

        }

        public List<OncologicaComorbilidad> ListarOncologicaComorbilidades() {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<OncologicaComorbilidad>("COMORBILIDAD_ONCOLOGICA", "id_oncologica", "descripcion");

        }

    }
}
