using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkflowSolicitudes.Datos;
using WorkflowSolicitudes.Entidades;

namespace WorkflowSolicitudes.Negocio
{
    public class NegAlumnos
    {
        public NegAlumnos() { }        
        DatosAlumnos DatAlumnos = new DatosAlumnos();

        public List<Alumnos> ObtenerInfoAlumnoByCodCli(string codcli)
        {
            DatosAlumnos DatAlumnos = new DatosAlumnos();
            return DatAlumnos.select_All_GetInfoAlumno(codcli);

        }
       


        
    }
}