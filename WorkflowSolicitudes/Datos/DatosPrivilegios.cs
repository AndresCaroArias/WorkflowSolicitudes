using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Configuration;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Datos
{
    public class DatosPrivilegios
    {
        public List<Privilegios> select_All_Privilegios()
        {
            List<Privilegios> LstPrivilegios = new List<Privilegios>();

            string StoredProcedure = "sp_Get_Consulta_Privilegios";
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
                            LstPrivilegios.Add(
                                new Privilegios((int)dr["CODPRIVILEGIOS"],
                                    (string)dr["DESCPRIVILEGIOS"],
                                    (string)dr["NOMPRIVILEGIOS"],
                                    (string)dr["ESTADOPRIVILEGIOS"]));
                        }
                    }
                }
            }
            return LstPrivilegios;
        }

        

        public List<Privilegios> select_Privilegios_por_Rol(int intCodRol)
        {
            List<Privilegios> LstPrivilegios = new List<Privilegios>(intCodRol);

            string StoredProcedure = "sp_get_consulta_ByCodrol_RolesPrivilegios";
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
                            LstPrivilegios.Add(
                                new Privilegios((int)dr["CODPRIVILEGIOS"],
                                               (string)dr["NOMPRIVILEGIOS"]));
                        }
                    }
                }
            }
            return LstPrivilegios;
        }

        public int InsertPrivilegios(string DESCPRIVILEGIOS, string NOMPRIVILEGIOS, int ESTADOPRIVILEGIOS)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter param1 = Conexion.dpf.CreateParameter();
            param1.Value = DESCPRIVILEGIOS;
            param1.ParameterName = "DESCPRIVILEGIOS";
            parametros.Add(param1);

            DbParameter param2 = Conexion.dpf.CreateParameter();
            param2.Value = NOMPRIVILEGIOS;
            param2.ParameterName = "NOMPRIVILEGIOS";
            parametros.Add(param2);

            DbParameter param3 = Conexion.dpf.CreateParameter();
            param3.Value = ESTADOPRIVILEGIOS;
            param3.ParameterName = "ESTADOPRIVILEGIOS";
            parametros.Add(param3);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Privilegios", parametros);
        }

        public int ActualizarPrivilegios(int CODPRIVILEGIOS, string DESCPRIVILEGIOS, string NOMPRIVILEGIOS, int ESTADOPRIVILEGIOS)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODPRIVILEGIOS;
            param.ParameterName = "CODPRIVILEGIOS";
            parametros.Add(param);

            DbParameter paramDescripcion = Conexion.dpf.CreateParameter();
            paramDescripcion.Value = DESCPRIVILEGIOS;
            paramDescripcion.ParameterName = "DESCPRIVILEGIOS";
            parametros.Add(paramDescripcion);

            DbParameter paramNonbre = Conexion.dpf.CreateParameter();
            paramNonbre.Value = NOMPRIVILEGIOS;
            paramNonbre.ParameterName = "NOMPRIVILEGIOS";
            parametros.Add(paramNonbre);

            DbParameter paramEstado = Conexion.dpf.CreateParameter();
            paramEstado.Value = ESTADOPRIVILEGIOS;
            paramEstado.ParameterName = "ESTADOPRIVILEGIOS";
            parametros.Add(paramEstado);



            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Privilegios", parametros);
        }

        public int ActualizarEstadoPrivilegios(int CODPRIVILEGIOS, int ESTADOPRIVILEGIOS)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODPRIVILEGIOS;
            param.ParameterName = "CODPRIVILEGIOS";
            parametros.Add(param);

            DbParameter paramEstPriv = Conexion.dpf.CreateParameter();
            paramEstPriv.Value = ESTADOPRIVILEGIOS;
            paramEstPriv.ParameterName = "ESTADOPRIVILEGIOS";
            parametros.Add(paramEstPriv);

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_ByCodEstado_Privilegios", parametros);
        }

        public int EliminarPrivilegios(int CODPRIVILEGIOS)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODPRIVILEGIOS;
            param.ParameterName = "CODPRIVILEGIOS";
            parametros.Add(param);

            return Conexion.ejecutaNonQuery("sp_Set_Borra_Privilegios", parametros);
        }

        public int ExistePrivilegio_RolesPrivilegios(int intCodRol)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_ConsultaPrivi_ByTipo_Privilegio";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExistePrivi = cmd.CreateParameter();
                    paramExistePrivi.DbType = DbType.Int32;
                    paramExistePrivi.ParameterName = "CODPRIVILEGIOS";
                    paramExistePrivi.Value = intCodRol;
                    cmd.Parameters.Add(paramExistePrivi);
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


        public int ExistePrivilegio_Privilegios(string strDescPrivilegios)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByPrivilegios_Privilegios";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExistePrivi = cmd.CreateParameter();
                    paramExistePrivi.DbType = DbType.String;
                    paramExistePrivi.ParameterName = "DESCPRIVILEGIOS";
                    paramExistePrivi.Value = strDescPrivilegios;
                    cmd.Parameters.Add(paramExistePrivi);
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

        public int ExistePrivilegio_NomPrivilegios(string strNomPrivilegios)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByPrivilegios_NomPrivilegios";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramExisteNomPrivi = cmd.CreateParameter();
                    paramExisteNomPrivi.DbType = DbType.String;
                    paramExisteNomPrivi.ParameterName = "NOMPRIVILEGIOS";
                    paramExisteNomPrivi.Value = strNomPrivilegios;
                    cmd.Parameters.Add(paramExisteNomPrivi);
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
