using System;
using System.Data;
using System.Data.Odbc;
using System.IO;

namespace CapaModelo
    /* AUTORES:
        LUIS ALBERTO FRANCO MORAN 0901-20-23979
        OTTO ADRIAN LOPEZ VENTURA 0901-20-1069  */
{
    public class Sentencias
    {
        private Conexion con;

        public Sentencias()
        {
            con = new Conexion();
        }

        // LUIS ALBERTO FRANCO MORAN 0901-20-23979
        // Insertar un nuevo registro con archivo .rpt
        public void InsertarReporte(string correlativo,string nombreArchivo, string estado, string rutaArchivo)
        {
            using (OdbcConnection connection = con.AbrirConexion())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_reportes (rep_correlativo, rep_nombre, fk_estado, rep_fecha, rep_archivo) VALUES (?, ?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@rep_correlativo", correlativo);
                                cmd.Parameters.AddWithValue("@rep_nombre", nombreArchivo);
                                cmd.Parameters.AddWithValue("@fk_estado", estado);
                                cmd.Parameters.AddWithValue("@rep_fecha", DateTime.Now);
                                cmd.Parameters.AddWithValue("@rep_archivo", rutaArchivo);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al insertar el registro: {ex.Message}");
                        }
                    }
                }
            }
        }


        // Leer registros existentes
        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        public DataTable ObtenerReportes()
        {
            using (OdbcConnection connection = con.AbrirConexion())
            {
                if (connection != null)
                {
                    string selectQuery = "SELECT pk_id_reporte, rep_correlativo, rep_nombre, fk_estado, rep_archivo ,rep_fecha, rep_fechaMod FROM reportes";
                    using (OdbcCommand cmd = new OdbcCommand(selectQuery, connection))
                    {
                        DataTable dataTable = new DataTable();
                        using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                        return dataTable;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069
        // Actualizar un registro existente
        public void ActualizarReporte(int idReporte,string nombre, string estado)
        {
    using (OdbcConnection connection = con.AbrirConexion())
    {
        if (connection != null)
        {
            using (OdbcTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    string updateQuery = "UPDATE tbl_reportes SET rep_nombre=?, fk_estado=?, rep_fechaMod=? WHERE pk_id_reporte=?";
                    using (OdbcCommand cmd = new OdbcCommand(updateQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@rep_nombre", nombre);
                        cmd.Parameters.AddWithValue("@fk_estado", estado);
                        cmd.Parameters.AddWithValue("@rep_fechaMod", DateTime.Now);
                        cmd.Parameters.AddWithValue("@pk_id_reporte", idReporte);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Error al actualizar el registro: {ex.Message}");
                }
            }
        }
    }
        }

        //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069
        // Eliminar un registro existente
        public void EliminarReporte(int idReporte)
        {
            using (OdbcConnection connection = con.AbrirConexion())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string deleteQuery = "DELETE FROM tbl_reportes WHERE pk_id_reporte=?";
                            using (OdbcCommand cmd = new OdbcCommand(deleteQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@pk_id_reporte", idReporte);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al eliminar el registro: {ex.Message}");
                        }
                    }
                }
            }
        }
        // LUIS ALBERTO FRANCO MORAN 0901-20-23979
        public DataTable llenarTbl(string tabla) //Llenar tabla de reportes
        {
            using (OdbcConnection connection = con.AbrirConexion())
            {
                if (connection != null)
                {
                    string sql = "SELECT pk_id_reporte, rep_correlativo, rep_nombre, fk_estado, rep_archivo ,rep_fecha, rep_fechaMod FROM  " + tabla + ";";
                    OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, connection);
                    DataTable table = new DataTable();
                    dataTable.Fill(table);
                    return table;
                }
                else
                {
                    return null;
                }
            }
        }

        //Llenar tabla de seguridad (Por cuestiones practicas lo implemento dentro de navegador solo para que se vea como funciona el metodo)
        //LUIS ALBERTO FRANCO MORAN 0901-20-23979 
        public DataTable llenarTblapp(string tablaapp)
        {
            using (OdbcConnection connection = con.AbrirConexion())
            {
                if (connection != null)
                {
                    string sql = "SELECT PK_id_aplicacion, nbr_nombre_aplicacion, nbr_descripcion_aplicacion, fk_no_reporteAsociado, nbr_estado_aplicacion FROM  " + tablaapp + ";";
                    OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, connection);
                    DataTable table = new DataTable();
                    dataTable.Fill(table);
                    return table;
                }
                else
                {
                    return null;
                }
            }
        }






        
    }
}


    