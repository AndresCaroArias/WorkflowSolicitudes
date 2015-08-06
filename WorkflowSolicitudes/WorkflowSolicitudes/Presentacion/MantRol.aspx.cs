using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        public static String StrPrivilegio = "MantRol.aspx";
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
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Usted no tiene acceso a esta opción');</script>");
                    return;
                }

                LoadGrid();

                
            }

        }
        private void LoadGrid()
        {
            NegRol NegocioRol = new NegRol();
            grvRol.DataSource = NegocioRol.ObtenerRol();
            grvRol.DataBind();
           txtDescripcionRol.Text = string.Empty;
        }
        

        protected void grvRol_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvRol.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void grvRol_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Existe;
            int id = (int)grvRol.DataKeys[e.RowIndex].Values[0];

            int intCodRol = (int)grvRol.DataKeys[e.RowIndex].Values[0];
            NegRolesPrivilegios ExiteRolPriv = new NegRolesPrivilegios();
            Existe = ExiteRolPriv.select_ExisteRol_RolesPrivilegios(intCodRol);
            if (Existe > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('No se puede eliminar ya que existe en la tabla Roles Privilegios');</script>");
                
                return;
            }

            if (id > 0)
            {
                NegRol Neg = new NegRol();
                Neg.EliminarRol(id);
                LoadGrid();
            }

            grvRol.EditIndex = -1;
            LoadGrid();
        }

        protected void grvRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvRol.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void grvRol_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grvRol.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvRol.Rows[e.RowIndex];


            System.Web.UI.WebControls.TextBox EditDescripcionRol = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDescripcionRol");
            string descripcion = EditDescripcionRol.Text;

          
            (new NegRol()).ActualizarRol(id, descripcion);

            grvRol.EditIndex = -1;
            LoadGrid();
        }

        protected void grvRol_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            grvRol.EditIndex = -1;
            LoadGrid();
        }

        protected void grvRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        protected void btnInsertar_Click(object sender, ImageClickEventArgs e)
        {
       
            int intEstadoRol;
            lblMensaje.Text = String.Empty;
            if (txtDescripcionRol.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Ingrese la descripción del rol');</script>");
                
               
                return;
            }

            if (chkEstadoRol.Checked)
            {
                intEstadoRol = 1;
            }
            else
            {
                intEstadoRol = 0;
            }

                       
            NegRol NegocioRol = new NegRol();

            int intExisteRol;


            intExisteRol = NegocioRol.select_ExisteRol_Roles(txtDescripcionRol.Text);


            if (!intExisteRol.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Rol ya existe');</script>");
                txtDescripcionRol.Text = String.Empty;
                return;
            }
            
            

            NegocioRol.AltaRol(txtDescripcionRol.Text, intEstadoRol);
           
            {

                LoadGrid();
            }

        }

        
    }
}