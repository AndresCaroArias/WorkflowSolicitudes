using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegTareas
    {

        public NegTareas() { }  

        public List<Tareas> ObtenerTareasPendientes(string RutUsuario)        
        {
            DatosTareas DatoTareasPendientes = new DatosTareas();
            return DatoTareasPendientes.select_All_TareasPendientes(RutUsuario);
        }

        public List<Tareas> ObtenerTareasPendientesByCodUnidad(int intCodUnidad)
        {
            DatosTareas DatoTareasPendientes = new DatosTareas();
            return DatoTareasPendientes.select_All_TareasPendientesByCodUnidad(intCodUnidad);
        }



    }
}