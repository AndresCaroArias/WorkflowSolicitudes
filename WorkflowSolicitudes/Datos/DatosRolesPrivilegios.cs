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
    public class DatosRolesPrivilegios
    {
        

        

        public List<RolesPrivilegios> select_All_RolesPrivilegios()
        {
            List<RolesPrivilegios> LstRolesPrivilegios = new List<RolesPrivilegios>();

            string StoredProcedure = "sp_Get_Consulta_RolesPrivilegios";
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
                            LstRolesPrivilegios.Add(
                                new RolesPrivilegios((int)dr["CODPRIVILEGIOS"],
                                    (int)dr["CODROL"],
                                    (int)dr["ESTADOROLPRIVI"],
                                    (string)dr["DESCPRIVILEGIOS"],
                                    (string)dr["DESCRIPCION"]));
                        }
                    }
                }
            }
            return LstRolesPrivilegios;
        }

        public int EliminarRolesPrivilegios(int CODPRIVILEGIOS, int CODROL)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODPRIVILEGIOS;
            param.ParameterName = "CODPRIVILEGIOS";
            parametros.Add(param);

            DbParameter param2 = Conexion.dpf.CreateParameter();
            param2.Value = CODROL;
            param2.ParameterName = "CODROL";
            parametros.Add(param2);

            return Conexion.ejecutaNonQuery("sp_Set_Borra_RolesPrivilegios", parametros);
        }

        public int InsertRolesPrivilegios(int CODPRIVILEGIOS, int CODROL, int ESTADOROLPRIVI)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter param1 = Conexion.dpf.CreateParameter();
            param1.Value = CODPRIVILEGIOS;
            param1.ParameterName = "CODPRIVILEGIOS";
            parametros.Add(param1);

            DbParameter param2 = Conexion.dpf.CreateParameter();
            param2.Value = CODROL;
            param2.ParameterName = "CODROL";
            parametros.Add(param2);

            DbParameter param3 = Conexion.dpf.CreateParameter();
            param3.Value = ESTADOROLPRIVI;
            param3.ParameterName = "ESTADOROLPRIVI";
            parametros.Add(param3);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_RolesPrivilegios", parametros);

        }

        public int ActualizarRolesPrivilegios(int CODPRIVILEGIOS, int CODROL)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramCodRol = Conexion.dpf.CreateParameter();
            paramCodRol.Value = CODPRIVILEGIOS;
            paramCodRol.ParameterName = "CODPRIVILEGIOS";
            parametros.Add(paramCodRol);


            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODROL;
            param.ParameterName = "CODROL";
            parametros.Add(param);



            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Rol", parametros);
        }
    }
}