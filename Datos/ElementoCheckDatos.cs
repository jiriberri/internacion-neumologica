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
 

        public List<T> Listar<T>(string tabla, string Id, string descripcion, bool soloActivos = true) where T : IElementoCheck, new()
        {
            List<T> lista = new List<T>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                int valorActivo = soloActivos ? 1 : 0;

                datos.SetearConsulta($"Select {Id}, {descripcion} from {tabla} WHERE activo = {valorActivo}");
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
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.CerrarConexion();
            }
        }

        public void guardarOpcionesMultiples(int idPaciente, string stringIds, string nombreTabla, string nombreColumnaIdOpcion)
        {
            if (string.IsNullOrEmpty(stringIds)) return;

            string[] idsSeleccionados = stringIds.Split(',');

            foreach (var idOpcion in idsSeleccionados)
            {
                AccesoDatos datos = new AccesoDatos();
                string consulta = $"INSERT INTO {nombreTabla} (id_paciente, {nombreColumnaIdOpcion}) VALUES (@idPaciente, @idOpcion)";

                datos.SetearConsulta(consulta);
                datos.SetearParametro("@idPaciente", idPaciente);
                datos.SetearParametro("@idOpcion", int.Parse(idOpcion));

                try
                {
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
    }
