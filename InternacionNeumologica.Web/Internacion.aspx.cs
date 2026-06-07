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
                ddlInfrecciones.DataSource = listaInfeccion;
                ddlInfrecciones.DataValueField = "Id";
                ddlInfrecciones.DataTextField = "Descripcion";
                ddlInfrecciones.DataBind();

                List<Obstructiva> listaObstrutiva = negocio.ListarObtructiva();
                ddlObtrucciones.DataSource = listaObstrutiva;
                ddlObtrucciones.DataValueField = "Id";
                ddlObtrucciones.DataTextField = "Descripcion";
                ddlObtrucciones.DataBind();

                List<Intersticiales> listaIntersticiales = negocio.ListarIntersticiales();
                ddlIntersticiales.DataSource = listaIntersticiales;
                ddlObtrucciones.DataValueField = "Id";
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

            Response.Redirect("Antecedentes.aspx");

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("BuscarPaciente.aspx");

        }


    }
}