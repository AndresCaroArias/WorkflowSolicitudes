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
        public static String strDescripActividad { get; set; }
        public static int intDuracion { get; set; }
        public static string gblAccion { get; set; }
        public static int intCodActividad {get; set;}
        public static string strEstadoActividad { get; set; }
        public static int intEstadoActividad {get; set; }
        

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
            NegActividad NegAct = new NegActividad();
            grvActividad.DataSource = NegAct.ObtenerActividad();
            grvActividad.DataBind();
            txtDescripcion.Text = string.Empty;
            txtDuracion.Text    = string.Empty;
            chkEstadoActividad.Checked = false;
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

            if (chkEstadoActividad.Checked)
            {
                intEstadoActividad = 1;
            }
            else
            {
                intEstadoActividad = 0;
            }

                    if (gblAccion.Equals("Actualizar"))
                    {
                        NegAct.ActualizarActividad(intCodActividad, txtDescripcion.Text, int.Parse(txtDuracion.Text), intEstadoActividad);
                       LoadGrid();
                       ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se actualizo correctamente');</script>");
                    }
                    else
                    {
                        NegAct.AltaActividad(txtDescripcion.Text, int.Parse(txtDuracion.Text), intEstadoActividad);
                        LoadGrid();
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se ingreso correctamente');</script>");
                    }

                    //if (gblAccion.Equals("Actualizar"))
                    //{
                    //    //(new NegTipoSolicitud()).ActualizarTipoSolicitud(intCodTipoSolicitud, txtDescripcionTS.Text, intEstadoSolicitud, DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFin.Text), int.Parse(txtCantidadSol.Text), ddlOrigenSolicitud.Text, int.Parse(txtCantMaxDoc.Text));

                    //}

                    grvActividad.EditIndex = -1;
                    LoadGrid();
                    //ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Se actualizó correctamente');</script>");

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
        
        }

        protected void grvActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvActividad.SelectedRow;
            strDescripActividad = Convert.ToString(grvActividad.DataKeys[row.RowIndex].Values["strDescripActividad"]);
            intDuracion = Convert.ToInt32(grvActividad.DataKeys[row.RowIndex].Values["intDuracion"]);
            intCodActividad = Convert.ToInt32(grvActividad.DataKeys[row.RowIndex].Values["intCodActividad"]);
            strEstadoActividad = Convert.ToString(grvActividad.DataKeys[row.RowIndex].Values["strEstadoActividad"]);

            txtDescripcion.Text = strDescripActividad;
            txtDuracion.Text = Convert.ToString(intDuracion);

            if (strEstadoActividad.Equals("ACTIVO"))
            {
                chkEstadoActividad.Checked = true;
            }
            else
            {
                chkEstadoActividad.Checked = false;
            }

            gblAccion = "Actualizar";
        }

       
       
    }
}