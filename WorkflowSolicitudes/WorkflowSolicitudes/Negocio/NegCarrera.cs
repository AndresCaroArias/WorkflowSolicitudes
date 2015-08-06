using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Entidades;
using WorkflowSolicitudes.Datos;

namespace WorkflowSolicitudes.Negocio
{
    public class NegCarrera
    {
        public NegCarrera() { }  

        public List<Carrera> ObtenerCarrera(){

            DatosCarreras DatoCarreras = new DatosCarreras();
            return DatoCarreras.select_All_Carreras();


        }
    }
}