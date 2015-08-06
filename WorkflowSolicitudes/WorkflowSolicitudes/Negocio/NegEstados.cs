using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegEstados
    {
        public NegEstados() { }  

        public List<Estados> ObtenerEstados(){

            DatosEstados DatoEstados = new DatosEstados();
            return DatoEstados.select_All_Estados();


        }



    }
}