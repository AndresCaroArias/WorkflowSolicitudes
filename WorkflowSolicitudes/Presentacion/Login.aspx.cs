using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using System.Text;

namespace WorkflowSolicitudes.Presentacion
{
    public partial class loginWorkFlow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                
            }
        }
      

        protected void ValidaUsuario(object sender, ImageClickEventArgs e)
        {

            string strRutUsuario;
            string strPassword;
            LblError.Text = String.Empty;
            Funciones encriptarMD5 = new Funciones();
            TxtPassword.Text = encriptarMD5.EncriptarMD5(TxtPassword.Text);

            if (TxtUsuario.Text.Equals(String.Empty) && TxtPassword.Text.Equals(String.Empty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Ingrese Rut Usuario');</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Ingrese Password');</script>");
                
                return;
            }
            else
            {
                LblUsuario.Text = String.Empty;
                LblPassword.Text = String.Empty;
                if (TxtUsuario.Text.Equals(String.Empty))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('Ingrese Rut Usuario');</script>");
                    
                    return;
                }
                else
                {
                    strRutUsuario = TxtUsuario.Text;
                    LblUsuario.Text = String.Empty;
                }

                if (TxtPassword.Text.Equals(String.Empty))
                {
                    LblPassword.Text = "Ingrese Password";
                    return;
                }
                else
                {
                    strPassword = TxtPassword.Text;
                    LblPassword.Text = String.Empty;
                }
            }
            NegUsuario NegUsuarios = new NegUsuario();
            int intCodRoUser = NegUsuarios.ValidarUsuario(strRutUsuario, strPassword);
            if (intCodRoUser == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('RUT USUARIO Y/O CONTRASEÑA NO VALIDA');</script>");
                TxtPassword.Text = String.Empty;
                TxtUsuario.Text = String.Empty;
                return;
            }
            else
            {
                Session["strRutUsuario"] = strRutUsuario;
                Session["intCodRoUser"] = intCodRoUser;
                NegAuditoria InsertarLog = new NegAuditoria();
                InsertarLog.InsertaAuditoria(strRutUsuario, "LOGIN", "INGRESO DEL SISTEMA", "INGRESA AL SISTEMA CON");
                Response.Redirect("Default.aspx");


            }

        }

        protected void lnkRecordarContraseña_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        

      
        }
    }