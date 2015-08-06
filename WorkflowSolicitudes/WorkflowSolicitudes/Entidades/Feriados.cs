using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Feriados
    {
        #region Atributos

        private int _intCodFeriado;

       
        private string _strDescFeriado;

        
        private DateTime _dtmFechaFeriado;

        

        #endregion

        #region constructor

        public Feriados() { }

        public Feriados(int intCodFeriado, string strDescFeriado, DateTime dtmFechaFeriado)
    {
        this.intCodFeriado = intCodFeriado;
        this.strDescFeriado = strDescFeriado;
        this.dtmFechaFeriado = dtmFechaFeriado;        
    }
       #endregion

        #region Encapsulamiento

        public int intCodFeriado
        {
            get { return _intCodFeriado; }
            set { _intCodFeriado = value; }
        }
        public string strDescFeriado
        {
            get { return _strDescFeriado; }
            set { _strDescFeriado = value; }
        }

        public DateTime dtmFechaFeriado
        {
            get { return _dtmFechaFeriado; }
            set { _dtmFechaFeriado = value; }
        }  


        #endregion
    }
}