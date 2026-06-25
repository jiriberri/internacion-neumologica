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

        public List<Cirugia> ListaCirugia { get; set; } 

        public List<ExposicionAmbiental> ListaExpoAmb { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            ElementoCheckNegocio negociocheck = new ElementoCheckNegocio();
            ListaAntecedentesRespiratorios = negociocheck.ListarAntecedentesRespActivo();
            ListaSecuela = negociocheck.ListarSecuelaActivo();
            ListaCirugia = negociocheck.ListarCirugiaActivo();
            ListaExpoAmb = negociocheck.ListarExpoAmb();

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
            string tipoFumador = Request.Form["TipodeFumadores"];

            Internaciones auxInternacion = (Internaciones)Session["InternacionEnCurso"];
           
            if (string.IsNullOrEmpty(tipoFumador))
            {
                lblTipoFumador.Visible = true;
                return;
            }

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

            auxInternacion.Insuficiencia = new InsuficienciaRespiratoria();
            auxInternacion.Insuficiencia.Id = int.Parse(ddlInsRespiratoria.SelectedValue);

            auxInternacion.Soporte= new SoporteRespiratorio();
            auxInternacion.Soporte.Id = int.Parse(ddlSoporte.SelectedValue);


            //Todos lo Session que guardan el checkbox



            string seleccionadosResp = Request.Form["chkAntecedentes"]; //Va string porque lo reconoce como texto plano
            Session["SeleccionRespiratorios"] = seleccionadosResp;
            
            string seleccionadosSecuela = Request.Form["chkSecuela"];
            Session["SeleccionSecuelas"] = seleccionadosSecuela;

            string seleccionadosCirugia = Request.Form["chkCirugias"];
            Session["SeleccionCirugias"] = seleccionadosCirugia;

            string seleccionadosExpAmb = Request.Form["chkExposiciones"];
            Session["SeleccionExpo"] = seleccionadosExpAmb;


            Session["InternacionEnCurso"] = auxInternacion;
            
            Response.Redirect("Comorbilidades.aspx");

        }


    }
}