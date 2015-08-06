using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        public static String StrPrivilegio = "MantActividades.aspx";
        public static String StrRutUsuario { get; set; }
        public static int  intCodRoUser { get; set; }

        
        

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
            NegActividad NegAct = new NegActividad();
            grvActividad.DataSource = NegAct.ObtenerActividad();
            grvActividad.DataBind();
            txtDescripcion.Text = string.Empty;
            txtDuracion.Text    = string.Empty;
        }

        protected void grvActividad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvActividad.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnInsertar_Click(object sender, ImageClickEventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Ingrese la Descripición');</script>");
 
                return;
            }

            if (txtDuracion.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Ingrese la Duración');</script>");
 
                return;
            }


            NegActividad NegAct = new NegActividad();
            NegAct.AltaActividad(txtDescripcion.Text, int.Parse(txtDuracion.Text));
            {
                LoadGrid();
                
            }
        }

        protected void grvActividad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Existe;
            int id = (int)grvActividad.DataKeys[e.RowIndex].Values[0];

            int intCodActividad = (int)grvActividad.DataKeys[e.RowIndex].Values[0];
            NegActividad ExiteActivida = new NegActividad();
            Existe = ExiteActivida.ExisteActividadFlujo(intCodActividad);
            if (Existe > 0)
            {
                return;
            }

            if (id > 0)
            {
                NegActividad Neg = new NegActividad();
                Neg.EliminarActvidad(id);
                LoadGrid();
            }



            grvActividad.EditIndex = -1;
            LoadGrid();
        }
        protected void grvActividad_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvActividad.EditIndex = -1;
            LoadGrid();
        }
        protected void grvActividad_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvActividad.EditIndex = e.NewEditIndex;
            LoadGrid();
        }

        protected void grvActividad_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grvActividad.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvActividad.Rows[e.RowIndex];


            System.Web.UI.WebControls.TextBox EditDescripcion = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDescripcion");
            string descripcion = EditDescripcion.Text;

            System.Web.UI.WebControls.TextBox EditDuracion = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDuracion");
            int duracion = int.Parse(EditDuracion.Text);




            (new NegActividad()).ActualizarActividad(id, descripcion, duracion);

            grvActividad.EditIndex = -1;
            LoadGrid();

        }

       
       
    }
}