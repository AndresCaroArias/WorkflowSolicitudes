using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class CSolicitudes
    {
        #region Atributos

        private int _intFolioSolicitud;
        private DateTime _dtmFechaSolicitud;
        private string _strCod_Cli;
        private DateTime _dtmFechaResolucion;
        private string _strObsSolucion;
        private string _strGlosaSolucion;
        private string _strDescSolicitud;
        private string _strNombre;
        private string _strPaterno;
        private string _strMaterno;
        private string _strNombre_Largo;
        private string _strDescEstado;
        private string _strJornada;
        private string _strOrigen;
        private string _strActividad;
        private int _intSecuencia;
        private string _strDetalleSolicitud;
        private string _strEstado;
        private DateTime _dtmFechaVencSoli;
        private DateTime _dtmFechaEjecActi;
        private int _intDiasAtraso;
        private DateTime _dtmFechaResolu;
        private DateTime _dtmFechaRecepc;
        private string _strDescUnidad;


        #endregion

        #region Cosntructor

        public CSolicitudes() { }


        public CSolicitudes(int intFolioSolicitud, DateTime dtmFechaSolicitud, String strCod_Cli, DateTime dtmFechaResolucion,
                            string strObsSolucion, string strGlosaSolucion, string strDescSolicitud, string strNombre,
                            string strPaterno, string strMaterno, string strNombre_Largo, string strDescEstado, string strJornada, string strOrigen)
        {
            this.intFolioSolicitud = intFolioSolicitud;
            this.dtmFechaSolicitud = dtmFechaSolicitud;
            this.strCod_Cli = strCod_Cli;
            this.dtmFechaResolucion = dtmFechaResolucion;
            this.strObsSolucion = strObsSolucion;
            this.strGlosaSolucion = strGlosaSolucion;
            this.strDescSolicitud = strDescSolicitud;
            this.strNombre = strNombre;
            this.strPaterno = strPaterno;
            this.strMaterno = strMaterno;
            this.strNombre_Largo = strNombre_Largo;
            this.strDescEstado = strDescEstado;
            this.strJornada = strJornada;
            this.strOrigen = strOrigen;
        }

        public CSolicitudes(int intFolioSolicitud, int intSecuencia, string strDescSolicitud, string strActividad, string strNombre,
                            string strDetalleSolicitud, string strEstado, string strDesUnidad, DateTime dtmFechaEjecActi, DateTime dtmFechaVencSoli,
                            int intDiasAtraso, DateTime dtmFechaResolu, DateTime dtmFechaRecepc)
        {
                this.intFolioSolicitud = intFolioSolicitud;
                this.intSecuencia = intSecuencia;
                this.strDescSolicitud = strDescSolicitud;
                this.strActividad = strActividad;
                this.strNombre = strNombre;
                this.strDetalleSolicitud = strDetalleSolicitud;
                this.strEstado = strEstado;
                this.strDescUnidad = strDesUnidad;
                this.dtmFechaEjecActi = dtmFechaEjecActi;
                this.dtmFechaVencSoli = dtmFechaVencSoli;
                this.intDiasAtraso = intDiasAtraso;
                this.dtmFechaResolu = dtmFechaResolu;
                this.dtmFechaRecepc = dtmFechaRecepc;
                
        
        
        }
            


        #endregion

        #region Encapsulamiento
        public string strPaterno
        {
            get { return _strPaterno; }
            set { _strPaterno = value; }
        }

        public string strNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        public string strGlosaSolucion
        {
            get { return _strGlosaSolucion; }
            set { _strGlosaSolucion = value; }
        }
        public string strDescSolicitud
        {
            get { return _strDescSolicitud; }
            set { _strDescSolicitud = value; }
        }

        public string strCod_Cli
        {
            get { return _strCod_Cli; }
            set { _strCod_Cli = value; }
        }
        public string strObsSolucion
        {
            get { return _strObsSolucion; }
            set { _strObsSolucion = value; }
        }

        public DateTime dtmFechaResolucion
        {
            get { return _dtmFechaResolucion; }
            set { _dtmFechaResolucion = value; }
        }
        public DateTime dtmFechaSolicitud
        {
            get { return _dtmFechaSolicitud; }
            set { _dtmFechaSolicitud = value; }
        }
        public int intFolioSolicitud
        {
            get { return _intFolioSolicitud; }
            set { _intFolioSolicitud = value; }
        }

        public string strDescEstado
        {
            get { return _strDescEstado; }
            set { _strDescEstado = value; }
        }
        public string strNombre_Largo
        {
            get { return _strNombre_Largo; }
            set { _strNombre_Largo = value; }
        }

        public string strMaterno
        {
            get { return _strMaterno; }
            set { _strMaterno = value; }
        }
        public string strJornada
        {
            get { return _strJornada; }
            set { _strJornada = value; }
        }

        public string strOrigen
        {
            get { return _strOrigen; }
            set { _strOrigen = value; }
        }

        public string strActividad
        {
            get { return _strActividad; }
            set { _strActividad = value; }
        }
        public int intSecuencia
        {
            get { return _intSecuencia;  }
            set { _intSecuencia = value ;}
        }

        public string strDetalleSolicitud
        {
            get { return _strDetalleSolicitud; }
            set { _strDetalleSolicitud = value; }                  
        }

        public string strEstado
        {
            get { return _strEstado; }
            set { _strEstado = value; }
        }

        public DateTime dtmFechaEjecActi
        {
            get { return _dtmFechaEjecActi; }
            set { _dtmFechaEjecActi = value; }
        }

        public DateTime dtmFechaVencSoli
        {
            get { return _dtmFechaVencSoli; }
            set { _dtmFechaVencSoli = value; }
        }

        public int intDiasAtraso
        {
            get { return _intDiasAtraso; }
            set { _intDiasAtraso = value;  }
        }


        public DateTime dtmFechaResolu
        {
            get { return _dtmFechaResolu; }
            set { _dtmFechaResolu = value; }
        }

        public DateTime dtmFechaRecepc
        {
            get { return _dtmFechaRecepc; }
            set { _dtmFechaRecepc = value; }
        }

        public string strDescUnidad
        {
            get { return _strDescUnidad; }
            set { _strDescUnidad = value; }
        }

        }
        #endregion
}