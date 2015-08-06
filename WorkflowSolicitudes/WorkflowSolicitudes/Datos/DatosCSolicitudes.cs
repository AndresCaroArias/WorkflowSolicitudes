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
    public class DatosCSolicitudes
    {
        public DatosCSolicitudes() { }

        public List<CSolicitudes> select_All_CDinamicaDetSol(int intTipoSolicitud,
                                                            int intTipoActividad,
                                                            int intEstado,
                                                            int intCodUnidad,
                                                            DateTime dtmFechaRecepDesde,
                                                            DateTime dtmFechaRecepHasta,
                                                            DateTime dtmFechaEjecDesde,
                                                            DateTime dtmFechaEjecHasta,
                                                            DateTime dtmFechaResolDesde,
                                                            DateTime dtmFechaResolHasta)
        {

            int intFolioSolicitudes;
            int intSecuencias;
            string strTipoSolicitudes;
            string strActividades;
            string strNombres;
            string strDetalleSolicitudes;
            string strEstados;
            DateTime dtmFechaEjecActi;
            DateTime dtmFechaVencSoli;
            int intDiasAtrasos;
            DateTime dtmFechaResolu;
            DateTime dtmFechaRecepc;
            String strDescUnidad;

            List<CSolicitudes> LstCSolicitudes = new List<CSolicitudes>();

            string StoredProcedure = "sp_Get_Consulta_ByDinamica_Actividad";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramTipoSolicitud = cmd.CreateParameter();
                    paramTipoSolicitud.DbType = DbType.Int32;
                    paramTipoSolicitud.ParameterName = "@TIPOSOLICITUD";
                    if (intTipoSolicitud == 0)
                    {
                        paramTipoSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramTipoSolicitud.Value = intTipoSolicitud;
                    }
                    cmd.Parameters.Add(paramTipoSolicitud);


                    DbParameter paramTipoActividad = cmd.CreateParameter();
                    paramTipoActividad.DbType = DbType.Int32;
                    paramTipoActividad.ParameterName = "@TIPOACTIVIDAD";
                    if (intTipoActividad == 0)
                    {
                        paramTipoActividad.Value = DBNull.Value;
                    }
                    else
                    {
                        paramTipoActividad.Value = intTipoActividad;
                    }
                    cmd.Parameters.Add(paramTipoActividad);


                    DbParameter paramEstado = cmd.CreateParameter();
                    paramEstado.DbType = DbType.Int32;
                    paramEstado.ParameterName = "@ESTADO";
                    if (intEstado == 0)
                    {
                        paramEstado.Value = DBNull.Value;
                    }
                    else
                    {
                        paramEstado.Value = intEstado;
                    }
                    cmd.Parameters.Add(paramEstado);


                    DbParameter paramCodunidad = cmd.CreateParameter();
                    paramCodunidad.DbType = DbType.Int32;
                    paramCodunidad.ParameterName = "@CODUNIDAD";
                    if (intCodUnidad == 0)
                    {
                        paramCodunidad.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodunidad.Value = intCodUnidad;
                    }
                    cmd.Parameters.Add(paramCodunidad);



                    DbParameter paramFechaRecepDesde = cmd.CreateParameter();
                    paramFechaRecepDesde.DbType = DbType.DateTime;
                    paramFechaRecepDesde.ParameterName = "@FECHARECEPCIONDESDE";
                    if (dtmFechaRecepDesde == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaRecepDesde.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaRecepDesde.Value = dtmFechaRecepDesde;
                    }
                    cmd.Parameters.Add(paramFechaRecepDesde);


                    DbParameter paramFechaRecepHasta = cmd.CreateParameter();
                    paramFechaRecepHasta.DbType = DbType.DateTime;
                    paramFechaRecepHasta.ParameterName = "@FECHARECEPCIONHASTA";
                    if (dtmFechaRecepHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaRecepHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaRecepHasta.Value = dtmFechaRecepHasta;
                    }
                    cmd.Parameters.Add(paramFechaRecepHasta);

                    DbParameter paramFechaEjecDesde = cmd.CreateParameter();
                    paramFechaEjecDesde.DbType = DbType.DateTime;
                    paramFechaEjecDesde.ParameterName = "@FECHAEJECUCIONDESDE";
                    if (dtmFechaEjecDesde == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaEjecDesde.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaEjecDesde.Value = dtmFechaEjecDesde;
                    }
                    cmd.Parameters.Add(paramFechaEjecDesde);


                    DbParameter paramFechaEjecHasta = cmd.CreateParameter();
                    paramFechaEjecHasta.DbType = DbType.DateTime;
                    paramFechaEjecHasta.ParameterName = "@FECHAEJECUCIONHASTA";
                    if (dtmFechaEjecHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaEjecHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaEjecHasta.Value = dtmFechaEjecHasta;
                    }
                    cmd.Parameters.Add(paramFechaEjecHasta);

                    DbParameter paramFechaResolDesde = cmd.CreateParameter();
                    paramFechaResolDesde.DbType = DbType.DateTime;
                    paramFechaResolDesde.ParameterName = "@FECHARESOLUCIONDESDE";
                    if (dtmFechaResolDesde == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaResolDesde.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaResolDesde.Value = dtmFechaResolDesde;
                    }
                    cmd.Parameters.Add(paramFechaResolDesde);


                    DbParameter paramFechaResolHasta = cmd.CreateParameter();
                    paramFechaResolHasta.DbType = DbType.DateTime;
                    paramFechaResolHasta.ParameterName = "@FECHARESOLUCIONHASTA";
                    if (dtmFechaResolHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaResolHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaResolHasta.Value = dtmFechaResolHasta;
                    }
                    cmd.Parameters.Add(paramFechaResolHasta);



                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes = (int)dr["FOLIOSOLICITUD"];
                            intSecuencias = (int)dr["SECUENCIA"];
                            strTipoSolicitudes = (string)dr["DESCTIPOSOLICITUD"];
                            strActividades = (string)dr["DESCRIPCION"];
                            strNombres = Convert.ToString(dr["NOMBRE"] is DBNull ? null : dr["NOMBRE"]);
                            try
                            {
                                strDetalleSolicitudes = (string)dr["GLOSADETALLESOL"];
                            }
                            catch (Exception)
                            {
                                strDetalleSolicitudes = "0";
                            }
                            strEstados = (string)dr["DESCESTADO"];
                            dtmFechaEjecActi = Convert.ToDateTime(dr["FECHAEJECACTIVIDAD"] is DBNull ? null : dr["FECHAEJECACTIVIDAD"]);
                            dtmFechaVencSoli = Convert.ToDateTime(dr["FECHAVENCSOL"] is DBNull ? null : dr["FECHAVENCSOL"]);
                            intDiasAtrasos = (int)dr["DIASATRASO"];
                            dtmFechaResolu = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            dtmFechaRecepc = Convert.ToDateTime(dr["FECHARECEP"] is DBNull ? null : dr["FECHARECEP"]);
                            strDescUnidad = Convert.ToString(dr["DESCUNIDAD"] is DBNull ? null : dr["DESCUNIDAD"]);


                            LstCSolicitudes.Add(new CSolicitudes(intFolioSolicitudes,
                                                                 intSecuencias,
                                                                strTipoSolicitudes,
                                                                strActividades,
                                                                strNombres,
                                                                strDetalleSolicitudes,
                                                                strEstados,
                                                                strDescUnidad,
                                                                dtmFechaEjecActi,
                                                                dtmFechaVencSoli,
                                                                intDiasAtrasos,
                                                                dtmFechaResolu,
                                                                dtmFechaRecepc));

                        }
                    }
                }
            }
            return LstCSolicitudes;
        }

        public List<CSolicitudes> select_All_DatCSolicitudes(int intFolio,
               string strCod_Cli,
               int intCodTipoSolicitud,
                string strCodCarrera,
                int intCodEstado,
                DateTime dtmFechaSolicitud,
                DateTime dtmFechaSolicitudHasta,
                DateTime dtmFechaResolucion,
                DateTime dtmFechaResolucionHasta,
                string strJornada,
                string strOrigen)
        {

            int intFolioSolicitudes;
            DateTime dtmFechaSolicitudes;
            string strCod_Clie;
            DateTime dtmFechaResoluciones;
            string strObsSoluciones;
            string strGlosaSoluciones;
            string strDescSolicitudes;
            string strNombres;
            string strPaternos;
            string strMaternos;
            string strNombre_Largos;
            string strDescEstados;
            string strJornadas;
            string strOrigenes;

            

            List<CSolicitudes> LstCSolicitudes = new List<CSolicitudes>();
            string StoredProcedure = "sp_Get_Consulta_ByDinamica_Solicitudes";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramFolioSolicitud = cmd.CreateParameter();
                    paramFolioSolicitud.DbType = DbType.Int32;
                    paramFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
                    if (intFolio == 0)
                    {
                        paramFolioSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFolioSolicitud.Value = intFolio;
                    }
                    cmd.Parameters.Add(paramFolioSolicitud);

                    DbParameter paramCodCli = cmd.CreateParameter();
                    paramCodCli.DbType = DbType.String;
                    paramCodCli.ParameterName = "CODCLI";
                    if (strCod_Cli == null)
                    {
                        paramCodCli.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodCli.Value = strCod_Cli;
                    }
                    cmd.Parameters.Add(paramCodCli);

                    DbParameter paramCodTipoSolicitud = cmd.CreateParameter();
                    paramCodTipoSolicitud.DbType = DbType.Int32;
                    paramCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
                    if (intCodTipoSolicitud == 0)
                    {
                        paramCodTipoSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodTipoSolicitud.Value = intCodTipoSolicitud; ;
                    }
                    cmd.Parameters.Add(paramCodTipoSolicitud);

                    DbParameter paramCodCarr = cmd.CreateParameter();
                    paramCodCarr.DbType = DbType.String;
                    paramCodCarr.ParameterName = "CODCARR";
                    if (strCodCarrera == null || strCodCarrera == "0")
                    {
                        paramCodCarr.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodCarr.Value = strCodCarrera;
                    }
                    cmd.Parameters.Add(paramCodCarr);

                    DbParameter paramCodEstadoSol = cmd.CreateParameter();
                    paramCodEstadoSol.DbType = DbType.Int32;
                    paramCodEstadoSol.ParameterName = "CODESTADOSOL";
                    if (intCodEstado == 0)
                    {
                        paramCodEstadoSol.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodEstadoSol.Value = intCodEstado;
                    }
                    cmd.Parameters.Add(paramCodEstadoSol);

                    DbParameter paramFechaSolicitud = cmd.CreateParameter();
                    paramFechaSolicitud.DbType = DbType.DateTime;
                    paramFechaSolicitud.ParameterName = "FECHASOLICITUD";
                    if (dtmFechaSolicitud == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaSolicitud.Value = dtmFechaSolicitud;
                    }
                    cmd.Parameters.Add(paramFechaSolicitud);


                    DbParameter paramFechaSolicitudHasta = cmd.CreateParameter();
                    paramFechaSolicitudHasta.DbType = DbType.DateTime;
                    paramFechaSolicitudHasta.ParameterName = "FECHASOLICITUDHASTA";
                    if (dtmFechaSolicitudHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaSolicitudHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaSolicitudHasta.Value = dtmFechaSolicitudHasta;
                    }
                    cmd.Parameters.Add(paramFechaSolicitudHasta);


                    DbParameter paramFechaResolucion = cmd.CreateParameter();
                    paramFechaResolucion.DbType = DbType.DateTime;
                    paramFechaResolucion.ParameterName = "FECHARESOLUCION";
                    if (dtmFechaResolucion == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaResolucion.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaResolucion.Value = dtmFechaResolucion;
                    }
                    cmd.Parameters.Add(paramFechaResolucion);


                    DbParameter paramFechaResolucionHasta = cmd.CreateParameter();
                    paramFechaResolucionHasta.DbType = DbType.DateTime;
                    paramFechaResolucionHasta.ParameterName = "FECHARESOLUCIONHASTA";
                    if (dtmFechaResolucionHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaResolucionHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaResolucionHasta.Value = dtmFechaResolucionHasta;
                    }
                    cmd.Parameters.Add(paramFechaResolucionHasta);


                    DbParameter paramJornada = cmd.CreateParameter();
                    paramJornada.DbType = DbType.String;
                    paramJornada.ParameterName = "JORNADA";
                    if (strJornada == null || strJornada == "0")
                    {
                        paramJornada.Value = DBNull.Value;
                    }
                    else
                    {
                        paramJornada.Value = strJornada;
                    }

                    cmd.Parameters.Add(paramJornada);

                    DbParameter paramOrigen = cmd.CreateParameter();
                    paramOrigen.DbType = DbType.String;
                    paramOrigen.ParameterName = "ORIGEN";
                    if (strOrigen == null || strOrigen == "0")
                    {
                        paramOrigen.Value = DBNull.Value;
                    }
                    else
                    {
                        paramOrigen.Value = strOrigen;
                    }
                    cmd.Parameters.Add(paramOrigen);


                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes = (int)dr["FOLIOSOLICITUD"];

                            dtmFechaSolicitudes = (DateTime)dr["FECHASOLICITUD"];
                            strCod_Clie = (string)dr["CODCLI"];
                            dtmFechaResoluciones = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            try
                            {
                                strObsSoluciones = (string)dr["OBSSOLUCION"];
                            }
                            catch (Exception)
                            {
                                strObsSoluciones = "0";
                            }

                            strObsSoluciones = Convert.ToString(dr["OBSSOLUCION"] is DBNull ? 0 : dr["OBSSOLUCION"]);
                            strGlosaSoluciones = (string)dr["GLOSASOLICITUD"];
                            strDescSolicitudes = (string)dr["DESCTIPOSOLICITUD"];
                            strNombres = Convert.ToString(dr["NOMBRE"] is DBNull ? "" : dr["NOMBRE"]);
                            strPaternos = Convert.ToString(dr["PATERNO"] is DBNull ? "" : dr["PATERNO"]);
                            strMaternos = Convert.ToString(dr["MATERNO"] is DBNull ? "" : dr["MATERNO"]);
                            strNombre_Largos = Convert.ToString(dr["NOMBRE_L"] is DBNull ? "" : dr["NOMBRE_L"]);
                            strDescEstados = (string)dr["DESCESTADO"];
                            strJornadas = Convert.ToString(dr["JORNADA"] is DBNull ? "" : dr["JORNADA"]);
                            strOrigenes = (string)dr["ORIGEN"];


                            LstCSolicitudes.Add(new CSolicitudes(intFolioSolicitudes,
                                                    dtmFechaSolicitudes,
                                                    strCod_Clie,
                                                    dtmFechaResoluciones,
                                                    strObsSoluciones,
                                                    strGlosaSoluciones,
                                                    strDescSolicitudes,
                                                    strNombres,
                                                    strPaternos,
                                                    strMaternos,
                                                    strNombre_Largos,
                                                    strDescEstados,
                                                    strJornadas,
                                                    strOrigenes
                                                    ));
                        }
                    }
                }
            }
            return LstCSolicitudes;

        }
    


    public List<CSolicitudes> select_All_DatCSolicitudesInternas(int intFolio,
                                                                  string strCod_Cli,
                                                                  int intCodTipoSolicitud,
                                                                  int intCodEstado,
                                                                  DateTime dtmFechaSolicitud,
                                                                  DateTime dtmFechaSolicitudHasta,
                                                                  DateTime dtmFechaResolucion,
                                                                  DateTime dtmFechaResolucionHasta
                                                                  )
        {

            int intFolioSolicitudes;
            DateTime dtmFechaSolicitudes;
            string strCod_Clie = String.Empty;
            DateTime dtmFechaResoluciones;
            string strObsSoluciones = String.Empty;
            string strGlosaSoluciones = String.Empty;
            string strDescSolicitudes = String.Empty;
            string strNombres = String.Empty;
            string strPaternos = String.Empty;
            string strMaternos = String.Empty;
            string strNombre_Largos = String.Empty;
            string strDescEstados = String.Empty;
            string strJornadas = String.Empty;
            string strOrigenes = String.Empty;

            

            List<CSolicitudes> LstCSolicitudes = new List<CSolicitudes>();
            string StoredProcedure = "sp_Get_Consulta_ByDinamicaInternas_Solicitudes";
            using (DbConnection con = Conexion.dpf.CreateConnection())
            {
                con.ConnectionString = Conexion.constr;
                using (DbCommand cmd = Conexion.dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter paramFolioSolicitud = cmd.CreateParameter();
                    paramFolioSolicitud.DbType = DbType.Int32;
                    paramFolioSolicitud.ParameterName = "FOLIOSOLICITUD";
                    if (intFolio == 0)
                    {
                        paramFolioSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFolioSolicitud.Value = intFolio;
                    }
                    cmd.Parameters.Add(paramFolioSolicitud);

                    DbParameter paramCodCli = cmd.CreateParameter();
                    paramCodCli.DbType = DbType.String;
                    paramCodCli.ParameterName = "CODCLI";
                    if (strCod_Cli == null)
                    {
                        paramCodCli.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodCli.Value = strCod_Cli;
                    }
                    cmd.Parameters.Add(paramCodCli);

                    DbParameter paramCodTipoSolicitud = cmd.CreateParameter();
                    paramCodTipoSolicitud.DbType = DbType.Int32;
                    paramCodTipoSolicitud.ParameterName = "CODTIPOSOLICITUD";
                    if (intCodTipoSolicitud == 0)
                    {
                        paramCodTipoSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodTipoSolicitud.Value = intCodTipoSolicitud; ;
                    }
                    cmd.Parameters.Add(paramCodTipoSolicitud);

                    DbParameter paramCodEstadoSol = cmd.CreateParameter();
                    paramCodEstadoSol.DbType = DbType.Int32;
                    paramCodEstadoSol.ParameterName = "CODESTADOSOL";
                    if (intCodEstado == 0)
                    {
                        paramCodEstadoSol.Value = DBNull.Value;
                    }
                    else
                    {
                        paramCodEstadoSol.Value = intCodEstado;
                    }
                    cmd.Parameters.Add(paramCodEstadoSol);

                    DbParameter paramFechaSolicitud = cmd.CreateParameter();
                    paramFechaSolicitud.DbType = DbType.DateTime;
                    paramFechaSolicitud.ParameterName = "FECHASOLICITUD";
                    if (dtmFechaSolicitud == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaSolicitud.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaSolicitud.Value = dtmFechaSolicitud;
                    }
                    cmd.Parameters.Add(paramFechaSolicitud);


                    DbParameter paramFechaSolicitudHasta = cmd.CreateParameter();
                    paramFechaSolicitudHasta.DbType = DbType.DateTime;
                    paramFechaSolicitudHasta.ParameterName = "FECHASOLICITUDHASTA";
                    if (dtmFechaSolicitudHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaSolicitudHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaSolicitudHasta.Value = dtmFechaSolicitudHasta;
                    }
                    cmd.Parameters.Add(paramFechaSolicitudHasta);


                    DbParameter paramFechaResolucion = cmd.CreateParameter();
                    paramFechaResolucion.DbType = DbType.DateTime;
                    paramFechaResolucion.ParameterName = "FECHARESOLUCION";
                    if (dtmFechaResolucion == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaResolucion.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaResolucion.Value = dtmFechaResolucion;
                    }
                    cmd.Parameters.Add(paramFechaResolucion);


                    DbParameter paramFechaResolucionHasta = cmd.CreateParameter();
                    paramFechaResolucionHasta.DbType = DbType.DateTime;
                    paramFechaResolucionHasta.ParameterName = "FECHARESOLUCIONHASTA";
                    if (dtmFechaResolucionHasta == Convert.ToDateTime("01/01/0001"))
                    {
                        paramFechaResolucionHasta.Value = DBNull.Value;
                    }
                    else
                    {
                        paramFechaResolucionHasta.Value = dtmFechaResolucionHasta;
                    }
                    cmd.Parameters.Add(paramFechaResolucionHasta);

                    
                    con.Open();
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            intFolioSolicitudes = (int)dr["FOLIOSOLICITUD"];

                            dtmFechaSolicitudes = (DateTime)dr["FECHASOLICITUD"];
                            strCod_Clie = (string)dr["CODCLI"];
                            dtmFechaResoluciones = Convert.ToDateTime(dr["FECHARESOLUCION"] is DBNull ? null : dr["FECHARESOLUCION"]);
                            try
                            {
                                strObsSoluciones = (string)dr["OBSSOLUCION"];
                            }
                            catch (Exception)
                            {
                                strObsSoluciones = "0";
                            }

                            strObsSoluciones = Convert.ToString(dr["OBSSOLUCION"] is DBNull ? 0 : dr["OBSSOLUCION"]);
                            strGlosaSoluciones = (string)dr["GLOSASOLICITUD"];
                            strDescSolicitudes = (string)dr["DESCTIPOSOLICITUD"];
                            strDescEstados = (string)dr["DESCESTADO"];
                            strOrigenes = (string)dr["ORIGEN"];
                            strNombres = (string)dr["NOMBRE"];
                            strPaternos = (string)dr["APELLIDO"];

                            LstCSolicitudes.Add(new CSolicitudes(intFolioSolicitudes,
                                                    dtmFechaSolicitudes,
                                                    strCod_Clie,
                                                    dtmFechaResoluciones,
                                                    strObsSoluciones,
                                                    strGlosaSoluciones,
                                                    strDescSolicitudes,
                                                    strNombres,
                                                    strPaternos,
                                                    strMaternos,
                                                    strNombre_Largos,
                                                    strDescEstados,
                                                    strJornadas,
                                                    strOrigenes
                                                    ));
                        }
                    }
                }
            }
            return LstCSolicitudes;

        }
		}
}