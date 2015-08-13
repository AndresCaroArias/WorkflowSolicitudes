using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        public static string gblAccion { get; set; }
        public static String StrPrivilegio = "MantFlujoSolicitudes.aspx";
        public static String StrRutUsuario { get; set; }
        public static int    intCodRoUser { get; set; }
        public static int intSecuencia { get; set; }
        public static int intCodTipoSolicitud { get; set; }
        public static int intCodActividad { get; set; }
        public static int intCodUnidad   { get; set; }
        public static int intBifurcacion { get; set; }
        public static int intActividadSI { get; set; }
        public static int intActividadNO { get; set; }
        public static string strAprobador { get; set; }
        public static string strBifurcacaion { get; set; }
        public static string strSecuenciaSI { get; set; }
        public static string strSecuenciaNO { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            EnableViewState = true;

            if (!Page.IsPostBack)
            {
                StrRutUsuario = Convert.ToString(Session["strRutUsuario"]);
                lee_ComboTipoSolicitud();
                lee_ComboUnidad();
                lee_ComboActividades();
            
                
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                Funciones ExisteAcceso = new Funciones();

                Boolean ExistePrivilegio = ExisteAcceso.TieneAcceso(intCodRoUser, StrPrivilegio);

                if (ExistePrivilegio.Equals(false))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Usted no tiene acceso a esta opción');</script>");
                    
                    ddlActividades.Visible = false;
                    ddlTipoSolicitudes.Visible = false;
                    grvModeladorSolicitud.Visible = false;
                    BtnGuardar.Visible = false;
                    txtSecuencia.Visible = false;
                  
                    return;
                }
            }
                
         
        }

        private void lee_ComboTipoSolicitud()
        {
            NegTipoSolicitud NegTipoSolicitudes = new NegTipoSolicitud();
            ddlTipoSolicitudes.DataSource = NegTipoSolicitudes.ObtenerTodosLosTipoSolicitud();
            ddlTipoSolicitudes.DataTextField = "strDescripcionSolicitud";
            ddlTipoSolicitudes.DataValueField = "intCodTipoSolicitud";
            ddlTipoSolicitudes.DataBind();
            ddlTipoSolicitudes.Items.Insert(0, "Seleccione");

        }

        private void lee_ComboUnidad()
        {
            NegUnidades NegUnidad = new NegUnidades();
            ddlUnidad.DataSource = NegUnidad.ObtenerUnidades();
            ddlUnidad.DataTextField = "strDescripcionUnidad";
            ddlUnidad.DataValueField = "intCodUnidad";
            ddlUnidad.DataBind();
            ddlUnidad.Items.Insert(0, "Seleccione");
        }

        private void lee_ComboActividades()
        {
            NegActividad NegActividades = new NegActividad();
            ddlActividades.DataSource = NegActividades.ObtenerActividades_Activas();
            ddlActividades.DataTextField = "strDescripActividad";
            ddlActividades.DataValueField = "intCodActividad";
            ddlActividades.DataBind();
            ddlActividades.Items.Insert(0, "Seleccione");
        }

        private void LoadGrid(int intCodTipoSolicitud)
        {

            NegFlujoSolicitud Negflujo = new NegFlujoSolicitud();
            grvModeladorSolicitud.DataSource = Negflujo.ObtenerFlujoSolicitud(intCodTipoSolicitud);
            grvModeladorSolicitud.DataBind();

        }



        protected void grvModeladorSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvModeladorSolicitud.PageIndex = e.NewPageIndex;
            LoadGrid(intCodTipoSolicitud);
        }

        protected void grvModeladorSolicitud_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvModeladorSolicitud.EditIndex = -1;
            LoadGrid(intCodTipoSolicitud);
        }


        protected void grvModeladorSolicitud_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvModeladorSolicitud.EditIndex = e.NewEditIndex;
            LoadGrid(intCodTipoSolicitud);
        }


        protected void grvModeladorSolicitud_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void grvModeladorSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCodActividad;
            int intAprobador;
            int intExiste;
            string strAprobador;
            string strBifurcacaion;
            int intCodUnidad;
            string strSi;
            string strNo;

            lblMensaje.Text = String.Empty;
            NegFlujoSolicitud NegFlujos = new NegFlujoSolicitud();
            NegSolicitud NegSolicitud = new NegSolicitud();

            

            GridViewRow row = grvModeladorSolicitud.SelectedRow;
            intAprobador = Convert.ToInt32(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["intAprobador"]);

            intSecuencia    = Convert.ToInt32(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["intSecuencia"]);
            string Rut      = Convert.ToString(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["strRutUsuario"]);
            strAprobador    = Convert.ToString(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["strAprobador"]);
            //strBifurcacaion = Convert.ToString(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["strBifurcacaion"]);
            intCodUnidad    = Convert.ToInt32(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["intCodUnidad"]);
            strSi           = Convert.ToString(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["strSi"]);
            strNo           = Convert.ToString(grvModeladorSolicitud.DataKeys[row.RowIndex].Values["strNo"]);
        
    	    intExiste =   NegSolicitud.HayProcesoEjecutandoSe(intCodTipoSolicitud);
	
            if (!intExiste.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : No se pueden realizar cambios en el proceso, ya que hay flujos ejecutandose');</script>");
                return;
            }
	
             
            intCodActividad = NegFlujos.BuscoCodigoActividad(intCodTipoSolicitud, intSecuencia);
            ddlActividades.SelectedIndex = intCodActividad;
            ddlUnidad.SelectedIndex = intCodUnidad;
            txtSecuenciaSi.Text = strSi;
            txtSecuenciaNo.Text = strNo;

            if (strAprobador.Equals("Si"))
            {
                chkAprobador.Checked = true;
            }
            else
            {
                chkAprobador.Checked = false;
            }


            txtSecuencia.Text = Convert.ToString(intSecuencia);
            BtnEliminar.Visible = true;
            gblAccion = "Actualizar";

        }

        
        
        protected void BtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            int intExiste;
            int intCodActividad;
            int intAprobador;
            

            lblMensaje.Text = String.Empty;

            NegSolicitud NegSolicitud = new NegSolicitud();
            NegAuditoria InsertarLog = new NegAuditoria();
            intExiste = NegSolicitud.HayProcesoEjecutandoSe(intCodTipoSolicitud);

            if (!intExiste.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : No se pueden realizar cambios en el proceso, ya que hay flujos ejecutandose');</script>");
                       
                return;
            }

            if (txtSecuencia.Text.Equals(String.Empty))
            {
               ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debío haber presionado el boton nuevo, para crear una nueva actividad');</script>");
                
               return;
            }
            
            if (ddlActividades.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe Seleccionar una actividad');</script>");
                             
                return;
            }

            
            if (ddlTipoSolicitudes.SelectedIndex.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe Seleccionar un tipo de Solicitud');</script>");
                            
                return;
            }

            if (ddlUnidad.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe Seleccionar una Unidad');</script>");

                return;
            }

            if (ChkBifurcacion.Checked)
            {
                intBifurcacion = 1;
            }
            else
            {
                intBifurcacion = 0;
            }

            if (chkAprobador.Checked)
            {
                intAprobador = 1;
            }
            else
            {
                intAprobador = 0;
            }

            intSecuencia        = int.Parse(txtSecuencia.Text);
            intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitudes.SelectedValue);
            intCodActividad     = Convert.ToInt32(ddlActividades.SelectedIndex);
            intCodUnidad        = Convert.ToInt32(ddlUnidad.SelectedIndex);
            strSecuenciaSI      = txtSecuenciaSi.Text;
            strSecuenciaNO      = txtSecuenciaNo.Text;

            NegFlujoSolicitud NegFlujoSolicitudes = new NegFlujoSolicitud();

            if (gblAccion == "Insertar")
            {
                NegFlujoSolicitudes.Insertarflujo(intSecuencia, intCodTipoSolicitud, intCodActividad, intCodUnidad, intAprobador, intBifurcacion, strSecuenciaSI, strSecuenciaNO);
                InsertarLog.InsertaAuditoria(StrRutUsuario, "MANTENEDOR DE FLUJOS ", "CREACION DE NUEVO FLUJO ", "PARA EL TIPO DE SOLICITUD " + ddlTipoSolicitudes.SelectedItem);
            }

            else
            {    
                NegFlujoSolicitudes.ActualizarFlujoSolicitud(intSecuencia, intCodTipoSolicitud, intCodActividad, intCodUnidad, intAprobador, intBifurcacion, strSecuenciaSI, strSecuenciaNO);
                InsertarLog.InsertaAuditoria(StrRutUsuario, "MANTENEDOR DE FLUJOS ", "ACTUALIZACION DE FLUJO ", "PARA EL TIPO DE SOLICITUD " + ddlTipoSolicitudes.SelectedItem);
            }

          
            LoadGrid(intCodTipoSolicitud);
            
            ddlActividades.SelectedIndex = -1;
            ddlUnidad.SelectedIndex = -1;
            txtSecuencia.Text = String.Empty;
            chkAprobador.Checked = false;
            ChkBifurcacion.Checked = false;
            txtSecuenciaSi.Text = String.Empty;
            txtSecuenciaNo.Text = String.Empty;
        }

        protected void BtnNuevo_Click(object sender, ImageClickEventArgs e)
        {
            lblMensaje.Text = String.Empty;
            
            if (ddlTipoSolicitudes.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe Selecionar un tipo de Solicitud');</script>");
                               
                return; 
                
            }
            
            gblAccion = "Insertar";

            BtnEliminar.Visible = false;

            ddlActividades.SelectedIndex = -1;
            
            ddlUnidad.SelectedIndex = -1;
            txtSecuencia.Text = String.Empty;
            chkAprobador.Checked = false;
            ChkBifurcacion.Checked = false;

            intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitudes.SelectedValue);
         
            NegFlujoSolicitud NegFlujoSolicitud = new NegFlujoSolicitud();
            int intSecuencia = NegFlujoSolicitud.UltimaSecuencia(intCodTipoSolicitud);
            txtSecuencia.Text = Convert.ToString(intSecuencia);
            txtSecuencia.Enabled = false;

            LoadGrid(intCodTipoSolicitud);


        }

        protected void BtnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            int intExiste;


            NegSolicitud NegSolicitud = new NegSolicitud();
            intExiste = NegSolicitud.HayProcesoEjecutandoSe(intCodTipoSolicitud);

            if (!intExiste.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('No se pueden eliminar actividades del proceso, ya que hay flujos ejecutandose');</script>");
                              
                return;
            }

            NegFlujoSolicitud NegFlujoSolicitudElimina = new NegFlujoSolicitud();
            NegFlujoSolicitudElimina.CambiaEstado(intCodTipoSolicitud, intSecuencia);
            LoadGrid(intCodTipoSolicitud);

            ddlActividades.SelectedIndex = -1;
            ddlUnidad.SelectedIndex = -1;
            txtSecuencia.Text = String.Empty;
            chkAprobador.Checked = false;
            lblMensaje.Text = String.Empty;
        }

        protected void ddlTipoSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlActividades.SelectedIndex = -1;
            ddlUnidad.SelectedIndex = -1;
            txtSecuencia.Text = String.Empty;
            chkAprobador.Checked = false;
 
        }

        }


    }
