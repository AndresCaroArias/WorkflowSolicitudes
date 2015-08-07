using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Errores
    {
        #region Atributos 
        private int _intIdError;
        private string _strRutUsuario;
        private string _strNombreProcedimiento;
        private string _strCodError;
        private string _strGlosaError;
        private string _strObservacion;
        private DateTime _dtmFecha;
        private string _strMetodo;
        #endregion 
        
        #region Cosntructor
        public Errores()
        {
          
        }

        public Errores(int intIdError, string strRutUsuario, string strNombreProcedimiento, string strCodError, string strGlosaError, string strObservacion, DateTime dtmFecha, string strMetodo)
        {
            this.intIdError = intIdError;
            this.strRutUsuario = strRutUsuario;
            this.strNombreProcedimiento = strNombreProcedimiento;
            this.strCodError = strCodError;
            this.strGlosaError = strGlosaError;
            this.strObservacion = strObservacion;
            this.dtmFecha = dtmFecha;
            this.strMetodo = strMetodo;

        }

        #endregion

        #region Encapsulamiento
        public int intIdError
        {
            get { return _intIdError; }
            set { _intIdError = value; }
        }

        public string strRutUsuario
        {
            get { return _strRutUsuario; }
            set { _strRutUsuario = value; }
        }
        public string strNombreProcedimiento
        {
            get { return _strNombreProcedimiento; }
            set { _strNombreProcedimiento = value; }
        }

        public string strCodError
        {
            get { return _strCodError; }
            set { _strCodError = value; }
        }

        public string strGlosaError
        {
            get { return _strGlosaError; }
            set { _strGlosaError = value; }
        }

        public string strObservacion
        {
            get { return _strObservacion; }
            set { _strObservacion = value; }
        }

        public DateTime dtmFecha
        {
            get { return _dtmFecha; }
            set { _dtmFecha = value; }
        }

        public string strMetodo
        {
            get { return _strMetodo; }
            set { _strMetodo = value; }
        } 
        #endregion
    }
}