using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class Seguimiento : System.Web.UI.Page
    {
        public static int intFolioSolicitud { get; set; }
        public static String StrPrivilegio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
     
            int intCodTipoSolicitud;
            List<WorkflowSolicitudes.Entidades.DetalleSolicitud> LstDetalleSolicitud = new List<WorkflowSolicitudes.Entidades.DetalleSolicitud>();
            NegTipoSolicitud TipoSolicitud = new NegTipoSolicitud();

            if (!Page.IsPostBack)
            
                intFolioSolicitud = Convert.ToInt32(Request.QueryString["folio"]);
                lblFolio.Text = Request.QueryString["folio"];
                LstDetalleSolicitud = lee_grilla(Convert.ToInt32(Request.QueryString["folio"]));

                foreach (WorkflowSolicitudes.Entidades.DetalleSolicitud Deta in LstDetalleSolicitud)
                {
                    intCodTipoSolicitud = Deta.intCodTipoSolicitud;
                    LblDesctipoSolicitud.Text = TipoSolicitud.ObtenerDescTipoSolicitud(intCodTipoSolicitud);
                }
                
             

        }

        public  List<WorkflowSolicitudes.Entidades.DetalleSolicitud> lee_grilla(int folio)
        {
            NegDetalleSolicitud   NegDetaSolicitud = new NegDetalleSolicitud();

            List<WorkflowSolicitudes.Entidades.DetalleSolicitud> LstDetalleSolicitud = new List<WorkflowSolicitudes.Entidades.DetalleSolicitud>();
            LstDetalleSolicitud = NegDetaSolicitud.ObtenerDetalleSolicitud(folio);          
            GridView1.DataSource = LstDetalleSolicitud; 
            GridView1.DataBind();

            return LstDetalleSolicitud;

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            int intSecuencia = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VerAdjuntos.aspx?Folio=" + intFolioSolicitud + "&Secuencia=" + intSecuencia + "&Tipo=A', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }

       
    }
}