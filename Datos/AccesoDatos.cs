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
        private SqlConnection conexion;

        public AccesoDatos()
        {
            conexion = new SqlConnection("Data Source=.\\Initial Catalog=INTERNACION_NEUMOLOGICA_DB;Integrated Security=True");
        }
    }
}
