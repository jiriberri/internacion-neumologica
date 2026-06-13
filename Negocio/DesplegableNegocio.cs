using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class DesplegableNegocio
    {

        public List<Origen> ListarOrigenes()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.ListarOrigenes();
        }


        public List<Origen> ListarOrigen()
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Origen>("ORIGEN_INTERNACION", "id_origen", "descripcion");
        }

        public List<DestinoEgreso> ListarEgreso()
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<DestinoEgreso>("DESTINO_EGRESO", "id_destino", "descripcion");

        }

        public List<Infeccion> ListarInfeccion()
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Infeccion>("DIAGNOSTICO_INFECCIONES", "id_infeccion", "descripcion"); 

        }

        public List<Obstructiva> ListarObtructiva() {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Obstructiva>("DIAGNOSTICO_OBSTRUCTIVAS", "id_obstructiva", "descripcion");

        }

        public List<Intersticiales> ListarIntersticiales()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Intersticiales>("DIAGNOSTICO_INTERSTICIALES", "id_intersticial", "descripcion");

        }

        public List<Pleura> ListarPleura() {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Pleura>("DIAGNOSTICO_PLEURA", "id_pleura", "descripcion");

        }

        public List<Vascular> ListarVascular()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Vascular>("DIAGNOSTICO_VASCULARES", "id_vascular", "descripcion");

        }

        public List<Oncologica> ListarOncologica()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Oncologica>("DIAGNOSTICO_ONCOLOGICAS", "id_oncologica", "descripcion");

        }

        public List<Otros> ListarOtros()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Otros>("DIAGNOSTICO_OTROS", "id_otro", "descripcion");

        }

        public List<InsuficienciaRespiratoria> ListarInsuficiencias() {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<InsuficienciaRespiratoria>("INSUFICIENCIA_RESPIRATORIA", "id_insuficiencia", "descripcion");

        }

        public List<SoporteRespiratorio> ListarSoportes() {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<SoporteRespiratorio>("SOPORTE_RESPIRATORIO", "id_soporte", "descripcion");
        }
        
        


        public List<T> ListarCatalogo<T>(string tabla, string idColumna, string descripcionColumna, bool soloActivos = true) where T : Desplegables, new()
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<T>(tabla, idColumna, descripcionColumna, soloActivos);
        }
        public void AgregarItem(string tabla, string descripcion)
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            datos.AgregarItem(tabla, descripcion);
        }
        public void ModificarItem(string tabla, string idColumna, int id, string descripcion)
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            datos.ModificarItem(tabla, idColumna, id, descripcion);
        }
        public void EliminarItem(string tabla, string idColumna, int id)
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            datos.EliminarItem(tabla, idColumna, id);
        }
        public void ReactivarItem(string tabla, string idColumna, int id)
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            datos.ReactivarItem(tabla, idColumna, id);
        }
    }
}