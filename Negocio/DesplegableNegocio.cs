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
            return datos.Listar<Infeccion>("INFECCIONES", "id_infeccion", "descripcion"); 

        }

        public List<Obstructiva> ListarObtructiva() {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Obstructiva>("OBSTRUCTIVAS", "id_obstructiva", "descripcion");

        }

        public List<Intersticiales> ListarIntersticiales()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Intersticiales>("INTERSTICIALES", "id_intersticial", "descripcion");

        }

        public List<Pleura> ListarPleura() {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Pleura>("PLEURA", "id_pleura", "descripcion");

        }

        public List<Vascular> ListarVascular()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Vascular>("VASCULARES", "id_vascular", "descripcion");

        }

        public List<Oncologica> ListarOncologica()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Oncologica>("ONCOLOGICAS", "id_oncologica", "descripcion");

        }

        public List<Otros> ListarOtros()
        {

            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Otros>("OTROS", "id_otro", "descripcion");

        }

        public List<InsuficienciaRespiratoria> ListarInsuficiencias() {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<InsuficienciaRespiratoria>("INSUFICIENCIA_RESPIRATORIA", "id_insuficiencia", "descripcion");

        }

        public List<SoporteRespiratorio> ListarSoportes() {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<SoporteRespiratorio>("SOPORTE_RESPIRATORIO", "id_soporte", "descripcion");
        }
        
        


        public List<T> ListarCatalogo<T>(string tabla, string idColumna, string descripcionColumna) where T : Despegables, new()
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<T>(tabla, idColumna, descripcionColumna);
        }
    
    
     
    
    
    }
}