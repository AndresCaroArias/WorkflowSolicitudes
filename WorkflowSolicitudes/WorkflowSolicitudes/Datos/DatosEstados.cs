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
    public class DatosEstados
    {


        


        public List<Estados> select_All_Estados()
        {
            List<Estados> LstEstados = new List<Estados>();

            string StoredProcedure = "sp_Get_Consulta_Estados";
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
                            LstEstados.Add(
                                new Estados((int)dr["CODESTADO"],
                                    (string)dr["DESCESTADO"]));
                        }
                    }
                }
            }
            return LstEstados;
        }

    }
}