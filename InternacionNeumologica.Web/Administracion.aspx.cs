using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

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

                if (btnAgregarItem.Text == "Guardar Cambios")
                {
                    int id = int.Parse(hfIdEditando.Value);
                    string columnaId = ObtenerColumnaId(tablaDestino);

                    negocio.ModificarItem(tablaDestino, columnaId, id, nuevaDescripcion);

                    ResetearFormularioEdicion();
                }
                else
                {
                    negocio.AgregarItem(tablaDestino, nuevaDescripcion);
                }

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

            bool filtrarSoloActivos = !chkMostrarDeshabilitados.Checked;

            DesplegableNegocio negocio = new DesplegableNegocio();

            dgvCatalogoGenerico.DataSource = negocio.ListarCatalogo<ItemCatalogo>(tablaSeleccionada, columnaId, "descripcion", filtrarSoloActivos);
            dgvCatalogoGenerico.DataBind();
        }
        private string ObtenerColumnaId(string tabla)
        {
            switch (tabla)
            {
                case "ANTECEDENTE_RESPIRATORIO": return "id_antecedente";
                case "CIRUGIA": return "id_cirugia";
                case "SECUELA": return "id_secuela";
                case "EXPOSICION_AMBIENTAL": return "id_exposicion";
                case "TABAQUISMO": return "id_tabaquismo";
                case "ORIGEN_INTERNACION": return "id_origen";
                case "DESTINO_EGRESO": return "id_destino";
                case "INSUFICIENCIA_RESPIRATORIA": return "id_insuficiencia";
                case "SOPORTE_RESPIRATORIO": return "id_soporte";
                case "COMORBILIDAD_CARDIOVASCULAR": return "id_cardiovascular";
                case "COMORBILIDAD_METABOLICA": return "id_metabolica";
                case "COMORBILIDAD_NEUROLOGICA": return "id_neurologico";
                case "COMORBILIDAD_SUEÑO": return "id_sueño";
                case "COMORBILIDAD_INMUNOLOGICA": return "id_inmunologica";
                case "COMORBILIDAD_ONCOLOGICA": return "id_oncologica";
                case "DIAGNOSTICO_INFECCIONES": return "id_infeccion";
                case "DIAGNOSTICO_OBSTRUCTIVAS": return "id_obstructiva";
                case "DIAGNOSTICO_INTERSTICIALES": return "id_intersticial";
                case "DIAGNOSTICO_PLEURA": return "id_pleura";
                case "DIAGNOSTICO_VASCULARES": return "id_vascular";
                case "DIAGNOSTICO_ONCOLOGICAS": return "id_oncologica";
                case "DIAGNOSTICO_OTROS": return "id_otro";
                default: return "";
            }
        }

        protected void btnEditarItemTabla_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //Guardo lo que esta dentro de CommandArgument en dos strings id y descripcion
            string[] argumentos = btn.CommandArgument.Split('|');
            string id = argumentos[0];
            string descripcion = argumentos[1];

            hfIdEditando.Value = id;
            txtNuevaDescripcion.Text = descripcion;

            btnAgregarItem.Text = "Guardar Cambios";
            btnAgregarItem.CssClass = "btn btn-warning w-100";
            txtNuevaDescripcion.CssClass = "form-control border border-warning border-3 border-opacity-50 pt-1 pb-1";
        }
        private void ResetearFormularioEdicion()
        {
            btnAgregarItem.Text = "Agregar a la Tabla";
            btnAgregarItem.CssClass = "btn btn-success w-100";
            hfIdEditando.Value = "";
            txtNuevaDescripcion.CssClass = "form-control";
        }

        protected void btnEliminarItem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int id = int.Parse(btn.CommandArgument);
            string tablaActive = ddlCatalogos.SelectedValue;
            string columnaId = ObtenerColumnaId(tablaActive);

            try
            {
                DesplegableNegocio negocio = new DesplegableNegocio();

                negocio.EliminarItem(tablaActive, columnaId, id);

                if (hfIdEditando.Value == id.ToString())
                {
                    ResetearFormularioEdicion();
                    txtNuevaDescripcion.Text = "";
                }

                CargarGrillaCatalogo();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void chkMostrarDeshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlCatalogos.SelectedValue != "0")
            {
                pnlAltaCatalogo.Visible = !chkMostrarDeshabilitados.Checked;
                CargarGrillaCatalogo();
            }
        }

        protected void btnReactivarItem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            string tablaActive = ddlCatalogos.SelectedValue;
            string columnaId = ObtenerColumnaId(tablaActive);

            try
            {
                DesplegableNegocio negocio = new DesplegableNegocio();
                negocio.ReactivarItem(tablaActive, columnaId, id);
                CargarGrillaCatalogo();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
        protected void btnBuscarPacienteAdmin_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente paciente = negocio.BuscarPorDni(txtDniBuscar.Text);

            if (paciente != null)
            {
                txtModNombre.Text = paciente.Nombre;
                txtModApellido.Text = paciente.Apellido;
                txtModDni.Text = paciente.Dni;
                txtModDomicilio.Text = paciente.Domicilio;
                txtModTel.Text = paciente.Telefono;
                txtModDate.Text = paciente.FechaNacimiento.ToString("yyyy-MM-dd");

                Session["PacienteEditar"] = paciente.IdPaciente;

                lblMensajeMod.CssClass = "text-success fw-bold";
                lblMensajeMod.Text = "";
            }
            else
            {
                lblMensajeMod.CssClass = "text-danger fw-bold";
                lblMensajeMod.Text = "No se encontró un paciente con el DNI ingresado.";
            }
        }

        protected void btnGuardarMod_Click(object sender, EventArgs e)
        {
            if (Session["PacienteEditar"] == null) return;

            Paciente paciente = new Paciente();

            paciente.IdPaciente = (int)Session["PacienteEditar"];

            paciente.Nombre = txtModNombre.Text;
            paciente.Apellido = txtModApellido.Text;
            paciente.Dni = txtModDni.Text;
            paciente.Domicilio = txtModDomicilio.Text;
            paciente.Telefono = txtModTel.Text;
            paciente.FechaNacimiento = DateTime.ParseExact(
                txtModDate.Text,
                "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

            PacienteNegocio negocio = new PacienteNegocio();
            try
            {
                negocio.ModificarPaciente(paciente);

                lblMensajeMod.CssClass = "text-success fw-bold";
                lblMensajeMod.Text = "✔ Los datos del paciente se actualizaron correctamente.";

                Session.Remove("PacienteEditar");
            }
            catch
            {
                lblMensajeMod.CssClass = "text-danger fw-bold";
                lblMensajeMod.Text = "✖ Ocurrió un error al guardar las modificaciones.";
            }
        }

        protected void btnCancelarMod_Click(object sender, EventArgs e)
        {
            txtDniBuscar.Text = "";
            txtModNombre.Text = "";
            txtModApellido.Text = "";
            txtModDni.Text = "";
            txtModDomicilio.Text = "";
            txtModTel.Text = "";
            txtModDate.Text = "";
            lblMensajeMod.Text = "";

            Session.Remove("PacienteEditar");
        }
    }
}