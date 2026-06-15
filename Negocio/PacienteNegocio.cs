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

        public List<Paciente> BuscarPorApellido(string apellido)
        {
            PacienteDatos datos = new PacienteDatos();

            return datos.BuscarPorApellido(apellido);
        }


        public List<Paciente> BuscarPorDNIoApellido(string Texto)
        {
            PacienteDatos datos = new PacienteDatos();

            return datos.BuscarPorDNIoApellido(Texto);

        }

        public void agregar(Paciente nuevo)
        {
            PacienteDatos datos = new PacienteDatos();
            datos.agregar(nuevo);
        }

        public void ModificarPaciente(Paciente paciente)
        {
            PacienteDatos datos = new PacienteDatos();

            datos.ModificarPaciente(paciente);
        }

        public List<Paciente> ListarPaciente()
        {
            PacienteDatos datos = new PacienteDatos();
            return datos.Listar();
        }

    }
}