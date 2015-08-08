using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegErrores
    {
        public int InsertarError( string strRutUsuario, string strNombreProcedimiento, string strCodError, string strGlosaError, string strObservacion, string strMetodo)
       {
           DatosErrores InsertarErrores = new DatosErrores();
           return InsertarErrores.InsertarError(strRutUsuario,  strNombreProcedimiento,  strCodError,  strGlosaError,  strObservacion, strMetodo);
        }

    }
}