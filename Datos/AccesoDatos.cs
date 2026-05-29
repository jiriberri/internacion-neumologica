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

        public AccesoDatos()//constructor
        {
            conexion = new SqlConnection("Data Source=.\\Initial Catalog=INTERNACION_NEUMOLOGICA_DB;Integrated Security=True");
            comando = new SqlCommand();
        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            conexion.Open();

            lector = comando.ExecuteReader();
        }

        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }
    }
}
