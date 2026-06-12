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

        public List<ItemGrafico> ObtenerDistribucionSoporte()
        {
            List<ItemGrafico> lista = new List<ItemGrafico>();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta(
                    "SELECT " +
                     "S.descripcion AS Categoria, " +
                     "COUNT(*) AS Cantidad " +
                     "FROM INTERNACION I " +
                     "INNER JOIN SOPORTE_RESPIRATORIO S " +
                     "ON I.id_soporte = S.id_soporte " +
                     "GROUP BY S.descripcion " +
                     "ORDER BY S.descripcion ");

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

        public List<ItemGrafico> ObtenerDiagnosticos()
        {
            {
                List<ItemGrafico> lista = new List<ItemGrafico>();

                AccesoDatos datos = new AccesoDatos();

                try
                {

                    datos.SetearConsulta(
                            "SELECT 'Infecciones' AS Categoria, COUNT(*) AS Cantidad " +
                            "FROM INTERNACION WHERE id_infeccion IS NOT NULL " +
                            "UNION ALL " +
                            "SELECT 'Obstructivas', COUNT(*) " +
                            "FROM INTERNACION WHERE id_obstructiva IS NOT NULL " +
                            "UNION ALL " +
                            "SELECT 'Intersticiales', COUNT(*) " +
                            "FROM INTERNACION WHERE id_intersticial IS NOT NULL " +
                            "UNION ALL " +
                            "SELECT 'Pleura', COUNT(*) " +
                            "FROM INTERNACION WHERE id_pleura IS NOT NULL " +
                            "UNION ALL " +
                            "SELECT 'Vasculares', COUNT(*) " +
                            "FROM INTERNACION WHERE id_vascular IS NOT NULL " +
                            "UNION ALL " +
                            "SELECT 'Oncológicas', COUNT(*) " +
                            "FROM INTERNACION WHERE id_oncologica IS NOT NULL " +
                            "UNION ALL " +
                            "SELECT 'Otros', COUNT(*) " +
                            "FROM INTERNACION WHERE id_otro IS NOT NULL");

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
        }

            public List<ItemGrafico> ObtenerComorbilidades()
        {
            {
                List<ItemGrafico> lista = new List<ItemGrafico>();

                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.SetearConsulta(
                                    "SELECT Categoria, SUM(Cantidad) AS Cantidad " +
                                    "FROM ( " +

                                    "SELECT C.descripcion AS Categoria, COUNT(*) AS Cantidad " +
                                    "FROM PACIENTE_COMORBILIDAD_CARDIOVASCULAR PC " +
                                    "INNER JOIN COMORBILIDAD_CARDIOVASCULAR C ON PC.id_cardiovascular = C.id_cardiovascular " +
                                    "GROUP BY C.descripcion " +

                                    "UNION ALL " +

                                    "SELECT C.descripcion, COUNT(*) AS Cantidad " +
                                    "FROM PACIENTE_COMORBILIDAD_METABOLICA PC " +
                                    "INNER JOIN COMORBILIDAD_METABOLICA C ON PC.id_metabolica = C.id_metabolica " +
                                    "GROUP BY C.descripcion " +

                                    "UNION ALL " +

                                    "SELECT C.descripcion, COUNT(*) AS Cantidad " +
                                    "FROM PACIENTE_COMORBILIDAD_NEUROLOGICA PC " +
                                    "INNER JOIN COMORBILIDAD_NEUROLOGICA C ON PC.id_neurologico = C.id_neurologico " +
                                    "GROUP BY C.descripcion " +

                                    "UNION ALL " +

                                    "SELECT C.descripcion, COUNT(*) AS Cantidad " +
                                    "FROM PACIENTE_COMORBILIDAD_INMUNOLOGICA PC " +
                                    "INNER JOIN COMORBILIDAD_INMUNOLOGICA C ON PC.id_inmunologica = C.id_inmunologica " +
                                    "GROUP BY C.descripcion " +

                                    "UNION ALL " +

                                    "SELECT C.descripcion, COUNT(*) AS Cantidad " +
                                    "FROM PACIENTE_COMORBILIDAD_ONCOLOGICA PC " +
                                    "INNER JOIN COMORBILIDAD_ONCOLOGICA C ON PC.id_oncologica = C.id_oncologica " +
                                    "GROUP BY C.descripcion " +

                                    "UNION ALL " +

                                    "SELECT C.descripcion, COUNT(*) AS Cantidad " +
                                    "FROM PACIENTE_COMORBILIDAD_SUEÑO PC " +
                                    "INNER JOIN COMORBILIDAD_SUEÑO C ON PC.id_sueño = C.id_sueño " +
                                    "GROUP BY C.descripcion " +

                                    ") AS T " +
                                    "GROUP BY Categoria " +
                                    "ORDER BY Cantidad DESC");

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
        }



    }
}


