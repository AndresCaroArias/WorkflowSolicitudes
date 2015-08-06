using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using WorkflowSolicitudes.Entidades;
using System.Data;

namespace WorkflowSolicitudes.Datos
{
    public class DatosAuditoria
    {

        public DatosAuditoria() { }


        public int InsertarAuditoria(String RUTUSUARIO, String IP, String MODULO, String ACCION, String OBSERVACION, String DISPOSITIVO, String NOMBREMAQUINA, String MACADDRESS)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramRutUsuario = Conexion.dpf.CreateParameter();
            paramRutUsuario.Value = RUTUSUARIO;
            paramRutUsuario.ParameterName = "RUTUSUARIO";
            parametros.Add(paramRutUsuario);

            DbParameter paramIp = Conexion.dpf.CreateParameter();
            paramIp.Value = IP;
            paramIp.ParameterName = "IP";
            parametros.Add(paramIp);

            DbParameter paramModulo = Conexion.dpf.CreateParameter();
            paramModulo.Value = MODULO;
            paramModulo.ParameterName = "MODULO";
            parametros.Add(paramModulo);

            DbParameter paramAccion = Conexion.dpf.CreateParameter();
            paramAccion.Value = ACCION;
            paramAccion.ParameterName = "ACCION";
            parametros.Add(paramAccion);

            DbParameter paramObservacion = Conexion.dpf.CreateParameter();
            paramObservacion.Value = OBSERVACION;
            paramObservacion.ParameterName = "OBSERVACION";
            parametros.Add(paramObservacion);

            DbParameter paramDispositivo = Conexion.dpf.CreateParameter();
            paramDispositivo.Value = DISPOSITIVO;
            paramDispositivo.ParameterName = "DISPOSITIVO";
            parametros.Add(paramDispositivo);

            DbParameter paramMaquina = Conexion.dpf.CreateParameter();
            paramMaquina.Value = NOMBREMAQUINA;
            paramMaquina.ParameterName = "NOMBREMAQUINA";
            parametros.Add(paramMaquina);

            DbParameter paramMacAddress = Conexion.dpf.CreateParameter();
            paramMacAddress.Value = MACADDRESS;
            paramMacAddress.ParameterName = "MACADDRESS";
            parametros.Add(paramMacAddress);


            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Auditoria", parametros);
        }

        public List<Auditoria> select_all_Auditoria(String strRutUsuario, DateTime dtmFechaDesde, DateTime dtmFechaHasta, string strIP, string strDispositivo)
        {
            List<Auditoria> LstAuditoria = new List<Auditoria>();
            string StoredProcedure = "sp_Get_Consulta_ByDinamica_Auditoria";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramRutUsuario = cmd.CreateParameter();
                    paramRutUsuario.DbType = DbType.String;
                    paramRutUsuario.ParameterName = "RUTUSUARIO";
                    if (strRutUsuario.Equals(String.Empty) || strRutUsuario.Equals(DBNull.Value))
                    {
                        paramRutUsuario.Value = DBNull.Value;
                    }
                    else
                    {
                        paramRutUsuario.Value = strRutUsuario;
                    }
                    cmd.Parameters.Add(paramRutUsuario);

                    DbParameter paramFecha = cmd.CreateParameter();
                    paramFecha.DbType = DbType.DateTime;
                    paramFecha.ParameterName = "FECHA";
                    if (dtmFechaDesde == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFecha.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFecha.Value = dtmFechaDesde;
                    }
                    cmd.Parameters.Add(paramFecha);


                    DbParameter paramFechaHasta = cmd.CreateParameter();
                    paramFechaHasta.DbType = DbType.DateTime;
                    paramFechaHasta.ParameterName = "FECHAHASTA";
                    if (dtmFechaHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaHasta.Value = dtmFechaHasta;
                    }
                    cmd.Parameters.Add(paramFechaHasta);

                    DbParameter paramIP = cmd.CreateParameter();
                    paramIP.DbType = DbType.String;
                    paramIP.ParameterName = "IP";
                    if (strIP.Equals(String.Empty))
                    {
                        paramIP.Value = DBNull.Value;
                    }
                    else
                    {
                        paramIP.Value = strIP;
                    }
                    cmd.Parameters.Add(paramIP);

                    DbParameter paramDispositivo = cmd.CreateParameter();
                    paramDispositivo.DbType = DbType.String;
                    paramDispositivo.ParameterName = "DISPOSITIVO";
                    if (strDispositivo.Equals(String.Empty))
                    {
                        paramDispositivo.Value = DBNull.Value;
                    }
                    else
                    {
                        paramDispositivo.Value = strDispositivo;
                    }
                    cmd.Parameters.Add(paramDispositivo);

                    con.Open();
                    String strRutUsuarios;
                    String strNombreUsuario;
                    DateTime dtmFechas;
                    String strIPs;
                    String strModulo;
                    String strAccion;
                    String strObservacion;
                    String strDispositivos;
                    String strNombreMaquina;
                    String strMacAdrress;

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            strRutUsuarios = (string)dr["RUTUSUARIO"];
                            strNombreUsuario = (string)dr["NOMBRE"];
                            dtmFechas = Convert.ToDateTime(dr["FECHA"] is DBNull ? null : dr["FECHA"]);
                            strIPs = (string)dr["IP"];
                            strModulo = (string)dr["MODULO"];
                            strAccion = (string)dr["ACCION"];
                            strObservacion = (string)dr["OBSERVACION"];
                            strDispositivos = (string)dr["DISPOSITIVO"];
                            strNombreMaquina = (string)dr["NOMBREMAQUINA"];
                            strMacAdrress = (string)dr["MACADDRESS"];


                            LstAuditoria.Add(new Auditoria(strRutUsuarios,
                                                           strNombreUsuario,
                                                           dtmFechas,
                                                           strIPs,
                                                           strModulo,
                                                           strAccion,
                                                           strObservacion,
                                                           strDispositivos,
                                                           strNombreMaquina,
                                                           strMacAdrress
                                                                   ));
                        }
                    }
                }
            }

            return LstAuditoria;
        }

        public List<Auditoria> select_all_Dispositivo()
        {
            List<Auditoria> LstAuditoria = new List<Auditoria>();

            string StoredProcedure = "sp_Get_Consulta_ByDispositivo_Auditoria";
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
                            try
                            {
                                LstAuditoria.Add(new Auditoria((string)dr["DISPOSITIVO"]));
                            }
                            catch
                            {
                                LstAuditoria.Add(new Auditoria(" "));
                            }

                        }
                    }

                    return LstAuditoria;
                }

            }

        }
        
    }
}