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
        private bool Validar(string dato)
        {
            if (dato != "")
                return true;

            else
                return false;
        }
        public static String StrRutUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            StrRutUsuario = Convert.ToString(Session["strRutUsuario"]);
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {
            String ClaveMd5;

           
                if (txtNuevaClave.Text.Equals(""))
                {
                    LblMensaje.Text = "ERROR : Ingrese la nueva clave";  
                    return;
                }
                else
                {
                    if (txtRepetirClave.Text.Equals(""))
                    {
                        LblMensaje.Text = "ERROR : La password Nueva y la password de repeticion no son iguales";
                        return; 
                    }
                }
            


            if (!txtRepetirClave.Text.Equals(txtNuevaClave.Text))
            {
                LblMensaje.Text = "ERROR : La password Nueva y la password de repeticion no son iguales ";
                return;
            }
            else {
                LblMensaje.Text = "La Clave se cambio Exitosamente";
            }


            NegUsuario CambioDePassword = new NegUsuario();
            Funciones encriptarMD5 = new Funciones();
            ClaveMd5 = encriptarMD5.EncriptarMD5(txtNuevaClave.Text);
            CambioDePassword.ActualizoPassword(StrRutUsuario, ClaveMd5);





        }
    }
}