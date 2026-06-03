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
                List<Origen> lista = negocio.ListarOrigenes();
                ddlOrigen.DataSource = lista;
                ddlOrigen.DataValueField = "Id";
                ddlOrigen.DataTextField = "Descripcion";
                ddlOrigen.DataBind();
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