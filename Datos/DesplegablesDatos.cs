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

        public List<Origen> ListarOrigenes()
        {

            List<Origen> lista = new List<Origen>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.SetearConsulta("Select id_origen, descripcion from ORIGEN_INTERNACION");
                datos.EjecutarLectura();


                while (datos.Lector.Read())
                {
                    Origen aux = new Origen();
                    aux.Id = (int)datos.Lector["id_origen"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

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


        public List<T> Listar<T>(string tabla, string Id, string descripcion) where T : Despegables, new()
        {
            List<T> lista = new List<T>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta($"Select {Id}, {descripcion} from {tabla}");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    T objeto = new T();
                    objeto.Id = (int)datos.Lector[Id];
                    objeto.Descripcion = (string)datos.Lector[descripcion];
                    lista.Add(objeto);
                }
                return lista;

            }
            catch (Exception ex) { throw ex; }

            finally { datos.CerrarConexion(); }
        }

        public void AgregarItem(string tabla, string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta($"INSERT INTO {tabla} (descripcion) VALUES (@descripcion)");
                datos.SetearParametro("@descripcion", descripcion);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
