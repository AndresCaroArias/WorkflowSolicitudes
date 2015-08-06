using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;

using System.Data;
using WorkflowSolicitudes.Entidades;
using System.Data.SqlClient;

namespace WorkflowSolicitudes.Datos
{
    public class DatosFlujoSolicitud
    {
        public DatosFlujoSolicitud() 
        { }

        
        public string select_glosaActividad(int intSecuencia, int intCodTipoSolicitud)
        {
            string StrGlosaActividad = String.Empty;

            string StoredProcedure = "sp_get_Consulta_ByCodtipoSolSecuencia_FlujoSolicitud";
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
                    param.ParameterName = "CODTIPOSOLICITUD";
                    param.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(param);


                    DbParameter param1 = cmd.CreateParameter();
                    param1.DbType = DbType.String;
                    param1.ParameterName = "SECUENCIA";
                    param1.Value = intSecuencia ;
                    cmd.Parameters.Add(param1);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            StrGlosaActividad = (string)dr["DESCRIPCION"];
                                                 
                        }
                    }
                }
            }
            return StrGlosaActividad; 
           
        }

       



        public List<FlujoSolicitud> select_All_GetFlujo(int intCodTipoSolicitud)
        {
            List<FlujoSolicitud> LstFlujoSolicitud = new List<FlujoSolicitud>();
                                      
            string StoredProcedure = "sp_Get_Consulta_ByCodtipoSol_flujosolicitud";
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
                    param.ParameterName = "CODTIPOSOLICITUD";
                    param.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(param);

                    
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstFlujoSolicitud.Add(
                                      new FlujoSolicitud((int)dr["SECUENCIA"],
                                                  (string)dr["DESCRIPCION"],
                                                  (int)dr["CODUNIDAD"],
                                                  (string)dr["DESCUNIDAD"],
                                                  (string)dr["APROBADOR"],
                                                  (String)dr["BIFURCACION"],
                                                  (int)dr["CODTIPOSOLICITUD"],
                                                  (int)dr["CODACTIVIDAD"],
                                                  Convert.ToString(dr["SI"] is DBNull ? null : dr["SI"]),
                                                  Convert.ToString(dr["NO"] is DBNull ? null : dr["NO"])                                                                                          
                                                  ));
                        }
                    }
                }
             }
            return LstFlujoSolicitud;
        }

        public List<FlujoSolicitud> select_All_GetUsuario(string strRutUsuario)
        {
            List<FlujoSolicitud> LstObtenerUsuario = new List<FlujoSolicitud>();

            string StoredProcedure = "sp_getDatUsuario";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "RUTUSUARIO";
                    param.Value = strRutUsuario;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstObtenerUsuario.Add(
                                      new FlujoSolicitud((string)dr["RUTUSUARIO"],
                                                  (string)dr["NOMBRE"],
                                                  (string)dr["APELLIDO"],
                                                  (string)dr["EMAILUSUARIO"]));
                        }
                    }
                }
            }
            return LstObtenerUsuario;
        }

        public int ActualizarFlujoSolicitud(int SECUENCIA, int CODTIPOSOLICITUD, int CODACTIVIDAD, int CODUNIDAD, int APROBADOR, int BIFURCACION, string SECUENCIASI, string SECUENCIANO)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramInsertSecuencia = Conexion.dpf.CreateParameter();
            paramInsertSecuencia.Value = SECUENCIA;
            paramInsertSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramInsertSecuencia);

            DbParameter paramInsertCodTipSol = Conexion.dpf.CreateParameter();
            paramInsertCodTipSol.Value = CODTIPOSOLICITUD;
            paramInsertCodTipSol.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramInsertCodTipSol);

            DbParameter paramInsertCodActividad = Conexion.dpf.CreateParameter();
            paramInsertCodActividad.Value = CODACTIVIDAD;
            paramInsertCodActividad.ParameterName = "CODACTIVIDAD";
            parametros.Add(paramInsertCodActividad);

            DbParameter paramInsertRutUsuario = Conexion.dpf.CreateParameter();
            paramInsertRutUsuario.Value = CODUNIDAD;
            paramInsertRutUsuario.ParameterName = "CODUNIDAD";
            parametros.Add(paramInsertRutUsuario);

            DbParameter paramInsertAprobador = Conexion.dpf.CreateParameter();
            paramInsertAprobador.Value = APROBADOR;
            paramInsertAprobador.ParameterName = "APROBADOR";
            parametros.Add(paramInsertAprobador);

            DbParameter paramInsertBifurcacion = Conexion.dpf.CreateParameter();
            paramInsertBifurcacion.Value = BIFURCACION;
            paramInsertBifurcacion.ParameterName = "BIFURCACION";
            parametros.Add(paramInsertBifurcacion);

            DbParameter paramInsertSecuenciaSi = Conexion.dpf.CreateParameter();
            paramInsertSecuenciaSi.Value = SECUENCIASI;
            paramInsertSecuenciaSi.ParameterName = "SECUENCIASI";
            parametros.Add(paramInsertSecuenciaSi);

            DbParameter paramInsertSecuenciaNo = Conexion.dpf.CreateParameter();
            paramInsertSecuenciaNo.Value = SECUENCIANO;
            paramInsertSecuenciaNo.ParameterName = "SECUENCIANO";
            parametros.Add(paramInsertSecuenciaNo);

            return Conexion.ejecutaNonQuery("sp_Set_Actualizar_flujosolicitud", parametros);
        }

        public int InsertarFlujoSolicitud(int SECUENCIA, int CODTIPOSOLICITUD, int CODACTIVIDAD, int  CODUNIDAD, int APROBADOR, int BIFURCACION, string SECUENCIASI, string SECUENCIANO)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramInsertSecuencia = Conexion.dpf.CreateParameter();
            paramInsertSecuencia.Value = SECUENCIA;
            paramInsertSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramInsertSecuencia);

            DbParameter paramInsertCodTipSol = Conexion.dpf.CreateParameter();
            paramInsertCodTipSol.Value = CODTIPOSOLICITUD;
            paramInsertCodTipSol.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramInsertCodTipSol);

            DbParameter paramInsertCodActividad = Conexion.dpf.CreateParameter();
            paramInsertCodActividad.Value = CODACTIVIDAD;
            paramInsertCodActividad.ParameterName = "CODACTIVIDAD";
            parametros.Add(paramInsertCodActividad);

            DbParameter paramInsertRutUsuario = Conexion.dpf.CreateParameter();
            paramInsertRutUsuario.Value = CODUNIDAD;
            paramInsertRutUsuario.ParameterName = "CODUNIDAD";
            parametros.Add(paramInsertRutUsuario);

            DbParameter paramInsertAprobador = Conexion.dpf.CreateParameter();
            paramInsertAprobador.Value = APROBADOR;
            paramInsertAprobador.ParameterName = "APROBADOR";
            parametros.Add(paramInsertAprobador);

            DbParameter paramInsertBifurcacion = Conexion.dpf.CreateParameter();
            paramInsertBifurcacion.Value = BIFURCACION;
            paramInsertBifurcacion.ParameterName = "BIFURCACION";
            parametros.Add(paramInsertBifurcacion);

            DbParameter paramInsertSecuenciaSi = Conexion.dpf.CreateParameter();
            paramInsertSecuenciaSi.Value = SECUENCIASI;
            paramInsertSecuenciaSi.ParameterName = "SECUENCIASI";
            parametros.Add(paramInsertSecuenciaSi);

            DbParameter paramInsertSecuenciaNo = Conexion.dpf.CreateParameter();
            paramInsertSecuenciaNo.Value = SECUENCIANO;
            paramInsertSecuenciaNo.ParameterName = "SECUENCIANO";
            parametros.Add(paramInsertSecuenciaNo);


            return Conexion.ejecutaNonQuery("sp_Set_Inserta_flujosolicitud", parametros);
        }


        public List<FlujoSolicitud> ConsultaActividadDelFlujo(int intCodTipoSolicitud, int intSecuencia)
        {
            List<FlujoSolicitud> LstUsuario_Secuencia = new List<FlujoSolicitud>();

            string StoredProcedure = "sp_Get_Consulta_ByCodTipoSolSec_FlujoSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramCodTipSol = cmd.CreateParameter();
                    paramCodTipSol.DbType = DbType.Int32;
                    paramCodTipSol.ParameterName = "CODTIPOSOLICITUD";
                    paramCodTipSol.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramCodTipSol);

                    DbParameter paramSecuencia = cmd.CreateParameter();
                    paramSecuencia.DbType = DbType.Int32;
                    paramSecuencia.ParameterName = "@SECUENCIA";
                    paramSecuencia.Value = intSecuencia;
                    cmd.Parameters.Add(paramSecuencia);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstUsuario_Secuencia.Add(
                                      new FlujoSolicitud((int)dr["SECUENCIA"],
                                                         (int)dr["CODACTIVIDAD"],
                                                         (int)dr["CODUNIDAD"],
                                                         (int)dr["APROBADOR"],
                                                         (int)dr["BIFURCACION"],
                                                         (string)dr["SI"],
                                                         (string)dr["NO"]
                                                         
                                                         ));

                        }
                    }
                }
            }
            return LstUsuario_Secuencia;
        }




        public List<FlujoSolicitud> select_Usuario_secuencia(int intCodTipoSolicitud, string strRutUsuario)
        {
            List<FlujoSolicitud> LstUsuario_Secuencia = new List<FlujoSolicitud>();

            string StoredProcedure = "sp_getDatUsuario_secuencia";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramCodTipSol = cmd.CreateParameter();
                    paramCodTipSol.DbType = DbType.Int32;
                    paramCodTipSol.ParameterName = "CODTIPOSOLICITUD";
                    paramCodTipSol.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramCodTipSol);

                    DbParameter paramSecuencia = cmd.CreateParameter();
                    paramSecuencia.DbType = DbType.Int32;
                    paramSecuencia.ParameterName = "@SECUENCIA";
                    paramSecuencia.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramSecuencia);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstUsuario_Secuencia.Add(
                                      new FlujoSolicitud((string)dr["RUTUSUARIO"],
                                                  (string)dr["NOMBRE"],
                                                  (string)dr["APELLIDO"],
                                                  (string)dr["EMAILUSUARIO"],
                                                  (int)dr["APROBADOR"]));
                                                  
                        }
                    }
                }
            }
            return LstUsuario_Secuencia;
        }

        public int UltimaSecuenciaFluSolicitud(int cod_tipo_solicitud)
        {

            using (SqlConnection conexion = new SqlConnection(Conexion.constr))
            {
                SqlCommand cmd = new SqlCommand("sp_get_MaxSecuencia_FlujoSolicitud", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CODTIPOSOLICITUD", cod_tipo_solicitud));

                SqlParameter ParamintUltimaSecuencia = new SqlParameter("@SECUENCIA", 0);
                ParamintUltimaSecuencia.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ParamintUltimaSecuencia);

                conexion.Open();
                cmd.ExecuteNonQuery();
                int intSecuencia = Int32.Parse(cmd.Parameters["@SECUENCIA"].Value.ToString());
                
                conexion.Close();

                return intSecuencia;

            }
        }

        public int EliminaFlujoSolicitud(int intCodTipoSolicitud , int intSecuencia)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntCodTipoSolicitud = Conexion.dpf.CreateParameter();
            paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
            paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramIntCodTipoSolicitud);


            DbParameter paramIntSecuencia = Conexion.dpf.CreateParameter();
            paramIntSecuencia.Value = intSecuencia;
            paramIntSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramIntSecuencia);

            return Conexion.ejecutaNonQuery("sp_get_delete_FlujoSolicitud", parametros);
        }

        public int CambiaEstado(int intCodTipoSolicitud, int intSecuencia)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntCodTipoSolicitud = Conexion.dpf.CreateParameter();
            paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
            paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramIntCodTipoSolicitud);


            DbParameter paramIntSecuencia = Conexion.dpf.CreateParameter();
            paramIntSecuencia.Value = intSecuencia;
            paramIntSecuencia.ParameterName = "SECUENCIA";
            parametros.Add(paramIntSecuencia);

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_cambioEstado_FlujoSolicitud", parametros);
        }




        public int BuscoCodActividad(int intCodTipoSolicitud, int intSecuencia)
        {

            int intCodActividad = 0;
            string StoredProcedure = "sp_Get_CpnsultaCodActividad_FlujoSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIntCodTipoSolicitud = cmd.CreateParameter();
                    paramIntCodTipoSolicitud.DbType = DbType.Int32;
                    paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
                    paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramIntCodTipoSolicitud);

                    DbParameter paramIntSecuencia = cmd.CreateParameter();
                    paramIntSecuencia.DbType = DbType.Int32;
                    paramIntSecuencia.ParameterName = "SECUENCIA";
                    paramIntSecuencia.Value = intSecuencia;
                    cmd.Parameters.Add(paramIntSecuencia);

                    
                    con.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intCodActividad = (int)dr["CODACTIVIDAD"];

                        }

                    }

                    return intCodActividad;
                }
            }
        }

   



        public int BuscoExisteActividad(int intCodActividad)
        {
            int intExiste; 

            string StoredProcedure = "sp_Get_Existe_ByActividad_FlujoSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;


                    DbParameter paramintCodActividad = cmd.CreateParameter();
                    paramintCodActividad.DbType = DbType.Int32;
                    paramintCodActividad.ParameterName = "CODACTIVIDAD";
                    paramintCodActividad.Value = intCodActividad;
                    cmd.Parameters.Add(paramintCodActividad);


                    con.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intExiste = (int)dr["CANTIDAD"];

                        }

                    }

                    return intCodActividad;
                }
            }
        }


        public int EsAprobadoResponsable(int intSecuencia, int intCodTipoSolicitud,  string StrRutUsuario)
        {

            int intAprobador = 0;
            string StoredProcedure = "sp_get_aprobador_flujoSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIntSecuencia = cmd.CreateParameter();
                    paramIntSecuencia.DbType = DbType.Int32;
                    paramIntSecuencia.ParameterName = "SECUENCIA";
                    paramIntSecuencia.Value = intSecuencia;
                    cmd.Parameters.Add(paramIntSecuencia);

                    DbParameter paramIntCodTipoSolicitud = cmd.CreateParameter();
                    paramIntCodTipoSolicitud.DbType = DbType.Int32;
                    paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
                    paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramIntCodTipoSolicitud);

                    DbParameter paramStrRutUsuario = cmd.CreateParameter();
                    paramStrRutUsuario.DbType = DbType.String;
                    paramStrRutUsuario.ParameterName = "RUTUSUARIO";
                    paramStrRutUsuario.Value = StrRutUsuario;
                    cmd.Parameters.Add(paramStrRutUsuario);


                    con.Open();


                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intAprobador = (int)dr["APROBADOR"];

                        }

                    }

                    return intAprobador;
                }
            }
        }

    }
}