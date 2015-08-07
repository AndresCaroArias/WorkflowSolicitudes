using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;

namespace WorkflowSolicitudes
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
      
        public static String StrRutUsuario { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                StrRutUsuario = Convert.ToString(Session["strRutUsuario"]);

            }
        }

          private bool Validar(string dato)
        {
            if (dato != "")
                return true;

            else
                return false;
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {
            String ClaveMd5;

           
                if (txtNuevaClave.Text.Equals(""))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : Ingrese la nueva clave');</script>");

                    return;
                }
                else
                {
                    if (txtRepetirClave.Text.Equals(""))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : La password Nueva y la password de repeticion no son iguales');</script>");
                        return; 
                    }
                }
            


            if (!txtRepetirClave.Text.Equals(txtNuevaClave.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('ERROR : La password Nueva y la password de repeticion no son iguales';</script>");
                return;
            }
            else 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript: alertify.alert('La Clave se cambio Exitosamente';</script>");
            }


            NegUsuario CambioDePassword = new NegUsuario();
            Funciones encriptarMD5 = new Funciones();
            ClaveMd5 = encriptarMD5.EncriptarMD5(txtNuevaClave.Text);
            CambioDePassword.ActualizoPassword(StrRutUsuario, ClaveMd5);

        }
    }
}