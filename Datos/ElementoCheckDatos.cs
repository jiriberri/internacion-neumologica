using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Datos
{
    public class ElementoCheckDatos
    {


        public List<AntecedenteRespiratorio> ListarAntecedentesRespActivo()
        {

            List<AntecedenteRespiratorio> lista = new List<AntecedenteRespiratorio>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.SetearConsulta("select id_antecedente, descripcion, activo from ANTECEDENTE_RESPIRATORIO where activo= 1");
                datos.EjecutarLectura();


                while (datos.Lector.Read())
                {
                    AntecedenteRespiratorio aux = new AntecedenteRespiratorio();
                    aux.Id = (int)datos.Lector["id_antecedente"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Activo = (bool)datos.Lector["activo"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex) { throw ex; }


            finally
            {

                datos.CerrarConexion();
            }

        }


        public List<Secuela> ListarSecuelaActivo() {

            List<Secuela> lista = new List<Secuela>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select id_secuela, descripcion, activo from SECUELA where activo= 1");
                datos.EjecutarLectura();


                while (datos.Lector.Read())
                {
                    Secuela aux = new Secuela();
                    aux.Id = (int)datos.Lector["id_secuela"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Activo = (bool)datos.Lector["activo"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex) { throw ex; }


            finally
            {

                datos.CerrarConexion();
            }


        }



    }
}
