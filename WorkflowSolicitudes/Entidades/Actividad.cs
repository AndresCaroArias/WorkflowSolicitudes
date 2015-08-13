using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Actividad
    {
        #region Atributos 

        private int _intCodActividad;       
        private string _strDescripActividad;        
        private int _intDuracion;
        private int _intEstadoActividad;
        private string _strEstadoActividad;

        #endregion
        
        #region Constructor 

        public Actividad() { }

        public Actividad(int intCodActividad, string strDescripActividad, int intDuracion, int intEstadoActividad)
        {
            this.intCodActividad = intCodActividad;
            this.strDescripActividad = strDescripActividad;
            this.intDuracion = intDuracion;
            this.intEstadoActividad = intEstadoActividad;
        }

        public Actividad(int intCodActividad, string strDescripActividad, int intDuracion, string strEstadoActividad) 
        {
            this.intCodActividad = intCodActividad;
            this.strDescripActividad = strDescripActividad;
            this.intDuracion = intDuracion;
            this.strEstadoActividad = strEstadoActividad;
        }

        public Actividad(int intCodActividad, string strDescripActividad, int intDuracion) 
        {
            this.intCodActividad = intCodActividad;
            this.strDescripActividad = strDescripActividad;
            this.intDuracion = intDuracion;
        }

        

        #endregion

        #region Encapsulamiento

        public int intCodActividad
        {
            get { return _intCodActividad; }
            set { _intCodActividad = value; }
        }

        public string strDescripActividad
        {
            get { return _strDescripActividad; }
            set { _strDescripActividad = value; }
        }

        public int intDuracion
        {
            get { return _intDuracion; }
            set { _intDuracion = value; }
        }

        public int intEstadoActividad
        {
            get { return _intEstadoActividad; }
            set { _intEstadoActividad = value; }
        }
        public string strEstadoActividad
        {
            get { return _strEstadoActividad; }
            set { _strEstadoActividad = value; }
        }
        #endregion
    }
}