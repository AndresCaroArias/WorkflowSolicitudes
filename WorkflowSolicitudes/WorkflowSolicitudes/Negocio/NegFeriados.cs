using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegFeriados
    {
        public List<Feriados> ObtenerFeriados()
        {
            DatosFeriados DatFeriados = new DatosFeriados();
            return DatFeriados.select_All_Feriados();

        }

        public int select_ExisteCodFeriado_Feriado(int intCodFeriado)
        {
            DatosFeriados ExiFeriado = new DatosFeriados();
            return ExiFeriado.ExisteCodFeriado_Feriado(intCodFeriado);
        }

        public int AltaFeriados(string strDescFeriado, DateTime dtmFechaFeriado)
        {
            DatosFeriados InsertaFeriados = new DatosFeriados();
            return InsertaFeriados.InsertFeriados(strDescFeriado, dtmFechaFeriado);
        }

        public int EliminarFeriado(int intCodFeriado)
        {
            return (new DatosFeriados()).EliminarFeriado(intCodFeriado);
        }

        public int ActualizarFeria(int intCodFeriado, string strDescFeriado,DateTime dtmFechaFeriado)
        {
            DatosFeriados ActPrivi = new DatosFeriados();
            return ActPrivi.ActualizarFeriado(intCodFeriado, strDescFeriado, dtmFechaFeriado);
        }
    }
}