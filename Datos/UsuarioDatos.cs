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

                    user.TipoUsuario =
                        (int)datos.Lector["tipo_usuario"];
                }

                return user;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
