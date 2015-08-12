using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        public static String StrPrivilegio = "MantUnidades.aspx";
        public static string gblAccion { get; set; }
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static string strDescripcionUnidad {get; set;}
        public static string strEstadoUnidad { get; set; }
        public static int intCodUnidad { get; set; }
        public static int intEstadoUnidad { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gblAccion = "";
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                Funciones ExisteAcceso = new Funciones();

                Boolean ExistePrivilegio = ExisteAcceso.TieneAcceso(intCodRoUser, StrPrivilegio);

                if (ExistePrivilegio.Equals(false))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Usted no tiene acceso a esta opción');</script>");
                    return;
                }
                LoadGrid();      
                }
            
        }

        private void LoadGrid()
        {
            NegUnidades NegocioUnid = new NegUnidades();
            grvUnidad.DataSource = NegocioUnid.ObtenerUnidades();
            grvUnidad.DataBind();
            txtDescripcionUnidad.Text = string.Empty;
            chkEstadoUnidad.Checked = false;

        }

        protected void grvUnidad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUnidad.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void grvUnidad_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvUnidad.EditIndex = -1;
            LoadGrid();
        }

        protected void grvUnidad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        protected void grvUnidad_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvUnidad.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void grvUnidad_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        }

        protected void grvUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = grvUnidad.SelectedRow;

            intCodUnidad = Convert.ToInt32(grvUnidad.DataKeys[row.RowIndex].Values["intCodUnidad"]);
            strDescripcionUnidad = Convert.ToString(grvUnidad.DataKeys[row.RowIndex].Values["strDescripcionUnidad"]);
            strEstadoUnidad = Convert.ToString(grvUnidad.DataKeys[row.RowIndex].Values["strEstadoUnidad"]);

            txtDescripcionUnidad.Text = strDescripcionUnidad;
            if (strEstadoUnidad.Equals("ACTIVO"))
            {
                chkEstadoUnidad.Checked = true;
            }
            else
            {
                chkEstadoUnidad.Checked = false;
            }

            gblAccion = "Actualizar";
        }


        

        protected void btnInsertar_Click(object sender, ImageClickEventArgs e)
        {
             int intEstadoUnidad;
            lblMensaje.Text = String.Empty;
            if (txtDescripcionUnidad.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese la descripción del rol');</script>");
                               
                return;
            }

            if (chkEstadoUnidad.Checked)
            {
                intEstadoUnidad = 1;
            }
            else
            {
                intEstadoUnidad = 0;
            }

                       
            NegUnidades NegocioUnidades = new NegUnidades();

            int intExisteUnidad;


            intExisteUnidad = NegocioUnidades.select_ExisteDescUnid_Unidad (txtDescripcionUnidad.Text);


            if (!intExisteUnidad.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Unidad ya existe');</script>");
                lblMensaje.Text = "";
                txtDescripcionUnidad.Text = String.Empty;
                return;
            }

            if (gblAccion.Equals("Actualizar"))
            {
                (new NegUnidades()).ActualizarUnidad(intCodUnidad, txtDescripcionUnidad.Text, intEstadoUnidad);
                LoadGrid();
                gblAccion = "";
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se actualizo correctamente');</script>");
            }
            else
            {
                NegocioUnidades.AltaUnidades(txtDescripcionUnidad.Text, intEstadoUnidad);
                LoadGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se ingreso correctamente');</script>");
            }


            grvUnidad.EditIndex = -1;
            LoadGrid();
                    




        }
        }
    }
