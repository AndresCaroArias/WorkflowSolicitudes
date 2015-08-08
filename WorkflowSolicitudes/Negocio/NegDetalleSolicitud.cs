using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegDetalleSolicitud
    {

        public NegDetalleSolicitud() { }

        public List<DetalleSolicitud> ObtenerDetalleSolicitud(int folio) 
        {
            DatosDetalleSolicitud DatDetalleSolicitud = new DatosDetalleSolicitud();
            return DatDetalleSolicitud.select_All_DetalleSolicitudes(folio);
        
        }

        public int ResolverActividad(int inFolioSolicitud, int intSecuencia, int intCodTipoSolicitud, int intCodEstado, string strGlosaDetalleSol, int intAprobador) 
        {
            int id;
            DatosDetalleSolicitud ResueleActividad = new DatosDetalleSolicitud();
            id = ResueleActividad.Resolutor(inFolioSolicitud, intSecuencia, intCodTipoSolicitud, intCodEstado, strGlosaDetalleSol, intAprobador);

            return id;
        }

        public int ResuelveActividadFlujo(int inFolioSolicitud, int intSecuencia, int intCodTipoSolicitud, int intCodEstado, string strGlosaDetalleSol, int intCodActividad, int intCodUnidad, int intSiguienteSecuencia)
        {
            DatosDetalleSolicitud ResuelveActividadFlujo = new DatosDetalleSolicitud();
            return ResuelveActividadFlujo.ElFlujoCreaSiguienteActividad(inFolioSolicitud, intSecuencia, intCodTipoSolicitud, intCodEstado, strGlosaDetalleSol, intCodActividad, intCodUnidad, intSiguienteSecuencia);
             
        }


        public int CierraProceso(int intFolioSolicitud, int intSecuencia, int intCodEstadSol, int intCodEstadoAct, string strGlosaDetalleSol) 
        {
            DatosDetalleSolicitud ResuelveCierraProceso = new DatosDetalleSolicitud();
            return ResuelveCierraProceso.CierraFlujo(intFolioSolicitud, intSecuencia, intCodEstadSol, intCodEstadoAct, strGlosaDetalleSol);
        }

        public int ActualizaFechaTomaActividad(int intFolioSolicitud, int intSecuencia, string strRutUsuario)
        {
            DatosDetalleSolicitud FechaTomaActividad = new DatosDetalleSolicitud();
            return FechaTomaActividad.ActualizarFechaTomaActividad(intFolioSolicitud, intSecuencia, strRutUsuario);
              
        }

        public int SolicitudTomada(int intFolioSolicitud)
        {
            DatosDetalleSolicitud EstaTomada = new DatosDetalleSolicitud();
            return EstaTomada.EstaTomadaLaSolicitud(intFolioSolicitud);
        }

        public int ExisteAlmenosUnaAprobacion(int intFolioSolicitud)
        {
            DatosDetalleSolicitud ExisteAprobacion = new DatosDetalleSolicitud();
            return ExisteAprobacion.ConsultaExisteAprobacion(intFolioSolicitud);
        }

        public int ApruebaLaSolicitud(int intFolioSolicitud, int intSecuencia) 
        {
            DatosDetalleSolicitud AprueboSolicitud = new DatosDetalleSolicitud();
            return AprueboSolicitud.ActualizaSolicitudAprobada(intFolioSolicitud, intSecuencia);
        }

        public List<DetalleSolicitud> HistorialDetalleSolicitud(int Folio)
        {
            DatosDetalleSolicitud HstDetalleSolicitud = new DatosDetalleSolicitud();
            return HstDetalleSolicitud.HistorialDetalleSolicitudes(Folio);

        }

       
        public List<DetalleSolicitud> ObtenerActDetalleSolicitud()
        {
                DatosDetalleSolicitud DatActDetalleSolicitud= new DatosDetalleSolicitud();
                return DatActDetalleSolicitud.select_all_EstadosDetSol();
            
        }

        public List<DetalleSolicitud> HistoriadelaSolicitud(int intFolioSolicitud)
        {
            DatosDetalleSolicitud DatActDetalleSolicitud = new DatosDetalleSolicitud();
            return DatActDetalleSolicitud.ConsultaHistoriaActividadesResueltas(intFolioSolicitud);

        }
        
    
    }

}