using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Loguear(string usuario, string pass)
        {
            UsuarioDatos datos = new UsuarioDatos();

            return datos.Loguear(usuario, pass);
        }
    

          public List<Usuario> Listar()// Puente entre web y dtos
        {
            UsuarioDatos datos = new UsuarioDatos();

            return datos.Listar();
        }
    }
}