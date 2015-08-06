using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegRol
    {
        public int AltaRol(string strDescripcion, int intEstadoRol)
        {
            DatosRol InsertaRol = new DatosRol();
            return InsertaRol.InsertRol(strDescripcion, intEstadoRol);
        }

        public int EliminarRol(int intCodRol)
        {
            return (new DatosRol()).EliminarRol(intCodRol);
        }

        public int ActualizarRol(int intCodRol, string strDescripcion)
        {
            DatosRol ActRol = new DatosRol();
            return ActRol.ActualizarRol(intCodRol, strDescripcion);
        }

        public int ActualizarEstRol(int intCodRol, string intEstadoRol)
        {
            DatosRol ActEstRol = new DatosRol();
            return ActEstRol.ActualizarEstadoRol(intCodRol, intEstadoRol);
        }

        public List<Rol> ObtenerRol()
        {
            DatosRol SelectRol = new DatosRol();
            return SelectRol.select_All_E_Rol();
        }

        public List<Rol> ConsultaRolByRol(int intCodRol)
        {
            DatosRol SelectRol = new DatosRol();
            return SelectRol.select_All_E_Rol_ByRol(intCodRol);
        }


        public int select_ExisteRol_Roles(string strDescripcion)
        {
            DatosRol ExiRol = new DatosRol();
            return ExiRol.ExisteRol_DescripcionDelRoles(strDescripcion);
        }

        
    }
}