using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class RecordarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestituir_Click(object sender, EventArgs e)
        {
            if (txtRutUsuario.Text.Equals(String.Empty))
            {
                LblMensaje.Text = "ERROR: Ingrese su Rut";

                return;
            }

            NegUsuario CrearNuevaConstraseña = new NegUsuario();
            CrearNuevaConstraseña.RecuperoPassword(txtRutUsuario.Text);
            Response.Redirect("Login.aspx");
        }
    }
}