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
    public partial class DetalleSolicitud : System.Web.UI.Page
    {
        public static String StrPrivilegio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int intFolioSolicitud;
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

       
    }
}