using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegActividad
    {
        public NegActividad() { }

        public int EliminarActvidad(int intCodActividad)
        {
            return (new DatosActividad()).EliminarActividad(intCodActividad);
        }

        public int AltaActividad(string strDescripActividad, int intDuracion, int intEstadoActivida)
        {
            DatosActividad DatAut = new DatosActividad();
            return DatAut.InsertActividad(strDescripActividad, intDuracion, intEstadoActivida);
        }

        public int ActualizarActividad(int intCodActividad, string strDescripActividad, int intDuracion, int intEstadoActividad)
        {
            DatosActividad DatAut = new DatosActividad();
            return DatAut.ActualizarActividad(intCodActividad, strDescripActividad, intDuracion, intEstadoActividad);
        }

        public List<Actividad> ObtenerActividad()
        {
            DatosActividad DatAut = new DatosActividad();
            return DatAut.select_All_E_Actividad();
        }

        public List<Actividad> ObtenerActividades_Activas()
        {
            DatosActividad DatAut = new DatosActividad();
            return DatAut.select_All_E_Actividad_Activas();
        }

        public int ExisteActividadDetalleSolicitud(int intCodActividad)
        {
            DatosActividad ExiteActDeta = new DatosActividad();
            return ExiteActDeta.EstaEnUsoLaActividaEnDetalleSolicitud(intCodActividad);
        }

        public int ExisteActividadFlujo(int intCodActividad)
        {
            DatosActividad ExiteActFlujo = new DatosActividad();
            return ExiteActFlujo.select_ExiteActividad_Flujo(intCodActividad);
        }

       

    }
}