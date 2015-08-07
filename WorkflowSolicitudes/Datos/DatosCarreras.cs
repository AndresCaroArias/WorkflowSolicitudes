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
    public class DatosCarreras
    {
        



        public List<Carrera> select_All_Carreras()
        {
            List<Carrera> LstCarrera= new List<Carrera>();

            string StoredProcedure = "sp_Get_Consulta_Mt_Carrera";
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
                            LstCarrera.Add(
                                new Carrera((string)dr["CODCARR"],
                                            (string)dr["NOMBRE_L"]));
                        }
                    }
                }
            }
            return LstCarrera;
        }


    }
}