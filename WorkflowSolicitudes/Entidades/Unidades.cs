using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Unidades
    {
        #region Atributos

        private int _intCodUnidad;
        private string _strDescripcionUnidad;        
        private int _intEstadoUnidad;
        
        #endregion

        #region Cosntructor

        public Unidades() { }

        public Unidades(int intCodUnidad) 
        {
            this.intCodUnidad = intCodUnidad;
        }


        public Unidades(int intCodUnidad, string strDescripcionUnidad, int intEstadoUnidad) 
        {
            this.intCodUnidad = intCodUnidad;
            this.strDescripcionUnidad = strDescripcionUnidad;
            this.intEstadoUnidad = intEstadoUnidad;
        }       

        #endregion

        #region Encapsulamiento

        public int intCodUnidad
        {
            get { return _intCodUnidad; }
            set { _intCodUnidad = value; }
        }

        public string strDescripcionUnidad
        {
            get { return _strDescripcionUnidad; }
            set { _strDescripcionUnidad = value; }
        }

        public int intEstadoUnidad
        {
            get { return _intEstadoUnidad; }
            set { _intEstadoUnidad = value; }
        }
        

        #endregion
    }
}