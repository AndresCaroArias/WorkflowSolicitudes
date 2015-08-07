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
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                Funciones ExisteAcceso = new Funciones();

                Boolean ExistePrivilegio = ExisteAcceso.TieneAcceso(intCodRoUser, StrPrivilegio);

                if (ExistePrivilegio.Equals(false))
                {
                    lblAcceso.Text = "ERROR : Usted no tiene acceso a esta opción";
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
            int id = (int)grvUnidad.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvUnidad.Rows[e.RowIndex];
            int intEstadoUnidad;

            System.Web.UI.WebControls.TextBox EditDescripcionUnidad = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDescripcionUnidad");
            string descripcion = EditDescripcionUnidad.Text;


            System.Web.UI.WebControls.CheckBox EditEstadoUnidad = (System.Web.UI.WebControls.CheckBox)Fila.FindControl("chkEditEstadoUnidad");


            

            if (EditEstadoUnidad.Checked)
                {
                    intEstadoUnidad = 1;
                }
                else
                {
                    intEstadoUnidad = 0;
               }
            (new NegUnidades()).ActualizarUnidad(id, descripcion, intEstadoUnidad);

            grvUnidad.EditIndex = -1;
            LoadGrid();


           }

        protected void grvUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, ImageClickEventArgs e)
        {
             int intEstadoUnidad;
            lblMensaje.Text = String.Empty;
            if (txtDescripcionUnidad.Text.Equals(String.Empty))
            {
                lblMensaje.Text = "ERROR: Ingrese la descripción del rol";
               
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
                lblMensaje.Text = "ERROR: Unidad ya existe";
                txtDescripcionUnidad.Text = String.Empty;
                return;
            }


            NegocioUnidades.AltaUnidades(txtDescripcionUnidad.Text, intEstadoUnidad);
           
           
            {

                LoadGrid();
            }

        }
        }
    }
