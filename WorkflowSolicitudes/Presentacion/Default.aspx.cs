using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkflowSolicitudes.Negocio;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes
{
    public partial class _Default : System.Web.UI.Page
    {
        public static String StrRutUsuario { get; set; }
        public static int intCodUnidad { get; set; }
        public static List<Unidades> LstUnidades = new List<Unidades>();

        protected void Page_Load(object sender, EventArgs e)
        {
            StrRutUsuario = Convert.ToString(Session["strRutUsuario"]);
            List<Usuario> LstUsuario = new List<Usuario>();
            NegUsuario Usuario = new NegUsuario();
            LstUsuario = Usuario.ObtenerUsuarioPorRut(StrRutUsuario);

            foreach (Usuario Usuarios in LstUsuario)
            {
                lblNombre.Text   = Usuarios.strNombre;
                lblApellido.Text = Usuarios.strApellido;
                intCodUnidad     = Usuarios.intCodUnidad;

            }

            NegUnidades NegUnidades = new NegUnidades();
            LstUnidades = NegUnidades.ConsultaByCodUnidadUnidades(intCodUnidad);

            foreach (Unidades Unidad in LstUnidades)
            {
                lblUnidad.Text = Unidad.strDescripcionUnidad;
            }
                

            Session["intCodUnidad"] = intCodUnidad;

        }

        
        }


    }

