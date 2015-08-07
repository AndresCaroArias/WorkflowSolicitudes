
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegAuditoria
    {
        public NegAuditoria() { }


        public List<Auditoria> select_All_Auditoria(String strRutUsuario, DateTime dtmFechaDesde, DateTime dtmFechaHasta, string strIP, string strDispositivo)
        {

            DatosAuditoria ConsultaLogs = new DatosAuditoria();
            return ConsultaLogs.select_all_Auditoria(strRutUsuario, dtmFechaDesde, dtmFechaHasta, strIP, strDispositivo);
        }


        public int InsertaAuditoria(String StrRutUsuario, String StrModulo, String StrAccion, String StrObservacion)
        {

            Funciones logs = new Funciones();
            DatosAuditoria insertaLog = new DatosAuditoria();

            String StrIP = logs.GetIpAddress();
            String StrNombreMaquina = logs.GetCompCode();
            String StrMacAddress = logs.GetMACAddress();
            String StrDispositivo = String.Empty;

            HttpContext context = HttpContext.Current;

            if (context.Request.Browser.IsMobileDevice)
            {
                StrDispositivo = "SMARTPHONE O TABLET";
            }
            else
            {
                StrDispositivo = "COMPUTADOR";
            }

            return insertaLog.InsertarAuditoria(StrRutUsuario, StrIP, StrModulo, StrAccion, StrObservacion, StrDispositivo, StrNombreMaquina, StrMacAddress);







        }


        public List<Auditoria> obtenerDispositivo()
        {
            DatosAuditoria DatAut = new DatosAuditoria();
            return DatAut.select_all_Dispositivo();

        }


    }
}