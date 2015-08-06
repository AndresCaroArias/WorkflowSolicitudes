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

        #endregion
        
        #region Constructor 

        public Actividad() { }
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
        #endregion
    }
}