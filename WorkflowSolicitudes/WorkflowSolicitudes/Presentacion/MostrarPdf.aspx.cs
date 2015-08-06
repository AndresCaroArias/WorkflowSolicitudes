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
    public partial class MoatrarPdf : System.Web.UI.Page
    {
        public static int  intIdArchivo { get; set; }
        public static List<Adjuntos> LstAdjuntos = new List<Adjuntos>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Byte[] bteArchivoPdf;

                
                List<Adjuntos> LstAdjuntos = new List<Adjuntos>();
                bteArchivoPdf = (byte[])Session["bteArchivoPdf"];

                if (bteArchivoPdf != null)
                {
                    Response.ContentType = "varbinary(MAX)/pdf";
                    Response.Expires = 0;
                    Response.Buffer = true;
                    Response.Clear();
                    Response.BinaryWrite(bteArchivoPdf);
                    Response.End();
                }

            }   
                
                

            
           
            

        }
    }
}