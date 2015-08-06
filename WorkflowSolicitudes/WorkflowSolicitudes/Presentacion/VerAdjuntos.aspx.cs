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
    public partial class VerAdjuntos : System.Web.UI.Page
    {

        public static int intFolioSolicitud { get; set; }
        public static String strTipoAdjunto { get; set; }
        public static int intSecuencia { get; set; }
        public static List<Adjuntos> LstAdjuntos = new List<Adjuntos>();

        protected void Page_Load(object sender, EventArgs e)
        {


            intFolioSolicitud = Convert.ToInt32(Request.QueryString["Folio"]);
            intSecuencia = Convert.ToInt32(Request.QueryString["Secuencia"]);
            strTipoAdjunto = Request.QueryString["Tipo"];

            NegAdjuntos NegArchivosADjuntos = new NegAdjuntos();
             

            if (strTipoAdjunto.Equals("A"))
            {
                LstAdjuntos = NegArchivosADjuntos.ObtenerAdjuntosFolioTipoSecuencia(intFolioSolicitud, "A", intSecuencia);
                
            }
            else
            {
                LstAdjuntos = NegArchivosADjuntos.ObtenerFolioTipo(intFolioSolicitud, "S");
            }
            grvAdjunto.DataSource = LstAdjuntos;
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
        }
    
}