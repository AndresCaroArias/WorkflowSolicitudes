using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Usuario
    {
        #region Atributos

        private string _strRutUsuario;
        private string _strPassword;
        private string _strNombre;
        private string _strApellido;
        private int    _intCodUnidad;       
        private int _intCodRol;
        private string _strEmailUsuario;
        private int _intEstadoUsuario;
        private string _strEstadoUsuario;       
        private string _strDepende;
        private string _strDescripcion;
        private string _strDescUnidad;
        private string _strTelefono;
        private string _strNombreDepende;

        #endregion

        #region Cosntructor
        public Usuario() { }

        public Usuario(string strRutUsuario, int intCodRol, string strPassword, string strNombre, string strApellido, string strEmailUsuario, int intEstadoUsuario, int intCodUnidad, string strDepende, string strTelefono)
        {
            this.strRutUsuario = strRutUsuario;
            this.intCodRol = intCodRol;
            this.strPassword = strPassword;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strEmailUsuario = strEmailUsuario;
            this.intEstadoUsuario = intEstadoUsuario;
            this.intCodUnidad = intCodUnidad;
            this.strDepende = strDepende;
            this.strTelefono = strTelefono;
        }

        //
        public Usuario(string strRutUsuario, int intCodRol, string strPassword, string strNombre, string strApellido, string strEmailUsuario, string strEstadoUsuario, int intCodUnidad, string strDepende, string strDescripcion, string strDescUnidad, string strTelefono, string strNombreDepende)
        {
            this.strRutUsuario = strRutUsuario;
            this.intCodRol = intCodRol;
            this.strPassword = strPassword;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strEmailUsuario = strEmailUsuario;
            this.strEstadoUsuario = strEstadoUsuario;
            this.intCodUnidad = intCodUnidad;
            this.strDepende = strDepende;
            this.strDescripcion = strDescripcion;
            this.strDescUnidad = strDescUnidad;
            this.strTelefono = strTelefono;
            this.strNombreDepende = strNombreDepende;
        }

        public Usuario(string strRutUsuario, string strPassword, string strNombre, string strApellido, int intCodRol,int intCodUnidad, string strEmailUsuario,int intEstadoUsuario)
        {
            this.strRutUsuario = strRutUsuario;
            this.strPassword = strPassword;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.intCodRol = intCodRol;
            this.intCodUnidad = intCodUnidad;
            this.strEmailUsuario = strEmailUsuario;
            this.intEstadoUsuario = intEstadoUsuario;
        }


        public Usuario(string strRutUsuario, string strPassword, string strNombre, string strApellido, int intCodRol, string strEmailUsuario)
        {
            this.strRutUsuario = strRutUsuario;
            this.strPassword = strPassword;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.intCodRol = intCodRol;
            this.strEmailUsuario = strEmailUsuario;
        }

        public Usuario(string strRutUsuario, string strNombre, string strApellido, string strEmailUsuario, int intCodRol, int intEstadoUsuario, int intCodUnidad)
        {
            this.strRutUsuario    = strRutUsuario;
            this.strNombre        = strNombre;
            this.strApellido      = strApellido;
            this.strEmailUsuario  = strEmailUsuario;
            this.intCodRol        = intCodRol;
            this.intEstadoUsuario = intEstadoUsuario;
            this.intCodUnidad     = intCodUnidad;
        }

        public Usuario(string strRutUsuario, int intCodRol, string strPassword, string strNombre, string strApellido, string strEmailUsuario, int intEstadoUsuario, int intCodUnidad, string strDepende)
        {
            this.strRutUsuario    = strRutUsuario;
            this.intCodRol        = intCodRol;
            this.strPassword      = strPassword;
            this.strNombre        = strNombre;
            this.strApellido      = strApellido;
            this.strEmailUsuario  = strEmailUsuario;
            this.intEstadoUsuario = intEstadoUsuario;
            this.intCodUnidad     = intCodUnidad;
            this.strDepende       = strDepende;   
        }

        public Usuario(string strRutUsuario, int intCodRol, string strPassword, string strNombre, string strApellido, string strEmailUsuario)
        {
            this.strRutUsuario = strRutUsuario;
            this.intCodRol = intCodRol;
            this.strPassword = strPassword;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strEmailUsuario = strEmailUsuario;
         }

        public Usuario(string strRutUsuario, string strNombre)
        {
            this.strRutUsuario = strRutUsuario;
            this.strNombre = strNombre;
        }

       
        #endregion

        #region Encapsulamiento
        public string strRutUsuario
        {
            get { return _strRutUsuario; }
            set { _strRutUsuario = value; }
        }
        public string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }
        public string strNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public string strApellido
        {
            get { return _strApellido; }
            set { _strApellido = value; }
        }
        public int intCodRol
        {
            get { return _intCodRol; }
            set { _intCodRol = value; }
        }
        public int intCodUnidad
        {
            get { return _intCodUnidad; }
            set { _intCodUnidad = value; }
        }
        public string strEmailUsuario
        {
            get { return _strEmailUsuario; }
            set { _strEmailUsuario = value; }
        }

        public int intEstadoUsuario
        {
            get { return _intEstadoUsuario; }
            set { _intEstadoUsuario = value; }
        }

        public string strEstadoUsuario
        {
            get { return _strEstadoUsuario; }
            set { _strEstadoUsuario = value; }
        }

        public string strDepende
        {
            get { return _strDepende; }
            set { _strDepende = value; }
        }

        public string strNombreDepende
        {
            get { return _strNombreDepende; }
            set { _strNombreDepende = value; }
        }

        






        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        public string strDescUnidad
        {
            get { return _strDescUnidad; }
            set { _strDescUnidad = value; }
        }

        public string strTelefono
        {
            get { return _strTelefono; }
            set { _strTelefono = value; }
        }

        #endregion
    }
}