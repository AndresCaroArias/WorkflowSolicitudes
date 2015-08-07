using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Privilegios
    {
        #region Atributos

        private int _intCodPrivilegios;        
        private string _strDescPrivilegios;
        private string _strNomPrivilegios;
        private int _intEstadoPrivilegios;
                
       
        #endregion

        #region Cosntructor

        
        

        public Privilegios() { }

        public Privilegios(int intCodPrivilegios, string strNomPrivilegios)
        {
            this.intCodPrivilegios = intCodPrivilegios;
            this.strNomPrivilegios = strNomPrivilegios;

        }
        //public Privilegios(int intCodPrivilegios, string strDescPrivilegios) 
        //{
        //    this.intCodPrivilegios = intCodPrivilegios;
        //    this.strDescPrivilegios = strDescPrivilegios;
            
        //}

        public Privilegios(int intCodPrivilegios, string strDescPrivilegios, string strNomPrivilegios, int intEstadoPrivilegios)
        {
            this.intCodPrivilegios = intCodPrivilegios;
            this.strDescPrivilegios = strDescPrivilegios;
            this.strNomPrivilegios = strNomPrivilegios;
            this.intEstadoPrivilegios = intEstadoPrivilegios;

        }

        public Privilegios(int intCodPrivilegios, string strDescPrivilegios, string strNomPrivilegios)
        {
            this.intCodPrivilegios = intCodPrivilegios;
            this.strDescPrivilegios = strDescPrivilegios;
            this.strNomPrivilegios = strNomPrivilegios;            

        }

        public Privilegios(string strDescPrivilegios, string strNomPrivilegios, int intEstadoPrivilegios)
        {
           
            this.strDescPrivilegios = strDescPrivilegios;
            this.strNomPrivilegios = strNomPrivilegios;
            this.intEstadoPrivilegios = intEstadoPrivilegios;

        }
        public Privilegios(string strDescPrivilegios, int intEstadoPrivilegios)
        {

            this.strDescPrivilegios = strDescPrivilegios;
            this.intEstadoPrivilegios = intEstadoPrivilegios;

        }

        //public Privilegios(int intCodPrivilegios, string strDescPrivilegios, string strNomPrivilegios, int intEstadoPrivilegios)
        //{
        //    this.intCodPrivilegios = intCodPrivilegios;
        //    this.strDescPrivilegios = strDescPrivilegios;
        //    this.strNomPrivilegios = strNomPrivilegios;
        //    this.intEstadoPrivilegios = intEstadoPrivilegios;

        //}
      
        #endregion

        #region Encapsulamiento

        public int intCodPrivilegios
        {
            get { return _intCodPrivilegios; }
            set { _intCodPrivilegios = value; }
        }
        
        public string strDescPrivilegios
        {
            get { return _strDescPrivilegios; }
            set { _strDescPrivilegios = value; }
        }

        public string strNomPrivilegios
        {
            get { return _strNomPrivilegios; }
            set { _strNomPrivilegios = value; }
        }
        public int intEstadoPrivilegios
        {
            get { return _intEstadoPrivilegios; }
            set { _intEstadoPrivilegios = value; }
        }  
        #endregion

    }
}