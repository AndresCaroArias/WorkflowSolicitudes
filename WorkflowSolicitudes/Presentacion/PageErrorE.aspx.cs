using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class PageErrorE : System.Web.UI.Page
    {
        public static String strError { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Funciones FuncionesDesencriptar = new Funciones();

            strError = Convert.ToString(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["TypeError"])));
            lblError.Text = strError;


        }
    }
}