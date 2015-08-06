using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;


namespace WorkflowSolicitudes.Negocio
{
    public class NegFlujoSolicitud
    {

        public string ObtenerActividad(int intSecuencia, int intCodTipoSolicitud)
        {
            string StrDescActividad; 
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return StrDescActividad = DatFlujoActividad.select_glosaActividad(intSecuencia, intCodTipoSolicitud);
        }


        public int EsAprobadorResponsable(int intSecuencia, int intCodTipoSolicitud, string StrRutUsuario)
        {
            int intAprobador;
            DatosFlujoSolicitud DatFlujoAprobador = new DatosFlujoSolicitud();
            return intAprobador = DatFlujoAprobador.EsAprobadoResponsable(intSecuencia, intCodTipoSolicitud,  StrRutUsuario);
        }
        
        public List<FlujoSolicitud> ObtenerFlujoSolicitud(int intCodTipoSolicitud)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.select_All_GetFlujo(intCodTipoSolicitud);
        }

        public List<FlujoSolicitud> SelectDatoActividad (int intCodTipoSolicitud, int intSecuencia)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.ConsultaActividadDelFlujo(intCodTipoSolicitud,intSecuencia);
        }

        public List<FlujoSolicitud> ObtenerUsuario(string strRutUsuario)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.select_All_GetUsuario(strRutUsuario);
        }

        
        public int EliminaFlujoSolicitud(int intCodTipoSolicitud, int intSecuencia)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.EliminaFlujoSolicitud(intCodTipoSolicitud, intSecuencia);
        }

        public int CambiaEstado(int intCodTipoSolicitud, int intSecuencia)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.CambiaEstado(intCodTipoSolicitud, intSecuencia);
        }

        public int Insertarflujo(int intSecuencia, int intCodTipoSolicitud, int intCodActividad, int intCodUnidad, int intAprobador, int intBifurcacion, string strSecuenciaSI, string strSecuenciaNO)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.InsertarFlujoSolicitud(intSecuencia, intCodTipoSolicitud, intCodActividad, intCodUnidad, intAprobador, intBifurcacion, strSecuenciaSI, strSecuenciaNO);
        }

        public int ActualizarFlujoSolicitud(int intSecuencia, int intCodTipoSolicitud, int intCodActividad, int intCodUnidad, int intAprobador, int intBifurcacion, string strSecuenciaSI, string strSecuenciaNO)
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            return DatFlujoActividad.ActualizarFlujoSolicitud(intSecuencia, intCodTipoSolicitud, intCodActividad, intCodUnidad, intAprobador, intBifurcacion, strSecuenciaSI, strSecuenciaNO);
        }

        public int UltimaSecuencia(int intCodTipoSolicitud) 
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            int intSecuencia = DatFlujoActividad.UltimaSecuenciaFluSolicitud(intCodTipoSolicitud);
          return intSecuencia;
        }


        public int BuscoCodigoActividad(int intCodTipoSolicitud, int intSecuencia) 
        {
            DatosFlujoSolicitud DatFlujoActividad = new DatosFlujoSolicitud();
            int intCodActividad = DatFlujoActividad.BuscoCodActividad(intCodTipoSolicitud, intSecuencia);
            return intCodActividad;
        }


        public int EstaEnUsolaActividad(int intCodActividad)
        {
            DatosFlujoSolicitud ExiteActFlujo = new DatosFlujoSolicitud();
            return ExiteActFlujo.BuscoExisteActividad(intCodActividad);
        }

        public List<FlujoSolicitud> ObtenerUsuario_Secuencia(int intCodTipoSolicitud, string intSecuencia)
        {
            DatosFlujoSolicitud DatoUsuarioSecuencia = new DatosFlujoSolicitud();
            return DatoUsuarioSecuencia.select_Usuario_secuencia(intCodTipoSolicitud, intSecuencia);
        }

        public int select_ExisteRut_Flujo(string strRutUsuario)
        {
            DatosUsuario ExiRut = new DatosUsuario();
            return ExiRut.ExisteRut_FlujoSolicitud(strRutUsuario);
        }
    }
}