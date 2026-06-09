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
        protected void Page_Load(object sender, EventArgs e)
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



        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("Internacion.aspx");

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Comorbilidades.aspx");

        }


    }
}