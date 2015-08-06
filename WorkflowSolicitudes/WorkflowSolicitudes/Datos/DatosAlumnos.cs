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
    public class DatosAlumnos
    {
        public DatosAlumnos() 
        { }

       


        public List<Alumnos> select_All_GetInfoAlumno(string codcli)
        {
            List<Alumnos> LstAlumnnos = new List<Alumnos>();

            string StoredProcedure = "sp_Get_Consulta_byCodcli_Mt_Alumno";
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
                    param.ParameterName = "CODCLI";
                    param.Value = codcli;
                    cmd.Parameters.Add(param);

                    
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstAlumnnos.Add(
                                      new Alumnos((string)dr["CODCLI"],
                                                  (string)dr["RUT"],
                                                  (string)dr["JORNADA"],
                                                  (string)dr["NOMBRE"],
                                                  (string)dr["PATERNO"],
                                                  (string)dr["MATERNO"],
                                                  (string)dr["CODCARR"],
                                                  (string)dr["NOMBRE_L"]));
                        }
                    }
                }
            }
            return LstAlumnnos;
        }


    }
}