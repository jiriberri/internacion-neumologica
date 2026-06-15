using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;



namespace Datos
{
    public class ReporteDatos
    {

        private string ArmarWhere(FiltroReporte filtro)
        {
            string where = " WHERE 1=1 ";

            if (filtro.FechaDesde.HasValue)
                where += "AND I.fecha_ingreso >= @fechaDesde ";

            if (filtro.FechaHasta.HasValue)
                where += "AND I.fecha_ingreso <= @fechaHasta ";

            if (filtro.SoporteRespiratorio.HasValue)
                where += "AND I.id_soporte = @soporte ";

            if (filtro.InsuficienciaRespiratoria.HasValue)
                where += "AND I.id_insuficiencia = @insuficiencia ";

            if (filtro.DestinoEgreso.HasValue)
                where += "AND I.id_destino = @destino ";

            if (filtro.Infeccion.HasValue)
                where += "AND I.id_infeccion = @infeccion ";

            if (filtro.Obstructiva.HasValue)
                where += "AND I.id_obstructiva = @obstructiva ";

            if (filtro.Intersticial.HasValue)
                where += "AND I.id_intersticial = @intersticial ";

            if (filtro.Pleura.HasValue)
                where += "AND I.id_pleura = @pleura ";

            if (filtro.Vascular.HasValue)
                where += "AND I.id_vascular = @vascular ";

            if (filtro.Oncologica.HasValue)
                where += "AND I.id_oncologica = @oncologica ";

            if (filtro.Otro.HasValue)
                where += "AND I.id_otro = @otro ";

            return where;
        }

        private void CargarParametros(FiltroReporte filtro, AccesoDatos datos)
        {
            if (filtro.FechaDesde.HasValue)
                datos.SetearParametro("@fechaDesde", filtro.FechaDesde.Value);

            if (filtro.FechaHasta.HasValue)
                datos.SetearParametro("@fechaHasta", filtro.FechaHasta.Value);

            if (filtro.SoporteRespiratorio.HasValue)
                datos.SetearParametro("@soporte", filtro.SoporteRespiratorio.Value);

            if (filtro.InsuficienciaRespiratoria.HasValue)
                datos.SetearParametro("@insuficiencia", filtro.InsuficienciaRespiratoria.Value);

            if (filtro.DestinoEgreso.HasValue)
                datos.SetearParametro("@destino", filtro.DestinoEgreso.Value);

            if (filtro.Infeccion.HasValue)
                datos.SetearParametro("@infeccion", filtro.Infeccion.Value);

            if (filtro.Obstructiva.HasValue)
                datos.SetearParametro("@obstructiva", filtro.Obstructiva.Value);

            if (filtro.Intersticial.HasValue)
                datos.SetearParametro("@intersticial", filtro.Intersticial.Value);

            if (filtro.Pleura.HasValue)
                datos.SetearParametro("@pleura", filtro.Pleura.Value);

            if (filtro.Vascular.HasValue)
                datos.SetearParametro("@vascular", filtro.Vascular.Value);

            if (filtro.Oncologica.HasValue)
                datos.SetearParametro("@oncologica", filtro.Oncologica.Value);

            if (filtro.Otro.HasValue)
                datos.SetearParametro("@otro", filtro.Otro.Value);
        }

