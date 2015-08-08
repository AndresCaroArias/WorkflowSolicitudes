using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web23 : System.Web.UI.Page

    {
        public static String StrPrivilegio = "MantUsuarios.aspx";
        public static string strRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }
        public static string strNombre { get; set; }
        public static string strApellido { get; set; }   
        public static string strTelefono { get; set; }
        public static string strEmailUsuario { get; set; } 
        public static string strPassword { get; set; }  
        public static int intCodRol { get; set; }
        public static int intCodUnidad { get; set; }
        public static string strDepende { get; set; }
        public static string strAccion { get; set; }
        public static string strEstadoUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                
                txtRut.Text = string.Empty;
                txtNombre.Text = String.Empty;
                txtApellido.Text = String.Empty;
                txtTelefono.Text = String.Empty;
                txtEmail.Text = String.Empty;
                ddlRol.SelectedIndex = -1;
                ddlUnidad.SelectedIndex = -1;
                ddlUsuario.SelectedIndex = -1;
                chkEstado.Checked = false;
                
               
                lee_ComboUsuario();
                lee_ComboUnidad();
                lee_Rol();
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                Funciones ExisteAcceso = new Funciones();

                Boolean ExistePrivilegio = ExisteAcceso.TieneAcceso(intCodRoUser, StrPrivilegio);

                if (ExistePrivilegio.Equals(false))
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Usted no tiene acceso a esta opción';</script>");
            
                   return;
                }

                LoadGrid();
               
            }


        }

        private void LoadGrid()
        {
            NegUsuario CargarUsuarios = new NegUsuario();
            grvUsuarios.DataSource = CargarUsuarios.ObtenerUsuarios();
            grvUsuarios.DataBind();
 
        }
 
         private void lee_Rol()
        {
            NegRol NegoRol = new NegRol();
            ddlRol.DataSource = NegoRol.ObtenerRol();
            ddlRol.DataTextField = "strDescripcion";
            ddlRol.DataValueField = "intCodRol";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, "Seleccione");
        }      


        private void lee_ComboUsuario()
        {
            NegUsuario NegUsuario = new NegUsuario();
            ddlUsuario.DataSource = NegUsuario.CargoComboRutNombre();
            ddlUsuario.DataTextField = "strNombre";
            ddlUsuario.DataValueField = "strRutUsuario";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, "Seleccione");
        }

        private void lee_ComboUnidad()
        {
            NegUnidades NegUnidad = new NegUnidades();
            ddlUnidad.DataSource = NegUnidad.ObtenerUnidades();
            ddlUnidad.DataTextField = "strDescripcionUnidad";
            ddlUnidad.DataValueField = "intCodUnidad";
            ddlUnidad.DataBind();
            ddlUnidad.Items.Insert(0, "Seleccione");
        }      



        protected void grvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvUsuarios.EditIndex = -1;
            LoadGrid();
        }

        protected void grvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
        
        }

        protected void grvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvUsuarios.SelectedRow;
            strRutUsuario = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strRutUsuario"]);
            strNombre = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strNombre"]);
            strEstadoUsuario = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strEstadoUsuario"]);
            strApellido = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strApellido"]);
            strTelefono = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strTelefono"]);
            intCodRol = Convert.ToInt32(grvUsuarios.DataKeys[row.RowIndex].Values["intCodRol"]);
            intCodUnidad = Convert.ToInt32(grvUsuarios.DataKeys[row.RowIndex].Values["intCodUnidad"]);
            strDepende = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strDepende"]);
            strEmailUsuario = Convert.ToString(grvUsuarios.DataKeys[row.RowIndex].Values["strEmailUsuario"]);

                
            txtRut.Enabled = false;
            txtRut.Text = strRutUsuario;
            txtNombre.Text = strNombre;
            txtApellido.Text = strApellido;    
            txtTelefono.Text = strTelefono;
            txtEmail.Text = strEmailUsuario;
            ddlRol.SelectedValue = Convert.ToString(intCodRol);
            ddlUnidad.SelectedIndex = intCodUnidad;
            ddlUsuario.SelectedValue = strDepende;

            strAccion = "Actualizar";

            if (strEstadoUsuario.Equals("ACTIVO"))
            {
                chkEstado.Checked = true;
            }
            else
            {
                chkEstado.Checked = false;
            }


            }

        protected void btnGrabarUsuario_Click(object sender, EventArgs e)
        {
           
            int   intEstadoUsuario;
            int   intCodRol=0;
            int   intCodUnidad = 0;
            string strDepende = String.Empty; 

            if (ddlRol.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Debe seleccionar un rol');</script>");
            
                return;
            }

            if (txtRut.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese Rut del usuario');</script>");
                return;
            }

            if (txtNombre.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese el nombre del usuario');</script>");

                return;
            }

            if (txtApellido.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese el apellido del usuario');</script>");

                return;
            }
            if (txtApellido.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese el apellido del usuario');</script>");

                return;
            }


            if (txtEmail.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese el Mail del usuario');</script>");
                
                return;
            }

           

            if (ddlUnidad.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese la unidad de negocio a cual pertenece');</script>");
                return;
            }

            if (ddlUsuario.SelectedIndex.Equals(0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese el usuario del cual depende o Jefe');</script>");
                return;
            }

            if (txtTelefono.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese telefono del usuario');</script>");
                return;
            }


            int intExistePuntoRut;
            intExistePuntoRut = txtRut.Text.IndexOf(".");

            if (!intExistePuntoRut.Equals(-1))
            {

               ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Rut debe ser ingresado sin puntos');</script>");
             
               txtRut.Text = String.Empty;
                return;
            }

            int intExisteGuionRut;
            intExisteGuionRut = txtRut.Text.IndexOf("-");

            if (intExisteGuionRut.Equals(-1))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Rut debe ser ingresado con guión');</script>");
                txtRut.Text = String.Empty;
                return;
            }

            Funciones ValidaRutUsuario = new Funciones();
            if (!ValidaRutUsuario.validarRut(txtRut.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Rut Invalido');</script>");
                txtRut.Text = String.Empty;
                return;
            }

            if (chkEstado.Checked)
            {
                intEstadoUsuario = 1;
            }
            else
            {
                intEstadoUsuario = 0;
            }
           

            intCodRol      = Convert.ToInt32(ddlRol.SelectedValue);
            intCodUnidad   = Convert.ToInt32(ddlUnidad.SelectedValue);
            strDepende     = ddlUsuario.SelectedValue;
            

            NegUsuario NegocioUsu = new NegUsuario();

            if (strAccion.Equals("Actualizar"))
            {
                (new NegUsuario()).ActualizaUsuario(txtRut.Text, intCodRol,txtNombre.Text, txtApellido.Text, txtEmail.Text, intEstadoUsuario, intCodUnidad, strDepende, txtTelefono.Text);

                NegAuditoria InsertarLog = new NegAuditoria();
                InsertarLog.InsertaAuditoria(strRutUsuario, "MANTENEDOR DE USUARIOS", "ACTUALIZA USAURIO", "ACTUALIZA PARA EL USUARIO " + txtRut.Text + " " + txtNombre.Text + " " + txtApellido.Text);
            }
            else
            {
                NegUsuario NegocioUsuario = new NegUsuario();
                int intExisteNomRut;
                intExisteNomRut = NegocioUsuario.select_ExisteRutUsuario_Usuar(txtRut.Text);


                if (!intExisteNomRut.Equals(0))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Rut ya existe');</script>");

                    txtRut.Text = String.Empty;
                    return;
                }

                NegocioUsu.AltaUsuario(txtRut.Text, intCodRol, "11espacios", txtNombre.Text, txtApellido.Text, txtEmail.Text, intEstadoUsuario, intCodUnidad, strDepende, txtTelefono.Text);
                NegAuditoria InsertarLog = new NegAuditoria();
                InsertarLog.InsertaAuditoria(strRutUsuario, "MANTENEDOR DE USUARIOS", "CREACION DE USUARIO", "SE CREO EL USUARIO " + txtRut.Text + " " + txtNombre.Text + " " + txtApellido.Text );
            }


                LoadGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Grabación Exitosa');</script>");
                
                txtRut.Text = string.Empty;
                txtNombre.Text = String.Empty;
                txtApellido.Text = String.Empty;
                txtTelefono.Text = String.Empty;
                txtEmail.Text = String.Empty;
                ddlRol.SelectedIndex = -1;
                ddlUnidad.SelectedIndex = -1;
                ddlUsuario.SelectedIndex = -1;
                chkEstado.Checked = false;
             

        }

        protected void botonPrueba_Click(object sender, EventArgs e)
        {
        
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            txtRut.Text = Session["Captura"].ToString();
        }

        protected void botonPrueba_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        

        protected void btnActualizarUsuario_Click(object sender, EventArgs e)
        {

            
        }

        protected void BtnNuevoUsuario_Click(object sender, ImageClickEventArgs e)
        {
            
            txtRut.Text = string.Empty;
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            ddlRol.SelectedIndex = -1;
            ddlUnidad.SelectedIndex = -1;
            ddlUsuario.SelectedIndex = -1;
            chkEstado.Checked = false;
            
        }

        
    }
}