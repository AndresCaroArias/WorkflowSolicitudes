using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
       
    public partial class Formulario_web24 : System.Web.UI.Page
    {
        public static String StrPrivilegio = "MantFeriados.aspx";
        public static String StrRutUsuario { get; set; }
        public static int intCodRoUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                intCodRoUser = Convert.ToInt32(Session["intCodRoUser"]);
                Funciones ExisteAcceso = new Funciones();
                CldFeriado.Visible = false;

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
            NegFeriados NegocioFeria = new NegFeriados();
            grvFeriado.DataSource = NegocioFeria.ObtenerFeriados();
            grvFeriado.DataBind();        
            txtDescripcionFeriados.Text = string.Empty;
            txtFechasFeriados.Text = string.Empty;

        }
        

       

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {


          

            if (txtDescripcionFeriados.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese la descripción del Feriado');</script>");
               
                return;
            }

            if (txtFechasFeriados.Text.Equals(String.Empty))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR: Ingrese la fecha del Feriado');</script>");
                return;
            }

            
            NegFeriados NegocioFeria = new NegFeriados();
            NegocioFeria.AltaFeriados(txtDescripcionFeriados.Text, DateTime.Parse(txtFechasFeriados.Text));

            {

                LoadGrid();
            }


        }

        protected void grvFeriado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvFeriado.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void grvFeriado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvFeriado.EditIndex = -1;
            LoadGrid();
        }

        protected void grvFeriado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)grvFeriado.DataKeys[e.RowIndex].Values[0];
            NegFeriados Neg = new NegFeriados();
            Neg.EliminarFeriado(id);
            LoadGrid();
            grvFeriado.EditIndex = -1;
            LoadGrid();


        }

        protected void grvFeriado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        

        }

        protected void grvFeriado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)grvFeriado.DataKeys[e.RowIndex].Values[0];
            GridViewRow Fila = grvFeriado.Rows[e.RowIndex];


            System.Web.UI.WebControls.TextBox EditCodFeriado = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditDescFeriado");
            string descripcion = EditCodFeriado.Text;

            System.Web.UI.WebControls.TextBox EditDescFeriado = (System.Web.UI.WebControls.TextBox)Fila.FindControl("txtEditFechaFeriado");
            DateTime fecha = Convert.ToDateTime(EditDescFeriado.Text);


            (new NegFeriados()).ActualizarFeria(id, descripcion, fecha);

            grvFeriado.EditIndex = -1;
            LoadGrid();
        }

        protected void grvFeriado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imbFeriado_Click(object sender, ImageClickEventArgs e)
        {
            if (CldFeriado.Visible == false)
            {
                CldFeriado.Visible = true;

            }
            else
            {
                CldFeriado.Visible = false;
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {

            txtFechasFeriados.Text = CldFeriado.SelectedDate.ToShortDateString();



            if (CldFeriado.Visible == true)
            {
                CldFeriado.Visible = false;

            }

            CldFeriado.Visible = false;


        }

        protected void imbFeriado_Click1(object sender, ImageClickEventArgs e)
        {
            if (CldFeriado.Visible == false)
            {
                CldFeriado.Visible = true;
                
            }
            else
            {
                CldFeriado.Visible = false;
            }
        }

       

       
    }
}