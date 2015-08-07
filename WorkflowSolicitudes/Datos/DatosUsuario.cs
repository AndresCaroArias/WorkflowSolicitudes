using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Data;
using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;



namespace WorkflowSolicitudes.Datos
{
    public class DatosUsuario
    {
        public DatosUsuario() { }
        
        public List<Usuario> select_All_E_Usuario(string strRutUsuario)
        {
            List<Usuario> LstTipoUsuario = new List<Usuario>();

            string StoredProcedure = "sp_Get_Consulta_ByRut_Usuario";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                   
                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "RUTUSUARIO";
                    param.Value = strRutUsuario;
                    cmd.Parameters.Add(param);


                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstTipoUsuario.Add(
                                new Usuario((string)dr["RUTUSUARIO"],
                                    (string)dr["NOMBRE"],
                                    (string)dr["APELLIDO"],
                                    (string)dr["EMAILUSUARIO"],
                                    (int)dr["CODROL"],
                                    (int)dr["ESTADOUSUARIO"],
                                    (int)dr["CODUNIDAD"]
                                    ));
                                    
                        }
                    }
                }
            }
            return LstTipoUsuario;
        }

        public int select_Validar_Usuario(string strRutUsuario, string strPassword)
        {
            int intCodrol = 0;
            string StoredProcedure = "sp_Get_Consulta_ByUsuPass_Usuario";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();


                    DbParameter param1 = cmd.CreateParameter();
                    param1.DbType = DbType.String;
                    param1.ParameterName = "RUTUSUARIO";
                    param1.Value = strRutUsuario;
                    cmd.Parameters.Add(param1);

                    DbParameter param2 = cmd.CreateParameter();
                    param2.DbType = DbType.String;
                    param2.ParameterName = "PASSWORD";
                    param2.Value = strPassword;
                    cmd.Parameters.Add(param2);


                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intCodrol = (int)dr["CODROL"];
                        }
                    }
                }
            }
            return intCodrol;
        }

        public List<Usuario> select_All_Usuarios()
        {
            List<Usuario> LstUsuarios = new List<Usuario>();

            string StoredProcedure = "sp_Get_Consulta_Usuario";
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
                            LstUsuarios.Add(
                                new Usuario((string)dr["RUTUSUARIO"],
                                    (int)dr["CODROL"],
                                    (string)dr["PASSWORD"],
                                    (string)dr["NOMBRE"],
                                    (string)dr["APELLIDO"],
                                    (string)dr["EMAILUSUARIO"],
                                    (string)dr["ESTADOUSUARIO"],
                                    (int)dr["CODUNIDAD"],
                                    (string)dr["DEPENDE"],
                                    (string)dr["DESCRIPCION"],
                                    (string)dr["DESCUNIDAD"],
                                    (string)dr["TELEFONO"],
                                    (string)dr["NOMBREDEPENDE"]
                                   
                                                                        
                                    ));
                        }
                    }
                }
            }
            return LstUsuarios;
        }


         public List<Usuario> select_All_Usuarios_RutNombre()
        {
            List<Usuario> LstUsuarios = new List<Usuario>();

            string StoredProcedure = "sp_Get_Consulta_Usuario_NomApellido";
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
                            LstUsuarios.Add(
                                new Usuario((string)dr["RUTUSUARIO"],
                                    (string)dr["NOMBRES"]));
                        }
                    }
                }
            }
            return LstUsuarios;
        }





         public int InsertUsuario(string RUTUSUARIO, int CODROL, string PASSWORD, string NOMBRE, string APELLIDO, string EMAILUSUARIO, int ESTADOUSUARIO, int CODUNIDAD, String DEPENDE, string TELEFONO)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter paramRutUsuario = Conexion.dpf.CreateParameter();
            paramRutUsuario.Value = RUTUSUARIO;
            paramRutUsuario.ParameterName = "RUTUSUARIO";
            parametros.Add(paramRutUsuario);

            DbParameter paramCodRol = Conexion.dpf.CreateParameter();
            paramCodRol.Value = CODROL;
            paramCodRol.ParameterName = "CODROL";
            parametros.Add(paramCodRol);

            DbParameter paramPassword = Conexion.dpf.CreateParameter();
            paramPassword.Value = PASSWORD;
            paramPassword.ParameterName = "PASSWORD";
            parametros.Add(paramPassword);

            DbParameter paramNombre = Conexion.dpf.CreateParameter();
            paramNombre.Value = NOMBRE;
            paramNombre.ParameterName = "NOMBRE";
            parametros.Add(paramNombre);

            DbParameter paramApellido = Conexion.dpf.CreateParameter();
            paramApellido.Value = APELLIDO;
            paramApellido.ParameterName = "APELLIDO";
            parametros.Add(paramApellido);

            DbParameter paramEmail = Conexion.dpf.CreateParameter();
            paramEmail.Value = EMAILUSUARIO;
            paramEmail.ParameterName = "EMAILUSUARIO";
            parametros.Add(paramEmail);

            DbParameter paramEstadoUsuario = Conexion.dpf.CreateParameter();
            paramEstadoUsuario.Value = ESTADOUSUARIO;
            paramEstadoUsuario.ParameterName = "ESTADOUSUARIO";
            parametros.Add(paramEstadoUsuario);

            DbParameter paramUnidad = Conexion.dpf.CreateParameter();
            paramUnidad.Value = CODUNIDAD;
            paramUnidad.ParameterName = "CODUNIDAD";
            parametros.Add(paramUnidad);

            DbParameter paramDepende = Conexion.dpf.CreateParameter();
            paramDepende.Value = DEPENDE;
            paramDepende.ParameterName = "DEPENDE";
            parametros.Add(paramDepende);

            DbParameter paramTelefono = Conexion.dpf.CreateParameter();
            paramTelefono.Value = TELEFONO;
            paramTelefono.ParameterName = "TELEFONO";
            parametros.Add(paramTelefono);
            
            
            return Conexion.ejecutaNonQuery("sp_Set_Inserta_Usuario", parametros);
        }

        public int ActualizatUsuario(string RUTUSUARIO, int CODROL, string NOMBRE, string APELLIDO, string EMAILUSUARIO, int ESTADOUSUARIO, int CODUNIDAD, String DEPENDE, string TELEFONO)
        {
            List<DbParameter> parametros = new List<DbParameter>();


            DbParameter paramRutUsuario = Conexion.dpf.CreateParameter();
            paramRutUsuario.Value = RUTUSUARIO;
            paramRutUsuario.ParameterName = "RUTUSUARIO";
            parametros.Add(paramRutUsuario);

            DbParameter paramCodRol = Conexion.dpf.CreateParameter();
            paramCodRol.Value = CODROL;
            paramCodRol.ParameterName = "CODROL";
            parametros.Add(paramCodRol);

            DbParameter paramNombre = Conexion.dpf.CreateParameter();
            paramNombre.Value = NOMBRE;
            paramNombre.ParameterName = "NOMBRE";
            parametros.Add(paramNombre);

            DbParameter paramApellido = Conexion.dpf.CreateParameter();
            paramApellido.Value = APELLIDO;
            paramApellido.ParameterName = "APELLIDO";
            parametros.Add(paramApellido);

            DbParameter paramEmail = Conexion.dpf.CreateParameter();
            paramEmail.Value = EMAILUSUARIO;
            paramEmail.ParameterName = "EMAILUSUARIO";
            parametros.Add(paramEmail);

            DbParameter paramEstadoUsuario = Conexion.dpf.CreateParameter();
            paramEstadoUsuario.Value = ESTADOUSUARIO;
            paramEstadoUsuario.ParameterName = "ESTADOUSUARIO";
            parametros.Add(paramEstadoUsuario);

            DbParameter paramUnidad = Conexion.dpf.CreateParameter();
            paramUnidad.Value = CODUNIDAD;
            paramUnidad.ParameterName = "CODUNIDAD";
            parametros.Add(paramUnidad);

            DbParameter paramDepende = Conexion.dpf.CreateParameter();
            paramDepende.Value = DEPENDE;
            paramDepende.ParameterName = "DEPENDE";
            parametros.Add(paramDepende);

            DbParameter paramTelefono = Conexion.dpf.CreateParameter();
            paramTelefono.Value = TELEFONO;
            paramTelefono.ParameterName = "TELEFONO";
            parametros.Add(paramTelefono);

            return Conexion.ejecutaNonQuery("sp_Set_Actualiza_Usuario", parametros);
        }

        public int ExisteRutUsuario_Usuario(string strRutUsuario)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_Consulta_ByRutUsuario_Usuario";
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
                    paramExisteNomPrivi.ParameterName = "RUTUSUARIO";
                    paramExisteNomPrivi.Value = strRutUsuario;
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

            public List<Usuario> BusquedaNombre(string strTextoBusqueda) {


            List<Usuario> LstBusquedaNombre = new List<Usuario>();

            string StoredProcedure = "sp_Get_Consulta_ByNombreConsulta_Usuario";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramUsuario = cmd.CreateParameter();
                    paramUsuario.DbType = DbType.String;
                    paramUsuario.ParameterName = "TEXTOBUSQUEDA";
                    paramUsuario.Value = strTextoBusqueda;
                    cmd.Parameters.Add(paramUsuario);
                    con.Open();

                    

                   
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstBusquedaNombre.Add(
                                new Usuario((string)dr["RUTUSUARIO"],
                                    (int)dr["CODROL"],
                                    (string)dr["PASSWORD"],
                                    (string)dr["NOMBRE"],
                                    (string)dr["APELLIDO"],
                                    (string)dr["EMAILUSUARIO"]));
                        }
                    }
                }
            }
            return LstBusquedaNombre;
        }

            public int EliminarUsuario(string RUTUSUARIO)
            {
                List<DbParameter> parametros = new List<DbParameter>(); ;

                DbParameter param = Conexion.dpf.CreateParameter();
                param.Value = RUTUSUARIO;
                param.ParameterName = "RUTUSUARIO";
                parametros.Add(param);

                return Conexion.ejecutaNonQuery("sp_Set_Borra_Usuario", parametros);
            }
            public int ExisteRut_FlujoSolicitud(string strRutUsuario)
            {

                int intCantidad = 0;
                string StoredProcedure = "sp_Get_Consulta_ByRut_FlujoSolicitud";
                using (DbConnection con = Conexion.dpf.CreateConnection())
                {
                    con.ConnectionString = Conexion.constr;
                    using (DbCommand cmd = Conexion.dpf.CreateCommand())
                    {


                        cmd.Connection = con;
                        cmd.CommandText = StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DbParameter paramExisteRut = cmd.CreateParameter();
                        paramExisteRut.DbType = DbType.String;
                        paramExisteRut.ParameterName = "RUTUSUARIO";
                        paramExisteRut.Value = strRutUsuario;
                        cmd.Parameters.Add(paramExisteRut);
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

            public int ActualizaPasswordUsuario(string RUTUSUARIO, string PASSWORD)
            {
                List<DbParameter> parametros = new List<DbParameter>();


                DbParameter paramRutUsuario = Conexion.dpf.CreateParameter();
                paramRutUsuario.Value = RUTUSUARIO;
                paramRutUsuario.ParameterName = "RUTUSUARIO";
                parametros.Add(paramRutUsuario);


                DbParameter paramPassword = Conexion.dpf.CreateParameter();
                paramPassword.Value = PASSWORD;
                paramPassword.ParameterName = "PASSWORD";
                parametros.Add(paramPassword);

                return Conexion.ejecutaNonQuery("sp_Set_Actualiza_ByRut_Pasword_Usuario", parametros);
            }

            public int GeneraNuevaPassword(string RUTUSUARIO, string PASSWORD, string PASSWORDMD5)
            {
                List<DbParameter> parametros = new List<DbParameter>();


                DbParameter paramRutUsuario = Conexion.dpf.CreateParameter();
                paramRutUsuario.Value = RUTUSUARIO;
                paramRutUsuario.ParameterName = "RUTUSUARIO";
                parametros.Add(paramRutUsuario);


                DbParameter paramPassword = Conexion.dpf.CreateParameter();
                paramPassword.Value = PASSWORD;
                paramPassword.ParameterName = "PASSWORD";
                parametros.Add(paramPassword);

                DbParameter paramPassword2 = Conexion.dpf.CreateParameter();
                paramPassword2.Value = PASSWORDMD5;
                paramPassword2.ParameterName = "PASSWORDMD5";
                parametros.Add(paramPassword2);

                return Conexion.ejecutaNonQuery("sp_Get_Actualiza_ByPassword_Usuario", parametros);
            }



        }
    
}