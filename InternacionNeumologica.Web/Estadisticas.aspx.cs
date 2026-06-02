using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace InternacionNeumologica.Web
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = txtFiltroBusqueda.Text;
                PacienteNegocio negocio = new PacienteNegocio();

                List<Paciente> listaFiltrada = negocio.BuscarPorDNIoApellido(texto);

                dgvPacientesFiltrados.DataSource = listaFiltrada;
                dgvPacientesFiltrados.DataBind();
            }
            catch(Exception ex) {

                throw ex;

            }
        }





    }
}