using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public static String StrRutUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {

            StrRutUsuario = Convert.ToString(Session["strRutUsuario"]);
            NegAuditoria InsertarLog = new NegAuditoria();
            InsertarLog.InsertaAuditoria(StrRutUsuario, "LOGOUT", "ABANDONA EL SISTEMA ", "EL USUARIO ABANDONA EL SISTEMA WORKFLOW SOLICITUDES COMO " + StrRutUsuario);

            Session.Abandon();
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
