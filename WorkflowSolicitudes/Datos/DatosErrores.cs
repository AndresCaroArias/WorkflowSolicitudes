using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

namespace WorkflowSolicitudes.Datos
{
    public class DatosErrores
    {
        public int InsertarError(String RUTUSARIO, String NOMBREPROCEDIMIENTO, String CODERROR, String GLOSAERROR, String OBSERVACION, String METODO)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramRutUsuario = Conexion.dpf.CreateParameter();
            paramRutUsuario.Value = RUTUSARIO;
            paramRutUsuario.ParameterName = "RUTUSARIO";
            parametros.Add(paramRutUsuario);

            DbParameter paramNombreProcedimiento = Conexion.dpf.CreateParameter();
            paramNombreProcedimiento.Value = NOMBREPROCEDIMIENTO;
            paramNombreProcedimiento.ParameterName = "NOMBREPROCEDIMIENTO";
            parametros.Add(paramNombreProcedimiento);

            DbParameter paramCodError = Conexion.dpf.CreateParameter();
            paramCodError.Value = CODERROR;
            paramCodError.ParameterName = "CODERROR";
            parametros.Add(paramCodError);

            DbParameter paramGlosaError = Conexion.dpf.CreateParameter();
            paramGlosaError.Value = GLOSAERROR;
            paramGlosaError.ParameterName = "GLOSAERROR";
            parametros.Add(paramGlosaError);

            DbParameter paramObserbacion = Conexion.dpf.CreateParameter();
            paramObserbacion.Value = OBSERVACION;
            paramObserbacion.ParameterName = "OBSERVACION";
            parametros.Add(paramObserbacion);

            DbParameter paramMetodo = Conexion.dpf.CreateParameter();
            paramMetodo.Value = METODO;
            paramMetodo.ParameterName = "METODO";
            parametros.Add(paramMetodo);

            return Conexion.ejecutaNonQuery("[sp_Set_Inserta_Errores", parametros);
        }

    }
}