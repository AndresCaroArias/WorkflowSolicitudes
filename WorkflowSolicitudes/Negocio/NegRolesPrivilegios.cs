using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegRolesPrivilegios
    {

        public List<RolesPrivilegios> ObtenerRolesPrivilegios()
        {
            DatosRolesPrivilegios DatPrivilegios = new DatosRolesPrivilegios();
            return DatPrivilegios.select_All_RolesPrivilegios();

        }

        public int EliminarRolesPrivilegios(int intCodPrivilegios, int intCodRol)
        {
            return (new DatosRolesPrivilegios()).EliminarRolesPrivilegios(intCodPrivilegios, intCodRol);
        }

        public int AltaRolesPrivilegios(int intCodPrivilegios, int intCodRol, int intEstadoRolPrivi)
        {
            DatosRolesPrivilegios InsertaRolPrivi = new DatosRolesPrivilegios();
            return InsertaRolPrivi.InsertRolesPrivilegios(intCodPrivilegios, intCodRol,  intEstadoRolPrivi);
        }

        public int select_ExisteRol_RolesPrivilegios(int intCodRol)
        {
            DatosRol ExiRolPri = new DatosRol();
            return ExiRolPri.ExisteRol_RolesPrivilegios(intCodRol);
        }

        public int ExisteUnRolyPrivilegio(int intCodRol, int intCodPrivilegio)
        {
            DatosRolesPrivilegios ExiRolPri = new DatosRolesPrivilegios();
            return ExiRolPri.ExisteElRolyPrivilegio(intCodRol, intCodPrivilegio);
        }

        public List<RolesPrivilegios> ConsultaRolByRolesPrivi(int intCodRol)
        {
            DatosRolesPrivilegios ConsultaRolByRolesPri = new DatosRolesPrivilegios();
            return ConsultaRolByRolesPri.select_All_E_Rol_ByRolesPrivilegios(intCodRol);
        }
    }
}