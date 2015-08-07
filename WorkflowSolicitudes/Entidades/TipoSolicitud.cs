using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class TipoSolicitud
    {
        #region Atributos

        private int _intCodTipoSolicitud;        
        private string _strDescripcionSolicitud;
        private int _intEstadoSolicitud;        
        private DateTime _dtmFechaIncioSol;        
        private DateTime _dtmFechaTerminoSol;
        private int _intCantMaxSolicitud;
        private string _strOrigenSolicitud;
        private int _intCantMaxDoc;

        

        #endregion

        #region Cosntructor
        public TipoSolicitud() { }
        public TipoSolicitud(int intCodTipoSolicitud)
        {
            this.intCodTipoSolicitud = intCodTipoSolicitud;
           
        }

        public TipoSolicitud(int intCodTipoSolicitud, string strDescripcionSolicitud)
        {
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.strDescripcionSolicitud = strDescripcionSolicitud;
        }

        public TipoSolicitud(int intCodTipoSolicitud,  int intCantMaxDoc)
        {
            this.intCodTipoSolicitud = intCodTipoSolicitud;            
            this.intCantMaxDoc = intCantMaxDoc;
        }


        public TipoSolicitud(int intCodTipoSolicitud, string strDescripcionSolicitud, int intEstadoSolicitud, DateTime dtmFechaIncioSol, DateTime dtmFechaTerminoSol) 
        {
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.strDescripcionSolicitud = strDescripcionSolicitud;
            this.intEstadoSolicitud = intEstadoSolicitud;
            this.dtmFechaIncioSol = dtmFechaIncioSol;
            this.dtmFechaTerminoSol = dtmFechaTerminoSol;
            
        }

        public TipoSolicitud(int intCodTipoSolicitud, string strDescripcionSolicitud, int intEstadoSolicitud, DateTime dtmFechaIncioSol, DateTime dtmFechaTerminoSol, int intCantMaxSolicitud, string strOrigenSolicitud, int intCantMaxDoc)
        {
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.strDescripcionSolicitud = strDescripcionSolicitud;
            this.intEstadoSolicitud =  intEstadoSolicitud;
            this.dtmFechaIncioSol = dtmFechaIncioSol;
            this.dtmFechaTerminoSol = dtmFechaTerminoSol;
            this.intCantMaxSolicitud = intCantMaxSolicitud;
            this.strOrigenSolicitud = strOrigenSolicitud;
            this.intCantMaxDoc = intCantMaxDoc;
        }

        public TipoSolicitud(string strDescripcionSolicitud, int intEstadoSolicitud, DateTime dtmFechaIncioSol, DateTime dtmFechaTerminoSol, int intCantMaxSolicitud, string strOrigenSolicitud, int intCantMaxDoc)
        {
            
            this.strDescripcionSolicitud = strDescripcionSolicitud;
            this.intEstadoSolicitud = intEstadoSolicitud;
            this.dtmFechaIncioSol = dtmFechaIncioSol;
            this.dtmFechaTerminoSol = dtmFechaTerminoSol;
            this.intCantMaxSolicitud = intCantMaxSolicitud;
            this.strOrigenSolicitud = strOrigenSolicitud;
            this.intCantMaxDoc = intCantMaxDoc;

        }

        public TipoSolicitud(int intCodTipoSolicitud, string strDescripcionSolicitud, DateTime dtmFechaIncioSol, DateTime dtmFechaTerminoSol)
        {
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.strDescripcionSolicitud = strDescripcionSolicitud;
            this.dtmFechaIncioSol = dtmFechaIncioSol;
            this.dtmFechaTerminoSol = dtmFechaTerminoSol;
        }

        #endregion

        #region Encapsulamiento

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
        public int intEstadoSolicitud
        {
            get { return _intEstadoSolicitud; }
            set { _intEstadoSolicitud = value; }
        }        
        public DateTime dtmFechaIncioSol
        {
            get { return _dtmFechaIncioSol; }
            set { _dtmFechaIncioSol = value; }
        }
        public DateTime dtmFechaTerminoSol
        {
            get { return _dtmFechaTerminoSol; }
            set { _dtmFechaTerminoSol = value; }
        }

        public int intCantMaxSolicitud
        {
            get { return _intCantMaxSolicitud; }
            set { _intCantMaxSolicitud = value; }
        }

        public string strOrigenSolicitud
        {
            get { return _strOrigenSolicitud; }
            set { _strOrigenSolicitud = value; }
        }

        public int intCantMaxDoc
        {
            get { return _intCantMaxDoc; }
            set { _intCantMaxDoc = value; }
        }


        #endregion

    }
}