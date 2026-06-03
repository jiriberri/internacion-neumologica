using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DesplegablesDatos
    {

        public List<Origen> ListarOrigenes() {

            List<Origen> lista = new List<Origen>();
            AccesoDatos datos = new AccesoDatos();


            try {
                datos.SetearConsulta("Select id_origen, descripcion from ORIGEN_INTERNACION");
                datos.EjecutarLectura();


                while (datos.Lector.Read()) {
                    Origen aux = new Origen();
                    aux.Id = (int)datos.Lector["id_origen"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex) { throw ex; }

            
            finally {

                datos.CerrarConexion();
            }

        }






    }
}
