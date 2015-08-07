using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class BuscadorPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //varsesion.Text = Session["Capturar"].ToString();
        
        }

        private void LoadGrid()
        {

            NegUsuario NegocioPrivi = new NegUsuario();
            grvBuscaPersonas.DataSource = NegocioPrivi.BusquedaNombre(txtNombreUsuario.Text);
            grvBuscaPersonas.DataBind();



        }

        protected void grvBuscaPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
         }

        protected void grvBuscaPersonas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
                       
           
                          
        }

        protected void grvBuscaPersonas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grvBuscaPersonas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grvBuscaPersonas_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grvBuscaPersonas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grvBuscaPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    
        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            NegUsuario NegocioUsu = new NegUsuario();
            NegocioUsu.BusquedaNombre(txtNombreUsuario.Text);
            LoadGrid();
            
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

            NegUsuario NegocioUsu = new NegUsuario();
            NegocioUsu.BusquedaNombre(txtNombreUsuario.Text);
            LoadGrid();
        }

        protected void grvBuscaPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                //int id = Convert.ToInt32(grvBuscaPersonas.DataKeys[index].Value);
                string texto = Convert.ToString(grvBuscaPersonas.DataKeys[index].Value);
                txtRecibe.Text = texto;
                Session["Captura"] = txtRecibe.Text; 
               

            }

        }

        

       

       

     

        
    }
}