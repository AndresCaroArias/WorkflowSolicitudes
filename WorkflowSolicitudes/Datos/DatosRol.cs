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
    public class DatosRol
    {
        public  DatosRol(){}

        
        public int InsertRol(string DESCRIPCION, int ESTADOROL)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter param1 = Conexion.dpf.CreateParameter();
            param1.Value = DESCRIPCION;
            param1.ParameterName = "DESCRIPCION";
            parametros.Add(param1);

            DbParameter paramEstadoRol = Conexion.dpf.CreateParameter();
            paramEstadoRol.Value = ESTADOROL;
            paramEstadoRol.ParameterName = "ESTADOROL";
            parametros.Add(paramEstadoRol);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Rol", parametros);
        }

        public int ActualizarRol(int CODROL, string DESCRIPCION)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODROL;
            param.ParameterName = "CODROL";
            parametros.Add(param);

            DbParameter paramDescripcion = Conexion.dpf.CreateParameter();
            paramDescripcion.Value = DESCRIPCION;
            paramDescripcion.ParameterName = "DESCRIPCION";
            parametros.Add(paramDescripcion);


            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Rol", parametros);
        }

        public int ActualizarEstadoRol(int CODROL, string ESTADOROL)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODROL;
            param.ParameterName = "CODROL";
            parametros.Add(param);

            DbParameter paramEstadoRol = Conexion.dpf.CreateParameter();
            paramEstadoRol.Value = ESTADOROL;
            paramEstadoRol.ParameterName = "ESTADOROL";
            parametros.Add(paramEstadoRol);


            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_ByCodEstado_Rol", parametros);
        }

        public int EliminarRol(int CODROL)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODROL;
            param.ParameterName = "CODROL";
            parametros.Add(param);

            return Conexion.ejecutaNonQuery("sp_Set_Borra_Rol", parametros);
        }

        

        public List<Rol> select_All_E_Rol()
        {
            List<Rol> LstRol = new List<Rol>();

            string StoredProcedure = "sp_Get_Consulta_Rol";
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
                            LstRol.Add(
                                new Rol((int)dr["CODROL"],
                                    (string)dr["DESCRIPCION"],
                                     (int)dr["ESTADOROL"]
                                    ));
                        }
                    }
                }
            }
            return LstRol;
        }

        public List<Rol> select_All_E_Rol_ByRol(int intCodRol)
        {
            List<Rol> LstRol = new List<Rol>();

            string StoredProcedure = "sp_Get_Consulta_ByRol_Rol";
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
                    param.ParameterName = "CODROL";
                    param.Value = intCodRol;
                    cmd.Parameters.Add(param);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstRol.Add(
                                new Rol((int)dr["CODROL"],
                                    (string)dr["DESCRIPCION"],
                                     (int)dr["ESTADOROL"]
                                    ));
                        }
                    }
                }
            }
            return LstRol;
        }




        public int ExisteRol_RolesPrivilegios(int intCodRol)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByTipo_Privilegio";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExisteRol = cmd.CreateParameter();
                    paramExisteRol.DbType = DbType.Int32;
                    paramExisteRol.ParameterName = "CODROL";
                    paramExisteRol.Value = intCodRol;
                    cmd.Parameters.Add(paramExisteRol);
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

        public int ExisteRol_DescripcionDelRoles(string strDescripcion)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ExisteByDescripcion_Rol";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExisteRolDesc = cmd.CreateParameter();
                    paramExisteRolDesc.DbType = DbType.String;
                    paramExisteRolDesc.ParameterName = "DESCRIPCION";
                    paramExisteRolDesc.Value = strDescripcion;
                    cmd.Parameters.Add(paramExisteRolDesc);
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