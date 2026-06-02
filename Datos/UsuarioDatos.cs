using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Datos
{
    public class UsuarioDatos
    {
        public Usuario Loguear(string usuario, string pass)
        {
            Usuario user = null;

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT * FROM USUARIO " +
                    "WHERE usuario = @usuario " +
                    "AND pass = @pass");

                datos.SetearParametro("@usuario", usuario);
                datos.SetearParametro("@pass", pass);

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    user = new Usuario();

                    user.IdUsuario =
                        (int)datos.Lector["id_usuario"];

                    user.User =
                        datos.Lector["usuario"].ToString();

                    user.Pass =
                        datos.Lector["pass"].ToString();

                    user.Admin =
                        (bool)datos.Lector["esAdmin"];
                }

                return user;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Usuario> Listar()//busca todos los usuarios de la bd
        {
            List<Usuario> lista = new List<Usuario>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT * FROM USUARIO");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();// por cada fila crea un objeto usuario y lo agrega a la lista, luego devuelve la lista completa

                    aux.IdUsuario =
                        (int)datos.Lector["id_usuario"];

                    aux.User =
                        datos.Lector["usuario"].ToString();

                    aux.Pass =
                        datos.Lector["pass"].ToString();

                    aux.Admin =
                        (bool)datos.Lector["esAdmin"];

                    lista.Add(aux);// guarda en la lista cada usuario que genera
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "INSERT INTO USUARIO (usuario, pass, esAdmin) " +
                    "VALUES (@usuario, @pass, @admin)");

                datos.SetearParametro("@usuario", nuevo.User);
                datos.SetearParametro("@pass", nuevo.Pass);
                datos.SetearParametro("@admin", nuevo.Admin);

                datos.EjecutarAccion();
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
