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
        public static String StrRutAlumno { get; set; }
        public static int intFolioSolicitud { get; set; }
        public static int intCodTipoSolicitud { get; set; }
        public static String strPrivilegio { get; set; }
        public static String strSession { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            StrRutAlumno = Convert.ToString(Session["StrRutAlumno"]);
            List<WorkflowSolicitudes.Entidades.DetalleSolicitud> LstDetalleSolicitud = new List<WorkflowSolicitudes.Entidades.DetalleSolicitud>();
            NegTipoSolicitud TipoSolicitud = new NegTipoSolicitud();
       

            if (!Page.IsPostBack)
            {
                Funciones FuncionesDesencriptar = new Funciones();
                if (!(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["folio"]))).Equals("Error_Autorizacion") &&
                    !(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["session"]))).Equals("Error_Autorizacion"))
                {
                    intFolioSolicitud = Convert.ToInt32(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["folio"])));
                    strSession = Convert.ToString(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["session"])));

                    if (!strSession.Equals(StrRutAlumno))
                    {
                        string Error = HttpUtility.UrlEncode(FuncionesDesencriptar.Encrypt("Error_Autorizacion"));
                        Response.Redirect("PageErrorE.aspx?TypeError=" + Error);
                    }
                    else
                    {
                        // Sin Accion
                    }
                
                
                }
                else
                {
                    string Error = HttpUtility.UrlEncode(FuncionesDesencriptar.Encrypt("Error_Autorizacion"));
                    Response.Redirect("PageErrorE.aspx?TypeError=" + Error);
                }

                lblFolio.Text = Convert.ToString(intFolioSolicitud);
                LstDetalleSolicitud = lee_grilla(intFolioSolicitud);

                foreach (WorkflowSolicitudes.Entidades.DetalleSolicitud Deta in LstDetalleSolicitud)
                {
                    intCodTipoSolicitud = Deta.intCodTipoSolicitud;
                    LblDesctipoSolicitud.Text = TipoSolicitud.ObtenerDescTipoSolicitud(intCodTipoSolicitud);
                }
    

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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Funciones FuncionesEncriptar = new Funciones();
            string session = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(StrRutAlumno));
            Response.Redirect("BandejaEntrada.aspx?session=" + session);
        }

       
    }
}