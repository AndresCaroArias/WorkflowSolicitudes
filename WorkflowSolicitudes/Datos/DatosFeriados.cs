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
    public class DatosFeriados
    {

        
    public List<Feriados> select_All_Feriados()
        {
            List<Feriados> LstFeriados = new List<Feriados>();

            string StoredProcedure = "sp_Get_Consulta_Feriados";
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
                            LstFeriados.Add(
                                new Feriados((int)dr["CODFERIADO"],
                                    (string)dr["DESCRIPCIONFERIADO"],
                                    (DateTime)dr["FECHAFERIADO"]));
                        }
                    }
                }
            }
            return LstFeriados;
        }

        public int ExisteCodFeriado_Feriado(int intCodFeriado)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByCodFeriado_Feriados";
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
                    paramExistePrivi.ParameterName = "CODFERIADO";
                    paramExistePrivi.Value = intCodFeriado;
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

        public int InsertFeriados(string DESCRIPCIONFERIADO, DateTime FECHAFERIADO)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter param2 = Conexion.dpf.CreateParameter();
            param2.Value = DESCRIPCIONFERIADO;
            param2.ParameterName = "DESCRIPCIONFERIADO";
            parametros.Add(param2);

            DbParameter param3 = Conexion.dpf.CreateParameter();
            param3.Value = FECHAFERIADO;
            param3.ParameterName = "FECHAFERIADO";
            parametros.Add(param3);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Feriados", parametros);
        }

        public int EliminarFeriado(int CODFERIADO)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODFERIADO;
            param.ParameterName = "CODFERIADO";
            parametros.Add(param);

            return Conexion.ejecutaNonQuery("sp_Set_Borra_Feriados", parametros);
        }

        public int ActualizarFeriado(int CODFERIADO, string DESCRIPCIONFERIADO, DateTime FECHAFERIADO)
        {

            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODFERIADO;
            param.ParameterName = "CODFERIADO";
            parametros.Add(param);

            DbParameter paramDescripcion = Conexion.dpf.CreateParameter();
            paramDescripcion.Value = DESCRIPCIONFERIADO;
            paramDescripcion.ParameterName = "DESCRIPCIONFERIADO";
            parametros.Add(paramDescripcion);

            DbParameter paramNonbre = Conexion.dpf.CreateParameter();
            paramNonbre.Value = FECHAFERIADO;
            paramNonbre.ParameterName = "FECHAFERIADO";
            parametros.Add(paramNonbre);

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Feriados", parametros);
        }

    }
}