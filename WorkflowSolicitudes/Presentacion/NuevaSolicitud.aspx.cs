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
    public partial class NuevaSolicitud : System.Web.UI.Page
    {
        public static String StrRutAlumno { get; set; }
        public static String StrCodCarrera { get; set; }
        public static String StrPrivilegio { get; set; }
        public static int intCodTipoSolicitud { get; set; }
        public static int intContador { get; set; }
        public static int intCantMaxDocumentos { get; set; }
        public static int intFolioSolicitud { get; set; }
        public static DateTime dtmFechaVencSol { get; set; }
        public static int intSecuencia { get; set; }
        public static List<Adjuntos> LstAdjuntos = new List<Adjuntos>();
        


        protected void Page_Load(object sender, EventArgs e)
        {

            StrRutAlumno  = Convert.ToString(Session["StrRutAlumno"]);
            StrCodCarrera = Convert.ToString(Session["StrCodCarrera"]);

            if (!Page.IsPostBack)
            {
                intContador = 0;
                lee_ComboTipoSolicitud();
            }

        
        }

         private void lee_ComboTipoSolicitud()
         {
             NegTipoSolicitud NegTipoSolicitudes = new NegTipoSolicitud();
             ddlTipoSolicitud.DataSource         = NegTipoSolicitudes.ObtenerTipoSolicitudesActivasExternas();
             ddlTipoSolicitud.DataTextField      = "strDescripcionSolicitud";
             ddlTipoSolicitud.DataValueField     = "intCodTipoSolicitud";
             ddlTipoSolicitud.DataBind();
             ddlTipoSolicitud.Items.Insert(0, "Seleccione");
        
         }

         
         protected void BtnEnviar_Click(object sender, EventArgs e)
         {
             NegSolicitud InsertaSolicitud = new NegSolicitud();

             if (ddlTipoSolicitud.SelectedIndex.Equals(0)) 
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe Seleccionar un tipo de Solicitud');</script>");
                 return;  
             }

             if (txtCelularContacto.Equals(String.Empty))
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe ingresar número de contacto');</script>");
                 return;
             }



             if (txtCorreo.Equals(String.Empty))
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe ingresar un correo electronico de contacto');</script>");
                 return;
             }

             if (Txtpeticion.Equals(String.Empty))
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Debe ingresar una petición');</script>");
                 return;
             }

             



             intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);

             int intExistenSolicitudes = InsertaSolicitud.ValidaCantidadSolicitudesXTipo(intCodTipoSolicitud);

             if (intExistenSolicitudes.Equals(1))
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR:  No tiene más solicitudes por realizar por este año, para el tipo de solicitud " + ddlTipoSolicitud.SelectedItem + "');</script>'");
                 return;  
             }


             List<Solicitud> LstSolicitud = new List<Solicitud>();
             LstSolicitud = InsertaSolicitud.Insertar_Solicitud(intCodTipoSolicitud, StrRutAlumno, StrCodCarrera, txtCelularContacto.Text, txtCorreo.Text, Txtpeticion.Text, "E");
            


             txtCelularContacto.Text = String.Empty;
             txtCorreo.Text = String.Empty;
             Txtpeticion.Text = String.Empty;
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
             LstAdjuntos.Clear();
             grvAdjunto.DataSource = null;
             grvAdjunto.DataBind();

         }

         protected void BtnLimpiar_Click(object sender, EventArgs e)
         {

             txtCelularContacto.Text = String.Empty;
             txtCorreo.Text = String.Empty;
             Txtpeticion.Text = String.Empty;
             ddlTipoSolicitud.SelectedIndex = -1;
             LblMensaje.Text = String.Empty;
             LstAdjuntos.Clear();
             grvAdjunto.DataSource = null;
             grvAdjunto.DataBind();

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
                     LstAdjuntos.RemoveAt(IdArch-1);
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

         protected void btnSubir_Click(object sender, EventArgs e)
         {
             int intCandocumentoLst = 0;
             intCandocumentoLst= LstAdjuntos.Count;
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
                     ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Solo se puede ingresar archivos con formato PDF');</script>");
                     return;
                 }


                 intContador = intContador + 1;

                 LstAdjuntos.Add(new Adjuntos(intContador, strNombreArchivo, byteImage));


                 grvAdjunto.DataSource = LstAdjuntos;
                 grvAdjunto.DataBind();
                 
             }
         }

         protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
         {
             Txtpeticion.Text = string.Empty;
             LstAdjuntos.Clear();
             grvAdjunto.DataSource = LstAdjuntos;
             grvAdjunto.DataBind();
             NegTipoSolicitud CantMaxDocumentos = new NegTipoSolicitud();
             int intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);
             intCantMaxDocumentos = CantMaxDocumentos.ObtenerCantMaxDocByTipoSolicitud(intCodTipoSolicitud);
         }

         protected void ddlTipoSolicitud_Load(object sender, EventArgs e)
         {
            
         }

         protected void ddlTipoSolicitud_TextChanged(object sender, EventArgs e)
         {
             Txtpeticion.Text = string.Empty;
         }

    }
}