        public int ObtenerTotalPacientes(FiltroReporte filtro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta =
                    "SELECT COUNT(DISTINCT P.id_paciente) cantidad " +
                    "FROM PACIENTE P " +
                    "INNER JOIN INTERNACION I ON P.id_paciente = I.id_paciente ";

                consulta += ArmarWhere(filtro);

                datos.SetearConsulta(consulta);

                CargarParametros(filtro, datos);

                datos.EjecutarLectura();


                if (datos.Lector.Read())
                    return Convert.ToInt32(datos.Lector["cantidad"]);

                return 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int ObtenerTotalInternaciones(FiltroReporte filtro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta =
                    "SELECT COUNT(*) cantidad " +
                    "FROM INTERNACION I ";

                consulta += ArmarWhere(filtro);

                datos.SetearConsulta(consulta);

                CargarParametros(filtro, datos);

                datos.EjecutarLectura();


                if (datos.Lector.Read())
                    return Convert.ToInt32(datos.Lector["cantidad"]);

                return 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int ObtenerTotalFallecidos(FiltroReporte filtro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta =
                    "SELECT COUNT(*) cantidad " +
                    "FROM INTERNACION I " +
                    "INNER JOIN DESTINO_EGRESO D " +
                    "ON I.id_destino = D.id_destino ";

                consulta += ArmarWhere(filtro);

                consulta += "AND D.descripcion = 'Fallecimiento' ";

                datos.SetearConsulta(consulta);

                CargarParametros(filtro, datos);

                datos.EjecutarLectura();

                if (datos.Lector.Read())
                    return Convert.ToInt32(datos.Lector["cantidad"]);

                return 0;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public decimal ObtenerEstadiaPromedio(FiltroReporte filtro)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta =
                    "SELECT AVG(DATEDIFF(DAY, I.fecha_ingreso, I.fecha_egreso)) promedio " +
                    "FROM INTERNACION I ";

                consulta += ArmarWhere(filtro);

                datos.SetearConsulta(consulta);

                CargarParametros(filtro, datos);

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


        

            public List<ItemGrafico> ObtenerDistribucionEdades(FiltroReporte filtro)
        {
            List<ItemGrafico> lista = new List<ItemGrafico>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta =
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
                    "ON I.id_paciente = P.id_paciente ";

                consulta += ArmarWhere(filtro);

                consulta +=
                    "GROUP BY " +
                    "CASE " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) < 40 THEN 'Menor de 40' " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) BETWEEN 40 AND 59 THEN '40 a 59' " +
                    "WHEN DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) BETWEEN 60 AND 79 THEN '60 a 79' " +
                    "ELSE '80 o más' " +
                    "END";

                datos.SetearConsulta(consulta);

                CargarParametros(filtro, datos);

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    ItemGrafico aux = new ItemGrafico();

                    aux.Categoria = datos.Lector["Categoria"].ToString();
                    aux.Cantidad = Convert.ToInt32(datos.Lector["Cantidad"]);

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }



        public List<ItemGrafico> ObtenerDistribucionSoporte(FiltroReporte filtro)
        {
            List<ItemGrafico> lista = new List<ItemGrafico>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta =
                    "SELECT S.descripcion AS Categoria, " +
                    "COUNT(*) AS Cantidad " +
                    "FROM INTERNACION I " +
                    "INNER JOIN SOPORTE_RESPIRATORIO S " +
                    "ON I.id_soporte = S.id_soporte ";

                consulta += ArmarWhere(filtro);

                consulta +=
                    "GROUP BY S.descripcion " +
                    "ORDER BY S.descripcion ";

                datos.SetearConsulta(consulta);

                CargarParametros(filtro, datos);

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

        public List<ItemGrafico> ObtenerDiagnosticos(FiltroReporte filtro)
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

            public List<ItemGrafico> ObtenerComorbilidades(FiltroReporte filtro)
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

        public DataTable ObtenerDetalle(FiltroReporte filtro) 
        
        { 
            AccesoDatos datos = new AccesoDatos(); 
            
            try
            { 
                
                        string consulta =
                            "SELECT " +
                            "ROW_NUMBER() OVER (PARTITION BY P.id_paciente ORDER BY I.fecha_ingreso) AS Internacion, " +
                            "P.dni AS DNI, " +
                            "P.apellido AS Apellido, " +
                            "P.nombre AS Nombre, " +
                            "DATEDIFF(YEAR, P.fecha_nacimiento, GETDATE()) AS Edad, " +
                            "I.fecha_ingreso AS [Ingreso], " +
                            "I.fecha_egreso AS [Egreso], " +
                            "S.descripcion AS [Soporte], " +
                            "IR.descripcion AS [Insuficiencia], " +
                            "D.descripcion AS [Destino] " +
                            "FROM INTERNACION I " +
                            "INNER JOIN PACIENTE P " +
                            "ON I.id_paciente = P.id_paciente " +
                            "LEFT JOIN SOPORTE_RESPIRATORIO S " +
                            "ON I.id_soporte = S.id_soporte " +
                            "LEFT JOIN INSUFICIENCIA_RESPIRATORIA IR " +
                            "ON I.id_insuficiencia = IR.id_insuficiencia " +
                            "LEFT JOIN DESTINO_EGRESO D " +
                            "ON I.id_destino = D.id_destino ";
                           


                consulta += ArmarWhere(filtro);

                consulta +=
                            "ORDER BY " +
                            "P.apellido, " +
                            "P.nombre, " +
                            "I.fecha_ingreso ";



                datos.SetearConsulta(consulta); 
                CargarParametros(filtro, datos); 
                datos.EjecutarLectura(); 
                DataTable tabla = new DataTable(); 
                tabla.Load(datos.Lector); 
                return tabla; 
            } 
            finally 
            { 
                datos.CerrarConexion(); 
            }
        }



    }
}


