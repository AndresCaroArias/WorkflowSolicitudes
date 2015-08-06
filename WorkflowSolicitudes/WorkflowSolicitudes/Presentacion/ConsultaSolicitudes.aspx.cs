using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WorkflowSolicitudes.Entidades;




namespace WorkflowSolicitudes.Presentacion
{
    public partial class ConsultaSolicitudes : System.Web.UI.Page
    {
        public static int intFolio { get; set; }
        public static string strRut { get; set; }
        public static int intFolioSolicitud { get; set; }
        public static DateTime dtmFechaSolicitud { get; set; }
        public static DateTime dtmFechaSolicitudHasta { get; set; }
        public static DateTime dtmFechaResolucion { get; set; }
        public static DateTime dtmFechaResolucionHasta { get; set; }
        public static int intTipoSolicitud { get; set; }
        public static string strCarrera { get; set; }
        public static int intEstado { get; set; }
        public static string strCodCarr { get; set; }
        public static string StrPrivilegio = "ConsultaSolicitudes.aspx";
        public static string StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static string strJornada { get; set; }
        public static string strOrigen { get; set; }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)

            {
                
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);

                intFolioSolicitud = Convert.ToInt32(Request.QueryString["Folio"]);
               
  
                Funciones ExisteAcceso = new Funciones();

                Boolean ExistePrivilegio = ExisteAcceso.TieneAcceso(intCodRoUser, StrPrivilegio);

                if (ExistePrivilegio.Equals(false))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Usted no tiene acceso a esta opción');</script>");
                    
