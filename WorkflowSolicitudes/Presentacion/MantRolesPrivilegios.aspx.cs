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
        public static String StrPrivilegio = "MantRolesPrivilegios.aspx";
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            //txtDescripcionPrivilegios.Text = string.Empty;


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



        }

        protected void grvRolPrivilegios_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvRolPrivilegios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grvRolPrivilegios.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvRolPrivilegios.Rows[e.RowIndex];
            int intEstadoRolPrivi;

            System.Web.UI.WebControls.TextBox EditDescripcion = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDescripcion");
            string descripcion = EditDescripcion.Text;

            System.Web.UI.WebControls.TextBox EditDescPrivilegios = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDescPrivilegios");
            string desc = EditDescPrivilegios.Text;

            System.Web.UI.WebControls.CheckBox EditEstadoRolPrvilegio = (System.Web.UI.WebControls.CheckBox)Fila.FindControl("chkEditEstadoRolPrvilegio");
            //CheckBox estado = EditEstadoPrvilegio.Checked;



            if (EditEstadoRolPrvilegio.Checked)
            {
                intEstadoRolPrivi = 1;
            }
            else
            {
                intEstadoRolPrivi = 0;
            }

            //(new NegRolesPrivilegios()).ActualizarPrivilegios(id, descripcion, desc, intEstadoRolPrivi);

            grvRolPrivilegios.EditIndex = -1;
            LoadGrid();

        }

        protected void grvRolPrivilegios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, ImageClickEventArgs e)
        {

            if (ddlRol.SelectedIndex.Equals(0))
            {
                lblMensaje.Text = "ERROR : Debe seleccionar un rol";
                return;
            }

            if (ddlPrivilegios.SelectedIndex.Equals(0))
            {
                lblMensaje.Text = "ERROR : Debe seleccionar un privilegio";
                return;
            }


            int intCodPrivilegios = Convert.ToInt32(ddlPrivilegios.SelectedValue);
            int intCodRol = Convert.ToInt32(ddlRol.SelectedValue); 
            int intEstadoRolPrivi;


            
            if (chkEstadoRolPriv.Checked)
            {
                intEstadoRolPrivi = 1;
            }
            else
            {
                intEstadoRolPrivi = 0;
            }

            NegRolesPrivilegios NegocioRolPrivi = new NegRolesPrivilegios();
            NegocioRolPrivi.AltaRolesPrivilegios(intCodPrivilegios, intCodRol, intEstadoRolPrivi);

            {

                LoadGrid();
            }
        }

    }
}