using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class ConsultaActividad : System.Web.UI.Page
    {
        public static int intCodActividad { get; set; }
        public static int intCodTipoSolicitud { get; set; }
        public static int intCodEstado { get; set; }
        public static int intCodUnidad { get; set; }
        public static DateTime dtmFechaRecepDesde{ get;set;}
        public static DateTime dtmFechaRecepHasta{ get;set;}
        public static DateTime dtmFechaEjecDesde{ get;set;}
        public static DateTime dtmFechaEjecHasta{ get;set;}
        public static DateTime dtmFechaResolDesde{ get;set;}
        public static DateTime dtmFechaResolHasta { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lee_ComboTipoSolicitud();
                lee_comboEstado();
                lee_ComboActividad();
                lee_ComboUnidad();
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                Calendar3.Visible = false;
                Calendar4.Visible = false;
                Calendar5.Visible = false;
                Calendar6.Visible = false;
   
            }
        }


        private void lee_ComboTipoSolicitud()
        {
            NegTipoSolicitud NegTipoSolicitudes = new NegTipoSolicitud();
            ddlTipoSolicitud.DataSource = NegTipoSolicitudes.ObtenerTodosLosTipoSolicitud();
            ddlTipoSolicitud.DataTextField = "strDescripcionSolicitud";
            ddlTipoSolicitud.DataValueField = "intCodTipoSolicitud";
            ddlTipoSolicitud.DataBind();
            ddlTipoSolicitud.Items.Insert(0, new ListItem("Todos", null));
        }

        private void lee_comboEstado()
        {
            NegDetalleSolicitud NegDetaSolAct = new NegDetalleSolicitud();
            ddlEstado.DataSource = NegDetaSolAct.ObtenerActDetalleSolicitud();
            ddlEstado.DataTextField = "strEstado";
            ddlEstado.DataValueField = "intCodEstado";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("Todos", null));
        }

        private void lee_ComboActividad()
        {
            NegActividad NegActividades = new NegActividad();
            ddlTipoActividad.DataSource = NegActividades.ObtenerActividad();
            ddlTipoActividad.DataTextField = "strDescripActividad";
            ddlTipoActividad.DataValueField = "intCodActividad";
            ddlTipoActividad.DataBind();
            ddlTipoActividad.Items.Insert(0, new ListItem("Todos", null));
         }

        private void lee_ComboUnidad()
        {
            NegUnidades NegUnidad = new NegUnidades();
            ddlUnidad.DataSource = NegUnidad.ObtenerUnidades();
            ddlUnidad.DataTextField = "strDescripcionUnidad";
            ddlUnidad.DataValueField = "intCodUnidad";
            ddlUnidad.DataBind();
            ddlUnidad.Items.Insert(0, "Todos");
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
            txtFechaRecepcionDesde.Text = Calendar1.SelectedDate.ToShortDateString();
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
            txtFechaRecepcionHasta.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void ImagenCalendario3_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar3.Visible)
            {
                Calendar3.Visible = false;
            }
            else
            {
                Calendar3.Visible = true;
            }
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaEjecDesde.Text = Calendar3.SelectedDate.ToShortDateString();
            Calendar3.Visible = false;
        }

        protected void ImagenCalendario4_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar4.Visible)
            {
                Calendar4.Visible = false;
            }
            else
            {
                Calendar4.Visible = true;
            }
        }

        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaEjecHasta.Text = Calendar4.SelectedDate.ToShortDateString();
            Calendar4.Visible = false;
        }

        protected void ImagenCalendario5_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar5.Visible)
            {
                Calendar5.Visible = false;
            }
            else
            {
                Calendar5.Visible = true;
            }
        }

        protected void Calendar5_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaResolDesde.Text = Calendar5.SelectedDate.ToShortDateString();
            Calendar5.Visible = false;
        }

        protected void ImagenCalendario6_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar6.Visible)
            {
                Calendar6.Visible = false;
            }
            else
            {
                Calendar6.Visible = true;
            }
        }

        protected void Calendar6_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaResolHasta.Text = Calendar6.SelectedDate.ToShortDateString();
            Calendar6.Visible = false;
        }


        protected void grvConsultaActividad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConsultaActividad.PageIndex = e.NewPageIndex;
            BindData();

        }

 

        private void BindData()
        {
            NegCSolicitudes NegCSolicitudes = new NegCSolicitudes();
            grvConsultaActividad.DataSource = NegCSolicitudes.ConsultaDetAct(intCodTipoSolicitud,
                                                                                intCodActividad,
                                                                                intCodEstado,
                                                                                intCodUnidad,
                                                                                dtmFechaRecepDesde,
                                                                                dtmFechaRecepHasta,
                                                                                dtmFechaEjecDesde,
                                                                                dtmFechaEjecHasta,
                                                                                dtmFechaResolDesde,
                                                                                dtmFechaResolHasta
                                                                                );
            grvConsultaActividad.DataBind();

        }

        protected void grvConsultaActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvConsultaActividad.SelectedRow;
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            lblError.Text = string.Empty;
            //grvConsultaActividad.DataSource = string.Empty;
            //grvConsultaActividad.DataBind()  ;


            if (txtFechaRecepcionDesde.Text != String.Empty && txtFechaRecepcionHasta.Text != String.Empty)
            {

                if ((Convert.ToDateTime(txtFechaRecepcionDesde.Text)) > (Convert.ToDateTime(txtFechaRecepcionHasta.Text)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: FechaSolicitud inicio es mayor a la FechaSolicitud de Termino');</script>");
                    txtFechaRecepcionDesde.Text = String.Empty;
                    txtFechaRecepcionHasta.Text = String.Empty;
                    txtFechaEjecDesde.Text = String.Empty;
                    txtFechaEjecHasta.Text = String.Empty;
                    txtFechaResolDesde.Text = String.Empty;
                    txtFechaResolHasta.Text = String.Empty;
                    return;
                }
            }


            if (txtFechaEjecDesde.Text != String.Empty && txtFechaEjecHasta.Text != String.Empty)
            {

                if ((Convert.ToDateTime(txtFechaEjecDesde.Text)) > (Convert.ToDateTime(txtFechaEjecHasta.Text)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: FechaSolicitud inicio es mayor a la FechaSolicitud de Termino');</script>");
                    txtFechaRecepcionDesde.Text = String.Empty;
                    txtFechaRecepcionHasta.Text = String.Empty;
                    txtFechaEjecDesde.Text = String.Empty;
                    txtFechaEjecHasta.Text = String.Empty;
                    txtFechaResolDesde.Text = String.Empty;
                    txtFechaResolHasta.Text = String.Empty;
                    return;
                }
            }

            if (txtFechaResolDesde.Text != String.Empty && txtFechaResolHasta.Text != String.Empty)
            {

                if ((Convert.ToDateTime(txtFechaResolDesde.Text)) > (Convert.ToDateTime(txtFechaResolHasta.Text)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: FechaSolicitud inicio es mayor a la FechaSolicitud de Termino');</script>");
                    txtFechaRecepcionDesde.Text = String.Empty;
                    txtFechaRecepcionHasta.Text = String.Empty;
                    txtFechaEjecDesde.Text = String.Empty;
                    txtFechaEjecHasta.Text = String.Empty;
                    txtFechaResolDesde.Text = String.Empty;
                    txtFechaResolHasta.Text = String.Empty;
                    return;
                }
            }

            if (txtFechaRecepcionDesde.Text.Equals(String.Empty))
            {
                dtmFechaRecepDesde = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaRecepDesde = Convert.ToDateTime(txtFechaRecepcionDesde.Text);
            }

            if (txtFechaRecepcionHasta.Text.Equals(String.Empty))
            {
                dtmFechaRecepHasta = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaRecepHasta = Convert.ToDateTime(txtFechaRecepcionHasta.Text);
            }


            if (txtFechaEjecDesde.Text.Equals(String.Empty))
            {
                dtmFechaEjecDesde = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaEjecDesde = Convert.ToDateTime(txtFechaEjecDesde.Text);
            }


            if (txtFechaEjecHasta.Text.Equals(String.Empty))
            {
                dtmFechaEjecHasta = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaEjecHasta = Convert.ToDateTime(txtFechaEjecHasta.Text);
            }



            if (txtFechaResolDesde.Text.Equals(String.Empty))
            {
                dtmFechaResolDesde = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaResolDesde = Convert.ToDateTime(txtFechaResolDesde.Text);
            }

            if (txtFechaResolHasta.Text.Equals(String.Empty))
            {
                dtmFechaResolHasta = Convert.ToDateTime("01/01/0001");
            }
            else
            {
                dtmFechaResolHasta = Convert.ToDateTime(txtFechaResolHasta.Text);
            }




            if (ddlTipoActividad.SelectedValue.Equals("Todos"))
            {
                intCodActividad = 0;
            }
            else
            {
                intCodActividad = Convert.ToInt32(ddlTipoActividad.SelectedValue);
            }


            if (ddlTipoSolicitud.SelectedValue.Equals("Todos"))
            {
                intCodTipoSolicitud = 0;
            }
            else
            {
                intCodTipoSolicitud = Convert.ToInt32(ddlTipoSolicitud.SelectedValue);
            }

            if (ddlEstado.SelectedValue.Equals("Todos"))
            {
                intCodEstado = 0;
            }
            else
            {
                intCodEstado = Convert.ToInt32(ddlEstado.SelectedValue);
            }

            if (ddlUnidad.SelectedValue.Equals("Todos"))
            {
                intCodUnidad = 0;
            }
            else
            {
                intCodUnidad = Convert.ToInt32(ddlUnidad.SelectedValue);
            }


            NegCSolicitudes NegCSolicitudes = new NegCSolicitudes();
            grvConsultaActividad.DataSource = NegCSolicitudes.ConsultaDetAct(   intCodTipoSolicitud,
                                                                                intCodActividad,
                                                                                intCodEstado,
                                                                                intCodUnidad,
                                                                                dtmFechaRecepDesde,
                                                                                dtmFechaRecepHasta,
                                                                                dtmFechaEjecDesde,
                                                                                dtmFechaEjecHasta,
                                                                                dtmFechaResolDesde,
                                                                                dtmFechaResolHasta
                                                                                );
            grvConsultaActividad.DataBind();

        }

    }
}