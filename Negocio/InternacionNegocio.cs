using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InternacionNegocio
    {

        public void agregar(Internaciones nuevo)
        {

            InternacionDatos datos = new InternacionDatos();
            datos.agregar(nuevo);
        }


    }
}