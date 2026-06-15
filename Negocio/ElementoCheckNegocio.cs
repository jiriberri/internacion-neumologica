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

        public List<OncologicaComorbilidad> ListarOncologicaComorbilidades()
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();
            return datos.Listar<OncologicaComorbilidad>("COMORBILIDAD_ONCOLOGICA", "id_oncologica", "descripcion");

        }



        public void guardarOncologiaPaciente(int idPaciente, string Oncologia)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Oncologia, "PACIENTE_COMORBILIDAD_ONCOLOGICA", "id_oncologica");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void guardarCardiovascularPaciente(int idPaciente, string CardioVascular)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, CardioVascular, "PACIENTE_COMORBILIDAD_CARDIOVASCULAR", "id_cardiovascular");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void guardarNeurologicoPaciente(int idPaciente, string Neurologica)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente,Neurologica, "PACIENTE_COMORBILIDAD_NEUROLOGICA", "id_neurologico");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void guardarMetabolicaPaciente(int idPaciente, string Metabolica)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Metabolica, "PACIENTE_COMORBILIDAD_METABOLICA", "id_metabolica");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void guardarSueñoPaciente(int idPaciente, string Sueño)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Sueño, "PACIENTE_COMORBILIDAD_SUEÑO", "id_sueño");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void guardarInmunologPaciente(int idPaciente, string Inmunologica)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Inmunologica, "PACIENTE_COMORBILIDAD_INMUNOLOGICA", "id_inmunologica");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void guardarRespiratorioPaciente(int idPaciente, string Respiratorio)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Respiratorio, "PACIENTE_ANTECEDENTE_RESPIRATORIO", "id_antecedente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void guardarSecuelaPaciente(int idPaciente, string Secuela)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Secuela, "PACIENTE_SECUELA", "id_secuela");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void guardarCirugiaPaciente(int idPaciente, string Cirugia)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Cirugia, "PACIENTE_CIRUGIA", "id_cirugia");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void guardarExposicionPaciente(int idPaciente, string Expo)
        {
            ElementoCheckDatos datos = new ElementoCheckDatos();

            try
            {
                datos.guardarOpcionesMultiples(idPaciente, Expo, "PACIENTE_EXPOSICION_AMBIENTAL", "id_exposicion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    }


