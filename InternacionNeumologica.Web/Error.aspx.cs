using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternacionNeumologica.Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["ErrorActual"] != null)
                {
                    lblMensajeError.Text = Session["ErrorActual"].ToString();

                    Session.Remove("ErrorActual");
                }
                else
                {
                    lblMensajeError.Text = "No se ha especificado un mensaje de error detallado.";
                }
            }
        }
    }
}