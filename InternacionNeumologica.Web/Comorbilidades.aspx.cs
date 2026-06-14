using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace InternacionNeumologica.Web
{
    public partial class Comorbilidades : System.Web.UI.Page
    {
        public List<Cardiovascular> ListaCardioVascular { get; set; } 
        public List<Neurologico> ListaNeurologico { get; set; }
        public List<Metabolica> ListaMetabolica { get; set; } 
        public List<Sueño> ListaSueño {get; set; } 

        public List<Inmunologica> ListaInmunologica { get; set; }

        public List<OncologicaComorbilidad> ListaOncologica { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ElementoCheckNegocio negociocheck = new ElementoCheckNegocio();
            ListaCardioVascular = negociocheck.ListarCardioVasActivo();
            ListaNeurologico = negociocheck.ListarNeurologicos();
            ListaMetabolica = negociocheck.ListarMetabolicas();
            ListaSueño = negociocheck.ListarSueños();
            ListaInmunologica = negociocheck.ListarInmunologicas();
            ListaOncologica = negociocheck.ListarOncologicaComorbilidades();
        
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string cardiovasculares = Request.Form["chkCardio"];
            string oncologiaSel = Request.Form["chkOncologica"];


            Internaciones internacionFinal = (Internaciones)Session["InternacionEnCurso"];
            InternacionNegocio negocio = new InternacionNegocio();
            ElementoCheckNegocio checkboxNegocio = new ElementoCheckNegocio();
           

            try
            {
                negocio.agregar(internacionFinal);

                checkboxNegocio.guardarOncologiaPaciente(internacionFinal.IdPaciente, oncologiaSel);





                Session["InternacionEnCurso"] = null;
                Response.Redirect("BuscarPaciente.aspx?exito=true");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("Antecedentes.aspx");

        }









    }
}