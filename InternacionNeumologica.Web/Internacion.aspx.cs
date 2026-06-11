using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio; 

namespace InternacionNeumologica.Web
{
    public partial class Internacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DesplegableNegocio negocio = new DesplegableNegocio();
                List<Origen> listaOrigen = negocio.ListarOrigen();
                ddlOrigen.DataSource = listaOrigen;
                ddlOrigen.DataValueField = "Id";
                ddlOrigen.DataTextField = "Descripcion";
                ddlOrigen.DataBind();

                List<DestinoEgreso> listaEgreso = negocio.ListarEgreso();
                ddlDestinoEgreso.DataSource = listaEgreso;
                ddlDestinoEgreso.DataValueField = "Id";
                ddlDestinoEgreso.DataTextField = "Descripcion";
                ddlDestinoEgreso.DataBind();

                List<Infeccion> listaInfeccion = negocio.ListarInfeccion();
                ddlInfecciones.DataSource = listaInfeccion;
                ddlInfecciones.DataValueField = "Id";
                ddlInfecciones.DataTextField = "Descripcion";
                ddlInfecciones.DataBind();

                List<Obstructiva> listaObstrutiva = negocio.ListarObtructiva();
                ddlObtrucciones.DataSource = listaObstrutiva;
                ddlObtrucciones.DataValueField = "Id";
                ddlObtrucciones.DataTextField = "Descripcion";
                ddlObtrucciones.DataBind();

                List<Intersticiales> listaIntersticiales = negocio.ListarIntersticiales();
                ddlIntersticiales.DataSource = listaIntersticiales;
                ddlIntersticiales.DataValueField = "Id";
                ddlIntersticiales.DataTextField = "Descripcion";
                ddlIntersticiales.DataBind();

                List<Pleura> listaPleura = negocio.ListarPleura();
                ddlPleura.DataSource = listaPleura;
                ddlPleura.DataValueField = "Id";
                ddlPleura.DataTextField = "Descripcion";
                ddlPleura.DataBind();

                List<Vascular> listaVascular = negocio.ListarVascular();
                ddlVasculares.DataSource = listaVascular;
                ddlVasculares.DataValueField = "Id";
                ddlVasculares.DataTextField = "Descripcion";
                ddlVasculares.DataBind();

                List<Oncologica> listaOncologica = negocio.ListarOncologica();
                ddlOncologicas.DataSource = listaOncologica;
                ddlOncologicas.DataValueField = "Id";
                ddlOncologicas.DataTextField = "Descripcion";
                ddlOncologicas.DataBind();

                List<Otros> listaOtro = negocio.ListarOtros();
                ddlOtros.DataSource = listaOtro;
                ddlOtros.DataValueField = "Id";
                ddlOtros.DataTextField = "Descripcion";
                ddlOtros.DataBind();


            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e) {
            Internaciones auxInternacion = new Internaciones();
            
            auxInternacion.FechaIngreso = DateTime.Parse(txtFechaIngreso.Text);
            auxInternacion.FechaEgreso = DateTime.Parse(txtFechaEgreso.Text);
            
            auxInternacion.Origen = new Origen();
            auxInternacion.Origen.Id = int.Parse(ddlOrigen.SelectedValue);
            
            auxInternacion.Destino = new DestinoEgreso();
            auxInternacion.Destino.Id = int.Parse(ddlDestinoEgreso.SelectedValue);

            auxInternacion.Infeccion = new Infeccion();
            auxInternacion.Infeccion.Id = int.Parse(ddlInfecciones.SelectedValue);

            auxInternacion.Obstructiva = new Obstructiva();
            auxInternacion.Obstructiva.Id = int.Parse(ddlObtrucciones.SelectedValue);

            auxInternacion.Intersticial = new Intersticiales();
            auxInternacion.Intersticial.Id = int.Parse(ddlIntersticiales.SelectedValue);


            auxInternacion.Pleura = new Pleura();
            auxInternacion.Pleura.Id = int.Parse(ddlPleura.SelectedValue);

            auxInternacion.Vascular = new Vascular();
            auxInternacion.Vascular.Id = int.Parse(ddlVasculares.SelectedValue);

            auxInternacion.Oncologica = new Oncologica();
            auxInternacion.Oncologica.Id = int.Parse(ddlOncologicas.SelectedValue);

            auxInternacion.Otro = new Otros();
            auxInternacion.Otro.Id = int.Parse(ddlOtros.SelectedValue);


            Session["InternacionEnCurso"] = auxInternacion;

            Response.Redirect("Antecedentes.aspx");

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("BuscarPaciente.aspx");

        }


    }
}