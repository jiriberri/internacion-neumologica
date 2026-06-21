using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using Dominio;
using Negocio;

namespace InternacionNeumologica.Web
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            Usuario usuario =
                negocio.ObtenerPorEmail(txtEmail.Text);

            if (usuario == null)
            {
                lblMensaje.CssClass =
                    "text-danger mt-3 d-block";

                lblMensaje.Text =
                    "No existe un usuario asociado a ese email.";

                return;
            }

            try
            {
                MailMessage mail = new MailMessage();

                mail.From =
                    new MailAddress("neumo.clinica@gmail.com");

                mail.To.Add(usuario.Email);

                mail.Subject =
                    "Recuperación de contraseña";

                mail.Body =
                    "Usuario: " + usuario.User +
                    "\nContraseña: " + usuario.Pass;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.Credentials =
                    new NetworkCredential(
                        "neumo.clinica.tp@gmail.com",
                        "zplufymrbtoivfbe");

                smtp.EnableSsl = true;

                smtp.Send(mail);

                lblMensaje.CssClass =
                    "text-success mt-3 d-block";

                lblMensaje.Text =
                    "Correo enviado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass =
                    "text-danger mt-3 d-block";

                lblMensaje.Text =
                    "Error al enviar correo: " + ex.Message;
            }
        }
    }
}