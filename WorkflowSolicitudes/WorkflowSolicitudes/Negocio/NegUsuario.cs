using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;


namespace WorkflowSolicitudes.Negocio
{
    public class NegUsuario
    {
        public List<Usuario> ObtenerUsuarioPorRut(string strRutUsuario)
        {
            DatosUsuario DatUsuario = new DatosUsuario();
            return DatUsuario.select_All_E_Usuario(strRutUsuario);
        }


        public int ValidarUsuario(string strRutUsuario, string strPassword)
        {
            DatosUsuario DatUsuario = new DatosUsuario();
            return DatUsuario.select_Validar_Usuario(strRutUsuario, strPassword);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            DatosUsuario DatObtenerUsuario = new DatosUsuario();
            return DatObtenerUsuario.select_All_Usuarios();

        }

        public int AltaUsuario(string strRutUsuario, int intCodRol, string strPassword, string strNombre, string strApellido, string strEmailUsuario, int intEstadoUsuario, int intCodUnidad, string strDepende, string strTelefono)
        {
            DatosUsuario InsertaUsuario = new DatosUsuario();
            return InsertaUsuario.InsertUsuario(strRutUsuario, intCodRol, strPassword, strNombre, strApellido, strEmailUsuario, intEstadoUsuario, intCodUnidad, strDepende, strTelefono);
        }

        public int ActualizaUsuario(string strRutUsuario, int intCodRol,  string strNombre, string strApellido, string strEmailUsuario, int intEstadoUsuario, int intCodUnidad, string strDepende, string strTelefono)
        {
            DatosUsuario ActualiUsuario = new DatosUsuario();
            return ActualiUsuario.ActualizatUsuario(strRutUsuario, intCodRol, strNombre, strApellido, strEmailUsuario, intEstadoUsuario, intCodUnidad, strDepende, strTelefono);
        }

        public int select_ExisteRutUsuario_Usuar(string strRutUsuario)
        {
            DatosUsuario ExiUsuarioRut = new DatosUsuario();
            return ExiUsuarioRut.ExisteRutUsuario_Usuario(strRutUsuario);
        }

        public int ActualizoPassword(string strRutUsuario, string strPassword)
        {
            DatosUsuario ActualizandoPassword = new DatosUsuario();
            return ActualizandoPassword.ActualizaPasswordUsuario(strRutUsuario, strPassword);
        }

        public int RecuperoPassword(string strRutUsuario)
        {
            string strPasswordMD5 = String.Empty;
            string strPassword    = String.Empty;


            Funciones FuncionesPassword = new Funciones();


            strPassword    = FuncionesPassword.GetGeneradordePassword();
            strPasswordMD5 = FuncionesPassword.EncriptarMD5(strPassword);

            DatosUsuario ActualizandoPassword = new DatosUsuario();
            return ActualizandoPassword.GeneraNuevaPassword(strRutUsuario, strPassword, strPasswordMD5);
        }


        public List<Usuario> BusquedaNombre(string strTextoBusqueda)
        {
            DatosUsuario DatBusquedaNombre = new DatosUsuario();
            return DatBusquedaNombre.BusquedaNombre(strTextoBusqueda);
        }
        
        public int EliminarUsuario(string strRutUsuario)
        {
            return (new DatosUsuario()).EliminarUsuario(strRutUsuario);
        }

        public int ExisteCodUnidad_Usuario(int intCodUnidad)
        {
            DatosUnidades ExiCodUnidUsuarios = new DatosUnidades();
            return ExiCodUnidUsuarios.ExisteCodUnidad_Usuario (intCodUnidad);
        }

        public List<Usuario> CargoComboRutNombre()
        {
            DatosUsuario CargarComboRutNombre = new DatosUsuario();
            return CargarComboRutNombre.select_All_Usuarios_RutNombre(); 
        }

      
    }
}