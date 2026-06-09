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
    public partial class Administracion : System.Web.UI.Page
    {

        private void CargarGrilla()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            dgvUsuarios.DataSource = negocio.Listar();
            dgvUsuarios.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];//el usuario esta guardado en sesion y si no es admin enonces no se muestra el panel de administracion)por si quieren entrar con url gaurdada

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (!usuario.Admin)
            {
                Response.Redirect("Default.aspx");
                return;
            }
            if (!IsPostBack)// cada vez que se recarga la pagina se vuelve a cargar la grilla, entonces con esto se hace que solo se cargue la grilla la primera vez que se carga la pagina
            {
                CargarGrilla();
            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioFormulario.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string id = btn.CommandArgument;

            Response.Redirect(
                "UsuarioFormulario.aspx?id=" + id);
        }

        protected void ddlCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCatalogos.SelectedValue != "0")
            {
                phFormularioCatalogo.Visible = true;
                CargarGrillaCatalogo();
                txtNuevaDescripcion.Text = "";
            }
            else
            {
                phFormularioCatalogo.Visible = false;
            }
        }
        protected void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNuevaDescripcion.Text))
                return;

            try
            {
                string tablaDestino = ddlCatalogos.SelectedValue;
                string nuevaDescripcion = txtNuevaDescripcion.Text.Trim();

                DesplegableNegocio negocio = new DesplegableNegocio();
                negocio.AgregarItem(tablaDestino, nuevaDescripcion);

                CargarGrillaCatalogo();
                txtNuevaDescripcion.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
        private void CargarGrillaCatalogo()
        {
            string tablaSeleccionada = ddlCatalogos.SelectedValue;
            string columnaId = ObtenerColumnaId(tablaSeleccionada);

            DesplegableNegocio negocio = new DesplegableNegocio();

            dgvCatalogoGenerico.DataSource = negocio.ListarCatalogo<ItemCatalogo>(tablaSeleccionada, columnaId, "descripcion");
            dgvCatalogoGenerico.DataBind();
        }
        private string ObtenerColumnaId(string tabla)
        {
            switch (tabla)
            {
                case "ANTECEDENTE_RESPIRATORIO": return "id_antecedente";
                case "COMORBILIDAD": return "id_comorbilidad";
                case "DESTINO_EGRESO": return "id_destino";
                case "INFECCIONES": return "id_infeccion";
                case "INTERSTICIALES": return "id_intersticial";
                case "OBSTRUCTIVAS": return "id_obstructiva";
                case "ONCOLOGICAS": return "id_oncologica";
                case "PLEURA": return "id_pleura";
                case "VASCULARES": return "id_vascular";
                case "EXPOSICION_AMBIENTAL": return "id_exposicion";
                case "INSUFICIENCIA_RESPIRATORIA": return "id_insuficiencia";
                case "ORIGEN_INTERNACION": return "id_origen";
                case "SOPORTE_RESPIRATORIO": return "id_soporte";
                case "TABAQUISMO": return "id_tabaquismo";
                case "OTROS": return "id_otro";
                default: return "";
            }
        }
    }
}