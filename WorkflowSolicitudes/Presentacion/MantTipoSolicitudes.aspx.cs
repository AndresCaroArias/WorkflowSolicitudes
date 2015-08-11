using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using System.Windows.Forms;


namespace WorkflowSolicitudes
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        public static string gblAccion { get; set; }
        public static String StrPrivilegio = "MantTipoSolicitudes.aspx";
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static string strDescripcionSolicitud { get; set;}
        public static int intCantMaxSolicitud {get; set;}
        public static int intEstadoSolicitud { get; set; }
        public static string strEstadoSolicitud {get; set;}
        public static int intCantMaxDoc { get; set; }
        public static string strOrigenSolicitud { get; set; }
        public static int intCodTipoSolicitud { get; set; }
        public static DateTime dtmFechaTerminoSol { get; set; }
        public static DateTime dtmFechaIncioSol { get; set; }
        public static int intId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                Funciones ExisteAcceso = new Funciones();
                  Boolean ExistePrivilegio = ExisteAcceso.TieneAcceso(intCodRoUser, StrPrivilegio);

                if (ExistePrivilegio.Equals(false))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Usted no tiene acceso a esta opción');</script>");
                    return;
                }

                txtCantidadSol.Text = String.Empty;
                ChkEstado.Checked = false;
                LoadGrid();
                CldFechainicio.Visible = false;
                CldFechaFin.Visible = false;
                lblMensaje.Text = string.Empty;
            }
        }

        


        private bool Validar(string dato)
        {
            if (dato != "")
                return true;

            else
                return false;
        }

        private void LoadGrid()
        {
            NegTipoSolicitud NegAct = new NegTipoSolicitud();
            grvTipoSolicitud.DataSource = NegAct.ObtenerTodosLosTipoSolicitud();
            grvTipoSolicitud.DataBind();
            txtDescripcionTS.Text = string.Empty;

            txtFechaInicio.Text       = string.Empty;
            txtFechaFin.Text          = string.Empty;
            lblMensjeDescripcion.Text = string.Empty;
            lblFechaInicio.Text       = string.Empty;
            lblFechaFin.Text          = string.Empty;
            txtCantidadSol.Text       = string.Empty;
            txtCantMaxDoc.Text        = string.Empty;
            ddlOrigenSolicitud.SelectedIndex = 0;
            ChkEstado.Checked         = false;
            
            
        }

        protected void grvgrvTipoSolicitud_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTipoSolicitud.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void grvTipoSolicitud_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvTipoSolicitud.EditIndex = -1;
            LoadGrid();
        }

        protected void grvTipoSolicitud_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Existe;
            int intCodTipoSolicitud = (int)grvTipoSolicitud.DataKeys[e.RowIndex].Values[0];
            NegTipoSolicitud ExiteFluTip = new NegTipoSolicitud();
            Existe = ExiteFluTip.ExisteTipoFlujoSol(intCodTipoSolicitud); ;
            if (Existe > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : No se puede eliminar ya que existe en la tabla flujo solicitudes');</script>");
                    
                return;
            }

            int id = (int)grvTipoSolicitud.DataKeys[e.RowIndex].Values[0];
            if (id > 0)
            {
                NegTipoSolicitud Neg = new NegTipoSolicitud();
                Neg.EliminarTipoSolicitud(id);
                LoadGrid();
            }

            grvTipoSolicitud.EditIndex = -1;
            LoadGrid();
        }

        protected void grvTipoSolicitud_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvTipoSolicitud.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void grvTipoSolicitud_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            intId = (int)grvTipoSolicitud.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvTipoSolicitud.Rows[e.RowIndex];

        }
                        
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaFin.Text = CldFechaFin.SelectedDate.ToShortDateString();

            DateTime Fechaincio = DateTime.Parse(txtFechaInicio.Text);
            DateTime FechaTermino = DateTime.Parse(txtFechaFin.Text);

            int result = DateTime.Compare(FechaTermino, Fechaincio);
            
            if (result < 0)
            {
                txtFechaFin.Text = string.Empty;
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : La fecha de termino debe ser mayor a la de inicio');</script>");
            }


            if (CldFechaFin.Visible == true)
            {
                CldFechaFin.Visible = false;

            }


        }

        protected void imbInicio_Click(object sender, ImageClickEventArgs e)
        {
            if (CldFechainicio.Visible == false)
            {
                CldFechainicio.Visible = true;
               
            }
            else
            {
                CldFechainicio.Visible = false;
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {

            txtFechaInicio.Text = CldFechainicio.SelectedDate.ToShortDateString();



            if (CldFechainicio.Visible == true)
            {
                CldFechainicio.Visible = false;
                
            }

            CldFechaFin.Visible = false;


        }
        
        protected void grvTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvTipoSolicitud.SelectedRow;
            
            intCodTipoSolicitud = Convert.ToInt32(grvTipoSolicitud.DataKeys[row.RowIndex].Values["intCodTipoSolicitud"]);
            strDescripcionSolicitud = Convert.ToString(grvTipoSolicitud.DataKeys[row.RowIndex].Values["strDescripcionSolicitud"]);
            intCantMaxSolicitud = Convert.ToInt32(grvTipoSolicitud.DataKeys[row.RowIndex].Values["intCantMaxSolicitud"]);
            intEstadoSolicitud = Convert.ToInt32(grvTipoSolicitud.DataKeys[row.RowIndex].Values["intEstadoSolicitud"]);
            strEstadoSolicitud = Convert.ToString(grvTipoSolicitud.DataKeys[row.RowIndex].Values["strEstadoSolicitud"]);
            intCantMaxDoc = Convert.ToInt32(grvTipoSolicitud.DataKeys[row.RowIndex].Values["intCantMaxDoc"]);
            strOrigenSolicitud = Convert.ToString(grvTipoSolicitud.DataKeys[row.RowIndex].Values["strOrigenSolicitud"]);
            dtmFechaTerminoSol = Convert.ToDateTime (grvTipoSolicitud.DataKeys[row.RowIndex].Values["dtmFechaTerminoSol"]);
            dtmFechaIncioSol = Convert.ToDateTime(grvTipoSolicitud.DataKeys[row.RowIndex].Values["dtmFechaIncioSol"]);
    
            txtDescripcionTS.Text = strDescripcionSolicitud;
            txtCantidadSol.Text = Convert.ToString(intCantMaxSolicitud);
            txtCantMaxDoc.Text = Convert.ToString(intCantMaxDoc);
            ddlOrigenSolicitud.SelectedValue = strOrigenSolicitud;
            txtFechaFin.Text = Convert.ToString(dtmFechaTerminoSol);
            txtFechaInicio.Text = Convert.ToString(dtmFechaIncioSol);
            
            if (strEstadoSolicitud.Equals("ACTIVO"))
            {
                ChkEstado.Checked = true;
            }
            else
            {
                ChkEstado.Checked = false;
            }
            gblAccion = "Actualizar";
        
        
        }

        protected void imbInicio_Click1(object sender, ImageClickEventArgs e)
        {
            if (CldFechainicio.Visible == false)
            {
                CldFechainicio.Visible = true;
                CldFechaFin.Visible = false;
            }
            else
            {
                CldFechainicio.Visible = false;
            }
        }

        protected void imbFin_Click(object sender, ImageClickEventArgs e)
        {
            if (CldFechaFin.Visible == false)
            {
                CldFechaFin.Visible = true;
                CldFechainicio.Visible = false;
            }
            else
            {
                CldFechaFin.Visible = false;
            }
        }

        protected void btnInsertarTS_Click(object sender, ImageClickEventArgs e)
        {
        int IntEstado;

        if (ChkEstado.Checked)
	    {
		    IntEstado = 1;
	    } else
	    {
        IntEstado = 0;
	    }
        
    
        if(ddlOrigenSolicitud.Text.Equals("0") ){

            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Ingrese El Origen de la Solicitud');</script>");
            
            return;
        }
  
        if (!Validar(txtDescripcionTS.Text))//envias el textbox que quieres comprobar
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Debe ingresar descripción');</script>");
            
            
        }
        else
        {

            if (!Validar(txtFechaInicio.Text))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Debe ingresar Fecha de inicio');</script>");
            
            }
            else
            {
                if (!Validar(txtFechaFin.Text))
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Debe ingresar Fecha de termino');</script>");
            
                }
                else
                {


                    NegTipoSolicitud NegAct = new NegTipoSolicitud();


                    if (gblAccion.Equals("Insertar"))
                    {
                        if (NegAct.AltaTipoSolicitud(txtDescripcionTS.Text,
                                                 IntEstado,
                                                 DateTime.Parse(txtFechaInicio.Text),
                                                 DateTime.Parse(txtFechaFin.Text),
                                                 int.Parse(txtCantidadSol.Text),
                                                 ddlOrigenSolicitud.Text,
                                                 int.Parse(txtCantMaxDoc.Text)) > 0)
                        {
                            LoadGrid();

                            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se ingreso correctamente');</script>");
            
                            txtCantidadSol.Text = String.Empty;
                            ChkEstado.Checked = false;
                        }

                    }

                    if (gblAccion.Equals("Actualizar"))
                    {
                        (new NegTipoSolicitud()).ActualizarTipoSolicitud(intCodTipoSolicitud, txtDescripcionTS.Text, intEstadoSolicitud, DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text), int.Parse(txtCantidadSol.Text), ddlOrigenSolicitud.Text, int.Parse(txtCantMaxDoc.Text));

                    }

                    grvTipoSolicitud.EditIndex = -1;
                    LoadGrid();
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se actualizó correctamente');</script>");

                }
               
            }
         }

      }




        protected void txtEditFechaInicioTS_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlOrigenSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            gblAccion = "Insertar";
            txtCantidadSol.Text = String.Empty;
            ChkEstado.Checked = false;
            LoadGrid();
            CldFechainicio.Visible = false;
            CldFechaFin.Visible = false;
            lblMensaje.Text = string.Empty;
            ddlOrigenSolicitud.SelectedIndex=0;
            txtCantMaxDoc.Text = String.Empty;
        }

            
              
    }
}