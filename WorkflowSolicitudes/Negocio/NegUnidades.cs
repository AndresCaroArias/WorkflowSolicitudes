using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegUnidades
    {
        public int AltaUnidades(string strDescripcionUnidad, int intEstadoUnidad)
        {
            DatosUnidades InsertaUnides = new DatosUnidades();
            return InsertaUnides.InsertUnidades(strDescripcionUnidad, intEstadoUnidad);
        }

        public int ActualizarUnidad(int intCodUnidad, string strDescripcionUnidad, int intEstadoUnidad)
        {
            DatosUnidades ActUnidad = new DatosUnidades();
            return ActUnidad.ActualizarUnidad(intCodUnidad, strDescripcionUnidad, intEstadoUnidad);
        }

        public List<Unidades> ObtenerUnidades()
        {
            DatosUnidades SelectUnidades = new DatosUnidades();
            return SelectUnidades.select_All_E_Unidades();
        }

        public List<Unidades> ConsultaByCodUnidadUnidades(int intCodUnidad)
        {
            DatosUnidades SelectUnidades = new DatosUnidades();
            return SelectUnidades.select_All_E_ByCodUnidad_Unidades(intCodUnidad);
        }

        public int select_ExisteDescUnid_Unidad(string strDescripcionUnidad)
        {
            DatosUnidades ExesteUnidad = new DatosUnidades();
            return ExesteUnidad.ExisteDescripcionUnidad_Unidades (strDescripcionUnidad);
        }
    }
}