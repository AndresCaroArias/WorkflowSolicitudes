using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkflowSolicitudes.Entidades
{
    public class FlujoSolicitud
    {
        #region Atributos

        private int _intSecuencia;
        private int _intCodTipoSolicitud;
        private int _intCodActividad;
        private string _strRutUsuario;
        private int _intAprobador;
        private string _strAprobador;
        private string _strDescripcion;        
        private string _strNombre;       
        private string _strApellido;        
        private string _strEmailUsuario;
        private int _intCodUnidad;
        private string _strDescUnidad;
        private int    _intBifurcacion;
        private string _strBifurcacion;
        private int _intSi;
        private int _intNo;
        private string _strSi;
        private string _strNo;
        
        
        #endregion 

        #region Cosntructor
        public FlujoSolicitud() { }

        public FlujoSolicitud(int intSecuencia, string strDescripcion, int intCodUnidad, string strDescUnidad, string strAprobador, string strBifurcacion, int intCodTipoSolicitud, int intCodActividad, string strSi, string strNo )
        {
            this.intSecuencia = intSecuencia;
            this.strDescripcion = strDescripcion;
            this.intCodUnidad = intCodUnidad;
            this.strDescUnidad = strDescUnidad;
            this.strAprobador = strAprobador;
            this.strBifurcacion = strBifurcacion;
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.intCodActividad = intCodActividad;
            this.strSi = strSi;
            this.strNo = strNo;
        }

        public FlujoSolicitud(string strRutUsuario, string strNombre, string strApellido, string strEmailUsuario) 
        {
            this.strRutUsuario = strRutUsuario;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strEmailUsuario = strEmailUsuario;
        }

        //
        public FlujoSolicitud(int intSecuencia, int intCodActividad, int intCodUnidad, int intAprobador, int intBifurcacion, string strSi, string strNo)
        {
            this.intSecuencia    = intSecuencia;
            this.intCodActividad = intCodActividad;
            this.intCodUnidad    = intCodUnidad;
            this.intAprobador    = intAprobador;
            this.intBifurcacion  = intBifurcacion;
            this.strSi           = strSi;
            this.strNo           = strNo;
        }

        public FlujoSolicitud(string strRutUsuario, string strNombre, string strApellido, string strEmailUsuario, int intAprobador)
        {
            this.strRutUsuario = strRutUsuario;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strEmailUsuario = strEmailUsuario;
            this.intAprobador = intAprobador;
        }


        public FlujoSolicitud(int intSecuencia, int intCodTipoSolicitud, int intCodActividad, string strRutUsuario, int intAprobador, string strDescripcion, string strNombre, string strApellido, string strEmailUsuario)
        {
            this.intSecuencia = intSecuencia;
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.intCodActividad = intCodActividad;
            this.strRutUsuario = strRutUsuario;
            this.intAprobador = intAprobador;
            this.strDescripcion = strDescripcion;
            this.strNombre = strNombre;
            this.strApellido = strApellido;
            this.strEmailUsuario = strEmailUsuario;
        }

        public FlujoSolicitud(int intSecuencia, int intCodTipoSolicitud, int intCodActividad, string strRutUsuario, int intAprobador)
        {
            this.intSecuencia = intSecuencia;
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.intCodActividad = intCodActividad;
            this.strRutUsuario = strRutUsuario;
            this.intAprobador = intAprobador;
        }

        public FlujoSolicitud(int intSecuencia, string strDescripcion, int intCodUnidad, string strDescUnidad, int intAprobador, int intCodTipoSolicitud, int intCodActividad, string strSi, string strNo) 
        {
            this.intSecuencia        = intSecuencia;
            this.strDescripcion      = strDescripcion;
            this.intCodUnidad        = intCodUnidad;
            this.strDescUnidad       = strDescUnidad;
            this.intAprobador        = intAprobador;
            this.intCodTipoSolicitud = intCodTipoSolicitud;
            this.intCodActividad     = intCodActividad;
        }

        
        #endregion

        #region Encapsulamiento

        public int intSecuencia
        {
            get { return _intSecuencia; }
            set { _intSecuencia = value; }
        }
        public int intCodTipoSolicitud
        {
            get { return _intCodTipoSolicitud; }
            set { _intCodTipoSolicitud = value; }
        }
        public int intCodActividad
        {
            get { return _intCodActividad; }
            set { _intCodActividad = value; }
        }

        public string strRutUsuario
        {
            get { return _strRutUsuario; }
            set { _strRutUsuario = value; }
        }
        public int intAprobador
        {
            get { return _intAprobador; }
            set { _intAprobador = value; }
        }

        public string strAprobador
        {
            get { return _strAprobador; }
            set { _strAprobador = value; }
        }     


        public string strDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }
        public string strNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }
        public string strApellido
        {
            get { return _strApellido; }
            set { _strApellido = value; }
        }
        public string strEmailUsuario
        {
            get { return _strEmailUsuario; }
            set { _strEmailUsuario = value; }
        }

        public int intCodUnidad
        {
            get { return _intCodUnidad; }
            set { _intCodUnidad = value; }
        }

        public int intBifurcacion
        {
            get { return _intBifurcacion; }
            set { _intBifurcacion = value; }
        }


        public string strBifurcacion
        {
            get { return _strBifurcacion; }
            set { _strBifurcacion = value; }
        }

        public int intSi
        {
            get { return _intSi; }
            set { _intSi = value; }
        }

        public int intNo
        {
            get { return _intNo; }
            set { _intNo = value; }
        }

        public string strDescUnidad
        {
            get { return _strDescUnidad; }
            set { _strDescUnidad = value; }
        }

        public string strSi
        {
            get { return _strSi; }
            set { _strSi = value; }
        }

        public string strNo
        {
            get { return _strNo; }
            set { _strNo = value; }
        }


        #endregion

    }
}