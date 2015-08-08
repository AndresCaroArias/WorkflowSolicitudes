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

        private static DataTable movSource;
        private static String orden = "ASC";        

         protected void Page_Load(object sender, EventArgs e)
        {

            //try
            //{
                //PrchBtnHiddenNo.Click += PrchBtnHiddenNo_Click;
                //PrchBtnHiddenYes.Click += PrchBtnHiddenYes_Click;

                //string ref1 = Request.ServerVariables["HTTP_REFERER"];
                //if (Request.ServerVariables["HTTP_REFERER"].Equals("http://10.0.0.2/Prueba.asp")) /// Codigo para verificar servidor de envio post
                //{
                    lblMensaje.Text = String.Empty;
                    //StrCodCli = Convert.ToString(Request.Form["codcli"]); // Linea para que rescate desde U+ el CODCLI  
                    StrCodCli = "20001IECIRE004";   /// Despues borrar esta linea de codigo 
                    Obtener_RutAlumno(StrCodCli);
                    Session["StrRutAlumno"] = StrRutAlumno;

                    if (!Page.IsPostBack)
                        lee_grilla(StrRutAlumno);
                    lee_alumnos(StrCodCli);
                    Session["StrCodCarrera"] = StrCodCarrera;

                //}
                //else
                //{
                //    Funciones FuncionesEncriptar = new Funciones();
                //    string strError = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt("Error_Autorizacion"));
                //    Response.Redirect("PageError.aspx?TypeError=" + strError);

                ////}

                //PrchBtnHiddenYes.Click += new EventHandler(GridView1_RowDeleting);
                //PrchBtnHiddenYes.Click += new GridViewDeleteEventHandler(GridView1_RowDeleting,);

            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
 
        }

         //void PrchBtnHiddenYes_Click(object sender, EventArgs e)
         //{

         //    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alertify.success('Solicitud Anulada')", true);
             

         //}

         //void PrchBtnHiddenNo_Click(object sender, EventArgs e)
         //{
         //    ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alertify.error('Registro Cancelado')", true);
         //}

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
                    LblJornada.Text = "VERSPERTINA";

                } 

            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = String.Empty;
            GridViewRow row = GridView1.SelectedRow;
            int Folio = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
            Response.Redirect("DetalleSolicitud.aspx?folio="+Folio);
           
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {


            lblMensaje.Text = String.Empty;

            int intFolioSolicitud = (int)GridView1.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = GridView1.Rows[e.RowIndex];

            NegDetalleSolicitud DetalleSolicitud = new NegDetalleSolicitud();
            
            int EstaTomada = DetalleSolicitud.SolicitudTomada(intFolioSolicitud);
            
            if (EstaTomada.Equals(0))
	        {
               lblMensaje.Text = "La Solicitud con Folio " + intFolioSolicitud  +"  ya se esta ejecutando o se resolvio. No se puede anular";
               return;
		    
	        }
            

            NegSolicitud         NegAnulaSolicitud = new NegSolicitud();            
            int existe = NegAnulaSolicitud.EstaAnulado(intFolioSolicitud);

            if (existe.Equals(0))
            {
                int id = NegAnulaSolicitud.AnulaSolicitud(intFolioSolicitud);
                lee_grilla(StrRutAlumno);
            }
            else
            {
                lblMensaje.Text = "La Solicitud con Folio " + intFolioSolicitud  +"  ya se encuentra Anulada";
                return;
            }
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMensaje.Text = String.Empty;            
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

        protected void PrchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}