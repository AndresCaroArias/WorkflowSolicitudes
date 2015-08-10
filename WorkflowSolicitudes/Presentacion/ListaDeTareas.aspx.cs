using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using System.Data;


namespace WorkflowSolicitudes.Presentacion
{
    public partial class ListaDeTareas : System.Web.UI.Page    {
        public static String StrRutUsuario { get; set; }
        public static int intCodUnidad { get; set; }
        public static String StrPrivilegio = "ListaDeTareas.aspx";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            StrRutUsuario = Convert.ToString(Session["strRutUsuario"]);
            intCodUnidad = Convert.ToInt32(Session["intCodUnidad"]);

            if (StrRutUsuario.Equals(String.Empty))
            {
                StrRutUsuario  = Convert.ToString(Session["StrRutUsuario"]);
            }      

            
            if (!Page.IsPostBack)
                lee_grilla(intCodUnidad);
        }
        


        private void lee_grilla(int intCodUnidad) 
        {
            NegTareas NegtareasPendientes = new NegTareas();
            GrvListaTareas.DataSource = NegtareasPendientes.ObtenerTareasPendientesByCodUnidad(intCodUnidad);
            GrvListaTareas.DataBind();
        }

        protected void GrvListaTareas_SelectedIndexChanged(object sender, EventArgs e)
        {

            Funciones FuncionesEncriptar = new Funciones();

            GridViewRow row = GrvListaTareas.SelectedRow;
            int Folio = Convert.ToInt32(GrvListaTareas.DataKeys[row.RowIndex].Values["IntFolioSolicitud"]);
            int Secuencia = Convert.ToInt32(GrvListaTareas.DataKeys[row.RowIndex].Values["IntSecuencia"]);
            string name = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(Convert.ToString(Folio)));
            string technology = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(Convert.ToString(Secuencia)));
            string sec = HttpUtility.UrlEncode(FuncionesEncriptar.Encrypt(StrRutUsuario));


            Response.Redirect("resuelve.aspx?Folio=" + name + "&Secuencia=" + technology + "&RutResponsable=" + sec);
        }

        protected void GrvListaTareas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvListaTareas.PageIndex = e.NewPageIndex;
            lee_grilla(intCodUnidad);
        }

        protected void GrvListaTareas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string _estado = DataBinder.Eval(e.Row.DataItem, "StrDescEstado").ToString();

                if (_estado.Equals("ATRASADA"))
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }


            }
        }
        }
    }
