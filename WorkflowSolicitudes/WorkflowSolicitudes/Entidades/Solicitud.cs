using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Solicitud
    {
        #region Atributos
        private int      _intFolio;        
        private int      _intCodTipoSolicitud;
        private string   _strDescripcionSolicitud;
        private string   _strRutAlumno;        
        private string   _strCodCarrera;
        private string   _strGlosaCarrera;
        private DateTime _dtmFechaSolicitud;
        private string   _strGlosaEstado;
        private string   _strGlosaSolicitud;        
        private string   _strObsResolucion;        
        private DateTime _dtmFechaResolucion;
        private string   _stropcion;
        private string _strCelularContacto;
        private string _strEmailContacto;
        private DateTime _dtmFechaVencimientoSol;
        private string _strOrigen;
        
        #endregion

        #region Cosntructor
        public Solicitud() { }
        public Solicitud(int intFolio, int intCodTipoSolicitud, string strRutAlumno, string strCodCarrera, DateTime dtmFechaSolicitud, string strGlosaSolicitud, string strObsResolucion, DateTime dtmFechaResolucion) 
        {
            this.intFolio = intFolio;
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.strRutAlumno = strRutAlumno;
            this.strCodCarrera = strCodCarrera;
            this.dtmFechaSolicitud = dtmFechaSolicitud;
            this.strGlosaSolicitud = strGlosaSolicitud;
            this.strObsResolucion = strObsResolucion;
            this.dtmFechaResolucion = dtmFechaResolucion;
        }

        public Solicitud(int intFolio, int intCodTipoSolicitud, string strDescripcionSolicitud, string strRutAlumno, string intCodCarrera, string strGlosaCarrera, DateTime dtmFechaSolicitud, string strGlosaEstado, string strGlosaSolicitud, string strObsResolucion, DateTime dtmFechaResolucion, string strOpcion)
        {
            this.intFolio                = intFolio;
            this.intCodTipoSolicitud     = intCodTipoSolicitud;
            this.strDescripcionSolicitud = strDescripcionSolicitud;
            this.strRutAlumno            = strRutAlumno;
            this.strCodCarrera           = strCodCarrera;
            this.strGlosaCarrera         = strGlosaCarrera;
            this.dtmFechaSolicitud       = dtmFechaSolicitud;
            this.strGlosaEstado          = strGlosaEstado;
            this.strGlosaSolicitud       = strGlosaSolicitud;
            this.strObsResolucion        = strObsResolucion;
            this.dtmFechaResolucion      = dtmFechaResolucion;
            this.strOpcion               = strOpcion;

        }


        public Solicitud(int intFolio, int intCodTipoSolicitud, string strDescripcionSolicitud, string strRutAlumno, string intCodCarrera, string strGlosaCarrera, DateTime dtmFechaSolicitud, string strGlosaEstado, string strGlosaSolicitud, string strObsResolucion, DateTime dtmFechaResolucion, string strOpcion, string strCelularContacto, string strEmailContacto, string strOrigen)
        {
            this.intFolio                = intFolio;
            this.intCodTipoSolicitud     = intCodTipoSolicitud;
            this.strDescripcionSolicitud = strDescripcionSolicitud;
            this.strRutAlumno            = strRutAlumno;
            this.strCodCarrera           = strCodCarrera;
            this.strGlosaCarrera         = strGlosaCarrera;
            this.dtmFechaSolicitud       = dtmFechaSolicitud;
            this.strGlosaEstado          = strGlosaEstado;
            this.strGlosaSolicitud       = strGlosaSolicitud;
            this.strObsResolucion        = strObsResolucion;
            this.dtmFechaResolucion      = dtmFechaResolucion;
            this.strOpcion               = strOpcion;
            this.strCelularContacto      = strCelularContacto;
            this.strEmailContacto        = strEmailContacto;
            this.strOrigen               = strOrigen;
        }





        public Solicitud(int intFolio, DateTime dtmFechaVencimientoSol)
        {
            this.intFolio = intFolio;
            this.dtmFechaVencimientoSol = dtmFechaVencimientoSol;
        }

        
       
        #endregion

        #region Encapsulamiento
        public int intFolio
        {
            get { return _intFolio; }
            set { _intFolio = value; }
        }
        public int intCodTipoSolicitud
        {
            get { return _intCodTipoSolicitud; }
            set { _intCodTipoSolicitud = value; }
        }

        public string strDescripcionSolicitud
        {
            get { return _strDescripcionSolicitud; }
            set { _strDescripcionSolicitud = value; }
        }
        
        public string strRutAlumno
        {
            get { return _strRutAlumno; }
            set { _strRutAlumno = value; }
        }
        public string strCodCarrera
        {
            get { return _strCodCarrera; }
            set { _strCodCarrera = value; }
        }


        public string strGlosaCarrera
        {
            get { return _strGlosaCarrera; }
            set { _strGlosaCarrera = value; }
        }

        public DateTime dtmFechaSolicitud
        {
            get { return _dtmFechaSolicitud; }
            set { _dtmFechaSolicitud = value; }
        }

        public string strGlosaEstado
        {
            get { return _strGlosaEstado; }
            set { _strGlosaEstado = value; }
        }

             
        public string strGlosaSolicitud
        {
            get { return _strGlosaSolicitud; }
            set { _strGlosaSolicitud = value; }
        }
        public string strObsResolucion
        {
            get { return _strObsResolucion; }
            set { _strObsResolucion = value; }
        }
        public DateTime dtmFechaResolucion
        {
            get { return _dtmFechaResolucion; }
            set { _dtmFechaResolucion = value; }
        }


        public string strOpcion
        {
            get { return _stropcion; }
            set { _stropcion = value; }
        }

        public string strCelularContacto
        {
            get { return _strCelularContacto; }
            set { _strCelularContacto = value; }
        }

        public string strEmailContacto
        {
            get { return _strEmailContacto; }
            set { _strEmailContacto = value; }
        }

        public DateTime dtmFechaVencimientoSol
        {
            get { return _dtmFechaVencimientoSol; }
            set { _dtmFechaVencimientoSol = value; }
        }


        public string strOrigen
        {
            get { return _strOrigen; }
            set { _strOrigen = value; }
        }

        #endregion

    }
}