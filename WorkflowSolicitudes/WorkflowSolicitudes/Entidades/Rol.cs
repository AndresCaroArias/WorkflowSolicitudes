using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Rol
    {
        #region Atributos

        private int _intCodRol;        
        private string _strDescripcion;        
        private string _strRutUsuario;
        private int _intEstadoRol;

       

        #endregion

        #region Cosntructor
        public Rol() { }
        public Rol(int intCodRol, string strDescripcion, string strRutUsuario) 
        {
            this.intCodRol = intCodRol;
            this.strDescripcion = strDescripcion;
            this.strRutUsuario = strRutUsuario;
        }
        public Rol(int intCodRol, string strDescripcion, int intEstadoRol)
        {
            this.intCodRol = intCodRol;
            this.strDescripcion = strDescripcion;
            this.intEstadoRol = intEstadoRol;
          
        }
        public Rol(int intCodRol, int intEstadoRol)
        {
            this.intCodRol = intCodRol;
            this.intEstadoRol = intEstadoRol;

        }

        public Rol(int intCodRol, string strDescripcion)
        {
            this.intCodRol = intCodRol;
            this.strDescripcion = strDescripcion;
           

        }

        #endregion

        #region Encapsulamiento

        public int intCodRol
        {
            get { return _intCodRol; }
            set { _intCodRol = value; }
        }
        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }
        public string strRutUsuario
        {
            get { return _strRutUsuario; }
            set { _strRutUsuario = value; }
        }
        public int intEstadoRol
        {
            get { return _intEstadoRol; }
            set { _intEstadoRol = value; }
        }

        #endregion
    }
}