                    return;
                }


                lee_ComboTipoSolicitud();
                lee_ComboEstados();
                lee_ComboCarrera();
                Calendario1.Visible = false;
                Calendario2.Visible = false;
                Calendario3.Visible = false;
                Calendario4.Visible = false;
               
            }
                }
        

        private void lee_ComboTipoSolicitud()
        {
            NegTipoSolicitud NegTipoSolicitudes = new NegTipoSolicitud();
            ddlTipoSolicitud.DataSource = NegTipoSolicitudes.ObtenerTodosLosTipoSolicitud();
            ddlTipoSolicitud.DataTextField = "strDescripcionSolicitud";
            ddlTipoSolicitud.DataValueField = "intCodTipoSolicitud";
            ddlTipoSolicitud.DataBind();
            ddlTipoSolicitud.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", null));
        }

        private void lee_ComboCarrera()
        {
            NegCarrera NegCarreras = new NegCarrera();
            ddlCarrera.DataSource = NegCarreras.ObtenerCarrera();
            ddlCarrera.DataTextField = "strDescripcionCarrera";
            ddlCarrera.DataValueField = "strCodCarrera";
            ddlCarrera.DataBind();
            ddlCarrera.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", null));
        }

        private void lee_ComboEstados()
        {
            NegEstados NegEstado = new NegEstados();
            ddlEstado.DataSource = NegEstado.ObtenerEstados();
            ddlEstado.DataTextField = "strDescEstado";
            ddlEstado.DataValueField = "intCodEstado";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos", null));
        }

        
        protected void ImagenCalendario1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendario1.Visible)
            {
                Calendario1.Visible = false;
            }
            else
            {
                Calendario1.Visible = true;
            }

        }
        protected void Calendario1_SelectionChanged(object sender, EventArgs e)
        {
            TxtFechaSolicitud.Text = Calendario1.SelectedDate.ToShortDateString();
            Calendario1.Visible = false;
        }

        protected void ImagenCalendario2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendario2.Visible)
            {
                Calendario2.Visible = false;
            }
            else
            {
                Calendario2.Visible = true;
            }

        }
        protected void Calendario2_SelectionChanged(object sender, EventArgs e)
        {
            TxtFechaSolicitudHasta.Text = Calendario2.SelectedDate.ToShortDateString();
            Calendario2.Visible = false;
        }

        protected void ImagenCalendario3_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendario3.Visible)
            {
                Calendario3.Visible = false;
            }
            else
            {
                Calendario3.Visible = true;
            }
        }
        protected void Calendario3_SelectionChanged(object sender, EventArgs e)
        {
            TxtFechaResolucion.Text = Calendario3.SelectedDate.ToShortDateString();
            Calendario3.Visible = false;

        }

        protected void ImagenCalendario4_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendario4.Visible)
            {
                Calendario4.Visible = false;
            }
            else
            {
                Calendario4.Visible = true;
            }
        }
        protected void Calendario4_SelectionChanged(object sender, EventArgs e)
        {
            TxtFechaResolucionHasta.Text = Calendario4.SelectedDate.ToShortDateString();
            Calendario4.Visible = false;

        }


        protected void grvConsultaSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e) 
                    {
                        grvConsultaSolicitud.PageIndex = e.NewPageIndex;
                        BindData();
                        
                    }
        protected void grvConsultaSolicitud_Sorting(object sender, GridViewSortEventArgs e)
                    {
                    }

        protected void grvConsultaSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvConsultaSolicitud.SelectedRow;
            int Folio = Convert.ToInt32(grvConsultaSolicitud.DataKeys[row.RowIndex].Value);
            Response.Redirect("Seguimiento.aspx?folio=" + Folio);

        }

        
        protected void BtnExcel_Click(object sender, ImageClickEventArgs e)
        {

            /* Sin error */
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            grvConsultaSolicitud.EnableViewState = false;

            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(grvConsultaSolicitud);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

            //grvConsultaSolicitud.AllowPaging = true;
            
            
        }

        private void BindData()
        {   
            //DataSet ds = new DataSet();
            NegCSolicitudes NegCSolicitude = new NegCSolicitudes();
            grvConsultaSolicitud.DataSource = NegCSolicitude.select_All_CSolicitudes(intFolio, strRut, intTipoSolicitud, strCarrera, intEstado, dtmFechaSolicitud, dtmFechaSolicitudHasta, dtmFechaResolucion, dtmFechaResolucionHasta, strJornada, strOrigen); 
            grvConsultaSolicitud.DataBind();

        }


        //public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        //{

        //// Confirms that an HtmlForm control is rendered for the specified ASP.NET server control at run time.

        //}

        protected void enviar(object sender, ImageClickEventArgs e)
        {
            if(TxtFechaSolicitud.Text != String.Empty && TxtFechaSolicitudHasta.Text != String.Empty){

            if ((Convert.ToDateTime(TxtFechaSolicitud.Text) )> (Convert.ToDateTime(TxtFechaSolicitudHasta.Text)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: FechaSolicitud inicio es mayor a la FechaSolicitud de Termino');</script>");
                TxtFechaSolicitud.Text = String.Empty;
                TxtFechaSolicitudHasta.Text = String.Empty;
                TxtFechaResolucion.Text = String.Empty;
                TxtFechaResolucionHasta.Text = String.Empty;
                return;
            }
            }

            if (TxtFechaResolucion.Text != String.Empty && TxtFechaResolucionHasta.Text != String.Empty)
            {
                if ((Convert.ToDateTime(TxtFechaResolucion.Text)) > (Convert.ToDateTime(TxtFechaResolucionHasta.Text)))
                {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: FechaSolicitud inicio es mayor a la FechaSolicitud de Termino');</script>");
                TxtFechaSolicitud.Text = String.Empty;
                TxtFechaSolicitudHasta.Text = String.Empty;
                TxtFechaResolucion.Text = String.Empty;
                TxtFechaResolucionHasta.Text = String.Empty;
                return;
            }
            }
            
            if (TxtFolio.Text == "")
            {
                intFolio = 0;
            }
            else
            {
                intFolio = Convert.ToInt32(TxtFolio.Text);
            }

            if (TxtRut.Text == "")
            {
                strRut = null;
            }
            else
            {
                strRut = (TxtRut.Text);
            }

            if (TxtFechaSolicitud.Text.Equals(String.Empty))
            {
                dtmFechaSolicitud = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaSolicitud = Convert.ToDateTime(TxtFechaSolicitud.Text);
            }


            if (TxtFechaSolicitudHasta.Text.Equals(String.Empty))
            {
                dtmFechaSolicitudHasta = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaSolicitudHasta = Convert.ToDateTime(TxtFechaSolicitudHasta.Text);
            }

            if (TxtFechaResolucion.Text.Equals(String.Empty))
            {
                dtmFechaResolucion = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaResolucion = Convert.ToDateTime(TxtFechaResolucion.Text);
            }

            if (TxtFechaResolucionHasta.Text.Equals(String.Empty))
            {
                dtmFechaResolucionHasta = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaResolucionHasta = Convert.ToDateTime(TxtFechaResolucionHasta.Text);
            }

            if (ddlCarrera.SelectedValue.Equals("Todos"))
            {
                strCarrera = "0";
            }
            else
            {
                strCarrera = Convert.ToString(ddlCarrera.SelectedValue);
            }

            intTipoSolicitud = Convert.ToInt32(ddlTipoSolicitud.SelectedIndex);

            
            if (ddlOrigen.SelectedValue.Equals("Todos"))
            {
                strOrigen = "null";
            }
            else
            {
                strOrigen = Convert.ToString(ddlOrigen.SelectedValue);
            }




            intEstado = Convert.ToInt32(ddlEstado.SelectedIndex);
            strJornada = ddlJornada.SelectedValue;
            NegCSolicitudes NegCSolicitude = new NegCSolicitudes();
            grvConsultaSolicitud.DataSource = NegCSolicitude.select_All_CSolicitudes(intFolio, strRut, intTipoSolicitud, strCarrera, intEstado, dtmFechaSolicitud, dtmFechaSolicitudHasta, dtmFechaResolucion, dtmFechaResolucionHasta, strJornada, strOrigen);
            grvConsultaSolicitud.DataBind();
        }

        protected void grvConsultaSolicitud_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            intFolioSolicitud = (int)grvConsultaSolicitud.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvConsultaSolicitud.Rows[e.RowIndex];

            Response.Redirect("VerAdjuntos.aspx?Folio="+intFolioSolicitud+"&Tipo=S");

        }

        protected void grvConsultaSolicitud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            String strNombreArchivoPDF = String.Empty;

            string strRutAlumno            = String.Empty;
            string strNombreAlumno         = String.Empty;
            string strNombreCarrera        = String.Empty;
            string strNumCelular           = String.Empty;            
            string strCorreo               = String.Empty;
            string strDescTipoSolicitud    = String.Empty;
            string strGlosaSolicitud       = String.Empty;
            string strFechaSolicitud       = String.Empty;
            string strGlosaEstadoSolicitud = String.Empty;
            int intCodTipoSolicitud     = 0;
            
            
            DateTime Hoy = DateTime.Today;
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");

            int intFolioSolicitud = (int)grvConsultaSolicitud.DataKeys[e.RowIndex].Values[0];

            strNombreArchivoPDF = @"C:\Solicitud" + "_" + intFolioSolicitud  +"_"+ fecha_actual + ".pdf";

            List<Solicitud> lstSolicitud = new List<Solicitud>();
            NegSolicitud NegSolicitudes = new NegSolicitud();


            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(strNombreArchivoPDF, FileMode.Create));
           
            doc.AddTitle("Detalle de la Solicitud");
            doc.AddCreator("Workflow Solicitudes CIISA");

            
            doc.Open();
            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\logoCiisaPDF.jpg");
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 45 / imagen.Width;
            imagen.ScalePercent(percentage * 100);
            doc.Add(imagen);
            
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            lstSolicitud = NegSolicitudes.ObtenerSolicitudesByFolio(intFolioSolicitud);

            foreach (Solicitud Solicitudes in lstSolicitud)
            {
                strRutAlumno = Solicitudes.strRutAlumno;
                strNumCelular = Solicitudes.strCelularContacto;
                strCorreo = Solicitudes.strEmailContacto;
                strDescTipoSolicitud = Solicitudes.strDescripcionSolicitud;
                strGlosaSolicitud = Solicitudes.strGlosaSolicitud;
                strFechaSolicitud = Convert.ToString(Solicitudes.dtmFechaSolicitud);
                intCodTipoSolicitud = Solicitudes.intCodTipoSolicitud;
                strGlosaEstadoSolicitud = Solicitudes.strGlosaEstado;
            }

            List<Alumnos> LstAlumnnos = new List<Alumnos>();
            NegAlumnos NegAlumno = new NegAlumnos();

            LstAlumnnos = NegAlumno.ObtenerInfoAlumnoByCodCli(strRutAlumno);

            foreach (Alumnos alumno in LstAlumnnos)
            {
                StringBuilder strnombre = new StringBuilder();
                strnombre.Append(alumno.StrNombre);
                strnombre.Append(" ");
                strnombre.Append(alumno.StrApPaterno);
                strnombre.Append(" ");
                strnombre.Append(alumno.StrApMaterno);


                strNombreAlumno = strnombre.ToString();
                strNombreCarrera = alumno.StrNombreCarrera;

            }

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Información de la Solicitud"));
            doc.Add(new Paragraph("Instituto de Ciencias Tecnológicas"));
            doc.Add(Chunk.NEWLINE);


            iTextSharp.text.Font myfontEncabezado = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Paragraph myParagraph = new Paragraph("Datos del alumno \n\n", myfontEncabezado);
            doc.Add(myParagraph); 

            doc.Add(new Paragraph("Rut Alumnno        :" + strRutAlumno ));
            doc.Add(new Paragraph("Nombre Alumno      :" + strNombreAlumno));
            doc.Add(new Paragraph("N° Teléfono        :" + strNumCelular));
            doc.Add(new Paragraph("Correo Electrónico :" + strCorreo));
            doc.Add(new Paragraph("Carrera            :" + strNombreCarrera));
            doc.Add(Chunk.NEWLINE);

            Paragraph myParagraph2 = new Paragraph("Datos de la solicitud \n\n", myfontEncabezado);
            doc.Add(myParagraph2);

            doc.Add(new Paragraph("Folio Solicitud  :" + intFolioSolicitud));
            doc.Add(new Paragraph("Fecha Solicitud  :" + strFechaSolicitud));
            doc.Add(new Paragraph("Tipo Solicitud   :" + strDescTipoSolicitud));
            doc.Add(new Paragraph("Petición         :" + strGlosaSolicitud));
            doc.Add(new Paragraph("Estado Solicitud :" + strGlosaEstadoSolicitud));
            doc.Add(Chunk.NEWLINE);

            

            List<WorkflowSolicitudes.Entidades.DetalleSolicitud> LstHistory = new List<WorkflowSolicitudes.Entidades.DetalleSolicitud>();
            NegDetalleSolicitud NegDetSol = new NegDetalleSolicitud();
            LstHistory = NegDetSol.HistorialDetalleSolicitud(intFolioSolicitud);

            if (!LstHistory.Count.Equals(0))
            {

                Paragraph myParagraph3 = new Paragraph("Detalles de la Solicitud \n\n", myfontEncabezado);
                doc.Add(myParagraph3);

                PdfPTable tblPrueba = new PdfPTable(6);
                tblPrueba.WidthPercentage = 100;

                PdfPCell clSecuencia = new PdfPCell(new Phrase("Secuencia", _standardFont));
                clSecuencia.BorderWidth = 0;
                clSecuencia.BorderWidthBottom = 0.75f;

                PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
                clNombre.BorderWidth = 0;
                clNombre.BorderWidthBottom = 0.75f;

                PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
                clApellido.BorderWidth = 0;
                clApellido.BorderWidthBottom = 0.75f;

                PdfPCell clObservacion = new PdfPCell(new Phrase("Observación", _standardFont));
                clObservacion.BorderWidth = 0;
                clObservacion.BorderWidthBottom = 0.75f;

                PdfPCell clFechaResolucion = new PdfPCell(new Phrase("Fecha Resolución", _standardFont));
                clFechaResolucion.BorderWidth = 0;
                clFechaResolucion.BorderWidthBottom = 0.75f;

                PdfPCell clEstado = new PdfPCell(new Phrase("Estado", _standardFont));
                clEstado.BorderWidth = 0;
                clEstado.BorderWidthBottom = 0.75f;

                foreach (WorkflowSolicitudes.Entidades.DetalleSolicitud Detalle in LstHistory)
                {
                    // Añadimos las celdas a la tabla
                    tblPrueba.AddCell(clSecuencia);
                    tblPrueba.AddCell(clNombre);
                    tblPrueba.AddCell(clApellido);
                    tblPrueba.AddCell(clObservacion);
                    tblPrueba.AddCell(clFechaResolucion);
                    tblPrueba.AddCell(clEstado);

                    clSecuencia = new PdfPCell(new Phrase(Convert.ToString(Detalle.intSecuencia), _standardFont));
                    clSecuencia.BorderWidth = 0;

                    clNombre = new PdfPCell(new Phrase(Detalle.strnombre, _standardFont));
                    clNombre.BorderWidth = 0;

                    clApellido = new PdfPCell(new Phrase(Detalle.strApellido, _standardFont));
                    clApellido.BorderWidth = 0;

                    clObservacion = new PdfPCell(new Phrase(Detalle.StrGlosaDetalleSolictud, _standardFont));
                    clObservacion.BorderWidth = 0;

                    clFechaResolucion = new PdfPCell(new Phrase(Detalle.strApellido, _standardFont));
                    clFechaResolucion.BorderWidth = 0;

                    clEstado = new PdfPCell(new Phrase(Detalle.strEstado, _standardFont));
                    clEstado.BorderWidth = 0;

                    tblPrueba.AddCell(clSecuencia);
                    tblPrueba.AddCell(clNombre);
                    tblPrueba.AddCell(clApellido);
                    tblPrueba.AddCell(clObservacion);
                    tblPrueba.AddCell(clFechaResolucion);
                    tblPrueba.AddCell(clEstado);


                    doc.Add(tblPrueba);
                }
               
            }
            doc.Close();
            writer.Close();

            // Creo la Marca de agua 

            System.Diagnostics.Process.Start("AcroRd32.exe", strNombreArchivoPDF);

        }
         
        }
    }
