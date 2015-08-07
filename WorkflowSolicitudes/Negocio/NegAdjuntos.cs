using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegAdjuntos
    {
        public int AltaAdjuntos(int intFolio, string strNombreArchivo, byte[] bteArchivoPdf, string strTipoAdjunto, int intSecuencia)
        {
            DatosAdjutos DatAdjuntos = new DatosAdjutos();
            return DatAdjuntos.InsertAdjuntos(intFolio, strNombreArchivo, bteArchivoPdf, strTipoAdjunto, intSecuencia);
        }

        public List<Adjuntos> Obtener(int intIdArchivo)
        {
            DatosAdjutos SelectAdjuntos = new DatosAdjutos();
            return SelectAdjuntos.select_All_E_Adjuntos(intIdArchivo);
        }

        public List<Adjuntos> ObtenerFolioTipo(int intFolio, string strTipoAdjunto)
        {
            DatosAdjutos SelectAdjuntos = new DatosAdjutos();
            return SelectAdjuntos.select_All_ByFolio_TipoAdjuntos(intFolio, strTipoAdjunto);
        }

        public int ExistirianAdjutnos(int intFolio)
        {
            DatosAdjutos AdjuntosExisten = new DatosAdjutos();
            int intExiste = AdjuntosExisten.ExistenAdjuntos(intFolio);
            return intExiste;
        }

        public List<Adjuntos> ObtenerAdjuntosFolioTipoSecuencia(int intFolio, string strTipoAdjunto, int intSecuencia)
        {
            DatosAdjutos SelectAdjuntos = new DatosAdjutos();
            return SelectAdjuntos.select_All_ByFolio_TipoAdjuntos_Secuencia(intFolio, strTipoAdjunto, intSecuencia);
        }

    }
}