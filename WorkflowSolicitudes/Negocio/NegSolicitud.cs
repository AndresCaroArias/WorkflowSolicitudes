using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;


namespace WorkflowSolicitudes.Negocio
{
    public class NegSolicitud
    {

        public NegSolicitud() { }

        public List<Solicitud> ObtenerSolicitudes(string StrRutAlumno)
        {
            DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
            return DatoSolicitud.select_All_Solicitudes(StrRutAlumno);
        }

        public List<Solicitud> ObtenerSolicitudesByFolio(int FolioSolicitud)
        {
            DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
            return DatoSolicitud.select_ByFolio_Solicitudes(FolioSolicitud);
        }

       public List<Solicitud> Insertar_Solicitud(int cod_tipo_solicitud, string rut_alumno, string cod_carrera, string celularContacto, string emailcontacto, string glosa_solicitud , string origen) 
       {

           DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
           return DatoSolicitud.InsertaSolicitud(cod_tipo_solicitud, rut_alumno, cod_carrera, celularContacto, emailcontacto, glosa_solicitud, origen);
       }

        public int ValidaCantidadSolicitudesXTipo(int intCodTipoSolicitud)
        { 
            DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
            return DatoSolicitud.ValidaCantidadSolicitud(intCodTipoSolicitud);
        }

        public int AnulaSolicitud(int intFolioSolicitud) 
        {
            DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
            return DatoSolicitud.AnulaSolicitud(intFolioSolicitud);
        }

        public int EstaAnulado(int intFolioSolicitud) 
        
        {
            DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
            return DatoSolicitud.ValidaExisteAnulacion(intFolioSolicitud);
        }

        public int HayProcesoEjecutandoSe(int intCodTipoSolicitud)
        {
            DatosSolicitudes DatoSolicitud = new DatosSolicitudes();
            return DatoSolicitud.ValidaSiExistenSolicitudEjecutando(intCodTipoSolicitud);
              
        }
    
    }
}
