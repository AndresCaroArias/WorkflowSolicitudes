using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data.Common;
using System.Data;

using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Datos
{
    public class DatosTipoSolicitud
    {
        
        public int InsertipoSolicitud(string DESCSOLICITUD,
                                        int ESTADOSOLICITUD,
                                        DateTime FECHAINICIO,
                                        DateTime FECHAFIN,
                                        int CANTMAXSOLICITUD,
                                        string ORIGENSOLICITUD,
                                        int CANTMAXDOC)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter paramDescripcion = Conexion.dpf.CreateParameter();
            paramDescripcion.DbType = DbType.String;
            paramDescripcion.Value = DESCSOLICITUD;
            paramDescripcion.ParameterName = "DESCTIPOSOLICITUD";
            parametros.Add(paramDescripcion);

            DbParameter paramEstadoSolicitud = Conexion.dpf.CreateParameter();
            paramEstadoSolicitud.DbType = DbType.Int32;
            paramEstadoSolicitud.Value = ESTADOSOLICITUD;
            paramEstadoSolicitud.ParameterName = "ESTADOSOLICITUD";
            parametros.Add(paramEstadoSolicitud);


            DbParameter paramFeIncio = Conexion.dpf.CreateParameter();
            paramFeIncio.DbType = DbType.DateTime;
            paramFeIncio.Value = FECHAINICIO;
            paramFeIncio.ParameterName = "FECHAINICIO";
            parametros.Add(paramFeIncio);

            DbParameter paramFeFin = Conexion.dpf.CreateParameter();
            paramFeFin.DbType = DbType.DateTime;
            paramFeFin.Value = FECHAFIN;
            paramFeFin.ParameterName = "FECHAFIN";
            parametros.Add(paramFeFin);

            DbParameter paramCAntMaxSolicitud = Conexion.dpf.CreateParameter();
            paramCAntMaxSolicitud.DbType = DbType.Int32;
            paramCAntMaxSolicitud.Value = CANTMAXSOLICITUD;
            paramCAntMaxSolicitud.ParameterName = "CANTMAXSOLICITUD";
            parametros.Add(paramCAntMaxSolicitud);

            DbParameter paramOrigenSolicitud = Conexion.dpf.CreateParameter();
            paramOrigenSolicitud.DbType = DbType.String;
            paramOrigenSolicitud.Value = ORIGENSOLICITUD;
            paramOrigenSolicitud.ParameterName = "ORIGEN";
            parametros.Add(paramOrigenSolicitud);

            DbParameter paramCantMaxDoc = Conexion.dpf.CreateParameter();
            paramCantMaxDoc.DbType = DbType.Int32;
            paramCantMaxDoc.Value = CANTMAXDOC;
            paramCantMaxDoc.ParameterName = "CANTMAXDOC";
            parametros.Add(paramCantMaxDoc);


            return Conexion.ejecutaNonQuery("sp_Set_Inserta_TipoSol", parametros);
        }

        public int ActualizarTipoSolicitud(int CODTIPOSOLICITUD, string DESCSOLICITUD, int ESTADOSOLICITUD, DateTime FECHAINICIO, DateTime FECHAFIN, int CANTMAXSOLICITUD, string ORIGENSOLICITUD, int CANTMAXDOC)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.DbType = DbType.Int32;
            param.Value = CODTIPOSOLICITUD;
            param.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(param);

            DbParameter paramDescripcion = Conexion.dpf.CreateParameter();
            paramDescripcion.DbType = DbType.String;
            paramDescripcion.Value = DESCSOLICITUD;
            paramDescripcion.ParameterName = "DESCTIPOSOLICITUD";
            parametros.Add(paramDescripcion);

            DbParameter paramEstadoSolicitud = Conexion.dpf.CreateParameter();
            paramEstadoSolicitud.DbType = DbType.Int32;
            paramEstadoSolicitud.Value = ESTADOSOLICITUD;
            paramEstadoSolicitud.ParameterName = "ESTADOSOLICITUD";
            parametros.Add(paramEstadoSolicitud);


            DbParameter paramFeIncio = Conexion.dpf.CreateParameter();
            paramFeIncio.DbType = DbType.DateTime;
            paramFeIncio.Value = FECHAINICIO;
            paramFeIncio.ParameterName = "FECHAINICIO";
            parametros.Add(paramFeIncio);

            DbParameter paramFeFin = Conexion.dpf.CreateParameter();
            paramFeFin.DbType = DbType.DateTime;
            paramFeFin.Value = FECHAFIN;
            paramFeFin.ParameterName = "FECHAFIN";
            parametros.Add(paramFeFin);

            DbParameter paramCAntMaxSolicitud = Conexion.dpf.CreateParameter();
            paramCAntMaxSolicitud.DbType = DbType.Int32;
            paramCAntMaxSolicitud.Value = CANTMAXSOLICITUD;
            paramCAntMaxSolicitud.ParameterName = "CANTMAXSOLICITUD";
            parametros.Add(paramCAntMaxSolicitud);


            DbParameter paramOrigenSolicitud = Conexion.dpf.CreateParameter();
            paramOrigenSolicitud.DbType = DbType.String;
            paramOrigenSolicitud.Value = ORIGENSOLICITUD;
            paramOrigenSolicitud.ParameterName = "ORIGEN";
            parametros.Add(paramOrigenSolicitud);

            DbParameter paramCantMaxDoc = Conexion.dpf.CreateParameter();
            paramCantMaxDoc.DbType = DbType.Int32;
            paramCantMaxDoc.Value = CANTMAXDOC;
            paramCantMaxDoc.ParameterName = "@CANTMAXDOC";
            parametros.Add(paramCantMaxDoc);

            return Conexion.ejecutaNonQuery("sp_Set_ActualizaByTipo_Solicitud", parametros);
        }

        public int EliminarTipoSolicitud(int CODTIPOSOLICITUD)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramBorrar = Conexion.dpf.CreateParameter();
            paramBorrar.Value = CODTIPOSOLICITUD;
            paramBorrar.ParameterName = "CODTIPOSOLICITUD";
            parametros.Add(paramBorrar);

            return Conexion.ejecutaNonQuery("Sp_Set_Elimina_TipoSolicitud", parametros);
        }

        public List<TipoSolicitud> select_All_E_TipoSolicitud()
        {
            List<TipoSolicitud> LstTipoSolicitud = new List<TipoSolicitud>();

            string StoredProcedure = "sp_Get_Consulta_TipoSolicitudes";
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
                            LstTipoSolicitud.Add(
                                new TipoSolicitud((int)dr["CODTIPOSOLICITUD"],
                                    (string)dr["DESCTIPOSOLICITUD"],
                                    (int)dr["ESTADOSOLICITUD"],
                                    (DateTime)dr["FECHAINICIO"],
                                    (DateTime)dr["FECHAFIN"],
                                    (int)dr["CANTMAXSOLICITUD"],
                                    (string)dr["ORIGEN"],
                                    (int)dr["CANTMAXDOC"]));

                        }
                    }
                }
            }
            return LstTipoSolicitud;
        }

        public List<TipoSolicitud> select_All_TipoSolicitudExternas()
        {
            List<TipoSolicitud> LstTipoSolicitud = new List<TipoSolicitud>();

            string StoredProcedure = "sp_Get_Consulta_TipoSolicitud_externas";
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
                            LstTipoSolicitud.Add(
                                new TipoSolicitud((int)dr["CODTIPOSOLICITUD"],
                                    (string)dr["DESCTIPOSOLICITUD"]));
                        }
                    }
                }
            }
            return LstTipoSolicitud;
        }


        public List<TipoSolicitud> select_All_TipoSolicitudInternas()
        {
            List<TipoSolicitud> LstTipoSolicitud = new List<TipoSolicitud>();

            string StoredProcedure = "sp_Get_Consulta_TipoSolicitud_internas";
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
                            LstTipoSolicitud.Add(
                                new TipoSolicitud((int)dr["CODTIPOSOLICITUD"],
                                    (string)dr["DESCTIPOSOLICITUD"]));
                        }
                    }
                }
            }
            return LstTipoSolicitud;
        } 



        public TipoSolicitud select_TipoSolicitudbyId(int intCodTipoSolicitud)
        {
            TipoSolicitud ObjTipoSolicitud = new TipoSolicitud();
            string StoredProcedure = "OBTENERBYIDTIPOSOLICITUD";

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
                        if (dr.Read())
                        {
                            ObjTipoSolicitud = new TipoSolicitud(intCodTipoSolicitud,
                                (string)dr["strDescSolicitud"],
                                (DateTime)dr["dtmFechaInicio"],
                                (DateTime)dr["_dtmFechaFin"]);
                        }
                    }
                }
            }

            return ObjTipoSolicitud;
        }

        public int select_Exite_FlujoTipoSolicitud(int intCodTipoSolicitud)
        {

            int intCantidadFlujo = 0;
            string StoredProcedure = "sp_Get_Consulta_ByTipo_FlujoSolicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExisteTipoFlujo = cmd.CreateParameter();
                    paramExisteTipoFlujo.DbType = DbType.Int32;
                    paramExisteTipoFlujo.ParameterName = "CODTIPOSOLICITUD";
                    paramExisteTipoFlujo.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramExisteTipoFlujo);
                    con.Open();


                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intCantidadFlujo = (int)dr["CANTIDAD"];

                        }

                    }

                    return intCantidadFlujo;
                }
            }

        }



        public String select_By_TipoSolicitud(int intCodTipoSolicitud)
        {
            string StrDescTipoSolicitud = String.Empty;
            string StoredProcedure = "sp_Get_Consulta_ByTipo_Solicitud";


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
                            StrDescTipoSolicitud = (string)dr["DESCTIPOSOLICITUD"];
                        }
                    }
                }
                return StrDescTipoSolicitud;
            }

        }


        public int select_CantMaxDoc_By_TipoSolicitud(int intCodTipoSolicitud)
        {
            int intCantMaxDoc = 0;
            string StoredProcedure = "sp_Get_Consulta_CantMaxDoc_ByTipo_Solicitud";
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
                            intCantMaxDoc = (int)dr["CANTMAXDOC"];
                        }
                    }
                }
                return intCantMaxDoc;
            }

        }

    }
}