using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web21 : System.Web.UI.Page
    {

        public static String StrPrivilegio = "MantPrivilegios.aspx";
        public static string gblAccion { get; set; }
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static int intCodPrivilegios { get; set; }
        public static String strDescPrivilegios { get; set; }
        public static String strNomPrivilegios { get; set; }
        public static String strEstadoPrivilegios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                gblAccion = String.Empty;
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
            NegPrivilegios NegocioPrivi = new NegPrivilegios();
            grvPrivilegios.DataSource = NegocioPrivi.ObtenerPrivilegios();
            grvPrivilegios.DataBind();
            txtDescripcionPrivilegios.Text = string.Empty;
            TxtNombre.Text = string.Empty;
          
        }
        

        protected void grvPrivilegios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPrivilegios.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void grvPrivilegios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvPrivilegios.EditIndex = -1;
            LoadGrid();
        }

        protected void grvPrivilegios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Existe;
            int id = (int)grvPrivilegios.DataKeys[e.RowIndex].Values[0];

            int intCodPrivilegios = (int)grvPrivilegios.DataKeys[e.RowIndex].Values[0];
            NegPrivilegios ExitePrivi = new NegPrivilegios();
            Existe = ExitePrivi.ExistePrivilegio_RolesPrivilegios(intCodPrivilegios);
            if (Existe > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : No se puede eliminar ya que existe en la tabla Roles Privilegios');</script>");
                 
                return;
            }

            if (id > 0)
            {
                NegPrivilegios Neg = new NegPrivilegios();
                Neg.EliminarPrivilegios(id);
                LoadGrid();
            }

            grvPrivilegios.EditIndex = -1;
            LoadGrid();
        }

        protected void grvPrivilegios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvPrivilegios.SelectedRow;
            intCodPrivilegios   = Convert.ToInt32(grvPrivilegios.DataKeys[row.RowIndex].Values["intCodPrivilegios"]);
            strDescPrivilegios = Convert.ToString(grvPrivilegios.DataKeys[row.RowIndex].Values["strDescPrivilegios"]);
            strNomPrivilegios = Convert.ToString(grvPrivilegios.DataKeys[row.RowIndex].Values["strNomPrivilegios"]);
            strEstadoPrivilegios = Convert.ToString(grvPrivilegios.DataKeys[row.RowIndex].Values["strEstadoPrivilegios"]);
            

            txtDescripcionPrivilegios.Text = strDescPrivilegios;
            TxtNombre.Text = strNomPrivilegios;

            if (strEstadoPrivilegios.Equals("ACTIVO"))
            {
                chkEstado.Checked = true;
            }
            else
            {
                chkEstado.Checked = false;
            }

            gblAccion = "Actualizar";
            
        }

        protected void grvPrivilegios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        }

        protected void grvPrivilegios_RowEditing(object sender, GridViewEditEventArgs e)
        {
        
        }

        

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            int intEstadoPrivilegios;
            lblMensaje.Text = String.Empty;
            NegPrivilegios NegocioPrivi = new  NegPrivilegios ();
            
            if (txtDescripcionPrivilegios.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese la descripción del privilegios');</script>");
                return;
            }

            if (TxtNombre.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese el nombre del privilegios');</script>");
                return;
            }


             if (txtDescripcionPrivilegios.Equals(String.Empty))
            {
              ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Debe ingresar la descripción del privilegio');</script>");
                return;
            }

             if (chkEstado.Checked)
             {
                 intEstadoPrivilegios = 1;
             }
             else
             {
                 intEstadoPrivilegios = 0;
             }

            


             if (gblAccion.Equals("Actualizar"))
             {
                 NegocioPrivi.ActualizarPrivilegios(intCodPrivilegios, txtDescripcionPrivilegios.Text, TxtNombre.Text, intEstadoPrivilegios);
                 gblAccion = String.Empty;
             }
             else
             {

                 NegPrivilegios NegocioPrivilegios = new NegPrivilegios();

                 int intExistePrivi;

                 intExistePrivi = NegocioPrivilegios.select_ExistePrivi_Privi(txtDescripcionPrivilegios.Text);


                 if (!intExistePrivi.Equals(0))
                 {
                     ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Privilegio ya existe');</script>");

                     txtDescripcionPrivilegios.Text = String.Empty;
                     return;
                 }

                 int intExisteNomPrivi;
                 intExisteNomPrivi = NegocioPrivilegios.select_ExistePrivi_NomPrivi(TxtNombre.Text);


                 if (!intExisteNomPrivi.Equals(0))
                 {
                     ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Nombre ya existe');</script>");

                     TxtNombre.Text = String.Empty;
                     return;
                 }
                 
                 
                 
                 
                 
                 NegocioPrivi.AltaPrivilegios(txtDescripcionPrivilegios.Text, TxtNombre.Text, intEstadoPrivilegios);
             }
             ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Grabación Exitosa');</script>");

            LoadGrid();
            }
        }
        
    }
