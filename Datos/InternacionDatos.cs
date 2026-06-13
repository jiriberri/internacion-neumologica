using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class InternacionDatos
    {

        public void agregar(Internaciones nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.SetearConsulta("INSERT INTO INTERNACION (id_paciente, fecha_ingreso, fecha_egreso, id_origen, id_destino, id_infeccion, id_obstructiva, id_intersticial, id_pleura, id_vascular, id_oncologica, id_otro, id_insuficiencia, id_soporte, id_tabaquismo, paquetes_anio) " +
                              "VALUES (@idPaciente, @fechaIngreso, @fechaEgreso, @idOrigen, @idDestino, @idInfeccion, @idObstructiva, @idIntersticial, @idPleura, @idVascular, @idOncologica, @idOtro, @idInsuficiencia, @idSoporte, @idTabaquismo, @paquetesAnio); ");


            try
            {

                datos.SetearParametro("@idPaciente", nuevo.IdPaciente);
                datos.SetearParametro("@fechaIngreso", nuevo.FechaIngreso);
                datos.SetearParametro("@fechaEgreso", nuevo.FechaEgreso);
                datos.SetearParametro("@idOrigen", nuevo.Origen.Id);
                datos.SetearParametro("@idDestino", nuevo.Destino.Id);
                datos.SetearParametro("@idInfeccion", nuevo.Infeccion.Id);
                datos.SetearParametro("@idObstructiva", nuevo.Obstructiva.Id);
                datos.SetearParametro("@idIntersticial", nuevo.Intersticial.Id);
                datos.SetearParametro("@idPleura", nuevo.Pleura.Id);
                datos.SetearParametro("@idVascular", nuevo.Vascular.Id);
                datos.SetearParametro("@idOncologica", nuevo.Oncologica.Id);
                datos.SetearParametro("@idOtro", nuevo.Otro.Id);
                datos.SetearParametro("@idInsuficiencia", nuevo.Insuficiencia.Id);
                datos.SetearParametro("@idSoporte", nuevo.Soporte.Id);
                datos.SetearParametro("@idTabaquismo", nuevo.Tabaquismo.IdTabaquismo);
                datos.SetearParametro("@paquetesAnio", nuevo.Paquetes_anio);
                

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }











    }
}
