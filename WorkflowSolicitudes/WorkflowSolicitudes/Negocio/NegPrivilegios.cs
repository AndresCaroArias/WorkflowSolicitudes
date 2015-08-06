using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegPrivilegios
    {
        DatosPrivilegios DatPrivilegios = new DatosPrivilegios();

        public List<Privilegios>ObtenerPrivilegios()
        {
            DatosPrivilegios DatPrivilegios = new DatosPrivilegios();
            return DatPrivilegios.select_All_Privilegios();

        }

        public List<Privilegios> ObtenerPrivbyRol(int intCodRol)
        {
            DatosPrivilegios DatPrivilegios = new DatosPrivilegios();
            return DatPrivilegios.select_Privilegios_por_Rol(intCodRol);

        }
        public int ExistePrivilegio_RolesPrivilegios(int intCodPrivilegios)
        {
            DatosPrivilegios ExiPri = new DatosPrivilegios();
            return ExiPri.ExistePrivilegio_RolesPrivilegios(intCodPrivilegios);
        }

        public int AltaPrivilegios(string strDescripcion, string strNomPrivilegios, int intEstadoPrivilegios)
        {
            DatosPrivilegios InsertaPrivi = new DatosPrivilegios();
            return InsertaPrivi.InsertPrivilegios(strDescripcion, strNomPrivilegios, intEstadoPrivilegios);
        }

        public int ActualizarPrivilegios(int intCodPrivilegios, string strDescPrivilegios, string strNomPrivilegios, int intEstadoPrivilegios)
        {
            DatosPrivilegios ActPrivi = new DatosPrivilegios();
            return ActPrivi.ActualizarPrivilegios(intCodPrivilegios, strDescPrivilegios, strNomPrivilegios, intEstadoPrivilegios);
        }

        public int ActualizarEstPrivilegios(int intCodPrivilegios, int intEstadoPrivilegios)
        {
            DatosPrivilegios ActEstPri = new DatosPrivilegios();
            return ActEstPri.ActualizarEstadoPrivilegios(intCodPrivilegios, intEstadoPrivilegios);
        }

        public int EliminarPrivilegios(int intCodPrivilegios)
        {
            return (new DatosPrivilegios()).EliminarPrivilegios(intCodPrivilegios);
        }

        public int select_ExistePrivi_Privi(string strDescripcion)
        {
            DatosPrivilegios ExiPrivi = new DatosPrivilegios();
            return ExiPrivi.ExistePrivilegio_Privilegios(strDescripcion);
        }

        public int select_ExistePrivi_NomPrivi(string strNomPrivilegios)
        {
            DatosPrivilegios ExiPrivi = new DatosPrivilegios();
            return ExiPrivi.ExistePrivilegio_NomPrivilegios(strNomPrivilegios);
        }

    }
}