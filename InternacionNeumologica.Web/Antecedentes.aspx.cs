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
    public partial class Antecedentes : System.Web.UI.Page
    {
        public List<AntecedenteRespiratorio> ListaAntecedentesRespiratorios { get; set; }
        public List<Secuela> ListaSecuela { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ElementoCheckNegocio negociocheck = new ElementoCheckNegocio();
            ListaAntecedentesRespiratorios = negociocheck.ListarAntecedentesRespActivo();
            ListaSecuela = negociocheck.ListarSecuelaActivo();


            if (!IsPostBack)
            {
                DesplegableNegocio negocio = new DesplegableNegocio();
                List<InsuficienciaRespiratoria> listaInsuRespiratoria = negocio.ListarInsuficiencias();
                ddlInsRespiratoria.DataSource = listaInsuRespiratoria;
                ddlInsRespiratoria.DataValueField = "Id";
                ddlInsRespiratoria.DataTextField = "Descripcion";
                ddlInsRespiratoria.DataBind();

                List<SoporteRespiratorio> listaSoportes = negocio.ListarSoportes();
                ddlSoporte.DataSource = listaSoportes;
                ddlSoporte.DataValueField = "Id";
                ddlSoporte.DataTextField = "Descripcion";
                ddlSoporte.DataBind();
            }
        }



        protected void btnAtras_Click(object sender, EventArgs e)
        {
           

            Response.Redirect("Internacion.aspx");

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Internaciones auxInternacion = (Internaciones)Session["InternacionEnCurso"];
            if (auxInternacion.Tabaquismo == null)
            {
                auxInternacion.Tabaquismo = new Tabaquismo(); 
            }
            auxInternacion.Tabaquismo.IdTabaquismo = int.Parse(Request.Form["TipodeFumadores"]);

            if (!string.IsNullOrEmpty(txtPaquetesAnio.Text.Trim()))
            {
                auxInternacion.Paquetes_anio = int.Parse(txtPaquetesAnio.Text.Trim());
            }
            else
            {
                auxInternacion.Paquetes_anio = 0;
            }

            string seleccionadosResp = Request.Form["chkAntecedentes"]; //Va string porque el internet solo reconoce como texto plano
            Session["SeleccionRespiratorios"] = seleccionadosResp;

            string seleccionadosSecuela = Request.Form["chkSecuela"];
            Session["SeleccionSecuelas"] = seleccionadosSecuela;

            Session["InternacionEnCurso"] = auxInternacion;
            Response.Redirect("Comorbilidades.aspx");

        }


    }
}