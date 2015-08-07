using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegTipoSolicitud
    {

        public NegTipoSolicitud() { }

        public int EliminarTipoSolicitud(int intCodTipoSolicitud)
        {
            return (new DatosTipoSolicitud()).EliminarTipoSolicitud(intCodTipoSolicitud);
        }

        public int AltaTipoSolicitud(string strDescripcionSolicitud, int intEstadoSolicitud, DateTime dtmFechaIncioSol, DateTime dtmFechaTerminoSol, int intCantMaxSolicitud, string strOrigenSolicitud, int intCantMaxDoc)
        {
            DatosTipoSolicitud DatAut = new DatosTipoSolicitud();

            return DatAut.InsertipoSolicitud(strDescripcionSolicitud, intEstadoSolicitud, dtmFechaIncioSol, dtmFechaTerminoSol, intCantMaxSolicitud, strOrigenSolicitud, intCantMaxDoc);
        }

        public int ActualizarTipoSolicitud(int intCodTipoSolicitud, string strDescripcionSolicitud, int intEstadoSolicitud, DateTime dtmFechaIncioSol, DateTime dtmFechaTerminoSol, int intCantMaxSolicitud, string strOrigenSolicitud, int intCantMaxDoc)
        {
            DatosTipoSolicitud ActTipSol = new DatosTipoSolicitud();
            return ActTipSol.ActualizarTipoSolicitud(intCodTipoSolicitud, strDescripcionSolicitud, intEstadoSolicitud, dtmFechaIncioSol, dtmFechaTerminoSol, intCantMaxSolicitud, strOrigenSolicitud, intCantMaxDoc);
        }

        public List<TipoSolicitud> ObtenerTodosLosTipoSolicitud()
        {
            DatosTipoSolicitud DatAut = new DatosTipoSolicitud();
            return DatAut.select_All_E_TipoSolicitud();
        }

        public List<TipoSolicitud> ObtenerTipoSolicitudesActivasExternas()
        {

            DatosTipoSolicitud DatoTipoSolicitud = new DatosTipoSolicitud();
            return DatoTipoSolicitud.select_All_TipoSolicitudExternas();


        }

        public List<TipoSolicitud> ObtenerTipoSolicitudesActivasInternas()
        {

            DatosTipoSolicitud DatoTipoSolicitud = new DatosTipoSolicitud();
            return DatoTipoSolicitud.select_All_TipoSolicitudInternas();


        }



        public TipoSolicitud ObtenerById(int intCodTipoSolicitud)
        {
            DatosTipoSolicitud DatAut = new DatosTipoSolicitud();
            return DatAut.select_TipoSolicitudbyId(intCodTipoSolicitud);
        }

        public int ExisteTipoFlujoSol(int intCodTipoSolicitud)
        {
            DatosTipoSolicitud ExiteTipoSolicitud = new DatosTipoSolicitud();
            return ExiteTipoSolicitud.select_Exite_FlujoTipoSolicitud(intCodTipoSolicitud);
        }

      

        public string ObtenerDescTipoSolicitud(int intCodTipoSolicitud)
        {
            DatosTipoSolicitud DatoTipoSolicitud = new DatosTipoSolicitud();
            return DatoTipoSolicitud.select_By_TipoSolicitud(intCodTipoSolicitud);
        }

        public int ObtenerCantMaxDocByTipoSolicitud(int intCodTipoSolicitud)
        {
            DatosTipoSolicitud CantMaxDoc = new DatosTipoSolicitud();
            return CantMaxDoc.select_CantMaxDoc_By_TipoSolicitud(intCodTipoSolicitud);
        }

    }


}