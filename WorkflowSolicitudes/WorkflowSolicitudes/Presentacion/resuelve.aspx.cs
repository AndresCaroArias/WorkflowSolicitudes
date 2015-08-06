using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Entidades;
using System.Text;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class resuelve : System.Web.UI.Page
    {
        public static String CodCarr      { get; set; }
        public static String StrRutAlumno { get; set; }
        public static  int   intCodTipoSolicitud { get; set; }
        public static int intFolioSolicitud { get; set; }
        public static int intContador { get; set; }
        public static int intCantMaxDocumentos { get; set; }
        public static int intSecuencia { get; set; }
        public static int intCodEstado { get; set; }
        public static string strGlosaDetalleSol { get; set; }
        public static string StrRutResponsable { get; set; }
        public static int intAprobador { get; set; }
        public static string strOrigen { get; set; }
        public static int intCodActividad { get; set; }
        public static int intCodUnidad    { get; set; }
        public static int intCodEstadSol  { get; set; }
        public static int intCodEstadoAct { get; set; }  

        public static String StrPrivilegio = "resuelve.aspx";
        public static List<Adjuntos> LstAdjuntos = new List<Adjuntos>();
        public static List<Usuario> LstUsuarios = new List<Usuario>();
        public static List<FlujoSolicitud> LstFlujoSolicitud = new List<FlujoSolicitud>();
        public static Boolean BolExisteSiguienteFlujo=true;
        public static string strSecuenciaSi { get; set; }
        public static string strSecuenciaNo { get; set; }
        public static string strAprobadaAuditoria { get; set; }
        public static string strRechazadaAuditoria { get; set; }
        public static string strContinuaAuditoria { get; set; }
        public static string strSiguienteSecuencia { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            NegFlujoSolicitud   NegFlujoSolicitud = new NegFlujoSolicitud();
            NegDetalleSolicitud NegDatellSolicitud = new NegDetalleSolicitud();
            lblMensaje.Text = String.Empty;



            if (!Page.IsPostBack)
            {
                Funciones FuncionesDesencriptar = new Funciones();

                if (!(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Folio"]))).Equals("Error_Autorizacion"))
                    intFolioSolicitud = Convert.ToInt32(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Folio"])));
                else
                {
                    Response.Redirect("PageError.aspx?TypeError=Error_Autorizacion");
                }
                if (!(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["RutResponsable"]))).Equals("Error_Autorizacion"))
                    StrRutResponsable = FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["RutResponsable"]));
                else
                {
                    Response.Redirect("PageError.aspx?TypeError=Error_Autorizacion");
                }

                if (!(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Secuencia"]))).Equals("Error_Autorizacion"))
                    intSecuencia = Convert.ToInt32(FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Secuencia"])));
                else
                {
                    Response.Redirect("PageError.aspxTypeError=Error_Autorizacion");
                }


                lblFolio.Text = FuncionesDesencriptar.Decrypt(HttpUtility.UrlDecode(Request.QueryString["Folio"]));

                ConsultaSolicitudFolio(Convert.ToInt32(lblFolio.Text));
                lblActividad.Text = ConsultaActividad(intSecuencia, intCodTipoSolicitud);
                NegDatellSolicitud.ActualizaFechaTomaActividad(intFolioSolicitud, intSecuencia, StrRutResponsable);

                NegAuditoria InsertarLog = new NegAuditoria();
                InsertarLog.InsertaAuditoria(StrRutResponsable, "RESUELVE", "ACCEDE A RESOLVER ACTIVIDAD", "ACTIVIDAD A RESOLVER ES " + lblActividad.Text + "PARA EL FOLIO :" + lblFolio);
                
                NegFlujoSolicitud DatosDelFlujoActividadActual = new NegFlujoSolicitud();  
                LstFlujoSolicitud = NegFlujoSolicitud.SelectDatoActividad(intCodTipoSolicitud, intSecuencia);

                foreach (FlujoSolicitud ActividadActual in LstFlujoSolicitud)
                    {
                        strSecuenciaSi  = ActividadActual.strSi;
                        strSecuenciaNo  = ActividadActual.strNo;
                        
                    }

                if (strSecuenciaNo.Equals(String.Empty))
                {
                    RbtSI.Visible      = false;
                    RbtNO.Visible      = false;
                    lblAprobar.Visible = false;
                }

                if (strSecuenciaNo.Equals("0") || (strSecuenciaNo.Equals("0")))
                {
                    RbtSI.Visible = false;
                    RbtNO.Visible = false;
                    lblAprobar.Visible = false;
                }

                mostrar_Historial(intFolioSolicitud);

                NegTipoSolicitud CantMaxDocumentos = new NegTipoSolicitud();

                intCantMaxDocumentos = CantMaxDocumentos.ObtenerCantMaxDocByTipoSolicitud(intCodTipoSolicitud);


                NegAdjuntos Adjuntos = new NegAdjuntos();
                int ExistenAdjuntos = Adjuntos.ExistirianAdjutnos(intFolioSolicitud);

                if (!ExistenAdjuntos.Equals(0))
                {
                    HypAdjuntos.Text = "Ver documetos adjuntos asociados a la solicitud";
                    HypAdjuntos.NavigateUrl = "VerAdjuntos.aspx?Folio=" + intFolioSolicitud + "&Tipo=S";

                }
                else
                {
                    HypAdjuntos.Text = String.Empty;
                    HypAdjuntos.Visible = false;
                }



                if (strOrigen.Equals("E"))
                {
                    lblrut.Text = StrRutAlumno;
                    lee_alumnos(StrRutAlumno);
                }
                else
                {
                    lblrut.Text = StrRutAlumno;
                    NegUsuario ObtenerUsuario = new NegUsuario();
                    LstUsuarios = ObtenerUsuario.ObtenerUsuarioPorRut(StrRutAlumno);

                    foreach (Usuario Usuarios in LstUsuarios)
                    {
                        StringBuilder strnombre = new StringBuilder();
                        strnombre.Append(Usuarios.strNombre);
                        strnombre.Append(" ");
                        strnombre.Append(Usuarios.strApellido);

                        lblNombre.Text = strnombre.ToString();
                    }
                }
            }    
        }



        private void lee_alumnos(string codcli)
        {
            List<Alumnos> LstAlumnnos = new List<Alumnos>();
            NegAlumnos NegAlumno = new NegAlumnos();

            LstAlumnnos = NegAlumno.ObtenerInfoAlumnoByCodCli(codcli);

            foreach (Alumnos alumno in LstAlumnnos)
            {
                StringBuilder strnombre = new StringBuilder();
                strnombre.Append(alumno.StrNombre);
                strnombre.Append(" ");
                strnombre.Append(alumno.StrApPaterno);
                strnombre.Append(" ");
                strnombre.Append(alumno.StrApMaterno);

                lblNombre.Text = strnombre.ToString();
                lblCarrera.Text = alumno.StrNombreCarrera;
            }

        }

        private string ConsultaActividad(int intSecuencia, int intCodTipoSolicitud)
        {
            string StrDesActividad; 
            NegFlujoSolicitud NegDescActividad = new NegFlujoSolicitud();
            StrDesActividad = NegDescActividad.ObtenerActividad(intSecuencia, intCodTipoSolicitud);
            return StrDesActividad;
        }


        private void ConsultaSolicitudFolio(int intFolioSolicitud) 
        { 
        
            List<Solicitud>   lstSolicitud      = new List<Solicitud>();
            NegSolicitud      NegSolicitudes    = new NegSolicitud();
            
 
            lstSolicitud = NegSolicitudes.ObtenerSolicitudesByFolio(intFolioSolicitud);

            foreach (Solicitud Solicitudes in lstSolicitud)
            {
              StrRutAlumno           = Solicitudes.strRutAlumno;
              lblCelular.Text        = Solicitudes.strCelularContacto;
              lblCorreo.Text         = Solicitudes.strEmailContacto;
              lbltipoSolicitud.Text  = Solicitudes.strDescripcionSolicitud;
              txtPeticion.Text       = Solicitudes.strGlosaSolicitud;
              lblFechaSolicitud.Text = Convert.ToString(Solicitudes.dtmFechaSolicitud);
              intCodTipoSolicitud    = Solicitudes.intCodTipoSolicitud;
              strOrigen              = Solicitudes.strOrigen;
            }
        
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaDeTareas.aspx?StrRutUsuario=" + StrRutResponsable);
            NegAuditoria InsertarLog = new NegAuditoria();
            InsertarLog.InsertaAuditoria(StrRutResponsable, "RESUELVE", "ABANDONA LA ACTIVIDAD", "ABANDONA LA ACTIVIDAD SIN RESOLVERLA " + lblActividad.Text + "PARA EL FOLIO :" + lblFolio);
                
        }

        private void mostrar_Historial(int Folio)
        {
            List<WorkflowSolicitudes.Entidades.DetalleSolicitud> LstHistory = new List<WorkflowSolicitudes.Entidades.DetalleSolicitud>();
            NegDetalleSolicitud NegDetSol = new NegDetalleSolicitud();
            LstHistory = NegDetSol.ObtenerDetalleSolicitud(Folio);
            grvMostrarHistorial.DataSource = LstHistory; 
            grvMostrarHistorial.DataBind();

            if (grvMostrarHistorial.Rows.Count.Equals(0))
            {
                lblDetalleResponsable.Visible = false;
                Panel1.Visible = false; 
            }

        }


        protected void BtnCompletar_Click(object sender, EventArgs e)
        {
            NegFlujoSolicitud NegFlujoSolicitud = new NegFlujoSolicitud();
            
            strGlosaDetalleSol = txtResolucion.Text;
            
            if (intAprobador.Equals(1))
            {
                if (RbtSI.Checked == false && RbtNO.Checked == false)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe selecionar SI  ó NO para aprobar o rechazar la solicitud');</script>");
                    return;
                }

            }

            if (txtResolucion.Text.Equals(String.Empty))
            {
               ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe ingresar un comentario u observacion al respecto');</script>");
                return;
            }
            NegAuditoria InsertarLog = new NegAuditoria();

            NegDetalleSolicitud ResuelveActividad = new NegDetalleSolicitud();
            if (RbtSI.Checked)
            {
                intCodEstadSol = 2;
                strAprobadaAuditoria = "APROBADA";
                strSiguienteSecuencia = strSecuenciaSi;
                InsertarLog.InsertaAuditoria(StrRutResponsable, "RESUELVE", "RESUELVE LA ACTIVIDAD ", "ACTIVIDIDAD APROBADA " + lblActividad.Text + "PARA EL FOLIO :" + lblFolio.Text);
            }

            if (RbtNO.Checked)
            {
                intCodEstadSol = 3;
                strRechazadaAuditoria = "RECHAZADA";
                strSiguienteSecuencia = strSecuenciaNo;
                intCodEstadoAct = 8;
                if (strSecuenciaNo.Equals("0"))
                {
                 ResuelveActividad.CierraProceso(intFolioSolicitud, intSecuencia, intCodEstadSol, intCodEstadoAct, strGlosaDetalleSol);
                 InsertarLog.InsertaAuditoria(StrRutResponsable, "RESUELVE", "RESUELVE LA ACTIVIDAD ", "ACTIVIDIDAD RECHAZADA " + lblActividad.Text + "PARA EL FOLIO :" + lblFolio.Text);
                 Response.Redirect("ListaDeTareas.aspx?StrRutUsuario=" + StrRutResponsable);
                }
            }

            if (strSecuenciaNo.Equals("0") || (strSecuenciaSi.Equals("0")))
            {
                
                // FALTA EL ALGORITMO PARA DETERMINAR QUE SI FUE ACEPTADA O REHZADA LA SOLICITUD AL TERMINAR EL PROCESO
                intCodEstadoAct = 8; 
                ResuelveActividad.CierraProceso(intFolioSolicitud, intSecuencia, intCodEstadSol, intCodEstadoAct, strGlosaDetalleSol);
                InsertarLog.InsertaAuditoria(StrRutResponsable, "RESUELVE", "RESUELVE LA ACTIVIDAD ", "SE COMPLETA LA " + lblActividad.Text + "SE TERMINA EL FLUJO PARA SOLICITUD " + lbltipoSolicitud.Text  + " PARA EL FOLIO :" + lblFolio.Text);
                Response.Redirect("ListaDeTareas.aspx?StrRutUsuario=" + StrRutResponsable);
            }


            if (RbtSI.Checked == false && RbtNO.Checked == false)
            {
                intCodEstadoAct = 8;
                strContinuaAuditoria = "CONTINUA";
            }

            NegAdjuntos NegAdjuntos = new NegAdjuntos();

            foreach (Adjuntos Adjunto in LstAdjuntos)
            {

                NegAdjuntos.AltaAdjuntos(intFolioSolicitud, Adjunto.strNombreArchivo, Adjunto.bteArchivoPdf, "A", intSecuencia);
            }

            LstAdjuntos.Clear();
            grvAdjunto.DataSource = null;
            grvAdjunto.DataBind();

            
            
            LstFlujoSolicitud = NegFlujoSolicitud.SelectDatoActividad(intCodTipoSolicitud, Convert.ToInt32(strSiguienteSecuencia));

            if (LstFlujoSolicitud.Count.Equals(0))
            {
                BolExisteSiguienteFlujo = false;
            }
            else
            {   
                BolExisteSiguienteFlujo = true;
                foreach (FlujoSolicitud ActividadActual in LstFlujoSolicitud)
                {
                    intCodActividad = ActividadActual.intCodActividad;
                    intCodUnidad    = ActividadActual.intCodUnidad;
                }
            }


            if (BolExisteSiguienteFlujo)
            {
                ResuelveActividad.ResuelveActividadFlujo(intFolioSolicitud, intSecuencia, intCodTipoSolicitud, intCodEstadoAct, strGlosaDetalleSol, intCodActividad, intCodUnidad, Convert.ToInt32(strSiguienteSecuencia));
            }
            else
            {
                ResuelveActividad.CierraProceso(intFolioSolicitud, intSecuencia, intCodEstadSol, intCodEstadoAct, strGlosaDetalleSol);    
            }

            InsertarLog.InsertaAuditoria(StrRutResponsable, "RESUELVE", "RESUELVE LA ACTIVIDAD ", "ACTIVIDIDAD RESUELTA " + lblActividad.Text + "PARA EL FOLIO :" + lblFolio);
            Response.Redirect("ListaDeTareas.aspx?StrRutUsuario=" + StrRutResponsable);

        }

        protected void grvAdjunto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grvAdjunto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grvAdjunto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int IdArch = (int)grvAdjunto.DataKeys[e.RowIndex].Values[0];

            foreach (Adjuntos Adjunto in LstAdjuntos)
            {
                if (Adjunto.intIdArchivo.Equals(IdArch))
                {
                    LstAdjuntos.RemoveAt(0);
                    grvAdjunto.DataSource = LstAdjuntos;
                    grvAdjunto.DataBind();
                    lblMensaje.Text = string.Empty;
                    return;
                }

            }
        }

        protected void grvAdjunto_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvAdjunto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grvAdjunto_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvAdjunto.SelectedRow;
            int IdArch = Convert.ToInt32(grvAdjunto.DataKeys[row.RowIndex].Value);

            foreach (Adjuntos Adjunto in LstAdjuntos)
            {
                if (Adjunto.intIdArchivo.Equals(IdArch))
                {
                    Session["bteArchivoPdf"] = Adjunto.bteArchivoPdf;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'MostrarPdf.aspx', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                }

            }     
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            int intCandocumentoLst = 0;
            intCandocumentoLst = LstAdjuntos.Count;
            if (intCantMaxDocumentos <= intCandocumentoLst)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('No esta permitido adjuntar mas documentos para esta solicitud');</script>");
                return;
            }

            if ((ImagenFile.PostedFile != null) && (ImagenFile.PostedFile.ContentLength > 0))
            {
                string strNombreArchivo = ImagenFile.FileName;
                HttpPostedFile ImgFile = ImagenFile.PostedFile;
                Byte[] byteImage = new Byte[ImagenFile.PostedFile.ContentLength];
                ImgFile.InputStream.Read(byteImage, 0, ImagenFile.PostedFile.ContentLength);

                string Aux = strNombreArchivo.ToUpper();

                int intExistePdf = Aux.IndexOf(".PDF");


                if (intExistePdf.Equals(-1))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Solo se pueden ingresar archivos tipo PDF');</script>");
                    return;
                }

                
                intContador = intContador + 1;

                LstAdjuntos.Add(new Adjuntos(intContador, strNombreArchivo, byteImage, intSecuencia));
                grvAdjunto.DataSource = LstAdjuntos;
                grvAdjunto.DataBind();

            }
        }

        protected void grvMostrarHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvMostrarHistorial.SelectedRow;
            int intSecuencia = Convert.ToInt32(grvMostrarHistorial.DataKeys[row.RowIndex].Value);

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'VerAdjuntos.aspx?Folio="+intFolioSolicitud+"&Secuencia="+intSecuencia+"&Tipo=A', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


            }   
        }

        
    
}