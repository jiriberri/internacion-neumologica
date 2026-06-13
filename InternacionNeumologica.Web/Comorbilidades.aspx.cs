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
        protected void Page_Load(object sender, EventArgs e)
        {
            ElementoCheckNegocio negociocheck = new ElementoCheckNegocio();
            ListaCardioVascular = negociocheck.ListarCardioVasActivo();


        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
             // string cardiovasculares = Request.Form["chkCardio"];
            Internaciones internacionFinal = (Internaciones)Session["InternacionEnCurso"];
            InternacionNegocio negocio = new InternacionNegocio();
            try
            {
                negocio.agregar(internacionFinal);
                Session["InternacionEnCurso"] = null;
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