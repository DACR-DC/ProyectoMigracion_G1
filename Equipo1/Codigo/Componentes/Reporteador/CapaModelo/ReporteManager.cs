using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
namespace CapaModelo
{
    public class ReporteManager
    {
        public Conexion conexion;

        public ReporteManager()
        {
            conexion = new Conexion();
        }

        // Método para obtener la ruta del informe por correlativo
        public string ObtenerRutaInformePorCorrelativo(int correlativo)
        {
            using (OdbcConnection connection = conexion.AbrirConexion())
            {
                if (connection != null)
                {
                    string selectQuery = "SELECT rep_archivo FROM tbl_reportes WHERE rep_correlativo = ?";
                    using (OdbcCommand cmd = new OdbcCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@correlativo", correlativo);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            return result.ToString();
                        }
                    }
                }   
                return null;
            }
        }
    }
}
