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
    public class DatosActividad
    { 
        public DatosActividad() { }





        public int InsertActividad(string DESCRIPCION, int DURACION, int ESTADOACTIVIDAD)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;


            DbParameter param1 = Conexion.dpf.CreateParameter();
            param1.Value = DESCRIPCION;
            param1.ParameterName = "DESCRIPCION";
            parametros.Add(param1);

            DbParameter param2 = Conexion.dpf.CreateParameter();
            param2.Value = DURACION;
            param2.ParameterName = "DURACION";
            parametros.Add(param2);

            DbParameter param3 = Conexion.dpf.CreateParameter();
            param3.Value = ESTADOACTIVIDAD;
            param3.ParameterName = "ESTADOACTIVIDAD";
            parametros.Add(param3);

            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Actividad", parametros);
        }

        public int ActualizarActividad(int CODACTIVIDAD, string DESCRIPCION, int DURACION, int ESTADOACTIVIDAD)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODACTIVIDAD;
            param.ParameterName = "CODACTIVIDAD";
            parametros.Add(param);

            DbParameter paramDescripcion = Conexion.dpf.CreateParameter();
            paramDescripcion.Value = DESCRIPCION;
            paramDescripcion.ParameterName = "DESCRIPCION";
            parametros.Add(paramDescripcion);

            DbParameter paramDuracion = Conexion.dpf.CreateParameter();
            paramDuracion.Value = DURACION;
            paramDuracion.ParameterName = "DURACION";
            parametros.Add(paramDuracion);

            DbParameter paramEstad = Conexion.dpf.CreateParameter();
            paramEstad.Value = ESTADOACTIVIDAD;
            paramEstad.ParameterName = "ESTADOACTIVIDAD";
            parametros.Add(paramEstad);

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Actividad", parametros);
        }

        public int EliminarActividad(int CODACTIVIDAD)
        {
            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter param = Conexion.dpf.CreateParameter();
            param.Value = CODACTIVIDAD;
            param.ParameterName = "CODACTIVIDAD";
            parametros.Add(param);

            return Conexion.ejecutaNonQuery("sp_Set_Borra_Actividad", parametros);
        }


        public int EstaEnUsoLaActividaEnDetalleSolicitud(int intCodActividad)
        {

            int intExiste = 0;
            string StoredProcedure = "sp_Get_ValidaExisteDetSoli_Actividad";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIntCodActividad = cmd.CreateParameter();
                    paramIntCodActividad.DbType = DbType.Int32;
                    paramIntCodActividad.ParameterName = "@CODACTIVIDAD";
                    paramIntCodActividad.Value = intCodActividad;
                    cmd.Parameters.Add(paramIntCodActividad);

                    con.Open();


                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intExiste = (int)dr["EXISTE"];
                        }
                    }
                    return intExiste;
                }
            }
        }



        public List<Actividad> select_All_E_Actividad()
        {
            List<Actividad> LstActividad = new List<Actividad>();

            string StoredProcedure = "sp_Get_Consulta_Actividad";
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
                            LstActividad.Add(
                                new Actividad((int)dr["CODACTIVIDAD"],
                                    (string)dr["DESCRIPCION"],
                                    (int)dr["DURACION"],
                                    (string)dr["ESTADOACTIVIDAD"]));
                        }
                    }
                }
            }
            return LstActividad;
        }

        public int select_ExiteActividad_Flujo(int intCodActividad)
        {

            int intCantidad=0;
            string StoredProcedure = "sp_get_Consulta_FujoSolicitud";
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
                    param.ParameterName = "CODACTIVIDAD";
                    param.Value = intCodActividad;
                    cmd.Parameters.Add(param);
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