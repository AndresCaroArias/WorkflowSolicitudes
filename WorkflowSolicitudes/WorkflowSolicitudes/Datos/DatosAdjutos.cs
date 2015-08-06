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
    public class DatosAdjutos
    {
        public int InsertAdjuntos(int FOLIOSOLICITUD, string NOMBREARCHIVO, byte[] ARCHIVOPDF, string TIPOADJUNTO, int SECUENCIA)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;


            DbParameter param1 = Conexion.dpf.CreateParameter();
            param1.Value = FOLIOSOLICITUD;
            param1.ParameterName = "FOLIOSOLICITUD";
            parametros.Add(param1);

            DbParameter param2 = Conexion.dpf.CreateParameter();
            param2.Value = NOMBREARCHIVO;
            param2.ParameterName = "NOMBREARCHIVO";
            parametros.Add(param2);

            DbParameter param3 = Conexion.dpf.CreateParameter();
            param3.Value = ARCHIVOPDF;
            param3.ParameterName = "ARCHIVOPDF";
            parametros.Add(param3);

            DbParameter param4 = Conexion.dpf.CreateParameter();
            param4.Value = TIPOADJUNTO;
            param4.ParameterName = "TIPOADJUNTO";
            parametros.Add(param4);

            DbParameter param5 = Conexion.dpf.CreateParameter();
            param5.Value = SECUENCIA;
            param5.ParameterName = "SECUENCIA";
            parametros.Add(param5);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Adjunto", parametros);
        }

        public List<Adjuntos> select_All_E_Adjuntos(int intIdArchivo)
        {
            List<Adjuntos> LstAdjunt = new List<Adjuntos>();

            string StoredProcedure = "sp_Get_Consulta_ByFolioNombreArchivo_Adjuntos";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIdArchivo = cmd.CreateParameter();
                    paramIdArchivo.DbType = DbType.Int32;
                    paramIdArchivo.ParameterName = "IDARCHIVO";
                    paramIdArchivo.Value = intIdArchivo;
                    cmd.Parameters.Add(paramIdArchivo);

                 


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstAdjunt.Add(
                                new Adjuntos((int)dr["IDARCHIVO"],
                                    (int)dr["FOLIOSOLICITUD"],
                                    (string)dr["NOMBREARCHIVO"],
                                    (Byte[])dr["ARCHIVOPDF"]
                                    ));
                        }
                    }
                }
            }
            return LstAdjunt;
        }

        public int ExistenAdjuntos(int intFolio)
        {

            using (SqlConnection conexion = new SqlConnection(Conexion.constr))
            {
                SqlCommand cmd = new SqlCommand("sp_Get_Existe_ByFolio_Adjuntos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@FOLIO", intFolio));

                SqlParameter ParamFoliSolicitud = new SqlParameter("@EXISTE", 0);
                ParamFoliSolicitud.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ParamFoliSolicitud);

                conexion.Open();
                cmd.ExecuteNonQuery();
                int intExistenAdjuntos = Int32.Parse(cmd.Parameters["@EXISTE"].Value.ToString());

                conexion.Close();

                return intExistenAdjuntos;

            }
        }

        public List<Adjuntos> select_All_ByFolio_TipoAdjuntos(int intFolio, string strTipoAdjunto)
        {
            List<Adjuntos> LstAdjuntosFolioTipo = new List<Adjuntos>();

            string StoredProcedure = "sp_Get_Consulta_ByFolio_Tipo_Adjuntos";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramFolio = cmd.CreateParameter();
                    paramFolio.DbType = DbType.Int32;
                    paramFolio.ParameterName = "FOLIOSOLICITUD";
                    paramFolio.Value = intFolio;
                    cmd.Parameters.Add(paramFolio);

                    DbParameter paramTipoAdjunto = cmd.CreateParameter();
                    paramTipoAdjunto.DbType = DbType.String;
                    paramTipoAdjunto.ParameterName = "TIPOADJUNTO";
                    paramTipoAdjunto.Value = strTipoAdjunto;
                    cmd.Parameters.Add(paramTipoAdjunto);




                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstAdjuntosFolioTipo.Add(
                                new Adjuntos((int)dr["IDARCHIVO"],
                                    (int)dr["FOLIOSOLICITUD"],
                                    (string)dr["NOMBREARCHIVO"],
                                    (Byte[])dr["ARCHIVOPDF"],
                                    (string)dr["TIPOADJUNTO"]
                                    ));
                        }
                    }
                }
            }
            return LstAdjuntosFolioTipo;
        }

        public List<Adjuntos> select_All_ByFolio_TipoAdjuntos_Secuencia(int intFolio, string strTipoAdjunto, int intSecuencia)
        {
            List<Adjuntos> LstAdjuntosFolioTipo = new List<Adjuntos>();

            string StoredProcedure = "sp_Get_Consulta_ByFolio_Tipo_Adjuntos_Secuencia";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramFolio = cmd.CreateParameter();
                    paramFolio.DbType = DbType.Int32;
                    paramFolio.ParameterName = "FOLIOSOLICITUD";
                    paramFolio.Value = intFolio;
                    cmd.Parameters.Add(paramFolio);

                    DbParameter paramTipoAdjunto = cmd.CreateParameter();
                    paramTipoAdjunto.DbType = DbType.String;
                    paramTipoAdjunto.ParameterName = "TIPOADJUNTO";
                    paramTipoAdjunto.Value = strTipoAdjunto;
                    cmd.Parameters.Add(paramTipoAdjunto);

                    DbParameter paramSecuencia = cmd.CreateParameter();
                    paramSecuencia.DbType = DbType.Int32;
                    paramSecuencia.ParameterName = "SECUENCIA";
                    paramSecuencia.Value = intSecuencia;
                    cmd.Parameters.Add(paramSecuencia);





                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstAdjuntosFolioTipo.Add(
                                new Adjuntos((int)dr["IDARCHIVO"],
                                    (int)dr["FOLIOSOLICITUD"],
                                    (string)dr["NOMBREARCHIVO"],
                                    (Byte[])dr["ARCHIVOPDF"],
                                    (string)dr["TIPOADJUNTO"]
                                    ));
                        }
                    }
                }
            }
            return LstAdjuntosFolioTipo;
        }





    }




}