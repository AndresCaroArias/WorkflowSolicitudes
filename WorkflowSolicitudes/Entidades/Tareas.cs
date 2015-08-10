using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Tareas
    {
        #region Atributos
        private int      _intFolioSolicitud;
        private string   _strDesSolicitud;
        private DateTime _dtmFechaSolicitud;       
        private int      _intSecuencia;       
        private string   _strDesActividad;        
        private DateTime _dtmFechaVencimiento;       
        private DateTime _dtmFechaResolucion;
        private int      _intDiasAtraso;
        private string   _strDescEstado;
        private int      _intEtapa;

        
        #endregion  

        #region Cosntructor
        public Tareas() { }
        public Tareas(int IntFolioSolicitud, string StrDesSolicitud, DateTime DtmFechaSolicitud, int IntSecuencia, string StrDesActividad,
                      DateTime DtmFechaVencimiento, DateTime DtmFechaResolucion, int IntDiasAtraso, string StrDescEstado, int intEtapa)
        
        {
            this.IntFolioSolicitud   = IntFolioSolicitud;
            this.StrDesSolicitud     = StrDesSolicitud;
            this.DtmFechaSolicitud   = DtmFechaSolicitud;
            this.IntSecuencia        = IntSecuencia;
            this.StrDesActividad     = StrDesActividad;
            this.DtmFechaVencimiento = DtmFechaVencimiento;
            this.DtmFechaResolucion  = DtmFechaResolucion;
            this.IntDiasAtraso       = IntDiasAtraso;
            this.StrDescEstado       = StrDescEstado;
            this._intEtapa = intEtapa;

        }
        #endregion

        #region Encapsulamiento
        public int IntFolioSolicitud
        {
            get { return _intFolioSolicitud; }
            set { _intFolioSolicitud = value; }
        }

        public string StrDesSolicitud
        {
            get { return _strDesSolicitud; }
            set { _strDesSolicitud = value; }
        }

        public DateTime DtmFechaSolicitud
        {
            get { return _dtmFechaSolicitud; }
            set { _dtmFechaSolicitud = value; }
        }
        public int IntSecuencia
        {
            get { return _intSecuencia; }
            set { _intSecuencia = value; }
        }

        public string StrDesActividad
        {
            get { return _strDesActividad; }
            set { _strDesActividad = value; }
        }

        public DateTime DtmFechaVencimiento
        {
            get { return _dtmFechaVencimiento; }
            set { _dtmFechaVencimiento = value; }
        }

        public DateTime DtmFechaResolucion
        {
            get { return _dtmFechaResolucion; }
            set { _dtmFechaResolucion = value; }
        }
        public int IntDiasAtraso
        {
            get { return _intDiasAtraso; }
            set { _intDiasAtraso = value; }
        }

        public string StrDescEstado
        {
            get { return _strDescEstado; }
            set { _strDescEstado = value; }
        }

        public int intEtapas
        {
            get { return _intEtapa; }
            set { _intEtapa = value; }
        }

        #endregion
    }
}