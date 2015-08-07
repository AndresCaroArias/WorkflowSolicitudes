using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Auditoria
    {

        #region Atributos

        private string _strRutUsuario;
        private string _strNombreUsuario;
        private DateTime _dtmFecha;
        private string _strIp;
        private string _strModulo;
        private string _strAccion;
        private string _strObservacion;
        private string _strDispositivo;
        private string _strNombreMaquina;
        private string _strMacaddress;

        #endregion

        #region Cosntructor
        public Auditoria() { }

        public Auditoria(string strRutUsuario, string strNombreUsuario, DateTime dtmFecha, string strIp, string strModulo, string strAccion, string strObservacion, string strDispositivo, string strNombreMaquina, string strMacaddress)
        {
            this.strRutUsuario = strRutUsuario;
            this.strNombreUsuario = strNombreUsuario;
            this.dtmFecha = dtmFecha;
            this.strIp = strIp;
            this.strModulo = strModulo;
            this.strAccion = strAccion;
            this.strObservacion = strObservacion;
            this.strDispositivo = strDispositivo;
            this.strNombreMaquina = strNombreMaquina;
            this.strMacaddress = strMacaddress;
        }

        public Auditoria(string strDispositivo)
        {
            this.strDispositivo = strDispositivo;

        }
        #endregion

        #region Encapsulamiento
        public string strRutUsuario
        {
            get { return _strRutUsuario; }
            set { _strRutUsuario = value; }
        }
        public DateTime dtmFecha
        {
            get { return _dtmFecha; }
            set { _dtmFecha = value; }
        }
        public string strIp
        {
            get { return _strIp; }
            set { _strIp = value; }
        }
        public string strModulo
        {
            get { return _strModulo; }
            set { _strModulo = value; }
        }
        public string strAccion
        {
            get { return _strAccion; }
            set { _strAccion = value; }
        }
        public string strObservacion
        {
            get { return _strObservacion; }
            set { _strObservacion = value; }
        }
        public string strDispositivo
        {
            get { return _strDispositivo; }
            set { _strDispositivo = value; }
        }

        public string strNombreMaquina
        {
            get { return _strNombreMaquina; }
            set { _strNombreMaquina = value; }
        }

        public string strMacaddress
        {
            get { return _strMacaddress; }
            set { _strMacaddress = value; }
        }

        public string strNombreUsuario
        {
            get { return _strNombreUsuario; }
            set { _strNombreUsuario = value; }
        }


        #endregion

    }
}