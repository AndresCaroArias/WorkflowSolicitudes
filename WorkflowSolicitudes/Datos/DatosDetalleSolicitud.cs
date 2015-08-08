using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Configuration;
using WorkflowSolicitudes.Entidades;
using System.Data;
using System.Text;

namespace WorkflowSolicitudes.Datos
{
    public class DatosDetalleSolicitud
    {
        public DatosDetalleSolicitud(){}

       

        public int Resolutor(int intFolioSolicitud, int intSecuencia, int intCodTipoSolicitud, int intCodEstado, string strGlosaDetalleSol, int intAprobador)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntFolioSolicitud = Conexion.dpf.CreateParameter();
            paramIntFolioSolicitud.DbType = DbType.Int32;
            paramIntFolioSolicitud.Value = intFolioSolicitud;
            paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
            parametros.Add(paramIntFolioSolicitud);


            DbParameter paramIntSecuencia = Conexion.dpf.CreateParameter();
            paramIntSecuencia.DbType = DbType.Int32;
            paramIntSecuencia.Value = intSecuencia;
            paramIntSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramIntSecuencia);

            DbParameter paramIntCodTipoSolicitud = Conexion.dpf.CreateParameter();
            paramIntCodTipoSolicitud.DbType = DbType.Int32;
            paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
            paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramIntCodTipoSolicitud);

            DbParameter paramIntCodEstadoSol = Conexion.dpf.CreateParameter();
            paramIntCodEstadoSol.DbType = DbType.Int32;
            paramIntCodEstadoSol.Value = intCodEstado;
            paramIntCodEstadoSol.ParameterName = "CODESTADOSOL";
            parametros.Add(paramIntCodEstadoSol);

            DbParameter paramStrGlosaDetalleSol = Conexion.dpf.CreateParameter();
            paramStrGlosaDetalleSol.DbType = DbType.String;
            paramStrGlosaDetalleSol.Value = strGlosaDetalleSol;
            paramStrGlosaDetalleSol.ParameterName = "GLOSADETALLESOL";
            parametros.Add(paramStrGlosaDetalleSol);

            DbParameter paramIntAprobador = Conexion.dpf.CreateParameter();
            paramIntAprobador.DbType = DbType.Int32;
            paramIntAprobador.Value = intAprobador;
            paramIntAprobador.ParameterName = "APROBADOR";
            parametros.Add(paramIntAprobador);
            
            return Conexion.ejecutaNonQuery("sp_actualiza_flujoActividad", parametros);
        }

        public int ElFlujoCreaSiguienteActividad(int intFolioSolicitud, int intSecuencia, int intCodTipoSolicitud, int intCodEstado, string strGlosaDetalleSol, int intCodActividad, int intCodUnidad, int intSiguienteSecuencia)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntFolioSolicitud = Conexion.dpf.CreateParameter();
            paramIntFolioSolicitud.DbType = DbType.Int32;
            paramIntFolioSolicitud.Value = intFolioSolicitud;
            paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
            parametros.Add(paramIntFolioSolicitud);

            DbParameter paramIntSecuencia = Conexion.dpf.CreateParameter();
            paramIntSecuencia.DbType = DbType.Int32;
            paramIntSecuencia.Value = intSecuencia;
            paramIntSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramIntSecuencia);

            DbParameter paramIntCodTipoSolicitud = Conexion.dpf.CreateParameter();
            paramIntCodTipoSolicitud.DbType = DbType.Int32;
            paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
            paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramIntCodTipoSolicitud);

            DbParameter paramIntCodEstadoSol = Conexion.dpf.CreateParameter();
            paramIntCodEstadoSol.DbType = DbType.Int32;
            paramIntCodEstadoSol.Value = intCodEstado;
            paramIntCodEstadoSol.ParameterName = "CODESTADOSOL";
            parametros.Add(paramIntCodEstadoSol);

            DbParameter paramStrGlosaDetalleSol = Conexion.dpf.CreateParameter();
            paramStrGlosaDetalleSol.DbType = DbType.String;
            paramStrGlosaDetalleSol.Value = strGlosaDetalleSol;
            paramStrGlosaDetalleSol.ParameterName = "GLOSADETALLESOL";
            parametros.Add(paramStrGlosaDetalleSol);

            DbParameter paramintCodActividad = Conexion.dpf.CreateParameter();
            paramintCodActividad.DbType = DbType.Int32;
            paramintCodActividad.Value = intCodActividad;
            paramintCodActividad.ParameterName = "CODACTIVIDAD";
            parametros.Add(paramintCodActividad);

            DbParameter paramintCodUnidad = Conexion.dpf.CreateParameter();
            paramintCodUnidad.DbType = DbType.Int32;
            paramintCodUnidad.Value = intCodUnidad;
            paramintCodUnidad.ParameterName = "CODUNIDAD";
            parametros.Add(paramintCodUnidad);

            DbParameter paramstrSiguienteSecuencia = Conexion.dpf.CreateParameter();
            paramstrSiguienteSecuencia.DbType = DbType.Int32;
            paramstrSiguienteSecuencia.Value = intSiguienteSecuencia;
            paramstrSiguienteSecuencia.ParameterName = "SIGUIENTESECUENCIA";
            parametros.Add(paramstrSiguienteSecuencia);

            

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_ByUnidad_DetalleSolicitud", parametros);
        }

        public int CierraFlujo(int intFolioSolicitud, int intSecuencia, int intCodEstadSol, int intCodEstadoAct, string strGlosaDetalleSol)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntFolioSolicitud = Conexion.dpf.CreateParameter();
            paramIntFolioSolicitud.DbType = DbType.Int32;
            paramIntFolioSolicitud.Value = intFolioSolicitud;
            paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
            parametros.Add(paramIntFolioSolicitud);

            DbParameter paramIntSecuencia = Conexion.dpf.CreateParameter();
            paramIntSecuencia.DbType = DbType.Int32;
            paramIntSecuencia.Value = intSecuencia;
            paramIntSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramIntSecuencia);

            DbParameter paramIntCodEstadoSol= Conexion.dpf.CreateParameter();
            paramIntCodEstadoSol.DbType = DbType.Int32;
            paramIntCodEstadoSol.Value = intCodEstadSol;
            paramIntCodEstadoSol.ParameterName = "CODESTADOSOL";
            parametros.Add(paramIntCodEstadoSol);

            DbParameter paramIntCodEstadoAct = Conexion.dpf.CreateParameter();
            paramIntCodEstadoAct.DbType = DbType.Int32;
            paramIntCodEstadoAct.Value = intCodEstadoAct;
            paramIntCodEstadoAct.ParameterName = "@CODESTADOACT";
            parametros.Add(paramIntCodEstadoAct);

            DbParameter paramStrGlosaDetalleSol = Conexion.dpf.CreateParameter();
            paramStrGlosaDetalleSol.DbType = DbType.String;
            paramStrGlosaDetalleSol.Value = strGlosaDetalleSol;
            paramStrGlosaDetalleSol.ParameterName = "GLOSADETALLESOL";
            parametros.Add(paramStrGlosaDetalleSol);


            return Conexion.ejecutaNonQuery("sp_Get_Actualiza_ByCierraFlujo_DetalleSolicitud", parametros);
        }


        public int ActualizarFechaTomaActividad(int inFolioSolicitud, int intSecuencia , string strRutUsuario)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntFolioSolicitud = Conexion.dpf.CreateParameter();
            paramIntFolioSolicitud.DbType = DbType.Int32;
            paramIntFolioSolicitud.Value = inFolioSolicitud;
            paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
            parametros.Add(paramIntFolioSolicitud);

            DbParameter paramIntSecuencia = Conexion.dpf.CreateParameter();
            paramIntSecuencia.DbType = DbType.Int32;
            paramIntSecuencia.Value = intSecuencia;
            paramIntSecuencia.ParameterName = "SECUENCIA ";
            parametros.Add(paramIntSecuencia);

            DbParameter paramStrRutUsuario = Conexion.dpf.CreateParameter();
            paramStrRutUsuario.DbType = DbType.String;
            paramStrRutUsuario.Value = strRutUsuario;
            paramStrRutUsuario.ParameterName = "RUTUSUARIO ";
            parametros.Add(paramStrRutUsuario);


            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_ByFechaTomaActividad_DetalleSolicitud", parametros);
        }



        public int EstaTomadaLaSolicitud(int intFolioSolicitud)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_get_EstaTomada_Solicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIntFolioSolicitud = cmd.CreateParameter();
                    paramIntFolioSolicitud.DbType = DbType.Int32;
                    paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
                    paramIntFolioSolicitud.Value = intFolioSolicitud;
                    cmd.Parameters.Add(paramIntFolioSolicitud);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intCantidad = (int)dr["CANTIDAD"];

                        }

                    }
                    return intCantidad;
                }
            }
        }


        public List<DetalleSolicitud> select_Dinamica_DetalleSolicitudes(int folio)
        {
            int intFolioSolicitudes;
            int intSecuencia;
            int intCodTipoSolicitud;
            int intCodActividad;
            string strGlosaActividad;
            int intCodEstado;
            string strGlosaEstado;
            string strRutUsuario;
            string strnombreAux;
            string strApellidoAux;
            DateTime dtmFechaVencSol;
            int intDiasDeRetraso;
            DateTime dtmFechaResolucion;
            DateTime dtmFecharecep;
            DateTime dtmFechaEjecutaActividad;
            string StrGlosaDetalleSolictud;
            int intCodUnidad;
            string strDescUnidad;


            List<DetalleSolicitud> LstDetalleSolicitud = new List<DetalleSolicitud>();
            string StoredProcedure = "sp_Get_Consulta_ByDinamica_DetalleSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "FOLIOSOLICITUD";
                    param.Value = folio;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes = (int)dr["FOLIOSOLICITUD"];
                            intSecuencia = (int)dr["SECUENCIA"];
                            intCodTipoSolicitud = (int)dr["CODTIPOSOLICITUD"];
                            intCodActividad = (int)dr["CODACTIVIDAD"];
                            strGlosaActividad = (string)dr["DESCRIPCION"];
                            intCodEstado = (int)dr["CODESTADO"];
                            strGlosaEstado = (string)dr["DESCESTADO"];
                            strRutUsuario = (string)dr["RUTUSUARIO"];
                            strnombreAux = (string)dr["NOMBRE"];
                            strApellidoAux = (string)dr["APELLIDO"];
                            dtmFechaVencSol = Convert.ToDateTime(dr["FECHAVENCSOL"] is DBNull ? null : dr["FECHAVENCSOL"]);
                            intDiasDeRetraso = (int)dr["DIASATRASO"];
                            dtmFechaResolucion = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            dtmFecharecep = Convert.ToDateTime(dr["FECHARECEP"] is DBNull ? null : dr["FECHARECEP"]);
                            dtmFechaEjecutaActividad = Convert.ToDateTime(dr["FECHAEJECACTIVIDAD"] is DBNull ? null : dr["FECHAEJECACTIVIDAD"]);
                            StrGlosaDetalleSolictud = Convert.ToString(dr["GLOSADETALLESOL"] is DBNull ? null : dr["GLOSADETALLESOL"]);
                            intCodUnidad = (int)dr["CODUNIDAD"];
                            strDescUnidad = Convert.ToString(dr["DESCUNIDAD"] is DBNull ? null : dr["DESCUNIDAD"]);



                            StringBuilder strnombre = new StringBuilder();

                            strnombre.Append(strnombreAux);
                            strnombre.Append(" ");
                            strnombre.Append(strApellidoAux);



                            LstDetalleSolicitud.Add(new DetalleSolicitud(intFolioSolicitudes,
                                                                         intSecuencia,
                                                                         intCodTipoSolicitud,
                                                                         intCodActividad,
                                                                         strGlosaActividad,
                                                                         intCodEstado,
                                                                         strGlosaEstado,
                                                                         strRutUsuario,
                                                                         strnombre.ToString(),
                                                                         dtmFechaVencSol,
                                                                         intDiasDeRetraso,
                                                                         dtmFecharecep,
                                                                         dtmFechaEjecutaActividad,
                                                                         dtmFechaResolucion,
                                                                         StrGlosaDetalleSolictud
                                                                         ));

                        }
                    }
                }
            }
            return LstDetalleSolicitud;

        }


        public List<DetalleSolicitud> select_all_EstadosDetSol()
        {
            List<DetalleSolicitud> LstDetalleSolicitud = new List<DetalleSolicitud>();

            string StoredProcedure = "sp_Get_Consulta_ByEstado_DetalleSol";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstDetalleSolicitud.Add(new DetalleSolicitud((int)dr["CODESTADO"],
                                                                         (string)dr["ESTADO"]));

                        }
                    }

                    return LstDetalleSolicitud;
                }

            }

        }


        public List<DetalleSolicitud> select_All_DetalleSolicitudes(int folio)
        {
             int    intFolioSolicitudes;        
             int    intSecuencia;        
             int    intCodTipoSolicitud;        
             int    intCodActividad;
             string strGlosaActividad;
             int    intCodEstado;
             string strGlosaEstado;
             string strRutUsuario;
             string strnombreAux;
             string strApellidoAux;
             DateTime dtmFechaVencSol;        
             int intDiasDeRetraso;
             DateTime dtmFechaResolucion;
             DateTime dtmFecharecep;
             DateTime dtmFechaEjecutaActividad;
             string   StrGlosaDetalleSolictud;
             int intCodUnidad;
             string strDescUnidad;
             int intEtapa;

            List<DetalleSolicitud> LstDetalleSolicitud = new List<DetalleSolicitud>();
            string StoredProcedure = "sp_Get_Consulta_ByFoliosolicitud_Detallesolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "FOLIOSOLICITUD";
                    param.Value = folio;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes      = (int)dr["FOLIOSOLICITUD"];
                            intSecuencia             = (int)dr["SECUENCIA"];
                            intCodTipoSolicitud      = (int)dr["CODTIPOSOLICITUD"];
                            intCodActividad          = (int)dr["CODACTIVIDAD"];
                            strGlosaActividad        = (string)dr["DESCRIPCION"];
                            intCodEstado             = (int)dr["CODESTADO"];
                            strGlosaEstado           = (string)dr["DESCESTADO"];
                            strRutUsuario            = Convert.ToString(dr["RUTUSUARIO"] is DBNull ? null : dr["RUTUSUARIO"]);
                            strnombreAux             = Convert.ToString(dr["NOMBRE"] is DBNull ? null : dr["NOMBRE"]);
                            strApellidoAux           = Convert.ToString(dr["APELLIDO"] is DBNull ? null : dr["APELLIDO"]);
                            dtmFechaVencSol          = Convert.ToDateTime(dr["FECHAVENCSOL"] is DBNull ? null : dr["FECHAVENCSOL"]);
                            intDiasDeRetraso         = (int)dr["DIASATRASO"];
                            dtmFechaResolucion       = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            dtmFecharecep            = Convert.ToDateTime(dr["FECHARECEP"] is DBNull ? null : dr["FECHARECEP"]);
                            dtmFechaEjecutaActividad = Convert.ToDateTime(dr["FECHAEJECACTIVIDAD"] is DBNull ? null : dr["FECHAEJECACTIVIDAD"]);
                            StrGlosaDetalleSolictud = Convert.ToString(dr["GLOSADETALLESOL"] is DBNull ? null : dr["GLOSADETALLESOL"]);
                            intCodUnidad            = (int)dr["CODUNIDAD"];
                            strDescUnidad           = Convert.ToString(dr["DESCUNIDAD"] is DBNull ? null : dr["DESCUNIDAD"]);
                            intEtapa                = (int)dr["ETAPA"];                  

                            StringBuilder strnombre = new StringBuilder();

                            strnombre.Append(strnombreAux);
                            strnombre.Append(" ");
                            strnombre.Append(strApellidoAux);


                            
                            LstDetalleSolicitud.Add(new DetalleSolicitud(intFolioSolicitudes,
                                                                         intSecuencia,
                                                                         intCodTipoSolicitud,
                                                                         intCodActividad,
                                                                         strGlosaActividad,
                                                                         intCodEstado,
                                                                         strGlosaEstado,                                                                         
                                                                         strRutUsuario,
                                                                         strnombre.ToString(),
                                                                         dtmFechaVencSol,
                                                                         intDiasDeRetraso,
                                                                         dtmFecharecep,                                                                                                                                                  
                                                                         dtmFechaEjecutaActividad,
                                                                         dtmFechaResolucion,
                                                                         StrGlosaDetalleSolictud,
                                                                         intCodUnidad,
                                                                         strDescUnidad,
                                                                         intEtapa
                                                                         ));

                        }
                    }
                }
            }
            return LstDetalleSolicitud;

        }

        public List<DetalleSolicitud> HistorialDetalleSolicitudes(int folio)
        {
            int intFolioSolicitudes;
            int intSecuencia;
            string strnombre;
            string strApellido;
            DateTime dtmFechaResolucion;
            string strGlosaDetalleSolictud;

            List<DetalleSolicitud> LstHistorialDetalleSolicitud = new List<DetalleSolicitud>();
            string StoredProcedure = "sp_Get_Consulta_ByFolio_DetalleSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "FOLIO";
                    param.Value = folio;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes     = (int)dr["FOLIOSOLICITUD"];
                            intSecuencia            = (int)dr["SECUENCIA"];
                            strnombre               = Convert.ToString(dr["NOMBRE"] is DBNull ? null : dr["NOMBRE"]);
                            strApellido             = Convert.ToString(dr["APELLIDO"] is DBNull ? null : dr["APELLIDO"]);
                            dtmFechaResolucion      = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            strGlosaDetalleSolictud = Convert.ToString(dr["GLOSADETALLESOL"] is DBNull ? null : dr["GLOSADETALLESOL"]);

                            LstHistorialDetalleSolicitud.Add(new DetalleSolicitud(intFolioSolicitudes,
                                                                                  intSecuencia,
                                                                                  strnombre,
                                                                                  strApellido,
                                                                                  dtmFechaResolucion,
                                                                                  strGlosaDetalleSolictud));

                        }
                    }
                }
            }
            return LstHistorialDetalleSolicitud;
        }

        public List<DetalleSolicitud> ConsultaHistoriaActividadesResueltas(int folio)
        {
             int    intFolioSolicitudes;        
             int    intSecuencia;        
             int    intCodTipoSolicitud;        
             int    intCodActividad;
             string strGlosaActividad;
             int    intCodEstado;
             string strGlosaEstado;
             string strRutUsuario;
             string strnombreAux;
             string strApellidoAux;
             DateTime dtmFechaVencSol;        
             int intDiasDeRetraso;
             DateTime dtmFechaResolucion;
             DateTime dtmFecharecep;
             DateTime dtmFechaEjecutaActividad;
             string   StrGlosaDetalleSolictud;
             int intCodUnidad;
             string strDescUnidad;
			 int intEtapa;

            List<DetalleSolicitud> LstDetalleSolicitud = new List<DetalleSolicitud>();
            string StoredProcedure = "sp_Get_Consulta_ByFolioHistoria_Detallesolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "FOLIOSOLICITUD";
                    param.Value = folio;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes      = (int)dr["FOLIOSOLICITUD"];
                            intSecuencia             = (int)dr["SECUENCIA"];
                            intCodTipoSolicitud      = (int)dr["CODTIPOSOLICITUD"];
                            intCodActividad          = (int)dr["CODACTIVIDAD"];
                            strGlosaActividad        = (string)dr["DESCRIPCION"];
                            intCodEstado             = (int)dr["CODESTADO"];
                            strGlosaEstado           = (string)dr["DESCESTADO"];
                            strRutUsuario            = Convert.ToString(dr["RUTUSUARIO"] is DBNull ? null : dr["RUTUSUARIO"]);
                            strnombreAux             = Convert.ToString(dr["NOMBRE"] is DBNull ? null : dr["NOMBRE"]);
                            strApellidoAux           = Convert.ToString(dr["APELLIDO"] is DBNull ? null : dr["APELLIDO"]);
                            dtmFechaVencSol          = Convert.ToDateTime(dr["FECHAVENCSOL"] is DBNull ? null : dr["FECHAVENCSOL"]);
                            intDiasDeRetraso         = (int)dr["DIASATRASO"];
                            dtmFechaResolucion       = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            dtmFecharecep            = Convert.ToDateTime(dr["FECHARECEP"] is DBNull ? null : dr["FECHARECEP"]);
                            dtmFechaEjecutaActividad = Convert.ToDateTime(dr["FECHAEJECACTIVIDAD"] is DBNull ? null : dr["FECHAEJECACTIVIDAD"]);
                            StrGlosaDetalleSolictud = Convert.ToString(dr["GLOSADETALLESOL"] is DBNull ? null : dr["GLOSADETALLESOL"]);
                            intCodUnidad            = (int)dr["CODUNIDAD"];
                            strDescUnidad           = Convert.ToString(dr["DESCUNIDAD"] is DBNull ? null : dr["DESCUNIDAD"]);
                            intEtapa = (int)dr["ETAPA"];  

                            StringBuilder strnombre = new StringBuilder();

                            strnombre.Append(strnombreAux);
                            strnombre.Append(" ");
                            strnombre.Append(strApellidoAux);


                            
                            LstDetalleSolicitud.Add(new DetalleSolicitud(intFolioSolicitudes,
                                                                         intSecuencia,
                                                                         intCodTipoSolicitud,
                                                                         intCodActividad,
                                                                         strGlosaActividad,
                                                                         intCodEstado,
                                                                         strGlosaEstado,                                                                         
                                                                         strRutUsuario,
                                                                         strnombre.ToString(),
                                                                         dtmFechaVencSol,
                                                                         intDiasDeRetraso,
                                                                         dtmFecharecep,                                                                                                                                                  
                                                                         dtmFechaEjecutaActividad,
                                                                         dtmFechaResolucion,
                                                                         StrGlosaDetalleSolictud,
                                                                         intCodUnidad,
                                                                         strDescUnidad,
                                                                         intEtapa
                                                                         ));

                        }
                    }
                }
            }
            return LstDetalleSolicitud;

        }
          
    }




}