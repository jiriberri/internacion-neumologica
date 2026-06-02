using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Datos
{
    public class PacienteDatos
    {
        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();

            return lista;
        }

        public Paciente BuscarPorDni(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            Paciente paciente = null;

            try
            {
                datos.SetearConsulta("SELECT * FROM PACIENTE WHERE dni = @dni");
                datos.SetearParametro("@dni", dni);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    paciente = new Paciente();

                    paciente.IdPaciente = (int)datos.Lector["id_paciente"];
                    paciente.Dni = datos.Lector["dni"].ToString();
                    paciente.Nombre = datos.Lector["nombre"].ToString();
                    paciente.Apellido = datos.Lector["apellido"].ToString();
                    paciente.FechaNacimiento = (DateTime)datos.Lector["fecha_nacimiento"];
                    paciente.Domicilio = datos.Lector["domicilio"].ToString();
                    paciente.Telefono = datos.Lector["telefono"].ToString();
                }

                return paciente;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Paciente> BuscarPorApellido(string apellido)
        {
            List<Paciente> lista = new List<Paciente>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                   "SELECT * FROM PACIENTE " +
                   "WHERE apellido " +
                   "COLLATE Latin1_General_CI_AI LIKE @apellido");

                datos.SetearParametro(
                    "@apellido",
                    "%" + apellido + "%");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.IdPaciente =
                        (int)datos.Lector["id_paciente"];

                    aux.Dni =
                        datos.Lector["dni"].ToString();

                    aux.Nombre =
                        datos.Lector["nombre"].ToString();

                    aux.Apellido =
                        datos.Lector["apellido"].ToString();

                    aux.FechaNacimiento =
                        (DateTime)datos.Lector["fecha_nacimiento"];

                    aux.Domicilio =
                        datos.Lector["domicilio"].ToString();

                    aux.Telefono =
                        datos.Lector["telefono"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Paciente> BuscarPorDNIoApellido(string Texto) {

            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                   "SELECT * FROM PACIENTE " +
    "WHERE apellido COLLATE Latin1_General_CI_AI LIKE @apellido " +
    "OR dni=@Dni");

                datos.SetearParametro("@Dni",Texto);
                datos.SetearParametro("@apellido", "%" + Texto + "%");
                

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.IdPaciente =
                        (int)datos.Lector["id_paciente"];

                    aux.Dni =
                        datos.Lector["dni"].ToString();

                    aux.Nombre =
                        datos.Lector["nombre"].ToString();

                    aux.Apellido =
                        datos.Lector["apellido"].ToString();

                    aux.FechaNacimiento =
                        (DateTime)datos.Lector["fecha_nacimiento"];

                    aux.Domicilio =
                        datos.Lector["domicilio"].ToString();

                    aux.Telefono =
                        datos.Lector["telefono"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
      
        }














    }
}
