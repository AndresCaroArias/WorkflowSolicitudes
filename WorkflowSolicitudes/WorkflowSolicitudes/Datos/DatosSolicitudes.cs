using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace WorkflowSolicitudes.Datos

{
    public class DatosSolicitudes
    {

        public DatosSolicitudes() { }

      

        public List<Solicitud> select_All_Solicitudes(string RutAlumno) 
        {

            int intFolio;
            int intCodTipoSolicitud;
            string StrDescripcionSolicitud;
            string StrRutAlumno;
            string StrCodCarrera;
            string StrDesCarrera;
            DateTime DtmFechaSolicitud;
            string StrDescEstado;
            string StrGlosaSolicitud;
            string StrObsResolucion;
            DateTime DtmFechaResolucion;
            string StrOpcion;

            List<Solicitud> LstSolicitud = new List<Solicitud>();
            string StoredProcedure = "Sp_Get_Consulta_Solicitudes";
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
                    param.Value = RutAlumno;
                    cmd.Parameters.Add(param);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolio                = (int)dr["FOLIOSOLICITUD"];
                            intCodTipoSolicitud     = (int)dr["CODTIPOSOLICITUD"];
                            StrDescripcionSolicitud = (string)dr["DESCTIPOSOLICITUD"];
                            StrRutAlumno            = (string)dr["CODCLI"];
                            StrCodCarrera           = (string)dr["CODCARR"];
                            StrDesCarrera           = (string)dr["NOMBRE_C"];
                            DtmFechaSolicitud       = (DateTime)dr["FECHASOLICITUD"];
                            StrDescEstado           = (string)dr["DESCESTADO"];
                            StrGlosaSolicitud       = (string)dr["GLOSASOLICITUD"];
                            StrObsResolucion        = Convert.ToString(dr["OBSSOLUCION"] is DBNull ? 0 : dr["OBSSOLUCION"]);
                            DtmFechaResolucion      = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            StrOpcion               = Convert.ToString(dr["OPCION"] is DBNull ? 0 : dr["OPCION"]);

                            LstSolicitud.Add( new Solicitud(intFolio,
                                                            intCodTipoSolicitud,
                                                            StrDescripcionSolicitud,
                                                            StrRutAlumno,
                                                            StrCodCarrera,
                                                            StrDesCarrera,
                                                            DtmFechaSolicitud,
                                                            StrDescEstado,
                                                            StrGlosaSolicitud,
                                                            StrObsResolucion,
                                                            DtmFechaResolucion,
                                                            StrOpcion));
                                         
                                                    }
                    }
                }
            }
            return LstSolicitud;
        
        }


        

        public List<Solicitud> select_ByFolio_Solicitudes(int intFolioSolicitud)
        {

            int intFolio;
            int intCodTipoSolicitud;
            string StrDescripcionSolicitud;
            string StrRutAlumno;
            string StrCodCarrera;
            string StrDesCarrera;
            DateTime DtmFechaSolicitud;
            string StrDescEstado;
            string StrGlosaSolicitud;
            string StrObsResolucion;
            DateTime DtmFechaResolucion;
            string StrOpcion;
            string strCelularContacto;
            string strEmailContacto;
            string strOrigen;

            List<Solicitud> LstSolicitud = new List<Solicitud>();
            string StoredProcedure = "sp_Get_Consulta_ByFolio_Solicitud";
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
                    param.ParameterName = "FOLIOSOLICITUD";
                    param.Value = intFolioSolicitud;
                    cmd.Parameters.Add(param);

                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolio                = (int)dr["FOLIOSOLICITUD"];
                            intCodTipoSolicitud     = (int)dr["CODTIPOSOLICITUD"];
                            StrDescripcionSolicitud = (string)dr["DESCTIPOSOLICITUD"];
                            StrRutAlumno            = (string)dr["CODCLI"];
                            StrCodCarrera           = (string)dr["CODCARR"];
                            StrDesCarrera           = Convert.ToString(dr["NOMBRE_C"] is DBNull ? 0 : dr["NOMBRE_C"]);
                            DtmFechaSolicitud       = (DateTime)dr["FECHASOLICITUD"];
                            StrDescEstado           = (string)dr["DESCESTADO"];
                            StrGlosaSolicitud       = (string)dr["GLOSASOLICITUD"];
                            StrObsResolucion        = Convert.ToString(dr["OBSSOLUCION"] is DBNull ? 0 : dr["OBSSOLUCION"]);
                            DtmFechaResolucion      = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            StrOpcion               = Convert.ToString(dr["OPCION"] is DBNull ? 0 : dr["OPCION"]);
                            strCelularContacto      = (string)dr["CELULARDECONTACTO"];
                            strEmailContacto        = (string)dr["EMAILCONTACTO"];
                            strOrigen               = (string)dr["ORIGEN"]; 

                            LstSolicitud.Add(new Solicitud( intFolio,
                                                            intCodTipoSolicitud,
                                                            StrDescripcionSolicitud,
                                                            StrRutAlumno,
                                                            StrCodCarrera,
                                                            StrDesCarrera,
                                                            DtmFechaSolicitud,
                                                            StrDescEstado,
                                                            StrGlosaSolicitud,
                                                            StrObsResolucion,
                                                            DtmFechaResolucion,
                                                            StrOpcion,
                                                            strCelularContacto,
                                                            strEmailContacto,
                                                            strOrigen
                                                            ));

                        }
                    }
                }
            }
            return LstSolicitud;

        }

        public int ValidaExisteAnulacion(int intFolioSolicitud)                
        {

            int intEstaAnulado = 0;
            string StoredProcedure = "sp_get_ExisteAnula_Solicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {


                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIntFolioSolicitud = cmd.CreateParameter();
                    paramIntFolioSolicitud.DbType = DbType.Int32;
                    paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
                    paramIntFolioSolicitud.Value = intFolioSolicitud;
                    cmd.Parameters.Add(paramIntFolioSolicitud);

                    con.Open();
                    
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intEstaAnulado = (int)dr["CANTIDAD"];

                        }

                    }

                    return intEstaAnulado;
                }
            }
        }


        public int ValidaSiExistenSolicitudEjecutando(int intCodTipoSolicitud)
        {

            int intCantidad = 0;
            string StoredProcedure = "sp_Get_ValidaProcesoEjecucion_Solicitud";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramIntCodTipoSolicitud = cmd.CreateParameter();
                    paramIntCodTipoSolicitud.DbType = DbType.Int32;
                    paramIntCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
                    paramIntCodTipoSolicitud.Value = intCodTipoSolicitud;
                    cmd.Parameters.Add(paramIntCodTipoSolicitud);

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

        public int AnulaSolicitud(int intFolioSolicitud)
        {

            List<DbParameter> parametros = new List<DbParameter>(); ;

            DbParameter paramIntFolioSolicitud = Conexion.dpf.CreateParameter();
            paramIntFolioSolicitud.Value = intFolioSolicitud;
            paramIntFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
            parametros.Add(paramIntFolioSolicitud);

            return Conexion.ejecutaNonQuery("sp_get_anula_solicitud", parametros);
        }


       


       public List<Solicitud> InsertaSolicitud(int cod_tipo_solicitud, 
                                        string  rut_alumno, 
                                        string  cod_carrera, 
                                        string  celularContacto, 
                                        string  emailcontacto , 
                                        string  glosa_solicitud,
                                        string  origen )
        {
         

             List<Solicitud> LstSolicitud = new List<Solicitud>();
            using (SqlConnection conexion = new SqlConnection(Conexion.constr))
{
            SqlCommand cmd = new SqlCommand("sp_Set_Insertar_Solicitudes", conexion);
            //SqlCommand cmd = new SqlCommand("sp_Set_Inserta_Solicitud", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@CODTIPOSOLICITUD", cod_tipo_solicitud));
            cmd.Parameters.Add(new SqlParameter("@CODCLI", rut_alumno));
            cmd.Parameters.Add(new SqlParameter("@CODCARR", cod_carrera));
            cmd.Parameters.Add(new SqlParameter("@CELULARDECONTACTO", celularContacto));
            cmd.Parameters.Add(new SqlParameter("@EMAILCONTACTO", emailcontacto));
            cmd.Parameters.Add(new SqlParameter("@GLOSASOLICITUD", glosa_solicitud));
            cmd.Parameters.Add(new SqlParameter("@ORIGEN", origen));

            SqlParameter NroInscritosParametro = new SqlParameter("@FOLIOSOLICITUD_OUT", 0);
            NroInscritosParametro.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(NroInscritosParametro);

            SqlParameter dtmFechaVencSolParam = new SqlParameter("@FECHAVENCSOL_OUT", SqlDbType.DateTime);
            dtmFechaVencSolParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dtmFechaVencSolParam);        
   
           conexion.Open();
           cmd.ExecuteNonQuery();                                        
   
           int nroFolio = Int32.Parse(cmd.Parameters["@FOLIOSOLICITUD_OUT"].Value.ToString());
           DateTime dtmFechaVencimientoSol = DateTime.Parse(cmd.Parameters["@FECHAVENCSOL_OUT"].Value.ToString());
           LstSolicitud.Add(new Solicitud(nroFolio, dtmFechaVencimientoSol));


           conexion.Close();

           return LstSolicitud;
        }
        }      


        

        public int ValidaCantidadSolicitud (   int  cod_tipo_solicitud)
        {

            using (SqlConnection conexion = new SqlConnection(Conexion.constr))
        {
            SqlCommand cmd = new SqlCommand("sp_Set_ValidaCantidad_Solicitud", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@CODTIPOSOLICITUD", cod_tipo_solicitud));
            
            SqlParameter NroInscritosParametro = new SqlParameter("@CANTIDAD", 0);
            NroInscritosParametro.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(NroInscritosParametro);
   
           conexion.Open();
           cmd.ExecuteNonQuery();                                        
   
           int nroFolio = Int32.Parse(cmd.Parameters["@CANTIDAD"].Value.ToString());
           conexion.Close();
    
          return nroFolio;

        }
     }


}
}