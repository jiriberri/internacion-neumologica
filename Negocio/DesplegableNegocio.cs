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

        public List<Motivo> ListarMotivo()
        {
            DesplegablesDatos datos = new DesplegablesDatos();
            return datos.Listar<Motivo>("MOTIVO_INTERNACION", "id_motivo", "descripcion");

        }
    }
}