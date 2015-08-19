using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using WorkflowSolicitudes.Entidades;
using System.Data;
using System.Text;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class BandejaEntrada : System.Web.UI.Page
    {
        public static String StrRutAlumno { get; set; }
        public static String StrCodCarrera { get; set; }
        public static String StrCodCli { get; set; }
        public static String strSession { get; set; }
        private static DataTable movSource;
        private static String orden = "ASC";

        protected void Page_Load(object sender, EventArgs e)
        {
            
           

                if (!Page.IsPostBack)
                {
                   StrCodCli = "20001IECIRE004";   /// Despues borrar esta linea de codigo 


                    /// Para desarrollo comentar desde aqui

                    //Funciones FuncionesDesencriptar = new Funciones();

                    //string strOrigen = Request.ServerVariables["HTTP_REFERER"];
                    ////if (strOrigen.Equals("http://umas.ipciisa.cl/alumnosnetTR/Workflow.asp"))
                    //if (strOrigen.Equals("http://10.0.0.2/Prueba.asp"))
                    //{
                    //    //if ((!(Convert.ToString(Request.Form["codcli1"])).Equals(String.Empty)) && (Request.ServerVariables["HTTP_REFERER"].Equals("http://umas.ipciisa.cl/alumnosnetTR/Workflow.asp")))
                    //    if ((!(Convert.ToString(Request.Form["codcli1"])).Equals(String.Empty)) && (Request.ServerVariables["HTTP_REFERER"].Equals("http://10.0.0.2/Prueba.asp")))
                    //    {
                    //        if (!(Request.Form["codcli1"]).Equals(string.Empty))
                    //        {

                    //            StrCodCli = Convert.ToString(Request.Form["codcli1"]); // Linea para que rescate desde U+ el CODCLI  

                    //        }
                    //        else
                    //        {
                    //            //sin accion
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    strSession = Convert.ToString(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["session"])));
                    //    if (!strSession.Equals(StrRutAlumno))
                    //    {
                    //        string Error = HttpUtility.UrlEncode(FuncionesDesencriptar.Encrypt("Error_Autorizacion"));
                    //        Response.Redirect("PageErrorE.aspx?TypeError=" + Error);
                    //    }
                    //    else
                    //    {
                    //        // Sin Accion
                    //    }
                    //}
	                    
                    // para desarrollo comentar hasta aqui


                    Obtener_RutAlumno(StrCodCli);
                    lee_grilla(StrRutAlumno);
                    lee_alumnos(StrCodCli);
                    Session["StrRutAlumno"] = StrRutAlumno;
                    Session["StrCodCarrera"] = StrCodCarrera;
                    Session["StrCodCli"] = StrCodCli;
                    
                }
        }

        private void Obtener_RutAlumno(string StrCodCli)
         {
             List<Alumnos> LstAlumnnos = new List<Alumnos>();
             NegAlumnos NegAlumno = new NegAlumnos();

             LstAlumnnos = NegAlumno.ObtenerInfoAlumnoByCodCli(StrCodCli);

             foreach (Alumnos alumno in LstAlumnnos)
             {
                 StrRutAlumno = alumno.StrRut;
             }
         }   

        private void lee_grilla(string StrRutAlumno) 
        {
            NegSolicitud NegSolicitudes = new NegSolicitud();
            GridView1.DataSource = NegSolicitudes.ObtenerSolicitudes(StrRutAlumno);
            GridView1.DataBind();
        }

        private void lee_alumnos(string StrCodCli)
        {
            List<Alumnos> LstAlumnnos = new List<Alumnos>();
            NegAlumnos NegAlumno = new NegAlumnos();

            LstAlumnnos = NegAlumno.ObtenerInfoAlumnoByCodCli(StrCodCli);
            
            foreach(Alumnos alumno in LstAlumnnos)
            {
                StringBuilder strnombre = new StringBuilder();
                strnombre.Append(alumno.StrNombre);
                strnombre.Append(" ");
                strnombre.Append(alumno.StrApPaterno);
                strnombre.Append(" ");
                strnombre.Append(alumno.StrApMaterno);


                lblNombre.Text  = strnombre.ToString();
                lblCarrera.Text = alumno.StrNombreCarrera;
                StrCodCarrera   = alumno.StrCodCarrera;

                if (alumno.StrJornada.Equals("D")) 
                   {
                       LblJornada.Text = "DIURNA";
                  }

                if (alumno.StrJornada.Equals("V"))
                {
                    LblJornada.Text = "VESPERTINA";

                } 

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
      
            GridViewRow row = GridView1.SelectedRow;
            int intFolio = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);

            Funciones FuncionesEncriptar = new Funciones();
            string folio = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(Convert.ToString(intFolio)));
            string session = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(StrRutAlumno));

            Response.Redirect("DetalleSolicitud.aspx?folio=" + folio + "&session=" + session);
           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            int intFolioSolicitud = (int)GridView1.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = GridView1.Rows[e.RowIndex];

            NegDetalleSolicitud DetalleSolicitud = new NegDetalleSolicitud();
            
            int EstaTomada = DetalleSolicitud.SolicitudTomada(intFolioSolicitud);
            
            if (EstaTomada.Equals(0))
	        {
               
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('La Solicitud con Folio " + intFolioSolicitud + "  se encuentra en proceso. No se puede anular');</script>"); 
                return;
		    
	        }
            

            NegSolicitud NegAnulaSolicitud = new NegSolicitud();            
            int existe = NegAnulaSolicitud.EstaAnulado(intFolioSolicitud);

            if (existe.Equals(0))
            {
                int id = NegAnulaSolicitud.AnulaSolicitud(intFolioSolicitud);
                lee_grilla(StrRutAlumno);
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Solicitud Folio  " + intFolioSolicitud + " fue Anulada.');</script>");
            }
            else
            {
                //lblMensaje.Text = "La Solicitud con Folio " + intFolioSolicitud  +"  ya se encuentra Anulada";

                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('La Solicitud con Folio  " + intFolioSolicitud + " ya se encuentra Anulada.');</script>"); 

                
                return;
            }
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
                      
            GridView1.PageIndex = e.NewPageIndex;
            lee_grilla(StrRutAlumno);
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = GridView1.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }
        }

        protected void Ordena(object sender, GridViewSortEventArgs e)
        {
            DataView dtview = new DataView(movSource);

            if (e.SortExpression.Equals("ASC"))
            {
                if (orden.Equals("ASC"))
                {
                    dtview.Sort = e.SortExpression + " " + "DESC";
                    orden = "DESC";
                }
                else
                {
                    dtview.Sort = e.SortExpression + " " + "ASC";
                    orden = "ASC";
                }

                //NegSolicitud NegSolicitudes = new NegSolicitud();
                //GridView1.DataSource = NegSolicitudes.ObtenerSolicitudes(StrRutAlumno);                
                this.GridView1.DataBind();
            }
            else
            {
                //Sin accion
            }

        }

        public void btnNuevaSolicitud_Click1(object sender, EventArgs e)
        {
            Funciones FuncionesEncriptar = new Funciones();
            string session = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(StrRutAlumno));
            Response.Redirect("NuevaSolicitud.aspx?session=" + session);


        }
    }
}