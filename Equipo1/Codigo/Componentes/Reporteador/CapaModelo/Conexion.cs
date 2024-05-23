using System;
using System.Data.Odbc;

namespace CapaModelo
/* AUTORES:
LUIS ALBERTO FRANCO MORAN 0901-20-23979  */
{
    public class Conexion
    {
        private string connectionString;

        public Conexion()
        {
            // Asignar el nombre de la base de datos directamente
            //string nombreBase = "BD_reporteador";
            connectionString = "Dsn=HotelSConexion";
        }

        public OdbcConnection AbrirConexion()
        {
            OdbcConnection conn = new OdbcConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (OdbcException ex)
            {
                Console.WriteLine($"Error al abrir la conexión: {ex.Message}");
                return null;
            }
        }

        public void CerrarConexion(OdbcConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}

