using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace Datos
{
    public class ReporteDatos
    {
        public int ObtenerTotalPacientes()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT COUNT(*) cantidad " +
                    "FROM PACIENTE");

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["cantidad"];

                return 0;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public int ObtenerTotalInternaciones()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT COUNT(*) cantidad " +
                    "FROM INTERNACION");

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["cantidad"];
                return 0;

            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public int ObtenerTotalFallecidos()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT COUNT(*) cantidad " +
                    "FROM INTERNACION I " +
                    "INNER JOIN DESTINO_EGRESO D " +
                    "    ON I.id_destino = D.id_destino " +
                    "WHERE D.descripcion = 'Fallecimiento'; "
                );

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["cantidad"];
                return 0;

            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public decimal ObtenerEstadiaPromedio()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(
                    "SELECT AVG(DATEDIFF(DAY, fecha_ingreso, fecha_egreso)) promedio " +
                    "FROM INTERNACION ");

                datos.EjecutarLectura();

                if (datos.Lector.Read() && datos.Lector["promedio"] != DBNull.Value)
                    return Convert.ToDecimal(datos.Lector["promedio"]);

                return 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public List<ItemGrafico> ObtenerDistribucionEdades()
        {
            List<ItemGrafico> lista = new List<ItemGrafico>();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta(
                    "SELECT " +
                    "CASE " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) < 40 THEN 'Menor de 40' " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) BETWEEN 40 AND 59 THEN '40 a 59' " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) BETWEEN 60 AND 79 THEN '60 a 79' " +
                    "ELSE '80 o más' " +
                    "END AS Categoria, " +
                    "COUNT(*) AS Cantidad " +
                    "FROM INTERNACION I " +
                    "INNER JOIN PACIENTE P " +
                    "ON I.id_paciente = P.id_paciente " +
                    "GROUP BY " +
                    "CASE " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) < 40 THEN 'Menor de 40' " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) BETWEEN 40 AND 59 THEN '40 a 59' " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) BETWEEN 60 AND 79 THEN '60 a 79' " +
                    "ELSE '80 o más' " +
                    "END");



                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    ItemGrafico aux = new ItemGrafico();

                    aux.Categoria = datos.Lector["Categoria"].ToString();
                    aux.Cantidad = (int)datos.Lector["Cantidad"];

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        /*public List<ItemGrafico> ObtenerDistribucionSoporte()

        public List<ItemGrafico> ObtenerDiagnosticos()

        public List<ItemGrafico> ObtenerComorbilidades()*/


    }
}

