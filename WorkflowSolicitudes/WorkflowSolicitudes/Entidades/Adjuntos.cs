using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Adjuntos
    {
        #region Atributos

        private int _intIdArchivo;        
        private int _intFolio;        
        private string _strNombreArchivo;        
        private Byte[] _bteArchivoPdf;
        private string _strTipoAdjunto;
        private int _intSecuencia;

        

        

               
        #endregion

        #region Constuctor 

        public Adjuntos()
        { }
        public Adjuntos(int intIdArchivo)
        {
            this.intIdArchivo = intIdArchivo;
            
        }

        public Adjuntos(int intIdArchivo, int intFolio, string strNombreArchivo, Byte[] bteArchivoPdf, string strTipoAdjunto, int intSecuencia)
        {
            this.intIdArchivo = intIdArchivo;
            this.intFolio = intFolio;
            this.strNombreArchivo = strNombreArchivo;
            this.bteArchivoPdf = bteArchivoPdf;
            this.strTipoAdjunto = strTipoAdjunto;
            this.intSecuencia = intSecuencia;
        }

        public Adjuntos(int intIdArchivo, int intFolio, string strNombreArchivo, Byte[] bteArchivoPdf, string strTipoAdjunto)
        {
            this.intIdArchivo = intIdArchivo;
            this.intFolio = intFolio;
            this.strNombreArchivo = strNombreArchivo;
            this.bteArchivoPdf = bteArchivoPdf;
            this.strTipoAdjunto = strTipoAdjunto;
        }

        public Adjuntos(int intIdArchivo, int intFolio, string strNombreArchivo, Byte[] bteArchivoPdf)
        {
            this.intIdArchivo = intIdArchivo;
            this.intFolio = intFolio;
            this.strNombreArchivo = strNombreArchivo;
            this.bteArchivoPdf = bteArchivoPdf;        
        }

        public Adjuntos(int intIdArchivo, string strNombreArchivo, Byte[] bteArchivoPdf)
        {
            this.intIdArchivo = intIdArchivo;
            this.strNombreArchivo = strNombreArchivo;
            this.bteArchivoPdf = bteArchivoPdf;

        }

        public Adjuntos(int intIdArchivo, string strNombreArchivo, Byte[] bteArchivoPdf, int intSecuencia)
        {
            this.intIdArchivo = intIdArchivo;
            this.strNombreArchivo = strNombreArchivo;
            this.bteArchivoPdf = bteArchivoPdf;
            this.intSecuencia = intSecuencia;

        }

        public Adjuntos( string strNombreArchivo, Byte[] bteArchivoPdf)
        {
            this.strNombreArchivo = strNombreArchivo;
            this.bteArchivoPdf = bteArchivoPdf;

        }
        public Adjuntos(int intIdArchivo, string strNombreArchivo)
        {
            this.intIdArchivo = intIdArchivo;
            this.strNombreArchivo = strNombreArchivo;
          
        }
       


        #endregion

        #region Encapsulamiento
        public int intIdArchivo
        {
            get { return _intIdArchivo; }
            set { _intIdArchivo = value; }
        }

        public int intFolio
        {
            get { return _intFolio; }
            set { _intFolio = value; }
        }

        public string strNombreArchivo
        {
            get { return _strNombreArchivo; }
            set { _strNombreArchivo = value; }
        }

        public Byte[] bteArchivoPdf
        {
            get { return _bteArchivoPdf; }
            set { _bteArchivoPdf = value; }
        }

        public string strTipoAdjunto
        {
            get { return _strTipoAdjunto; }
            set { _strTipoAdjunto = value; }
        }

        public int intSecuencia
        {
            get { return _intSecuencia; }
            set { _intSecuencia = value; }
        }

        #endregion
    }
}