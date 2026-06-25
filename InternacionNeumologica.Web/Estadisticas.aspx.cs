using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;



// Esta página solo recopila los criterios de búsqueda.
// La generación del reporte se realiza en Reporte.aspx.
namespace InternacionNeumologica.Web
{
    public partial class Estadisticas : System.Web.UI.Page
    {
            public List<Cardiovascular> ListaCardioVascular { get; set; }

            public List<Neurologico> ListaNeurologico { get; set; }

            public List<Metabolica> ListaMetabolica { get; set; }

            public List<Sueño> ListaSueño { get; set; }

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

            if (!IsPostBack)
            {
                CargarCombos();
                CargarComorbilidades();
            }
        }
        private void CargarCombos()
        {
            DesplegableNegocio negocio = new DesplegableNegocio();


            ddlInfecciones.DataSource = negocio.ListarInfeccion();
            ddlInfecciones.DataValueField = "Id";
            ddlInfecciones.DataTextField = "Descripcion";
            ddlInfecciones.DataBind();
            ddlInfecciones.Items.Insert(0, new ListItem("Todos", ""));

            ddlObstructivas.DataSource = negocio.ListarObtructiva();
            ddlObstructivas.DataValueField = "Id";
            ddlObstructivas.DataTextField = "Descripcion";
            ddlObstructivas.DataBind();
            ddlObstructivas.Items.Insert(0, new ListItem("Todas", ""));

            ddlIntersticiales.DataSource = negocio.ListarIntersticiales();
            ddlIntersticiales.DataValueField = "Id";
            ddlIntersticiales.DataTextField = "Descripcion";
            ddlIntersticiales.DataBind();
            ddlIntersticiales.Items.Insert(0, new ListItem("Todas", ""));

            ddlPleura.DataSource = negocio.ListarPleura();
            ddlPleura.DataValueField = "Id";
            ddlPleura.DataTextField = "Descripcion";
            ddlPleura.DataBind();
            ddlPleura.Items.Insert(0, new ListItem("Todas", ""));

            ddlVasculares.DataSource = negocio.ListarVascular();
            ddlVasculares.DataValueField = "Id";
            ddlVasculares.DataTextField = "Descripcion";
            ddlVasculares.DataBind();
            ddlVasculares.Items.Insert(0, new ListItem("Todas", "")); 

            ddlOncologicas.DataSource = negocio.ListarOncologica();
            ddlOncologicas.DataValueField = "Id";
            ddlOncologicas.DataTextField = "Descripcion";
            ddlOncologicas.DataBind();
            ddlOncologicas.Items.Insert(0, new ListItem("Todas", ""));

            ddlOtros.DataSource = negocio.ListarOtros();
            ddlOtros.DataValueField = "Id";
            ddlOtros.DataTextField = "Descripcion";
            ddlOtros.DataBind();
            ddlOtros.Items.Insert(0, new ListItem("Todas", ""));

            ddlInsuficiencia.DataSource = negocio.ListarInsuficiencias();
            ddlInsuficiencia.DataValueField = "Id";
            ddlInsuficiencia.DataTextField = "Descripcion";
            ddlInsuficiencia.DataBind();
            ddlInsuficiencia.Items.Insert(0, new ListItem("Todas", ""));

            ddlSoporte.DataSource = negocio.ListarSoportes();
            ddlSoporte.DataValueField = "Id";
            ddlSoporte.DataTextField = "Descripcion";
            ddlSoporte.DataBind();
            ddlSoporte.Items.Insert(0, new ListItem("Todas", ""));

            ddlDestino.DataSource = negocio.ListarEgreso();
            ddlDestino.DataValueField = "Id";
            ddlDestino.DataTextField = "Descripcion";
            ddlDestino.DataBind();
            ddlDestino.Items.Insert(0, new ListItem("Todos", ""));

        }

        private void CargarComorbilidades()
        {
            ElementoCheckNegocio negocio = new ElementoCheckNegocio();

            ListaCardioVascular = negocio.ListarCardioVasActivo();
            ListaNeurologico = negocio.ListarNeurologicos();
            ListaMetabolica = negocio.ListarMetabolicas();
            ListaSueño = negocio.ListarSueños();
            ListaInmunologica = negocio.ListarInmunologicas();
            ListaOncologica = negocio.ListarOncologicaComorbilidades();
        }




        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            FiltroReporte filtro = new FiltroReporte();

