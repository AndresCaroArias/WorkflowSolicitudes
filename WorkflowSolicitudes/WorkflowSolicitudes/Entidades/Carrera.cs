using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Carrera
    {
        #region Atributos

        private string _strCodCarrera;        
        private string _strDescripcionCarrera;        

        #endregion

        #region Cosntructor

        public Carrera() { }

        public Carrera(string strCodCarrera, string strDescripcionCarrera) 
        {
            this.strCodCarrera = strCodCarrera;
            this.strDescripcionCarrera = strDescripcionCarrera;
        }
        #endregion

        #region Encapsulamiento

        public string strCodCarrera
        {
            get { return _strCodCarrera; }
            set { _strCodCarrera = value; }
        }
        public string strDescripcionCarrera
        {
            get { return _strDescripcionCarrera; }
            set { _strDescripcionCarrera = value; }
        }
        #endregion

    }
}