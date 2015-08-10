using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using WorkflowSolicitudes.Entidades;
using System.Data;

namespace WorkflowSolicitudes.Datos
{
    public class DatosTareas
    {
        public DatosTareas(){} 

        

        public List<Tareas> select_All_TareasPendientes(string strRutUsuario )
        {

            int      IntFolioSolicitud;
            string   StrDesSolicitud;
            DateTime DtmFechaSolicitud;
            int      IntSecuencia;
            string   StrDesActividad;
            DateTime DtmFechaVencimiento;
            DateTime DtmFechaResolucion;
            int      IntDiasAtraso;
            string   StrDescEstado;
            int      intEtapa;
            
            
            List<Tareas> LstTareas = new List<Tareas>();
            string StoredProcedure = "sp_get_tareasPendientes";
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

                            IntFolioSolicitud   = (int)dr["FOLIOSOLICITUD"];
                            StrDesSolicitud = (string)dr["DESCTIPOSOLICITUD"];
                            DtmFechaSolicitud   = (DateTime)dr["FECHASOLICITUD"];
                            IntSecuencia        = (int)dr["SECUENCIA"];
                            StrDesActividad     = (string)dr["DESCRIPCION"];
                            DtmFechaVencimiento = Convert.ToDateTime(dr["FECHAVENCSOL"] is DBNull ? null : dr["FECHAVENCSOL"]); 
                            DtmFechaResolucion  = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]); 
                            IntDiasAtraso       = (int)dr["DIASATRASO"];
                            StrDescEstado       = (string)dr["DESCESTADO"];
                            intEtapa            = (int)dr["ETAPA"];

                            LstTareas.Add(new Tareas(IntFolioSolicitud,
                                                     StrDesSolicitud,
                                                     DtmFechaSolicitud,
                                                     IntSecuencia,
                                                     StrDesActividad,
                                                     DtmFechaVencimiento,
                                                     DtmFechaResolucion,
                                                     IntDiasAtraso,
                                                     StrDescEstado,
                                                     intEtapa
                                                     ));

                        }
                    }
                }
            }
            return LstTareas;
        
        
        
        }

        public List<Tareas> select_All_TareasPendientesByCodUnidad(int intCodUnidad)
        {

            int IntFolioSolicitud;
            string StrDesSolicitud;
            DateTime DtmFechaSolicitud;
            int IntSecuencia;
            string StrDesActividad;
            DateTime DtmFechaVencimiento;
            DateTime DtmFechaResolucion;
            int IntDiasAtraso;
            string StrDescEstado;
            int intEtapa;

            List<Tareas> LstTareas = new List<Tareas>();
            string StoredProcedure = "sp_get_tareasPendientesByCodUnidad";
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
                    param.ParameterName = "CODUNIDAD";
                    param.Value = intCodUnidad;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            IntFolioSolicitud   = (int)dr["FOLIOSOLICITUD"];
                            StrDesSolicitud     = (string)dr["DESCTIPOSOLICITUD"];
                            DtmFechaSolicitud   = (DateTime)dr["FECHASOLICITUD"];
                            IntSecuencia        = (int)dr["SECUENCIA"];
                            StrDesActividad     = (string)dr["DESCRIPCION"];
                            DtmFechaVencimiento = Convert.ToDateTime(dr["FECHAVENCSOL"] is DBNull ? null : dr["FECHAVENCSOL"]);
                            DtmFechaResolucion  = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            IntDiasAtraso       = (int)dr["DIASATRASO"];
                            StrDescEstado       = (string)dr["DESCESTADO"];
                            intEtapa            = (int)dr["ETAPA"];

                            LstTareas.Add(new Tareas(IntFolioSolicitud,
                                                     StrDesSolicitud,
                                                     DtmFechaSolicitud,
                                                     IntSecuencia,
                                                     StrDesActividad,
                                                     DtmFechaVencimiento,
                                                     DtmFechaResolucion,
                                                     IntDiasAtraso,
                                                     StrDescEstado,
                                                     intEtapa
                                                     ));

                        }
                    }
                }
            }
            return LstTareas;
        }


    }
}