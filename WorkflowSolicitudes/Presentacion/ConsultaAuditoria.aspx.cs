using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class ConsultaAuditoria: System.Web.UI.Page
    {
        public static int intCodRoUser { get; set; }
        public static string strPrivilegio = "ConsultaAuditoria.aspx";
        public static string strRutUsuario { get; set; }
        public static string strIP { get; set; }
        public static DateTime dtmFechaDesde { get; set; }
        public static DateTime dtmFechaHasta { get; set; }
        public static string strDispositivo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                leer_ComboDispositivos();
                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }
        }

        public void leer_ComboDispositivos()
        {
            NegAuditoria NegAuditorias = new NegAuditoria();
            ddlDispositivo.DataSource = NegAuditorias.obtenerDispositivo();
            ddlDispositivo.DataTextField = "strDispositivo";
            ddlDispositivo.DataValueField = "strDispositivo";
            ddlDispositivo.DataBind();
            ddlDispositivo.Items.Insert(0, new ListItem("Todos", null));
        }

        protected void ImagenCalendario1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaDesde.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void ImagenCalendario2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaHasta.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
        /* Sin error */
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Page page = new Page();
            HtmlForm form = new HtmlForm();

            grvConsultaAuditoria.EnableViewState = false;

            page.EnableEventValidation = false;
            page.DesignerInitialize();
            page.Controls.Add(form);
            form.Controls.Add(grvConsultaAuditoria);

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

        }


        protected void grvConsultaAuditoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvConsultaAuditoria.SelectedRow; 
        }

        protected void grvConsultaAuditoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConsultaAuditoria.PageIndex = e.NewPageIndex;
            BindData();
        }

        private void BindData()
        {

            NegAuditoria NegCSolicitude = new NegAuditoria();
            grvConsultaAuditoria.DataSource = NegCSolicitude.select_All_Auditoria(strRutUsuario, dtmFechaDesde, dtmFechaHasta, strIP, strDispositivo);
            grvConsultaAuditoria.DataBind();

        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

            grvConsultaAuditoria.DataSource = string.Empty;
            grvConsultaAuditoria.DataBind();

                if (txtFechaDesde.Text != String.Empty && txtFechaHasta.Text != String.Empty)
                {

                    if ((Convert.ToDateTime(txtFechaDesde.Text)) > (Convert.ToDateTime(txtFechaHasta.Text)))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: FechaSolicitud inicio es mayor a la FechaSolicitud de Termino');</script>");
                        txtFechaDesde.Text = String.Empty;
                        txtFechaHasta.Text = String.Empty;
                        return;
                    }
                }

                if (txtFechaDesde.Text.Equals(String.Empty))
                {
                    dtmFechaDesde = Convert.ToDateTime("01/01/0001");
                }
                else
                {
                    dtmFechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
                }


                if (txtFechaHasta.Text.Equals(String.Empty))
                {
                    dtmFechaHasta = Convert.ToDateTime("01/01/0001");
                }
                else
                {
                    dtmFechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
                }



                if (txtRutUsuario.Text.Equals(string.Empty))
                {
                    strRutUsuario = Convert.ToString(DBNull.Value);
                }
                else
                {
                    strRutUsuario = txtRutUsuario.Text;
                }


                if (txtIP.Text.Equals(string.Empty))
                {
                    strIP = Convert.ToString(DBNull.Value);
                }
                else
                {
                    strIP = txtIP.Text;
                }

                if (ddlDispositivo.SelectedValue.Equals("Todos"))
                {
                    strDispositivo = Convert.ToString(DBNull.Value);
                }
                else
                {
                    strDispositivo = Convert.ToString(ddlDispositivo.SelectedValue);
                }

                NegAuditoria NegAuditorias = new NegAuditoria();
                grvConsultaAuditoria.DataSource = NegAuditorias.select_All_Auditoria(strRutUsuario, dtmFechaDesde, dtmFechaHasta, strIP, strDispositivo);
                grvConsultaAuditoria.DataBind();
            }

        protected void grvConsultaAuditoria_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grvConsultaAuditoria.PageIndex = e.NewPageIndex;
        
        
}

    }

}

                