            // Fechas
            if (!string.IsNullOrEmpty(txtFechaDesde.Text))
                filtro.FechaDesde = DateTime.Parse(txtFechaDesde.Text);

            if (!string.IsNullOrEmpty(txtFechaHasta.Text))
                filtro.FechaHasta = DateTime.Parse(txtFechaHasta.Text);

            // Edad
            if (!string.IsNullOrEmpty(txtEdadMinima.Text))
                filtro.EdadMinima = int.Parse(txtEdadMinima.Text);

            if (!string.IsNullOrEmpty(txtEdadMaxima.Text))
                filtro.EdadMaxima = int.Parse(txtEdadMaxima.Text);

            // Sexo
            if (ddlSexo.SelectedValue != "Todos")
                filtro.Sexo = ddlSexo.SelectedValue;

            // Soporte
            if (!string.IsNullOrEmpty(ddlSoporte.SelectedValue))
                filtro.SoporteRespiratorio = int.Parse(ddlSoporte.SelectedValue);

            //Insuficiencia respirtoria
            if (!string.IsNullOrEmpty(ddlInsuficiencia.SelectedValue))
                filtro.InsuficienciaRespiratoria = int.Parse(ddlInsuficiencia.SelectedValue);

            // Destino de egreso
            if (!string.IsNullOrEmpty(ddlDestino.SelectedValue))
                filtro.DestinoEgreso = int.Parse(ddlDestino.SelectedValue);
            // Infecciones
            if (!string.IsNullOrEmpty(ddlInfecciones.SelectedValue))
                filtro.Infeccion = int.Parse(ddlInfecciones.SelectedValue);

            // Obstructivas
            if (!string.IsNullOrEmpty(ddlObstructivas.SelectedValue))
                filtro.Obstructiva = int.Parse(ddlObstructivas.SelectedValue);

            // Intersticiales
            if (!string.IsNullOrEmpty(ddlIntersticiales.SelectedValue))
                filtro.Intersticial = int.Parse(ddlIntersticiales.SelectedValue);

            // Pleura
            if (!string.IsNullOrEmpty(ddlPleura.SelectedValue))
                filtro.Pleura = int.Parse(ddlPleura.SelectedValue);

            // Vasculares
            if (!string.IsNullOrEmpty(ddlVasculares.SelectedValue))
                filtro.Vascular = int.Parse(ddlVasculares.SelectedValue);

            // Oncologicas
            if (!string.IsNullOrEmpty(ddlOncologicas.SelectedValue))
                filtro.Oncologica = int.Parse(ddlOncologicas.SelectedValue);

            // Otros
            if (!string.IsNullOrEmpty(ddlOtros.SelectedValue))
                filtro.Otro = int.Parse(ddlOtros.SelectedValue);
            // Comorbilidades

            filtro.Cardiovasculares = ObtenerSeleccionados("filtroCardiovascular");

            filtro.Metabolicas = ObtenerSeleccionados("filtroMetabolica");

            filtro.Neurologicas = ObtenerSeleccionados("filtroNeurologico");

            filtro.Inmunologicas = ObtenerSeleccionados("filtroInmunologica");

            filtro.Oncologicas = ObtenerSeleccionados("filtroOncologica");

            filtro.Sueño = ObtenerSeleccionados("filtroSueño");

            //Response.Write(string.Join(",", filtro.Cardiovasculares));
            //Response.End();//(para ver el resultado de la función ObtenerSeleccionados)

            Session["FiltroReporte"] = filtro;

            Response.Redirect("Reporte.aspx");
        }

        private List<int> ObtenerSeleccionados(string nombreControl)
        {
            List<int> lista = new List<int>();

            string valores = Request.Form[nombreControl];

            if (string.IsNullOrWhiteSpace(valores))
                return lista;

            foreach (string item in valores.Split(','))
                lista.Add(int.Parse(item));

            return lista;
        }
    }
}
