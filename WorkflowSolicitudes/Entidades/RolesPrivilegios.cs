using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class RolesPrivilegios
    {
        #region Atributos
        private int _intCodPrivilegios;
        private int _intCodRol;
        private int _intEstadoRolPrivi;
        private string _strDescPrivilegios;       
        private string _strDescripcion;
        private string _strEstadoRolPrivi;


        #endregion

        #region constructor

        public RolesPrivilegios() { }

        public RolesPrivilegios(int intCodPrivilegios, int intCodRol, int intEstadoRolPrivi)
    {
        this.intCodPrivilegios  = intCodPrivilegios;
        this.intCodRol = intCodRol;
        this._intEstadoRolPrivi = intEstadoRolPrivi;
        
    }

        public RolesPrivilegios(int intCodPrivilegios, int intCodRol, int intEstadoRolPrivi, string strDescPrivilegios, string strDescripcion, string strEstadoRolPrivi)
        {
            this.intCodPrivilegios = intCodPrivilegios;
            this.intCodRol = intCodRol;
            this.intEstadoRolPrivi = intEstadoRolPrivi;
            this.strDescPrivilegios = strDescPrivilegios;
            this.strDescripcion = strDescripcion;
            this.strEstadoRolPrivi = strEstadoRolPrivi;
        }

        public RolesPrivilegios(int intCodPrivilegios, int intCodRol, int intEstadoRolPrivi, string strDescPrivilegios, string strDescripcion)
        {
            this.intCodPrivilegios = intCodPrivilegios;
            this.intCodRol = intCodRol;
            this.intEstadoRolPrivi = intEstadoRolPrivi;
            this.strDescPrivilegios = strDescPrivilegios;
            this.strDescripcion = strDescripcion;
        }
        


        #endregion

        #region Encapsulamiento

        public int intCodPrivilegios
        {
            get { return _intCodPrivilegios; }
            set { _intCodPrivilegios = value; }
        }

        public int intCodRol
        {
            get { return _intCodRol; }
            set { _intCodRol = value; }
        }

        public int intEstadoRolPrivi
        {
            get { return _intEstadoRolPrivi; }
            set { _intEstadoRolPrivi = value; }
        }

        public string strDescPrivilegios
        {
            get { return _strDescPrivilegios; }
            set { _strDescPrivilegios = value; }
        }

        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }


        public string strEstadoRolPrivi
        {
            get { return _strEstadoRolPrivi; }
            set { _strEstadoRolPrivi = value; }
        }

        #endregion
    }
}