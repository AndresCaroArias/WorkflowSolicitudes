using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class DetalleSolicitud
    {
        #region Atributos

        private int      _intFolioSolicitudes;        
        private int      _intSecuencia;        
        private int      _intCodTipoSolicitud;        
        private int      _intCodActividad;
        private string   _strGlosaActividad;
        private int      _intCodEstado;
        private string   _strGlosaEstado;
        private string   _strRutUsuario;
        private string   _strnombre;
        private DateTime _dtmFechaVencSol;        
        private int      _intDiasDeRetraso;
        private DateTime _dtmFechaRecep;
        private DateTime _dtmFechaEjecutaActividad;
        private DateTime _dtmFechaResolucion;
        private string _strGlosaDetalleSolictud;
        private string _strApellido;
        private string _strEstado;
        private int _intCodUnidad;
        private string _strDescUnidad;

        #endregion

        #region Cosntructor
        public DetalleSolicitud() { }
        public DetalleSolicitud(int intFolioSolicitudes, int intSecuencia, int intCodTipoSolicitud, int intCodActividad, string strGlosaActividad,
                                int intCodEstado, string strGlosaEstado, string strRutUsuario, string strnombre, DateTime dtmFechaVencSol,
                                int intDiasDeRetraso, DateTime DtmFechaRecep, DateTime DtmFechaEjecutaActividad, DateTime DtmFechaResolucion, 
                                string StrGlosaDetalleSolictud, int intCodUnidad, string strDescUnidad) 
        {
          //
            this.intFolioSolicitudes      = intFolioSolicitudes;
            this.intSecuencia             = intSecuencia;
            this.intCodTipoSolicitud      = intCodTipoSolicitud;
            this.intCodActividad          = intCodActividad;
            this.strGlosaActividad        = strGlosaActividad;
            this.intCodEstado             = intCodEstado;
            this.strGlosaEstado           = strGlosaEstado;
            this.strRutUsuario            = strRutUsuario;
            this.strnombre                = strnombre;
            this.dtmFechaVencSol          = dtmFechaVencSol;
            this.intDiasDeRetraso         = intDiasDeRetraso;
            this.DtmFechaRecep            = DtmFechaRecep;
            this.DtmFechaEjecutaActividad = DtmFechaEjecutaActividad;
            this.DtmFechaResolucion       = DtmFechaResolucion;
            this.StrGlosaDetalleSolictud  = StrGlosaDetalleSolictud;
            this.intCodUnidad             = intCodUnidad;
            this.strDescUnidad            = strDescUnidad;

        }


        public DetalleSolicitud(int intFolioSolicitudes, int intSecuencia, int intCodTipoSolicitud, int intCodActividad, string strGlosaActividad,
                                int intCodEstado, string strGlosaEstado, string strRutUsuario, string strnombre, DateTime dtmFechaVencSol,
                                int intDiasDeRetraso, DateTime DtmFechaRecep, DateTime DtmFechaEjecutaActividad, DateTime DtmFechaResolucion,
                                string StrGlosaDetalleSolictud)
        {
            this.intFolioSolicitudes = intFolioSolicitudes;
            this.intSecuencia = intSecuencia;
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.intCodActividad = intCodActividad;
            this.strGlosaActividad = strGlosaActividad;
            this.intCodEstado = intCodEstado;
            this.strGlosaEstado = strGlosaEstado;
            this.strRutUsuario = strRutUsuario;
            this.strnombre = strnombre;
            this.dtmFechaVencSol = dtmFechaVencSol;
            this.intDiasDeRetraso = intDiasDeRetraso;
            this.DtmFechaRecep = DtmFechaRecep;
            this.DtmFechaEjecutaActividad = DtmFechaEjecutaActividad;
            this.DtmFechaResolucion = DtmFechaResolucion;
            this.StrGlosaDetalleSolictud = StrGlosaDetalleSolictud;
         
        }
        public DetalleSolicitud(int intFolioSolicitudes, int intSecuencia, string strNombre, string strApellido, DateTime dtmFehaResolucion, string StrGlosaDetalleSolictud)
        {
            this.intFolioSolicitudes     = intFolioSolicitudes;
            this.intSecuencia            = intSecuencia;
            this.strnombre               = strnombre;
            this.strApellido             = strApellido;
            this.DtmFechaResolucion      = dtmFehaResolucion;
            this.StrGlosaDetalleSolictud = StrGlosaDetalleSolictud;

        }

        public DetalleSolicitud(int intCodEstado, string strEstado) 
        {
            this.intCodEstado = intCodEstado;
            this.strEstado = strEstado;

        }

        #endregion

        #region Encapsulamiento

        public int intFolioSolicitudes
        {
            get { return _intFolioSolicitudes; }
            set { _intFolioSolicitudes = value; }
        }
        public int intSecuencia
        {
            get { return _intSecuencia; }
            set { _intSecuencia = value; }
        }
        public int intCodTipoSolicitud
        {
            get { return _intCodTipoSolicitud; }
            set { _intCodTipoSolicitud = value; }
        }
        public int intCodActividad
        {
            get { return _intCodActividad; }
            set { _intCodActividad = value; }
        }
        public string strGlosaActividad
        {
            get { return _strGlosaActividad; }
            set { _strGlosaActividad = value; }
        }
        public int intCodEstado
        {
            get { return _intCodEstado; }
            set { _intCodEstado = value; }
        }  
        public string strGlosaEstado
        {
            get { return _strGlosaEstado; }
            set { _strGlosaEstado = value; }
        }
        public string strRutUsuario
        {
            get { return _strRutUsuario; }
            set { _strRutUsuario = value; }
        }
        public string strnombre
        {
            get { return _strnombre; }
            set { _strnombre = value; }
        }        
        public DateTime dtmFechaVencSol
        {
            get { return _dtmFechaVencSol; }
            set { _dtmFechaVencSol = value; }
        }
        public int intDiasDeRetraso
        {
            get { return _intDiasDeRetraso; }
            set { _intDiasDeRetraso = value; }
        }
        public DateTime DtmFechaRecep
        {
            get { return _dtmFechaRecep; }
            set { _dtmFechaRecep = value; }
        }
        public DateTime DtmFechaEjecutaActividad
        {
            get { return _dtmFechaEjecutaActividad; }
            set { _dtmFechaEjecutaActividad = value; }
        }
        public DateTime DtmFechaResolucion
        {
            get { return _dtmFechaResolucion; }
            set { _dtmFechaResolucion = value; }
        }
        public string StrGlosaDetalleSolictud
        {
            get { return _strGlosaDetalleSolictud; }
            set { _strGlosaDetalleSolictud = value; }
        }
        public string strApellido
        {
            get { return _strApellido; }
            set { _strApellido = value; }
        }
        public string strEstado
        {
            get { return _strEstado;}
            set { _strEstado = value;}
        }

        public int intCodUnidad
        {
            get { return _intCodUnidad; }
            set { _intCodUnidad = value; }
        }

        public string strDescUnidad
        {
            get { return _strDescUnidad; }
            set { _strDescUnidad = value; }
        }

        #endregion

    }

    }
