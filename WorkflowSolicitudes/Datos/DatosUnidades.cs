using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using WorkflowSolicitudes.Entidades;
using System.Data;

namespace WorkflowSolicitudes.Datos
{
    public class DatosUnidades
    {
        public DatosUnidades() { }

        public int InsertUnidades(string DESCUNIDAD, int ESTADOUNIDAD)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter param1 = Conexion.dpf.CreateParameter();
            param1.Value = DESCUNIDAD;
            param1.ParameterName = "DESCUNIDAD";
            parametros.Add(param1);

            DbParameter paramEstadoRol = Conexion.dpf.CreateParameter();
            paramEstadoRol.Value = ESTADOUNIDAD;
            paramEstadoRol.ParameterName = "ESTADOUNIDAD";
            parametros.Add(paramEstadoRol);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Unidad", parametros);
        }

        public int ActualizarUnidad(int CODUNIDAD, string DESCUNIDAD, int ESTADOUNIDAD)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramCodUnidad = Conexion.dpf.CreateParameter();
            paramCodUnidad.Value = CODUNIDAD;
            paramCodUnidad.ParameterName = "CODUNIDAD";
            parametros.Add(paramCodUnidad);

            DbParameter paramDescripcionUnidad = Conexion.dpf.CreateParameter();
            paramDescripcionUnidad.Value = DESCUNIDAD;
            paramDescripcionUnidad.ParameterName = "DESCUNIDAD";
            parametros.Add(paramDescripcionUnidad);

            DbParameter paramEstadoUnidad = Conexion.dpf.CreateParameter();
            paramEstadoUnidad.Value = ESTADOUNIDAD;
            paramEstadoUnidad.ParameterName = "ESTADOUNIDAD";
            parametros.Add(paramEstadoUnidad);

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Unidad", parametros);
        }


        public List<Unidades> select_All_E_Unidades()
        {
            List<Unidades> LstUnidades = new List<Unidades>();

            string StoredProcedure = "sp_Get_Consulta_Unidad";
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
                            LstUnidades.Add(
                                new Unidades((int)dr["CODUNIDAD"],
                                    (string)dr["DESCUNIDAD"],
                                     (string)dr["ESTADOUNIDAD"]
                                    ));
                        }
                    }
                }
            }
            return LstUnidades;
        }

        public List<Unidades> select_All_E_ByCodUnidad_Unidades(int intCodUnidad)
        {
            List<Unidades> LstUnidByCod = new List<Unidades>();

            string StoredProcedure = "sp_Get_Consulta_ByCodUnidad_Unidades";
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
                            LstUnidByCod.Add(
                                new Unidades((int)dr["CODUNIDAD"],
                                    (string)dr["DESCUNIDAD"],
                                     (int)dr["ESTADOUNIDAD"]
                                    ));
                        }
                    }
                }
            }
            return LstUnidByCod;
        }



        public int ExisteCodUnidad_Usuario(int intCodUnidad)
        {
            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByCodUnidad_Usuarios";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExisteCodUnidad = cmd.CreateParameter();
                    paramExisteCodUnidad.DbType = DbType.Int32;
                    paramExisteCodUnidad.ParameterName = "CODUNIDAD";
                    paramExisteCodUnidad.Value = intCodUnidad;
                    cmd.Parameters.Add(paramExisteCodUnidad);
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

        public int ExisteDescripcionUnidad_Unidades(string strDescripcionUnidad)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByDescripcionUnidades_Unidades";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExisteDescUnidad = cmd.CreateParameter();
                    paramExisteDescUnidad.DbType = DbType.String;
                    paramExisteDescUnidad.ParameterName = "DESCUNIDAD";
                    paramExisteDescUnidad.Value = strDescripcionUnidad;
                    cmd.Parameters.Add(paramExisteDescUnidad);
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
    
    
    
    }

}