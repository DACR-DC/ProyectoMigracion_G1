using System;
using System.Data;
using CapaModelo;

namespace CapaControlador
/* AUTORES:
LUIS ALBERTO FRANCO MORAN 0901-20-23979
OTTO ADRIAN LOPEZ VENTURA 0901-20-1069  */
{


    public class Controlador
    {
        private Sentencias sentencias;
        private ReporteManager reporteManager;
        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        public Controlador()
        {
            sentencias = new Sentencias();
            reporteManager = new ReporteManager();
        }

        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        // Insertar un nuevo registro con archivo de texto
        public void InsertarReporte(string correlativo, string nombreArchivo, string estado, string rutaArchivo)
        {
            sentencias.InsertarReporte(correlativo, nombreArchivo, estado, rutaArchivo);
        }
        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        // Método para obtener la ruta del informe por correlativo
        public string ObtenerRutaInformePorCorrelativo(int correlativo)
        {
            return reporteManager.ObtenerRutaInformePorCorrelativo(correlativo);
        }

        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        // Obtener todos los reportes
        public DataTable ObtenerReportes()
        {
            return sentencias.ObtenerReportes();
        }

        //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
        // Actualizar un reporte existente
        public void ActualizarReporte(int idReporte,  string nombre, string estado)
        {
            sentencias.ActualizarReporte(idReporte, nombre, estado);
        }

        //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
        // Eliminar un reporte existente
        public void EliminarReporte(int idReporte)
        {
            sentencias.EliminarReporte(idReporte);
        }

        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        // Obtener los datos de una tabla específica (llenarTbl)
        public DataTable llenarTbl(string tabla)
        {
            return sentencias.llenarTbl(tabla);
        }

        public DataTable llenarTblapl(string tabla)
        {
            return sentencias.llenarTblapp(tabla);
        }

    }
}


