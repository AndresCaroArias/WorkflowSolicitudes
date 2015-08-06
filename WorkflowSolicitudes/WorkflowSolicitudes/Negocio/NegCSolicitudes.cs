using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegCSolicitudes
    {
        public NegCSolicitudes() { }


        public List<CSolicitudes> select_All_CSolicitudes(int intFolio,
                                                          string strCod_CLi,
                                                          int intCodTipoSolicitud,
                                                          string strCodCarrera,
                                                          int intCodEstado,
                                                          DateTime dtmFechaSolicitud,
                                                          DateTime dtmFechaSolicitudHasta,
                                                          DateTime dtmFechaResolucion,
                                                          DateTime dtmFechaResolucionHasta,
                                                          string strJornada,
                                                          string strOrigen
                                                                          )
        {
            DatosCSolicitudes DatCSolicitudes = new DatosCSolicitudes();
            return DatCSolicitudes.select_All_DatCSolicitudes(intFolio,
                                                              strCod_CLi,
                                                              intCodTipoSolicitud,
                                                              strCodCarrera,
                                                              intCodEstado,
                                                              dtmFechaSolicitud,
                                                              dtmFechaSolicitudHasta,
                                                              dtmFechaResolucion,
                                                              dtmFechaResolucionHasta,
                                                              strJornada,
                                                              strOrigen);

        }

        public List<CSolicitudes> select_All_CSolicitudesInternas(int intFolio,
                                                  string strCod_CLi,
                                                  int intCodTipoSolicitud,
                                                  string strCodCarrera,
                                                  int intCodEstado,
                                                  DateTime dtmFechaSolicitud,
                                                  DateTime dtmFechaSolicitudHasta,
                                                  DateTime dtmFechaResolucion,
                                                  DateTime dtmFechaResolucionHasta,
                                                  string strJornada,
                                                  string strOrigen
                                                                  )
        {
            DatosCSolicitudes DatCSolicitudes = new DatosCSolicitudes();
            return DatCSolicitudes.select_All_DatCSolicitudesInternas(intFolio,
                                                                      strCod_CLi,
                                                                      intCodTipoSolicitud,
                                                                      intCodEstado,
                                                                      dtmFechaSolicitud,
                                                                      dtmFechaSolicitudHasta,
                                                                      dtmFechaResolucion,
                                                                      dtmFechaResolucionHasta);

        }



        public List<CSolicitudes> ConsultaDetAct(int intTipoSolicitud,
                                                       int intTipoActividad,
                                                       int intEstado,
                                                       int intCodUnidad,
                                                       DateTime dtmFechaRecepDesde,
                                                       DateTime dtmFechaRecepHasta,
                                                       DateTime dtmFechaEjecDesde,
                                                       DateTime dtmFechaEjecHasta,
                                                       DateTime dtmFechaResolDesde,
                                                       DateTime dtmFechaResolHasta)
        {
            DatosCSolicitudes ConsultaDetalleActividad = new DatosCSolicitudes();

            return ConsultaDetalleActividad.select_All_CDinamicaDetSol(intTipoSolicitud, intTipoActividad, intEstado, intCodUnidad, dtmFechaRecepDesde, dtmFechaRecepHasta,
                                                                      dtmFechaEjecDesde, dtmFechaEjecHasta, dtmFechaResolDesde, dtmFechaResolHasta);

        }


    }
}