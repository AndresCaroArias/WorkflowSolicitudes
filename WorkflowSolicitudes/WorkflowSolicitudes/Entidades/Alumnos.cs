using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class Alumnos
    {
        #region Atributos
        private string _strCodCli;
        private string _strRut;
        private string _strJornada;
        private string _strNombre;
        private string _strApPaterno;


        private string _strApMaterno;
        private string _strCodCarrera;
        private string _StrNombreCarrera;

        #endregion 

        #region constructor 
        public Alumnos() { }
        public Alumnos(string strCodCli, 
                       string strRut, 
                       string strJornada, 
                       string strNombre, 
                       string strApPaterno, 
                       string strApMaterno, 
                       string strCodCarrera,
                       string strNombreCarrera)
        {

            this.StrCodCli        = strCodCli;
            this.StrRut           = strRut;
            this.StrJornada       = strJornada;
            this.StrNombre        = strNombre;
            this.StrApPaterno     = strApPaterno;
            this.StrApMaterno     = strApMaterno;
            this.StrCodCarrera    = strCodCarrera;
            this.StrNombreCarrera = strNombreCarrera;
                     
        }

        public string StrCodCli
        {
            get { return _strCodCli; }
            set { _strCodCli = value; }
        }

        public string StrRut
        {
            get { return _strRut; }
            set { _strRut = value; }
        }

        public string StrJornada
        {
            get { return _strJornada; }
            set { _strJornada = value; }
        }

        public string StrNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        public string StrApPaterno
        {
            get { return _strApPaterno; }
            set { _strApPaterno = value; }
        }

        public string StrApMaterno
        {
            get { return _strApMaterno; }
            set { _strApMaterno = value; }
        }

        public string StrCodCarrera
        {
            get { return _strCodCarrera; }
            set { _strCodCarrera = value; }
        }


        public string StrNombreCarrera
        {
            get { return _StrNombreCarrera; }
            set { _StrNombreCarrera = value; }
        }
       
        #endregion 

    }
}