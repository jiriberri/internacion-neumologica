using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Datos// puente de comunicacion con la db
{
    public class AccesoDatos
    {
        private SqlConnection conexion;//conexion fisica a la db
        private SqlCommand comando;//consulta a ejecutar
        private SqlDataReader lector;//lector de db, resultado de la consulta

        public SqlDataReader Lector//
        {
            get { return lector; }
        }

        public AccesoDatos()// constructor
        {
            conexion = new SqlConnection(
                "Data Source=localhost\\SQLEXPRESS;Initial Catalog=INTERNACION_NEUMOLOGICA_DB;Integrated Security=True");

            comando = new SqlCommand();
        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void SetearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            conexion.Open();

            lector = comando.ExecuteReader();// este se usa para el select, devuelve un lector con el resultado de la consulta, se recorre con un while para obtener cada fila
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }
    }
}
