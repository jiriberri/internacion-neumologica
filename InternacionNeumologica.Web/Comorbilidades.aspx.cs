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
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

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
            string cardiovasculares = Request.Form["chkCardiovascular"];
            string NeuroSel = Request.Form["chkNeurologico"];
            string MetaboSel= Request.Form["chkMetabolica"];
            string OncologiaSel = Request.Form["chkOncologica"];
            string SueñoSel = Request.Form["chkSueño"];
            string InmunologicaSel = Request.Form["chkInmunologica"];
           
            string respiratoriosSel = (string)Session["SeleccionRespiratorios"];
            string secuelasSel = (string)Session["SeleccionSecuelas"];
            string cirugiasSel = (string)Session["SeleccionCirugias"];
            string expoSel = (string)Session["SeleccionExpo"];


            Internaciones internacionFinal = (Internaciones)Session["InternacionEnCurso"];
            InternacionNegocio Negocio = new InternacionNegocio();
            ElementoCheckNegocio CheckboxNegocio = new ElementoCheckNegocio();


            try
            {
                CheckboxNegocio.guardarCardiovascularPaciente(internacionFinal.IdPaciente, cardiovasculares);
                CheckboxNegocio.guardarNeurologicoPaciente(internacionFinal.IdPaciente, NeuroSel);
                CheckboxNegocio.guardarMetabolicaPaciente(internacionFinal.IdPaciente, MetaboSel);
                CheckboxNegocio.guardarSueñoPaciente(internacionFinal.IdPaciente, SueñoSel);
                CheckboxNegocio.guardarInmunologPaciente(internacionFinal.IdPaciente, InmunologicaSel);
                CheckboxNegocio.guardarOncologiaPaciente(internacionFinal.IdPaciente, OncologiaSel);
              
                CheckboxNegocio.guardarRespiratorioPaciente(internacionFinal.IdPaciente, respiratoriosSel);
                CheckboxNegocio.guardarSecuelaPaciente(internacionFinal.IdPaciente, secuelasSel);
                CheckboxNegocio.guardarCirugiaPaciente(internacionFinal.IdPaciente, cirugiasSel);
                CheckboxNegocio.guardarExposicionPaciente(internacionFinal.IdPaciente,expoSel);

                Negocio.agregar(internacionFinal);

                Session["InternacionEnCurso"] = null;
                Response.Redirect("BuscarPaciente.aspx?exito=true");
            }
            catch (Exception ex)
            {
                Session["ErrorActual"] = "Ocurrió un error al guardar la internación: " + ex.Message;
                Response.Redirect("Error.aspx");
            }
        }



        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("Antecedentes.aspx");

        }









    }
}