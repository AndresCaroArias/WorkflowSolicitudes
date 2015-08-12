using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web22 : System.Web.UI.Page
    {
        public static string gblAccion { get; set; }
        public static String StrPrivilegio = "MantRolesPrivilegios.aspx";
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static int intCodRol { get; set; }
        public static  int intCodPrivilegios  { get; set; }
        public static int intEstadoRolPrivi { get; set; }
        public static string strEstadoRolPrivi { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            gblAccion = String.Empty;
            if (!IsPostBack)
            {
                lee_ComboRol();
                lee_ComboPrivilegios();

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
            NegRolesPrivilegios NegocioPrivi = new NegRolesPrivilegios();
            grvRolPrivilegios.DataSource = NegocioPrivi.ObtenerRolesPrivilegios();
            grvRolPrivilegios.DataBind();
            
        }

        private void lee_ComboRol()
        {
            NegRol NegoRol = new NegRol();
            ddlRol.DataSource = NegoRol.ObtenerRol();
            ddlRol.DataTextField = "strDescripcion";
            ddlRol.DataValueField = "intCodRol";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, "Seleccione");

        }

        private void lee_ComboPrivilegios()
        {

            NegPrivilegios NegoPrivi = new NegPrivilegios();
            ddlPrivilegios.DataSource = NegoPrivi.ObtenerPrivilegios();
            ddlPrivilegios.DataTextField = "strDescPrivilegios";
            ddlPrivilegios.DataValueField = "intCodPrivilegios";
            ddlPrivilegios.DataBind();
            ddlPrivilegios.Items.Insert(0, "Seleccione");
        }

        protected void grvRolPrivilegios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvRolPrivilegios.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
        protected void grvRolPrivilegios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvRolPrivilegios.EditIndex = -1;
            LoadGrid();
        }

        protected void grvRolPrivilegios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            NegRolesPrivilegios NegocioRolPrivi = new NegRolesPrivilegios();

            int intCodRol  = (int)grvRolPrivilegios.DataKeys[e.RowIndex].Values[0];
            int intCodPriv = (int)grvRolPrivilegios.DataKeys[e.RowIndex].Values[1];
            GridViewRow Fila = grvRolPrivilegios.Rows[e.RowIndex];

            NegocioRolPrivi.EliminarRolesPrivilegios(intCodPriv, intCodRol);


        }

        protected void grvRolPrivilegios_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvRolPrivilegios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        
        }

        protected void grvRolPrivilegios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row   = grvRolPrivilegios.SelectedRow;
            intCodRol         = Convert.ToInt32(grvRolPrivilegios.DataKeys[row.RowIndex].Values["intCodRol"]);
            intCodPrivilegios = Convert.ToInt32(grvRolPrivilegios.DataKeys[row.RowIndex].Values["intCodPrivilegios"]);
            intEstadoRolPrivi = Convert.ToInt32(grvRolPrivilegios.DataKeys[row.RowIndex].Values["intEstadoRolPrivi"]);
            strEstadoRolPrivi = Convert.ToString(grvRolPrivilegios.DataKeys[row.RowIndex].Values["strEstadoRolPrivi"]);


            ddlRol.SelectedValue = Convert.ToString(intCodRol);
            ddlPrivilegios.SelectedValue = Convert.ToString(intCodPrivilegios);

            if (strEstadoRolPrivi.Equals("ACTIVO"))
            {
                chkEstadoRolPriv.Checked = true;
            }
            else
            {
                chkEstadoRolPriv.Checked = false;
            }
            gblAccion = "Actualizar";

        }

        protected void btnInsertar_Click(object sender, ImageClickEventArgs e)
        {
            int intRegistroYaExiste;
            int intEstadoRolPrivi;
            NegRolesPrivilegios NegocioRolPrivi = new NegRolesPrivilegios();


            if (ddlRol.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Debe seleccionar un rol');</script>");
                return;
            }

            if (ddlPrivilegios.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Debe seleccionar un privilegio');</script>");
                return;
            }

            int intCodPrivilegios = Convert.ToInt32(ddlPrivilegios.SelectedValue);
            int intCodRol = Convert.ToInt32(ddlRol.SelectedValue); 
            
            if (chkEstadoRolPriv.Checked)
            {
                intEstadoRolPrivi = 1;
            }
            else
            {
                intEstadoRolPrivi = 0;
            }

            if (gblAccion.Equals("Actualizar"))
            {
                return;  
            }   
            else
            {
                intRegistroYaExiste = NegocioRolPrivi.ExisteUnRolyPrivilegio(intCodRol, intCodPrivilegios);
                if (intRegistroYaExiste.Equals(1))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : El Rol y Privilegio ingresado ya existe!!');</script>");
                    return;
                }
                
                NegocioRolPrivi.AltaRolesPrivilegios(intCodPrivilegios, intCodRol, intEstadoRolPrivi);
            }
            
            LoadGrid();
            
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            NegRolesPrivilegios NegocioRolPrivi = new NegRolesPrivilegios();
            if (ddlRol.SelectedIndex.Equals(0)) 
            {
                grvRolPrivilegios.DataSource = NegocioRolPrivi.ObtenerRolesPrivilegios();
            }
            else
            {
                grvRolPrivilegios.DataSource = NegocioRolPrivi.ConsultaRolByRolesPrivi(Convert.ToInt32(ddlRol.SelectedValue));
            }
            
            grvRolPrivilegios.DataBind();
        }

    }
}