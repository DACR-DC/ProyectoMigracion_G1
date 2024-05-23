using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Security.Policy;
using CapaModeloERP.clases;

namespace CapaModeloERP
{
    //David Carrillo  0901-20-3201 
    public class Producto
    {
        public int CodProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PrecioUnitario { get; set; }

    }
    public class Sentencias
    {
        Conexion con = new Conexion();

        //Andrea Corado 0901-20-2841
        public OdbcDataAdapter CargarDatos(string tabla)
        {
           string query = "SELECT * FROM " + tabla + ";";
           OdbcDataAdapter data = new OdbcDataAdapter(query, con.connection());
           return data;
        }
        //Andrea Corado    0901-20-2841

        public OdbcDataAdapter BuscarProv(string tabla, string columna, string dato, string columna2, string dato2, string columna3, string dato3)
        {
            string consulta = $"SELECT * FROM {tabla} WHERE {columna} = '{dato}' OR {columna2} = '{dato2}' OR {columna3} = '{dato3}'";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());
            return datos;
        }

        public OdbcDataAdapter filtrarDatosp(string tabla, string columna, string dato, string columna2, string dato2)
        {
            string consulta = $"SELECT * FROM {tabla} WHERE {columna} = '{dato}' AND {columna2} <> {dato2};";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());
            return datos;
        }

        //Andrea Corado    0901-20-2841
        public void guardarDatos(string nofact,string banmov,string tipomov,string numov,string conceptomov)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar en la primera tabla 
                           /* string insertQuery1 = "INSERT INTO tbl_encabezadomovpro (id_prove,fecha_MovPro,total_MovPro) VALUES (?,?,?)";
                            using (OdbcCommand cmd1 = new OdbcCommand(insertQuery1, connection, transaction))
                            {
                                cmd1.Parameters.AddWithValue("@id_prove", idp);
                                cmd1.Parameters.AddWithValue("@fecha_MovPro", fechamov);
                                cmd1.Parameters.AddWithValue("@itotal_MovPro", totalmov);
                                cmd1.ExecuteNonQuery();
                            }*/

                            // Insertar en la segunda tabla 
                            string insertQuery2 = "INSERT INTO tbl_detallemovpro (noFactura,banco_MovP,tipo_MovP,numero_MovP,concepto_MovP)VALUES (?,?,?,?,?)";
                            using (OdbcCommand cmd2 = new OdbcCommand(insertQuery2, connection, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@noFactura", nofact);
                                cmd2.Parameters.AddWithValue("@banco_MovP", banmov);
                                cmd2.Parameters.AddWithValue("@tipo_MovP", tipomov);
                                cmd2.Parameters.AddWithValue("@numero_MovP", numov);
                                cmd2.Parameters.AddWithValue("@concepto_MovP", conceptomov);
                                cmd2.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al guardar los datos: {ex.Message}");
                        }
                    }
                }
            }

        }

        //Andrea Corado 0901-20-2841
        public DataTable ActualizarDatos( string tabla, string columna,string dato1,string columna2, int igualA)
        {
            string consulta = $"UPDATE {tabla} SET {columna} = {dato1} WHERE {columna2} = {igualA};";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());

            DataTable dt = new DataTable();
            datos.Fill(dt);

            return dt;
        }

        //Andrea Corado 0901-20-2841
        public DataTable obtenerfac()
        {

            string sql = "SELECT NoFactura FROM tbl_facturaxpagar;";

            OdbcCommand command = new OdbcCommand(sql, con.connection());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }

        //Andrea Corado 0901-20-2841
        public List<string> ComboFillfactura(string columna, string tabla,string nit, string dato, string estadofact)
        {
            List<string> datos = new List<string>();
            try
            {

                string consulta = $"SELECT {columna} FROM {tabla} WHERE {nit}={dato} AND {estadofact}=0";

                OdbcCommand command = new OdbcCommand(consulta, con.connection());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader[columna].ToString();
                    datos.Add(ID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return datos;
        }

        //Andrea Corado 0901-20-2841
        public DateTime ObtenerFechaV(string dato)
        {
            string sql = $"SELECT fechavenc_facxpag FROM tbl_facturaxpagar WHERE NoFactura = {dato};";

            using (OdbcConnection connection = con.connection())
            {
                connection.Open();

                using (OdbcCommand command = new OdbcCommand(sql, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Convertir el resultado a DateTime y devolverlo
                        return Convert.ToDateTime(result);
                    }
                    else
                    {
                        throw new Exception("No se encontró la fecha de vencimiento para la factura especificada.");
                    }
                }
            }
        }

        //andrea corado 0901-20-2841
        public (DateTime, decimal) ObtenerFechaVYTotal(string dato)
        {
            string sql = $"SELECT fechavenc_facxpag, totalfac_facxpag FROM tbl_facturaxpagar WHERE NoFactura = {dato};";
            DateTime fechaVencimiento;
            decimal total;

            using (OdbcConnection connection = con.connection())
            {
                using (OdbcCommand command = new OdbcCommand(sql, connection))
                {
                    using (OdbcDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fechaVencimiento = reader.GetDateTime(0);
                            total = reader.GetDecimal(1);
                            return (fechaVencimiento, total);
                        }
                        else
                        {
                            throw new Exception("No se encontró la factura especificada.");
                        }
                    }
                }
            }
        }

        //Andrea Cecilia Corado Paiz 0901-20-2841
        public void InsertarOperacion(int idp, string fechaabono, double totalope)
        {
            using (OdbcConnection conn = con.connection())
            {

                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se inserta la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_encabezadomovpro(id_prove,fecha_MovPro,total_MovPro) VALUES (?,?,?)";
                        cmd.Parameters.AddWithValue("@id_prove", idp);
                        cmd.Parameters.AddWithValue("@fecha_MovPro", fechaabono);
                        cmd.Parameters.AddWithValue("@total_MovPro", totalope);
                        
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al insertar la orden de compra: " + ex.Message);
                    }
                }
            }
        }

        //Andrea Cecilia Corado Paiz 0901-20-2841
        public void InsertarDetalleOperacionPro(int numfact, string banco, string tipomov, string numdoc, string concepto)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se inserta el detalle de la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_detallemovpro(noFactura,banco_MovP,tipo_MovP,numero_MovP,concepto_MovP) VALUES (?,?,?,?,?)";
                        cmd.Parameters.AddWithValue("@noFactura", numfact);
                        cmd.Parameters.AddWithValue("@banco_MovP", banco);
                        cmd.Parameters.AddWithValue("@tipo_MovP", tipomov);
                        cmd.Parameters.AddWithValue("@numero_MovP", numdoc);
                        cmd.Parameters.AddWithValue("@concepto_MovP", concepto);
                        cmd.ExecuteNonQuery();
                        // Se confirma 
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar el detalle de la orden de compra: " + ex.Message);
                    }
                }
            }
        }



        //David Carrillo 0901-20-3201 
        public void InsertarCliente(string nombre_cl, string apellido_cl, string direccion_cl, string correo_cl, string telefono_cl)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_clientes (nombre_cl, apellido_cl, direccion_cl, correo_cl, telefono_cl) VALUES (?, ?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nombre_cl", nombre_cl);
                                cmd.Parameters.AddWithValue("@apellido_cl", apellido_cl);
                                cmd.Parameters.AddWithValue("@direccion_cl", direccion_cl);
                                cmd.Parameters.AddWithValue("@correo_cl", correo_cl);
                                cmd.Parameters.AddWithValue("@telefono_cl", telefono_cl);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al guardar el cliente: {ex.Message}");
                        }
                    }
                }
            }
        }

        
        //David Carrillo 0901-20-3201 
        public void InsertarCoti(int No_Cotizacion, string fecha_coti, string fechaFinal_coti, string Solicitud)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_cotizaciones (No_Cotizacion, fecha_coti, fechaFinal_coti,Solicitud) VALUES (?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@No_Cotizacion", No_Cotizacion);
                                cmd.Parameters.AddWithValue("@fecha_coti", fecha_coti);
                                cmd.Parameters.AddWithValue("@fechaFinal_coti", fechaFinal_coti);
                                cmd.Parameters.AddWithValue("@Solicitud",  Solicitud);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al guardar la cotización: {ex.Message}");
                        }
                    }
                }
            }
        }


        public void INSVentasPedido(int id_vendedor, int tbl_detalle_cotizacion_id)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_ventaspedido (id_vendedor, tbl_cotizaciones_No_Cotizacion) VALUES (?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id_vendedor", id_vendedor);
                                cmd.Parameters.AddWithValue("@tbl_cotizaciones_No_Cotizacion", tbl_detalle_cotizacion_id);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al guardar el pedido: {ex.Message}");
                        }
                    }
                }
            }
        }
        //David Carrillo 0901-20-3201 
        public List<string> ComboFill(string columna, string tabla)
        {
            List<string> datos = new List<string>();
            try
            {

                string consulta = $"SELECT {columna} FROM {tabla}";

                OdbcCommand command = new OdbcCommand(consulta, con.connection());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader[columna].ToString();
                    datos.Add(ID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return datos;
        }
        //David Carrillo 0901-20-3201
        public DataTable ObtenerPagosPorFecha(DateTime fechaPago)
        {
            DataTable dtPagos = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT p.id_pagoFact AS IDPago, " +
                                  "p.noFactura AS NoFactura, " +
                                  "p.cliente AS Cliente, " +
                                  "p.banco AS Banco, " +
                                  "p.concepto AS Concepto, " +
                                  "p.monto_pago AS MontoPago, " +
                                  "p.extra_pago AS ExtraPago, " +
                                  "p.fecha_pago AS FechaPago, " +
                                  "p.NIT AS NIT, " +
                                  "p.num_recibo AS NumRecibo " +
                                  "FROM tbl_pagofact p " +
                                  "WHERE p.fecha_pago BETWEEN ? AND ? " +
                                  "ORDER BY p.fecha_pago DESC";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("fechaPago", fechaPago);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dtPagos);
                }
            }

            return dtPagos;
        }
        //David Carrillo 0901-20-3201 
        public double GetPrecio(string nombreProducto)
        {
            double precioUnitario = 0.0;
            OdbcConnection connection = null;

            try
            {
                connection = con.connection();
                if (connection != null)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string selectQuery = "SELECT precioUnitario_prod FROM tbl_producto WHERE nombre_prod = ?";

                    using (OdbcCommand command = new OdbcCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@nombreProducto", nombreProducto);

                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            precioUnitario = Convert.ToDouble(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el precio unitario del producto: " + ex.Message);
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return precioUnitario;
        }
        //David Carrillo 0901-20-3201 
        public string ObtenerCliente(string nombrecliente)
        {
            try
            {
                using (OdbcConnection connection = con.connection())
                {
                    using (OdbcCommand cmd = new OdbcCommand("SELECT id_cliente FROM tbl_clientes WHERE nombre_cl= ?", connection))
                    {
                        cmd.Parameters.Add(new OdbcParameter("nombre_cliente", nombrecliente));
                        string descripcion = cmd.ExecuteScalar().ToString();
                        return descripcion;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null; 
            }
        }
        //David Carrillo   0901-20-3201 
       
        public string ObtenerUltimoDato(string dato, string tabla, string dato2)
        {
            try
            {
                using (OdbcConnection connection = con.connection())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    using (OdbcCommand cmd = new OdbcCommand($"SELECT {dato} FROM {tabla} ORDER BY {dato2} DESC LIMIT 1", connection))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string ultimoIdCoti = result.ToString();
                            return ultimoIdCoti;
                        }
                        else
                        {
                            return $"No hay dato registrado";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        //David Carrillo 0901-20-3201 
        public void InsertarDetalleCoti(int id_cliente, int cantidad_coti, int No_Cotizacion, int cod_producto, double total_detCoti)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_detalle_cotizacion (tbl_clientes_id_cliente, cantidad_coti, tbl_cotizaciones_No_Cotizacion, tbl_producto_cod_producto, total_detCoti) VALUES (?, ?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                                cmd.Parameters.AddWithValue("@cantidad_coti", cantidad_coti);
                                cmd.Parameters.AddWithValue("@No_Cotizacion", No_Cotizacion);
                                cmd.Parameters.AddWithValue("@cod_producto", cod_producto);
                                cmd.Parameters.AddWithValue("@total_detCoti", total_detCoti);
                               
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al guardar el detalle de la cotización: {ex.Message}");
                        }
                    }
                }
            }
        }
        //David Carrillo
        public void InsertarPagoFacXCobrar(string noFactura, int cliente, string banco, string concepto, double monto_pago, double extra_pago, string fecha_pago, string NIT, string num_recibo)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_pagofact (noFactura, cliente, banco, concepto, monto_pago, extra_pago, fecha_pago, NIT, num_recibo) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@noFactura", noFactura);
                                cmd.Parameters.AddWithValue("@cliente", cliente);
                                cmd.Parameters.AddWithValue("@banco", banco);
                                cmd.Parameters.AddWithValue("@concepto", concepto);
                                cmd.Parameters.AddWithValue("@monto_pago", monto_pago);
                                cmd.Parameters.AddWithValue("@extra_pago", extra_pago);
                                cmd.Parameters.AddWithValue("@fecha_pago", fecha_pago);
                                cmd.Parameters.AddWithValue("@NIT", NIT);
                                cmd.Parameters.AddWithValue("@num_recibo", num_recibo);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al guardar el pago de la factura: {ex.Message}");
                        }
                    }
                }
            }
        }
        public double CalcularPorPagar(string noFactura)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string queryTotal = "SELECT total_facxcob FROM tbl_facturaxcobrar WHERE NoFactura = ?";
                    double totalFacxCob = 0.0;

                    using (OdbcCommand cmdTotal = new OdbcCommand(queryTotal, connection))
                    {
                        cmdTotal.Parameters.AddWithValue("@NoFactura", noFactura);
                        object totalResult = cmdTotal.ExecuteScalar();
                        totalFacxCob = totalResult != DBNull.Value ? Convert.ToDouble(totalResult) : 0.0;
                    }
                    string queryPagos = "SELECT COALESCE(SUM(monto_pago), 0) FROM tbl_pagofact WHERE noFactura = ?";
                    double totalPagos = 0.0;

                    using (OdbcCommand cmdPagos = new OdbcCommand(queryPagos, connection))
                    {
                        cmdPagos.Parameters.AddWithValue("@noFactura", noFactura);
                        object pagosResult = cmdPagos.ExecuteScalar();
                        totalPagos = pagosResult != DBNull.Value ? Convert.ToDouble(pagosResult) : 0.0;
                    }

                    double porPagar = totalFacxCob - totalPagos;
                    return porPagar >= 0 ? porPagar : 0.0;
                }
                return 0.0;
            }
        }
        public void ActualizarFaltantePago(string noFactura, double faltantePago)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string query = "UPDATE tbl_facturaxcobrar SET faltante_pago = ? WHERE NoFactura = ?";

                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@faltante_pago", faltantePago);
                        cmd.Parameters.AddWithValue("@NoFactura", noFactura);

                       // connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    if (faltantePago == 0)
                    {
                        string updateEstadoQuery = "UPDATE tbl_facturaxcobrar SET estado_facxcob = 'FACTURA PAGADA' WHERE NoFactura = ?";

                        using (OdbcCommand cmd = new OdbcCommand(updateEstadoQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@NoFactura", noFactura);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public bool FacturaExiste(string noFactura)
        {
            using (OdbcConnection connection = con.connection())
            {
                string query = "SELECT COUNT(*) FROM tbl_pagofact WHERE noFactura = ?";
                using (OdbcCommand cmd = new OdbcCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@noFactura", noFactura);
                    //connection.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        //David Carrillo 0901-20-3201
        public void ActualizarExistencias(int idProducto, int cantidad)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string query = "UPDATE tbl_existencias SET cantidad = cantidad - ? WHERE tbl_producto_id_producto = ?";

                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@idProducto", idProducto);

                        //connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }



        //David Carrillo 0901-20-3201
        public void ActCoti(int No_Cotizacion)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string updateQuery = "UPDATE tbl_cotizaciones SET Solicitud = ? WHERE No_Cotizacion = ?";
                            using (OdbcCommand cmd = new OdbcCommand(updateQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Solicitud", "Pedido");
                                cmd.Parameters.AddWithValue("@No_Cotizacion", No_Cotizacion);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al actualizar el detalle de la cotización: {ex.Message}");
                        }
                    }
                }
            }
        }
        //David Carrillo 0901-20-3201 
        public int ObtenerCodigoProducto(string nombreProducto)
        {
            int codigoProducto = 0;

            try
            {
                using (OdbcConnection connection = con.connection())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string query = "SELECT cod_producto FROM tbl_producto WHERE nombre_prod = ?";
                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        cmd.Parameters.Add(new OdbcParameter("nombre_producto", nombreProducto));
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            codigoProducto = Convert.ToInt32(result);
                        }
                    } 
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el código del producto: " + ex.Message);
            }

            return codigoProducto;
        }

        //David Carrillo 0901-20-3201 
        public DataTable BuscarDato(string ObtenerDato, string tabla, string DatodeColumna, int igualA)
        {
            string consulta = $"SELECT {ObtenerDato} FROM {tabla} WHERE {DatodeColumna} ={igualA} ";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());

            DataTable dt = new DataTable();
            datos.Fill(dt);

            return dt; 
        }

        //David Carrillo 0901-20-3201
        public void InsertarFactura( double total_facxcob, string tiempoPago_facxcob, string estado_facxcob, int tbl_Ventas_detalle_id_ventas_det, int tbl_Clientes_id_cliente, string fecha_factura, double faltante_pago)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_facturaxcobrar ( total_facxcob, tiempoPago_facxcob, estado_facxcob, tbl_Ventas_detalle_id_ventas_det, tbl_Clientes_id_cliente, fecha_factura, faltante_pago) VALUES ( ?, ?, ?, ?, ?, ?,?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@total_facxcob", total_facxcob);
                                cmd.Parameters.AddWithValue("@tiempoPago_facxcob", tiempoPago_facxcob);
                                cmd.Parameters.AddWithValue("@estado_facxcob", estado_facxcob);
                                cmd.Parameters.AddWithValue("@tbl_Ventas_detalle_id_ventas_det", tbl_Ventas_detalle_id_ventas_det);
                                cmd.Parameters.AddWithValue("@tbl_Clientes_id_cliente", tbl_Clientes_id_cliente);
                                cmd.Parameters.AddWithValue("@fecha_factura", fecha_factura);
                                cmd.Parameters.AddWithValue("@faltante_pago", faltante_pago);
                                
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Error al insertar factura: {ex.Message}");
                        }
                    }
                }
            }
        }

        // Otto Adrian Lopez Ventura
        public DataTable BuscarVendedor(string tabla, string columna, string dato)
        {
            string consulta = $"SELECT * FROM {tabla} WHERE {columna} = '{dato}'";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());

            DataTable dt = new DataTable();
            datos.Fill(dt);

            return dt;
        }
        // Otto Adrian Lopez Ventura

        public DataTable BuscarCotizacion(string tabla, string columna, string dato)
        {
            string consulta = $"SELECT * FROM {tabla} WHERE {columna} = '{dato}'";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());

            DataTable dt = new DataTable();
            datos.Fill(dt);

            return dt;
        }

        // carlos enrique modulo bancos
        public List<string> llenarCombo(string columna1, string tabla)
        {
            List<string> datos = new List<string>();
            try
            {

                string consulta = $"SELECT {columna1} FROM {tabla}";

                OdbcCommand command = new OdbcCommand(consulta, con.connection());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ID = reader[columna1].ToString();
                    datos.Add(ID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return datos;

        }

        // carlos enrique modulo bancos
        public DataTable Buscar(string tabla, string columna, string dato)
        {
            string consulta = $"SELECT * FROM {tabla} WHERE {columna} = '{dato}'";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());

            DataTable dt = new DataTable();
            datos.Fill(dt);

            return dt;
        }

        // carlos enrique modulo bancos
        public bool Guardar(string tabla, Dictionary<string, object> valores)
        {


            using (OdbcConnection conn = con.connection())
            {
                string columnas = string.Join(", ", valores.Keys);
                string parametros = string.Join(", ", valores.Keys.Select(key => "?"));
                string consulta = $"INSERT INTO {tabla} ({columnas}) VALUES ({parametros})";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    foreach (var kvp in valores)
                    {
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }


        }

        public bool ActualizarC(string tabla, Dictionary<string, object> valores, string condicion)
        {
            using (OdbcConnection conn = con.connection())
            {
                string setClause = string.Join(", ", valores.Keys.Select(key => $"{key} = ?"));
                string consulta = $"UPDATE {tabla} SET {setClause} WHERE {condicion}";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    foreach (var kvp in valores)
                    {
                        cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }


        // carlos enrique modulo bancos
        public bool ActualizarSaldoCuentaBancaria(int idCuenta, double monto, bool esDeposito)
        {
            string operador = esDeposito ? "+" : "-";
            string consulta = $"UPDATE tbl_cuentaBancaria SET saldoDisponible = saldoDisponible {operador} ? WHERE id_cuentaBancaria = ?";

            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.Parameters.AddWithValue("@id_cuenta", idCuenta);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // carlos enrique guzman cabrera
        public OdbcDataAdapter llenartablabitacoraMB(string consulta)// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            //string sql = "SELECT * FROM " + tabla + "  ;";
            string sql = consulta;

            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.connection());
            return dataTable;
        }

        // carlos enrique guzman cabrera
        public DataTable BuscarMB(string strfiltro)
        {
            string consulta = $"SELECT * FROM tbl_movimientodebancos WHERE fecha_movimientoBanco = '{strfiltro}'";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());

            DataTable dt = new DataTable();
            datos.Fill(dt);

            return dt;
        }

        // carlos enrique guzman cabrera
        public bool EliminarMovimiento(int idMovimiento)
        {
            using (OdbcConnection conn = con.connection())
            {
                string consulta = "DELETE FROM tbl_movimientoDeBancos WHERE id_movimientoBanco = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("idMovimiento", idMovimiento);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // carlos enrique guzman cabrera
        public bool EliminarRegistroAO(int idRegistro)
        {
            using (OdbcConnection conn = con.connection())
            {
                string consulta = "DELETE FROM tbl_autorizacionordenescompra WHERE id_numeroDeAutorizacion = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("id_numeroDeAutorizacion", idRegistro);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // carlos enrique guzman cabrera
        public DataTable ObtenerRegistrosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtRegistros = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                //string consulta = "SELECT * FROM tbl_movimientoDeBancos WHERE fecha_movimientoBanco BETWEEN ? AND ? ORDER BY fecha_movimientoBanco DESC";

                string consulta = "SELECT mb.id_movimientoBanco AS ID, " +
                  "cm.concepto_movimientoBanco AS Concepto, " +
                  "cb.nombre_empresa AS Cuenta, " +
                  "mb.fecha_movimientoBanco AS Fecha, " +
                  "mb.monto_movimientoBanco AS Monto, " +
                  "mb.efecto_movimientoBanco AS Efecto, " +
                  "mb.tipo_movimientoBanco AS Codigo_movimiento, " +
                  "mb.cuenta_movimientoBanco AS Codigo_de_cuenta " +
                  "FROM tbl_movimientoDeBancos mb " +
                  "INNER JOIN tbl_conceptoMovimientoDeBancos cm ON mb.tipo_movimientoBanco = cm.id_conceptoMovimiento " +
                  "INNER JOIN tbl_cuentaBancaria cb ON mb.cuenta_movimientoBanco = cb.id_cuentaBancaria " +
                  "WHERE mb.fecha_movimientoBanco BETWEEN ? AND ? " +
                  "ORDER BY mb.fecha_movimientoBanco DESC";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dtRegistros);
                }
            }

            return dtRegistros;
        }

        // carlos enrique guzman cabrera
        public DataTable ObtenerRegistrosPorFechaAO(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtRegistros = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                //string consulta = "SELECT * FROM tbl_movimientoDeBancos WHERE fecha_movimientoBanco BETWEEN ? AND ? ORDER BY fecha_movimientoBanco DESC";

                string consulta = "SELECT ao.id_numeroDeAutorizacion AS ID, " +
                   "ao.tbl_OrdenesCompra_id_OrdComp AS Codigo_orden, " +
                   "ao.estadoOrden AS Estado, " +
                   "ao.conceptoDeAutorizacion AS Observaciones, " +
                   "ao.fechaAutorizacion AS Fecha, " +
                   "ao.subTotal AS Subtotal, " +
                   "ao.iva AS IVA, " +
                   "ao.totalOrden AS Total, " +
                   "cb.nombre_empresa AS Cuenta_asociada " +
                   "FROM tbl_AutorizacionOrdenesCompra ao " +
                   "INNER JOIN tbl_cuentaBancaria cb ON ao.cuentaAsociada = cb.id_cuentaBancaria " + // Aquí añadí un espacio después de 'id_cuentaBancaria'
                   "WHERE ao.fechaAutorizacion BETWEEN ? AND ? " + // Corregí el WHERE clause
                   "ORDER BY ao.fechaAutorizacion DESC"; // Corregí el ORDER BY clause


                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dtRegistros);
                }
            }

            return dtRegistros;
        }

        //Carol Chuy Modulo de Compras
        public string[] llenarCmbprod()
        {
            string[] Campos = new string[300];
            string[] auto = new string[300];
            int i = 0;
            string sql = "SELECT cod_producto, nombre_prod FROM tbl_producto;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.connection());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Campos[i] = reader.GetValue(0).ToString() + "-" + reader.GetValue(1).ToString();
                    i++;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo"); }
            return Campos;
        }

        public OdbcDataAdapter filtrarDatos(string tabla, string columna, string dato)
        {
            string consulta = $"SELECT * FROM {tabla} WHERE {columna} = '{dato}';";
            OdbcDataAdapter datos = new OdbcDataAdapter(consulta, con.connection());
            return datos;
        }

        //Carol Chuy Modulo de Compras
        public DataTable obtenerprod()
        {

            string sql = "SELECT cod_producto, nombre_prod FROM tbl_producto;";

            OdbcCommand command = new OdbcCommand(sql, con.connection());
            OdbcDataAdapter adaptador = new OdbcDataAdapter(command);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }

        //Carol Chuy Modulo de Compras
        public int ObtenerUltimoNumeroOrden(string campoid, string tabla)
        {
            int ultimoNumeroOrden = 0;
            Conexion con = new Conexion();
            OdbcConnection conn = con.connection();

            // Conectar a la base de datos utilizando la clase Conexion
            using (conn)
            {
                // Consulta SQL para obtener el último número de orden
                string query = "SELECT MAX(" + campoid + ") FROM " + tabla + ";";
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        ultimoNumeroOrden = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        ultimoNumeroOrden++;
                    }
                }
            }

            // 'conn' se cerrará automáticamente
            return ultimoNumeroOrden;
        }

        //Carol Chuy Modulo de Compras
        //Buscar todo de cualquier tabla
        public OdbcDataAdapter llenarTablas(string tabla)
        {
            string sql = "SELECT * FROM " + tabla + ";";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.connection());
            return dataTable;
        }

        //Carol Chuy Modulo de Compras
        public string ObtenerDescripcion(string productId)
        {
            string descripcion = string.Empty;
            using (OdbcConnection conn = con.connection())
            {
                string query = "SELECT descripcion_prod FROM tbl_producto WHERE cod_producto = " + productId + ";";
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", productId);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        descripcion = result.ToString();
                    }
                }
            }
            return descripcion;
        }

        //Carol Chuy Modulo de Compras
        public decimal ObtenerPrecioUnitario(string productId)
        {
            decimal precioUnitario = 0;
            using (OdbcConnection conn = con.connection())
            {
                string query = "SELECT precioUnitario_prod FROM tbl_producto WHERE cod_producto = " + productId + ";";
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", productId);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        precioUnitario = Convert.ToDecimal(result);
                    }
                }
            }
            return precioUnitario;
        }

        //Carol Chuy Modulo de Compras
        public string ObtenerNombreProveedor(string proveedorID)
        {
            string query = "SELECT nombre_prov FROM tbl_proveedor WHERE id_prov = " + proveedorID + ";";

            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }

            return string.Empty; // Se irá aquí en caso de no encontrar al proveedor
        }

        //Carol Chuy Modulo de Compras
        public string ObtenerDomicilioProveedor(string proveedorID)
        {
            string query = "SELECT domicilio_prov FROM tbl_proveedor WHERE id_prov = " + proveedorID + ";";

            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }

            return string.Empty;
        }

        //Carol Chuy Modulo de Compras
        public string ObtenerTelefonoProveedor(string proveedorID)
        {
            string query = "SELECT telefono_prov FROM tbl_proveedor WHERE id_prov = " + proveedorID + ";";

            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }

            return string.Empty;
        }

        //Carol Chuy Modulo de Compras
        public string ObtenerNitProveedor(string proveedorID)
        {
            string query = "SELECT nit_prov FROM tbl_proveedor WHERE id_prov = " + proveedorID + ";";

            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        return result.ToString();
                    }
                }
            }

            return string.Empty;
        }

        //Carol Chuy Modulo de Compras
        public OdbcDataAdapter llenarTablasCondicion(string tabla)
        {
            string sql = "SELECT * FROM " + tabla + " WHERE recibidoIgualSolicitado_EncComp=1;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.connection());
            return dataTable;
        }
        // Diego marroquin Modulo de banco 

        public void InsertarMovimiento(string valorMovimiento, string descripcionMovimiento, string numCuenta, string tipoTransaccion, string estado, string valorTrans, string estadoConciliacion)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_movimientosbancarios (movban_valor_transaccion, movban_descripcion_transaccion, fk_movban_num_cuenta, fk_movban_tipo_transaccion, fk_movban_valorTrans, movban_status, movban_fecha_de_ingreso, manag_status_conciliacion) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@movban_valor_transaccion", valorMovimiento);
                                cmd.Parameters.AddWithValue("@movban_descripcion_transaccion", descripcionMovimiento);
                                cmd.Parameters.AddWithValue("@fk_movban_num_cuenta", numCuenta);
                                cmd.Parameters.AddWithValue("@fk_movban_tipo_transaccion", tipoTransaccion);
                                cmd.Parameters.AddWithValue("@fk_movban_valorTrans", valorTrans);
                                cmd.Parameters.AddWithValue("@movban_status", estado);
                                cmd.Parameters.AddWithValue("@movban_fecha_de_ingreso", DateTime.Now);
                                cmd.Parameters.AddWithValue("@manag_status_conciliacion", estadoConciliacion);

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
        public OdbcDataAdapter llenartablatipodecambio(string tabla)
        {
            // Construye la consulta SQL para obtener los datos de la tabla tbl_tipocambio
            string sql = "SELECT tc.id_tipo_cambio AS ID, " +
                         "tc.moneda_origen AS 'Moneda Origen', " +
                         "tc.moneda_destino AS 'Moneda Destino', " +
                         "tc.cantidad AS 'Cantidad', " +
                         "tc.valor_calculado AS 'Valor Calculado', " +
                         "tc.total_calculado AS 'Total Calculado', " +
                         "tc.fecha AS 'Fecha' " +
                         "FROM " + tabla + " tc";

            // Crea un objeto OdbcDataAdapter y le pasa la consulta SQL y la conexión
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.connection());

            // Retorna el objeto OdbcDataAdapter con los datos obtenidos
            return dataTable;
        }


        public decimal CalcularSaldoTotal()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT movban_valor_transaccion FROM tbl_movimientosbancarios;";
                    using (OdbcCommand cmd = new OdbcCommand(sql, connection))
                    {
                        OdbcDataReader reader = cmd.ExecuteReader();
                        decimal saldoTotal = 0;
                        if (reader.HasRows) // Verificar si la consulta tiene resultados
                        {
                            while (reader.Read())
                            {
                                if (reader.IsDBNull(0))
                                {
                                    continue; // Salta si el valor es nulo
                                }
                                string valorStr = reader[0].ToString();
                                if (decimal.TryParse(valorStr, out decimal valorDecimal))
                                {
                                    saldoTotal += valorDecimal;
                                }
                            }
                        }
                        return saldoTotal;
                    }
                }
                return 0; // Devuelve 0 si no se puede conectar a la base de datos
            }
        }


        public DataTable LlenarTabla(string tabla)
        {

            string connectionString = "Dsn=HotelSConexion";
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM " + tabla + ";";
                    OdbcDataAdapter dataAdapter = new OdbcDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (OdbcException ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error al cargar datos: " + ex.Message);
                    return null;
                }
            }
        }

        public DataTable LlenarTablaMoneda(string tabla)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT regmon_id_Moneda, regmon_Tipo_moneda, regmon_Valor_moneda, regmon_fecha_de_registro, regmon_status FROM " + tabla + ";";
                    OdbcDataAdapter dataAdapter = new OdbcDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                else
                {
                    return null;
                }
            }
        }
        public DataTable valorTransaccion()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT movtm_valor_transaccion FROM tbl_mantenimientos_tipo_movimiento;";
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

        public void InsertarTipoMoneda(string TipoMoneda, string ValorMoneda, string estado)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string insertQuery = "INSERT INTO tbl_registro_moneda (regmon_Tipo_moneda, regmon_Valor_moneda, regmon_fecha_de_registro, regmon_status) VALUES (?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@regmon_Tipo_moneda", TipoMoneda);
                                cmd.Parameters.AddWithValue("@regmon_Valor_moneda", ValorMoneda);
                                cmd.Parameters.AddWithValue("@regmon_fecha_de_registro", DateTime.Now);
                                cmd.Parameters.AddWithValue("@regmon_status", estado);

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


        public DataTable ObtenerTiposMoneda()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT mon_nomMoneda FROM tbl_monedabanco;";
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

        public DataTable ObtenerCuentas()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT manac_numero_de_cuenta FROM tbl_mantenimientos_agregar_cuenta;";
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

        public DataTable TipoTransaccionBancaria()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT movtm_transacciones_existentes  FROM tbl_mantenimientos_tipo_movimiento;";
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
        public DataTable ObtenerBancos()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT manag_nombre_banco FROM tbl_mantenimientos_agregar_bancos;";
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

        public DataTable ObtenerTipoCuenta()
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string sql = "SELECT movtm_transacciones_existentes FROM tbl_mantenimientos_tipo_movimiento;";
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
        public int ObtenerValorTransaccion(string tipoTransaccion)
        {
            int valorTransaccion = 0; // Valor predeterminado (por ejemplo, pasivo)

            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string query = "SELECT movtm_valor_transaccion FROM tbl_mantenimientos_tipo_movimiento WHERE movtm_transacciones_existentes = ?";
                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", tipoTransaccion);
                        OdbcDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            valorTransaccion = reader.GetInt32(0);
                        }
                    }
                }
            }

            return valorTransaccion;
        }
        //Carol Chuy Modulo Compras
        public DataTable ObtenerProveedorPorID(int id)
        {
            DataTable proveedorData = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT nombre_prov, domicilio_prov, telefono_prov FROM tbl_proveedor WHERE id_prov = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        adapter.Fill(proveedorData);
                    }
                }
            }

            return proveedorData;
        }
        //Carol Chuy Modulo Compras
        public void InsertarOrdenCompra(int codigo, string fechasolicitud, string fechaentrega, string depa, double subtotal, double iva, double total, string notas, int codProv)
        {
            using (OdbcConnection conn = con.connection())
            {

                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se inserta la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_ordenescompra(id_OrdComp,fechaSolicitid_OrdComp,fechaEntrega_OrdComp,deptoSolicitante_OrdComp,subTotal_OrdComp,iva_OrdComp,totalOrden_OrdComp,notas_OrdComp,tbl_proveedor_id_prov) VALUES (?,?, ?, ?, ?, ?, ?, ?, ?)";
                        cmd.Parameters.AddWithValue("@id_OrdComp", codigo);
                        cmd.Parameters.AddWithValue("@fechaSolicitid_OrdComp", fechasolicitud);
                        cmd.Parameters.AddWithValue("@fechaEntrega_OrdComp", fechaentrega);
                        cmd.Parameters.AddWithValue("@deptoSolicitante_OrdComp", depa);
                        cmd.Parameters.AddWithValue("@subTotal_OrdComp", subtotal);
                        cmd.Parameters.AddWithValue("@iva_OrdComp", iva);
                        cmd.Parameters.AddWithValue("@totalOrden_OrdComp", total);
                        cmd.Parameters.AddWithValue("@notas_OrdComp", notas);
                        cmd.Parameters.AddWithValue("@tbl_proveedor_id_prov", codProv);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al insertar la orden de compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Modulo Compras
        public void InsertarDetalleOrdenCompra(int codigoOrden, int codigo, int cantidad, double totalfila, int idproducto)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se inserta el detalle de la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_detalleordenescompra(id_detalle,OrdenesCompra_id_OrdComp,cantidad_det,totalProducto_det,tbl_Producto_cod_producto) VALUES (?,?, ?, ?, ?)";
                        cmd.Parameters.AddWithValue("@id_detalle", codigoOrden);
                        cmd.Parameters.AddWithValue("@OrdenesCompra_id_OrdComp", codigo);
                        cmd.Parameters.AddWithValue("@cantidad_det", cantidad);
                        cmd.Parameters.AddWithValue("@totalProducto_det", totalfila);
                        cmd.Parameters.AddWithValue("@tbl_Producto_cod_producto", idproducto);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar el detalle de la orden de compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Modulo Compras
        public OdbcDataAdapter llenarTablasCondicionFactura(int codigo)
        {
            string sql = "SELECT * FROM tbl_detallecompras WHERE tbl_Encabezado_Compras_id_EncComp=" + codigo + ";";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.connection());
            return dataTable;
        }
        //Carol Chuy Modulo Compras
        public string ObtenerNombre(string productId)
        {
            string descripcion = string.Empty;
            using (OdbcConnection conn = con.connection())
            {
                string query = "SELECT nombre_prod FROM tbl_producto WHERE cod_producto = " + productId + ";";
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", productId);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        descripcion = result.ToString();
                    }
                }
            }
            return descripcion;
        }

        // DIEGO DISPONIBLILIDAD DIARIA

        public OdbcDataAdapter BuscarBanco(string nombreBanco, string estadoBanco)
        {
            Conexion con = new Conexion();
            string query = "SELECT nombre_banco, estado_banco FROM tbl_banco WHERE nombre_banco = ? AND estado_banco = ?";

            using (OdbcConnection connection = con.connection())
            {
                OdbcCommand command = new OdbcCommand(query, connection);
                command.Parameters.AddWithValue("@nombreBanco", nombreBanco);
                command.Parameters.AddWithValue("@estadoBanco", estadoBanco);

                OdbcDataAdapter adapter = new OdbcDataAdapter(command);
                return adapter;
            }
        }

        // Jimena Tobías - Logística
        public List<ProductoM> ObtenerProductos()
        {
            List<ProductoM> productos = new List<ProductoM>();
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string query = "select * from tbl_producto";
                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        OdbcDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int cod = reader.GetInt32(0);
                            string fecha = reader.GetString(1);
                            string nombre = reader.GetString(2);
                            string descripcion = reader.GetString(3);
                            double precio = reader.GetDouble(4);
                            int marca = reader.GetInt32(5);
                            int linea = reader.GetInt32(6);
                            int cantidad = 0;
                            ProductoM newPrd = new ProductoM(cod, nombre, descripcion, precio, marca, linea, cantidad);
                            productos.Add(newPrd);
                        }
                    }
                    Console.WriteLine("error");
                }
                con.disconnect(connection);
            }
            return productos;
        }

        // Jimena Tobías - Logística
        public List<Sucursal> ObtenerSucursales()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string query = "select * from tbl_sucursales";
                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        OdbcDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string cod = reader.GetString(0);
                            string nombre = reader.GetString(1);
                            string dir = reader.GetString(2);
                            string telefono = reader.GetString(3);
                            string correo = reader.GetString(4);
                            Sucursal suc = new Sucursal(cod, nombre, dir, telefono, correo);
                            sucursales.Add(suc);
                        }
                    }
                    Console.WriteLine("error");
                }
                con.disconnect(connection);
            }
            return sucursales;
        }

        // Jimena Tobías - Logística
        public void TrasladoProducto(int idOrigen, int idDestino, int idProducto, int cantidad)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    string query = "CALL TransferirProducto('" + idOrigen + "','" + idDestino + "','" + idProducto + "','" + cantidad + "')";
                    using (OdbcCommand cmd = new OdbcCommand(query, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("error");
                }
                con.disconnect(connection);
            }
        }

        //Carol Chuy Compras
        public DataTable ObtenerOrdenPorID(int id)
        {
            DataTable ordenData = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT fechaSolicitid_OrdComp, fechaEntrega_OrdComp,deptoSolicitante_OrdComp,tbl_proveedor_id_prov FROM tbl_ordenescompra WHERE id_OrdComp = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        adapter.Fill(ordenData);
                    }
                }
            }

            return ordenData;
        }
        //Carol Chuy Compras
        public void InsertarCompra(int codigo, string fechas, string fechae, string depa, double subtotal, double iva, double totalCompra, string notas, int codigoprov, int estadoCompra, string fechap, int codorden)
        {
            using (OdbcConnection conn = con.connection())
            {

                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se inserta la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_compras(id_EncComp,fechaSolicitid_EncComp,fechaEntrega_OrdComp,deptoSolicitante_EncComp,subTotal_EncComp,iva_EncComp,totalOrden_EncComp,notas_EncComp,tbl_proveedor_id_prov,recibidoIgualSolicitado_EncComp,fechaVencimientoPago_EncComp,id_OrdComp) VALUES (?,?, ?, ?, ?, ?, ?, ?, ?,?, ?, ?)";
                        cmd.Parameters.AddWithValue("@id_EncComp", codigo);
                        cmd.Parameters.AddWithValue("@fechaSolicitid_EncComp", fechas);
                        cmd.Parameters.AddWithValue("@fechaEntrega_OrdComp", fechae);
                        cmd.Parameters.AddWithValue("@deptoSolicitante_EncComp", depa);
                        cmd.Parameters.AddWithValue("@subTotal_EncComp", subtotal);
                        cmd.Parameters.AddWithValue("@iva_EncComp", iva);
                        cmd.Parameters.AddWithValue("@totalOrden_EncComp", totalCompra);
                        cmd.Parameters.AddWithValue("@notas_EncComp", notas);
                        cmd.Parameters.AddWithValue("@tbl_proveedor_id_prov", codigoprov);
                        cmd.Parameters.AddWithValue("@recibidoIgualSolicitado_EncComp", estadoCompra);
                        cmd.Parameters.AddWithValue("@fechaVencimientoPago_EncComp", fechap);
                        cmd.Parameters.AddWithValue("@id_OrdComp", codorden);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al insertar la compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void InsertarDetalleCompra(int codDetalle, int cantidad, double totalfila, int idprod, int codigo)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se inserta el detalle de la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_detallecompras(id_detalleCompra,cantidad_compra_det,totalPorProducto_det,tbl_Producto_cod_producto,tbl_Encabezado_Compras_id_EncComp) VALUES (?,?, ?, ?, ?)";
                        cmd.Parameters.AddWithValue("@id_detalleCompra", codDetalle);
                        cmd.Parameters.AddWithValue("@cantidad_compra_det", cantidad);
                        cmd.Parameters.AddWithValue("@totalPorProducto_det", totalfila);
                        cmd.Parameters.AddWithValue("@tbl_Producto_cod_producto", idprod);
                        cmd.Parameters.AddWithValue("@tbl_Encabezado_Compras_id_EncComp", codigo);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar el detalle de la compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void InsertarFactura(int codigo, string nombrep, string nitp, string fechaV, string fechaA, double subtotal, double iva, double totalCompra, int estado, string notas, int codcompra)
        {
            using (OdbcConnection conn = con.connection())
            {

                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se inserta la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_facturaxpagar(NoFactura,nombreprov_facxpag,nitprov_facxpag,fechavenc_facxpag,fecha_abono,subtotal_facxpag,iva_facxpag,totalfac_facxpag,estado_facxpag,notas_facxpag,tbl_Encabezado_Compras_id_EncComp) VALUES (?,?, ?, ?, ?, ?, ?, ?, ?,?, ?)";
                        cmd.Parameters.AddWithValue("@NoFactura", codigo);
                        cmd.Parameters.AddWithValue("@nombreprov_facxpag", nombrep);
                        cmd.Parameters.AddWithValue("@nitprov_facxpag", nitp);
                        cmd.Parameters.AddWithValue("@fechavenc_facxpag", fechaV);
                        cmd.Parameters.AddWithValue("@fecha_abono", fechaA);
                        cmd.Parameters.AddWithValue("@subtotal_facxpag", subtotal);
                        cmd.Parameters.AddWithValue("@iva_facxpag", iva);
                        cmd.Parameters.AddWithValue("@totalfac_facxpag", totalCompra);
                        cmd.Parameters.AddWithValue("@estado_facxpag", estado);
                        cmd.Parameters.AddWithValue("@notas_facxpag", notas);
                        cmd.Parameters.AddWithValue("@tbl_Encabezado_Compras_id_EncComp", codcompra);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al insertar la factura: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void InsertarDetalleFactura(int codDetalle, int cantidad, double totalfila, int codigo, int idprod)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se inserta el detalle de la orden de compra
                        cmd.CommandText = "INSERT INTO tbl_detallefacturaxpagar(id_detalleFac,cantidad_detalleFac,totalPorProducto_detalleFac,tbl_facturaXPagar_NoFactura,tbl_Producto_cod_producto) VALUES (?,?, ?, ?, ?)";
                        cmd.Parameters.AddWithValue("@id_detalleFac", codDetalle);
                        cmd.Parameters.AddWithValue("@cantidad_detalleFac", cantidad);
                        cmd.Parameters.AddWithValue("@totalPorProducto_detalleFac", totalfila);
                        cmd.Parameters.AddWithValue("@tbl_facturaXPagar_NoFacturao", codigo);
                        cmd.Parameters.AddWithValue("@tbl_Producto_cod_producto", idprod);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al insertar el detalle de la factura: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public DataTable ObtenerFactPorID(int id)
        {
            DataTable ordenData = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT fechaVencimientoPago_EncComp FROM tbl_compras WHERE id_EncComp = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        adapter.Fill(ordenData);
                    }
                }
            }

            return ordenData;




        }
        // DIego MArroquin 
                              
        public OdbcDataAdapter llenartablabitacoradispodiaria(string tabla)
        {
            // Construye la consulta SQL para obtener los datos de la tabla tbl_disponibilidaddiaria
            string sql = "SELECT dd.id_disponibilidad AS ID, " +
                         "cb.nombre_empresa AS Cuenta, " +
                         "ba.nombre_banco AS Banco, " +
                         "dd.saldo_disponible AS 'Saldo Disponible', " +
                         "dd.saldo_consumido AS 'Saldo Consumido', " +
                         "dd.saldo_actual AS 'Saldo Actual', " +
                         "dd.fecha_DisponibilidadDiaria AS 'Fecha' " +
                         "FROM " + tabla + " dd " +
                         "INNER JOIN tbl_cuentaBancaria cb ON dd.id_cuentaDisponibilidad = cb.id_cuentaBancaria " +
                         "INNER JOIN tbl_banco ba ON dd.id_bancoActual = ba.id_banco";

            // Crea un objeto OdbcDataAdapter y le pasa la consulta SQL y la conexión
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.connection());

            // Retorna el objeto OdbcDataAdapter con los datos obtenidos
            return dataTable;
        }
        public bool EliminarDisponibilidadDiaria(int idDisponibilidad)
        {
            using (OdbcConnection conn = con.connection())
            {
                string consulta = "DELETE FROM tbl_disponibilidaddiaria WHERE id_disponibilidad = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("idDisponibilidad", idDisponibilidad); // Usa el nombre correcto del parámetro
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        //Carol Chuy Compras
        public DataTable ObtenerOrdenesCompraPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtOrdenesCompra = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT oc.id_OrdComp AS ID, " +
                                  "oc.fechaSolicitid_OrdComp AS FechaSolicitud, " +
                                  "oc.fechaEntrega_OrdComp AS FechaEntrega, " +
                                  "oc.deptoSolicitante_OrdComp AS DepartamentoSolicitante, " +
                                  "oc.subTotal_OrdComp AS SubTotal, " +
                                  "oc.iva_OrdComp AS IVA, " +
                                  "oc.totalOrden_OrdComp AS TotalOrden, " +
                                  "oc.notas_OrdComp AS Notas, " +
                                  "oc.tbl_proveedor_id_prov AS IDProveedor " +
                                  "FROM tbl_ordenescompra oc " +
                                  "WHERE oc.fechaSolicitid_OrdComp BETWEEN ? AND ? " +
                                  "ORDER BY oc.fechaSolicitid_OrdComp DESC";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dtOrdenesCompra);
                }
            }

            return dtOrdenesCompra;
        }
        // Carol Chuy Compras
        public DataTable ObtenerComprasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtCompras = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT c.id_EncComp AS ID, " +
                                  "c.fechaSolicitid_EncComp AS FechaSolicitud, " +
                                  "c.fechaEntrega_OrdComp AS FechaEntrega, " +
                                  "c.deptoSolicitante_EncComp AS DepartamentoSolicitante, " +
                                  "c.subTotal_EncComp AS SubTotal, " +
                                  "c.iva_EncComp AS IVA, " +
                                  "c.totalOrden_EncComp AS TotalOrden, " +
                                  "c.notas_EncComp AS Notas, " +
                                  "c.tbl_proveedor_id_prov AS IDProveedor, " +
                                  "c.recibidoIgualSolicitado_EncComp AS RecibidoIgualSolicitado, " +
                                  "c.fechaVencimientoPago_EncComp AS FechaVencimientoPago, " +
                                  "c.id_OrdComp AS IDOrdenCompra " +
                                  "FROM tbl_compras c " +
                                  "WHERE c.fechaSolicitid_EncComp BETWEEN ? AND ? " +
                                  "ORDER BY c.fechaSolicitid_EncComp DESC";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dtCompras);
                }
            }

            return dtCompras;
        }
        //Carol Chuy Compras
        public DataTable ObtenerFacturasPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtFacturas = new DataTable();

            using (OdbcConnection conn = con.connection())
            {
                string consulta = "SELECT f.NoFactura AS NoFactura, " +
                                  "f.nombreprov_facxpag AS NombreProveedor, " +
                                  "f.nitprov_facxpag AS NITProveedor, " +
                                  "f.fechavenc_facxpag AS FechaVencimiento, " +
                                  "f.fecha_abono AS FechaAbono, " +
                                  "f.subtotal_facxpag AS Subtotal, " +
                                  "f.iva_facxpag AS IVA, " +
                                  "f.totalfac_facxpag AS TotalFactura, " +
                                  "f.estado_facxpag AS Estado, " +
                                  "f.notas_facxpag AS Notas, " +
                                  "f.tbl_Encabezado_Compras_id_EncComp AS IDEncabezadoCompra " +
                                  "FROM tbl_facturaxpagar f " +
                                  "WHERE f.fecha_abono BETWEEN ? AND ? " +
                                  "ORDER BY f.fecha_abono DESC";

                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    OdbcDataAdapter adapter = new OdbcDataAdapter(cmd);
                    adapter.Fill(dtFacturas);
                }
            }

            return dtFacturas;
        }
        //Carol Chuy Compras
        public void EliminarOrdenCompra(int codigo)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se elimina la orden de compra
                        cmd.CommandText = "DELETE FROM tbl_ordenescompra WHERE id_OrdComp = ?";
                        cmd.Parameters.AddWithValue("@id_OrdComp", codigo);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la orden de compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void EliminarDetalleOrdenCompra(int codigoOrden)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se elimina el detalle de la orden de compra
                        cmd.CommandText = "DELETE FROM tbl_detalleordenescompra WHERE OrdenesCompra_id_OrdComp = ?";
                        cmd.Parameters.AddWithValue("@OrdenesCompra_id_OrdComp", codigoOrden);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar el detalle de la orden de compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void EliminarCompra(int codigo)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se elimina la orden de compra
                        cmd.CommandText = "DELETE FROM tbl_compras WHERE id_EncComp = ?";
                        cmd.Parameters.AddWithValue("@id_EncComp", codigo);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void EliminarDetalleCompra(int codigoCompra)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se elimina el detalle de la orden de compra
                        cmd.CommandText = "DELETE FROM tbl_detallecompras WHERE tbl_Encabezado_Compras_id_EncComp = ?";
                        cmd.Parameters.AddWithValue("@tbl_Encabezado_Compras_id_EncComp", codigoCompra);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar el detalle de la compra: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void EliminarFactura(int codigo)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia la transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Se elimina la orden de compra
                        cmd.CommandText = "DELETE FROM tbl_facturaxpagar WHERE NoFactura = ?";
                        cmd.Parameters.AddWithValue("@NoFactura", codigo);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, se hace rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la factura: " + ex.Message);
                    }
                }
            }
        }
        //Carol Chuy Compras
        public void EliminarDetalleFactura(int codigoFactura)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Se inicia una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Se elimina el detalle de la orden de compra
                        cmd.CommandText = "DELETE FROM tbl_detallefacturaxpagar WHERE tbl_facturaXPagar_NoFactura = ?";
                        cmd.Parameters.AddWithValue("@tbl_facturaXPagar_NoFactura", codigoFactura);
                        cmd.ExecuteNonQuery();

                        // Se confirma la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar el detalle de la factura: " + ex.Message);
                    }
                }
            }
        }
        public string ObtenerIdProd(string nit)
        {
            string nitr = string.Empty;
            using (OdbcConnection conn = con.connection())
            {
                string query = "SELECT id_prov FROM tbl_proveedor WHERE nit_prov = " + nit + ";";
                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("nit_prov", nit);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        nitr = result.ToString();
                    }
                }
            }
            return nitr;
        }
        public void ActualizarOrdenCompra(int idOrdenCompra, string fechaSolicitud, string fechaEntrega, string deptoSolicitante, double subtotal, double iva, double total, string notas, int idProveedor)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Iniciar una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Actualizar la orden de compra
                        cmd.CommandText = "UPDATE tbl_ordenescompra SET fechaSolicitid_OrdComp = ?, fechaEntrega_OrdComp = ?, deptoSolicitante_OrdComp = ?, subTotal_OrdComp = ?, iva_OrdComp = ?, totalOrden_OrdComp = ?, notas_OrdComp = ?, tbl_proveedor_id_prov = ? WHERE id_OrdComp = ?";
                        cmd.Parameters.AddWithValue("@fechaSolicitud", fechaSolicitud);
                        cmd.Parameters.AddWithValue("@fechaEntrega", fechaEntrega);
                        cmd.Parameters.AddWithValue("@deptoSolicitante", deptoSolicitante);
                        cmd.Parameters.AddWithValue("@subtotal", subtotal);
                        cmd.Parameters.AddWithValue("@iva", iva);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@notas", notas);
                        cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                        cmd.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);
                        cmd.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hacer rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al actualizar la orden de compra: " + ex.Message);
                    }
                }
            }
        }
        public void ActualizarDetalleOrdenCompra(int codigodetalle, int idOrden, int cantidad, double total, int idprod)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Iniciar una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Crea el comando SQL de actualización
                        cmd.CommandText = "UPDATE tbl_detalleordenescompra SET cantidad_det = ?, totalProducto_det = ?, tbl_Producto_cod_producto = ? WHERE OrdenesCompra_id_OrdComp = ? AND id_detalle=?";

                        // Asigna los parámetros de la consulta
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@producto", idprod);
                        cmd.Parameters.AddWithValue("@idOrden", idOrden);
                        cmd.Parameters.AddWithValue("@idDetalle", codigodetalle);
                        cmd.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hacer rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al actualizar el detalle de la orden de compra: AA" + ex.Message);
                    }
                }
            }
        }
        public void ActualizarCompra(int codigo, string fechasolicitud, string fechaentrega, string depa, double subtotal, double iva, double total, string notas, int codProv, int recibidoigual, string fechav, int idorden)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Iniciar una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Actualizar la orden de compra
                        cmd.CommandText = "UPDATE tbl_compras SET fechaSolicitid_EncComp = ?, fechaEntrega_OrdComp = ?, deptoSolicitante_EncComp = ?, subTotal_EncComp = ?, iva_EncComp = ?, totalOrden_EncComp = ?, notas_EncComp = ?, tbl_proveedor_id_prov = ?, recibidoIgualSolicitado_EncComp = ?,fechaVencimientoPago_EncComp = ?,id_OrdComp = ? WHERE id_EncComp = ?";
                        cmd.Parameters.AddWithValue("@fechaSolicitid_EncComp", fechasolicitud);
                        cmd.Parameters.AddWithValue("@fechaEntrega_OrdComp", fechaentrega);
                        cmd.Parameters.AddWithValue("@deptoSolicitante_EncComp", depa);
                        cmd.Parameters.AddWithValue("@subTotal_EncComp", subtotal);
                        cmd.Parameters.AddWithValue("@iva_EncComp", iva);
                        cmd.Parameters.AddWithValue("@totalOrden_EncComp", total);
                        cmd.Parameters.AddWithValue("@notas_EncComp", notas);
                        cmd.Parameters.AddWithValue("@tbl_proveedor_id_prov", codProv);
                        cmd.Parameters.AddWithValue("@recibidoIgualSolicitado_EncComp", recibidoigual);
                        cmd.Parameters.AddWithValue("@fechaVencimientoPago_EncComp", fechav);
                        cmd.Parameters.AddWithValue("@id_OrdComp", idorden);
                        cmd.Parameters.AddWithValue("@id_EncComp", codigo);
                        cmd.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hacer rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al actualizar la de compra: MAL ENCABEZADO" + ex.Message);
                    }
                }
            }
        }
        public void ActualizarDetalleCompra(int codigodetalle, int cantidad, double total, int idprod, int idCompra)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Iniciar una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Crea el comando SQL de actualización
                        cmd.CommandText = "UPDATE tbl_detallecompras SET cantidad_compra_det = ?, totalPorProducto_det = ?, tbl_Producto_cod_producto = ? WHERE tbl_Encabezado_Compras_id_EncComp = ? AND id_detalleCompra=?";

                        // Asigna los parámetros de la consulta
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@producto", idprod);
                        cmd.Parameters.AddWithValue("@idOrden", idCompra);
                        cmd.Parameters.AddWithValue("@idDetalle", codigodetalle);
                        cmd.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hacer rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al actualizar el detalle de la compra: DETALLE" + ex.Message);
                    }
                }
            }
        }

        public void ActualizarFactura(int codigo, string nomprov, string nitprov, string fechav, string fechaa, double subtotal, double iva, double total, string notas, int idcomp)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Iniciar una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        // Actualizar la orden de compra
                        cmd.CommandText = "UPDATE tbl_facturaxpagar SET nombreprov_facxpag = ?, nitprov_facxpag = ?, fechavenc_facxpag = ?,fecha_abono = ?, subtotal_facxpag = ?, iva_facxpag = ?, totalfac_facxpag = ?, notas_facxpag = ?, tbl_Encabezado_Compras_id_EncComp = ? WHERE NoFactura = ?";
                        cmd.Parameters.AddWithValue("@nombreprov_facxpag", nomprov);
                        cmd.Parameters.AddWithValue("@nitprov_facxpag", nitprov);
                        cmd.Parameters.AddWithValue("@fechavenc_facxpag", fechav);
                        cmd.Parameters.AddWithValue("@fecha_abono", fechaa);
                        cmd.Parameters.AddWithValue("@subtotal_facxpag", subtotal);
                        cmd.Parameters.AddWithValue("@iva_facxpag", iva);
                        cmd.Parameters.AddWithValue("@totalfac_facxpag", total);
                        cmd.Parameters.AddWithValue("@notas_facxpag", notas);
                        cmd.Parameters.AddWithValue("@tbl_Encabezado_Compras_id_EncComp", idcomp);
                        cmd.Parameters.AddWithValue("@NoFactura", codigo);
                        cmd.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hacer rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al actualizar la factura: MAL ENCABEZADO" + ex.Message);
                    }
                }
            }
        }
        public void ActualizarDetalleFactura(int codigodetalle, int cantidad, double total, int idFactura, int idprod)
        {
            using (OdbcConnection conn = con.connection())
            {
                using (OdbcCommand cmd = conn.CreateCommand())
                {
                    // Iniciar una nueva transacción
                    OdbcTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;
                    try
                    {
                        // Crea el comando SQL de actualización
                        cmd.CommandText = "UPDATE tbl_detallefacturaxpagar SET cantidad_detalleFac = ?, totalPorProducto_detalleFac = ?, tbl_Producto_cod_producto = ? WHERE tbl_facturaXPagar_NoFactura = ? AND id_detalleFac=?";

                        // Asigna los parámetros de la consulta
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@producto", idprod);
                        cmd.Parameters.AddWithValue("@idOrden", idFactura);
                        cmd.Parameters.AddWithValue("@idDetalle", codigodetalle);
                        cmd.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        // Si ocurre un error, hacer rollback de la transacción
                        transaction.Rollback();
                        throw new Exception("Error al actualizar el detalle de la factura: DETALLE" + ex.Message);
                    }
                }
            }
        }
       

        public DataTable selectTable(string table, string query = "")
        {
            string sql = query.Equals("") ? "select * from " + table : query;
            OdbcDataAdapter adapter = new OdbcDataAdapter(sql, this.con.connection());
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            return tbl;
        }

        // DIEGO MAROOQUIN transacciones 

        public void InsertarTipoCambio(DateTime fecha, string monedaOrigen, string monedaDestino, double cantidad, double valorCalculado, double totalCalculado)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar en la tabla tbl_tipocambio
                            string insertQuery = "INSERT INTO tbl_tipocambio (fecha, moneda_origen, moneda_destino, cantidad, valor_calculado, total_calculado) " +
                                                 "VALUES (?, ?, ?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@fecha", fecha);
                                cmd.Parameters.AddWithValue("@moneda_origen", monedaOrigen);
                                cmd.Parameters.AddWithValue("@moneda_destino", monedaDestino);
                                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                                cmd.Parameters.AddWithValue("@valor_calculado", valorCalculado);
                                cmd.Parameters.AddWithValue("@total_calculado", totalCalculado);

                                cmd.ExecuteNonQuery();
                            }

                            // Confirmar la transacción si la inserción fue exitosa
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción si ocurre algún error
                            transaction.Rollback();
                            Console.WriteLine($"Error al insertar tipo de cambio: {ex.Message}");
                        }
                    }
                }
            }
        }
        public bool EliminarTipodecambio(int idTipodeCambio)
        {
            using (OdbcConnection conn = con.connection())
            {
                string consulta = "DELETE FROM tbl_tipocambio WHERE  id_tipo_cambio = ?";
                using (OdbcCommand cmd = new OdbcCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("id_tipo_cambio", idTipodeCambio);
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }

            }
        }

        public void InsertarTipoCambio2(DateTime fecha, string moneda, double venta, double compra)
        {
            using (OdbcConnection connection = con.connection())
            {
                if (connection != null)
                {
                    using (OdbcTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar en la tabla tbl_tipocambio2
                            string insertQuery = "INSERT INTO tbl_tipocambio2 (fecha, moneda, venta, compra) VALUES (?, ?, ?, ?)";
                            using (OdbcCommand cmd = new OdbcCommand(insertQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@fecha", fecha);
                                cmd.Parameters.AddWithValue("@moneda", moneda);
                                cmd.Parameters.AddWithValue("@venta", venta);
                                cmd.Parameters.AddWithValue("@compra", compra);

                                cmd.ExecuteNonQuery();
                            }

                            // Confirmar la transacción si la inserción fue exitosa
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Revertir la transacción si ocurre algún error
                            transaction.Rollback();
                            Console.WriteLine($"Error al insertar tipo de cambio: {ex.Message}");
                        }
                    }
                }
            }
        }



    }

}
