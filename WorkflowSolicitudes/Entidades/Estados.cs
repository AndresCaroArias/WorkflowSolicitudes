using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Estados
    {
        #region Atributos

        private int _intCodEstado;        
        private string _strDescEstado;        

        #endregion

        #region Cosntructor

        public Estados() { }
        public Estados(int intCodEstado, string strDescEstado) 
        {
            this.intCodEstado = intCodEstado;
            this.strDescEstado = strDescEstado;
        }

        #endregion

        #region Encapsulamiento

        public int intCodEstado
        {
            get { return _intCodEstado; }
            set { _intCodEstado = value; }
        }
        public string strDescEstado
        {
            get { return _strDescEstado; }
            set { _strDescEstado = value; }
        }
        #endregion

    }
}