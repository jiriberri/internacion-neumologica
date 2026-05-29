using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;

namespace Negocio
{
    public class PacienteNegocio
    {
        public Paciente BuscarPorDni(string dni)
        {
            PacienteDatos datos = new PacienteDatos();

            return datos.BuscarPorDni(dni);
        }
    }
}
