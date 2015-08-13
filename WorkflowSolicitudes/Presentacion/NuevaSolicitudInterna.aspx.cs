using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using WorkflowSolicitudes.Entidades;
using System.Text;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class NuevaSolicitudInterna : System.Web.UI.Page
    {
        public static String strCargo { get; set; }
        public static String strNombreUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static String strRutUsuario { get; set; }
        public static int intContador { get; set; }
        public static int intCantMaxDocumentos { get; set; }
        public static int intCodTipoSolicitud { get; set; }
        public static String strCorreo { get; set; }
        public static int intFolioSolicitud { get; set; }
        public static DateTime dtmFechaVencSol { get; set; }
        public static List<Adjuntos> LstAdjuntos = new List<Adjuntos>();
        public static List<Unidades> LstUnidades = new List<Unidades>();
        public static int intCodUnidad { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                
                intContador = 0;
                  
                strRutUsuario = Convert.ToString(Session["strRutUsuario"]);
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                intCodUnidad = Convert.ToInt32(Session["intCodUnidad"]);

                NegUnidades   NegUnidades = new NegUnidades();
                LstUnidades = NegUnidades.ConsultaByCodUnidadUnidades(intCodUnidad);

                foreach (Unidades Unidad in LstUnidades)
                {
                    lblUnidad.Text = Unidad.strDescripcionUnidad;
                }
                

                List<Usuario> LstUsuarios = new List<Usuario>();
                NegUsuario negUsuario = new NegUsuario();
                LstUsuarios = negUsuario.ObtenerUsuarioPorRut(strRutUsuario);

                foreach (Usuario Usuarios in LstUsuarios)
                {
                    StringBuilder strNombreUsuario = new StringBuilder();
                    strNombreUsuario.Append(Usuarios.strNombre);
                    strNombreUsuario.Append(" ");
                    strNombreUsuario.Append(Usuarios.strApellido);
                    lblNombre.Text = strNombreUsuario.ToString();
                    strCorreo = Usuarios.strEmailUsuario;
                }

                
                List<Rol>  LstRoles = new List<Rol>();
                NegRol negRol = new NegRol();
                LstRoles = negRol.ConsultaRolByRol(intCodRoUser);
                foreach (Rol Roles in LstRoles)
                {
                    StringBuilder strCargo = new StringBuilder();
                    strCargo.Append(Roles.strDescripcion);
                    lblCargo.Text = strCargo.ToString();
              
               }
                lee_ComboTipoSolicitud();
            }
        }
        private void lee_ComboTipoSolicitud()
        {
            NegTipoSolicitud NegTipoSolicitudes = new NegTipoSolicitud();
            ddlTipoSolicitud.DataSource = NegTipoSolicitudes.ObtenerTipoSolicitudesActivasInternas();
            ddlTipoSolicitud.DataTextField = "strDescripcionSolicitud";
            ddlTipoSolicitud.DataValueField = "intCodTipoSolicitud";
            ddlTipoSolicitud.DataBind();
            ddlTipoSolicitud.Items.Insert(0, "Seleccione");

        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {

            String strRutAlumno = strRutUsuario;
            NegSolicitud InsertaSolicitud = new NegSolicitud();
            string strPeticion;

            strPeticion = txtpeticion.Text;

            if (ddlTipoSolicitud.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR:  Debe Seleccionar un tipo de Solicitud');</script>");
                return;
            }

            intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);
            int intExistenSolicitudes = InsertaSolicitud.ValidaCantidadSolicitudesXTipo(intCodTipoSolicitud);

            if (intExistenSolicitudes.Equals(1))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR:  No tiene más solicitudes por realizar por este año, para el tipo de solicitud "  + ddlTipoSolicitud.SelectedItem + "');</script>'");
                return;
            }


            if (txtpeticion.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Debe Ingresar la petición de la solicitud');</script>");
                return;
                
            }


            String strCodCarrera = "Interna"; //Convert.ToString(DBNull.Value);
            String txtCelularContacto = "00";//Convert.ToString(DBNull.Value);

            

            List<Solicitud> LstSolicitud = new List<Solicitud>();
            LstSolicitud = InsertaSolicitud.Insertar_Solicitud(intCodTipoSolicitud, strRutAlumno, strCodCarrera, txtCelularContacto, strCorreo, txtpeticion.Text, "I");
            NegAuditoria InsertarLog = new NegAuditoria();
            InsertarLog.InsertaAuditoria(strRutUsuario, "NUEVA SOLICITUD INTERNA", "CREA UNA NUEVA SOLICITUD ", "EL USUARIO CREA UNA NUEVA SOLICITUD " + ddlTipoSolicitud.SelectedItem);


          
            ddlTipoSolicitud.SelectedIndex = -1;

            foreach (Solicitud Sol in LstSolicitud)
            {
                intFolioSolicitud = Sol.intFolio;
                dtmFechaVencSol = Sol.dtmFechaVencimientoSol;

            }

            NegAdjuntos NegAdjuntos = new NegAdjuntos();

            foreach (Adjuntos Adjunto in LstAdjuntos)
            {

                NegAdjuntos.AltaAdjuntos(intFolioSolicitud, Adjunto.strNombreArchivo, Adjunto.bteArchivoPdf, "S",0);
            }

            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('FELICITACIONES : Su Solicitud fue elevada Exitosamente, con número de Folio " + intFolioSolicitud + " . La Fecha de resolución estimada será " + dtmFechaVencSol + "');</script>'");
  

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {

            ddlTipoSolicitud.SelectedIndex = -1;
            LblMensaje.Text = String.Empty;
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            int intCandocumentoLst = 0;
            intCandocumentoLst = LstAdjuntos.Count;
            if (intCantMaxDocumentos <= intCandocumentoLst)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: No esta permitido adjuntar mas documentos para esta solicitud');</script>");
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
                    
                    LblMensaje.Text = "Solo se pueden ingresar archivos tipo PDF";
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert(' Solo se pueden ingresar archivos tipo PDF!!!');</script>");
                    return;
                }


                intContador = intContador + 1;

                LstAdjuntos.Add(new Adjuntos(intContador, strNombreArchivo, byteImage));


                grvAdjunto.DataSource = LstAdjuntos;
                grvAdjunto.DataBind();

            }
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
                    LblMensaje.Text = string.Empty;
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

        protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            LstAdjuntos.Clear();
            grvAdjunto.DataSource = LstAdjuntos;
            grvAdjunto.DataBind();

            NegTipoSolicitud CantMaxDocumentos = new NegTipoSolicitud();
            int intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);
            intCantMaxDocumentos = CantMaxDocumentos.ObtenerCantMaxDocByTipoSolicitud(intCodTipoSolicitud);
        }


    }
}