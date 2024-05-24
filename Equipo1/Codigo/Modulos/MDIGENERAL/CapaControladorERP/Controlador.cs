using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using CapaModeloERP;
using System.Windows.Forms;
using CapaModeloERP.clases;
using System.Data.SqlTypes;

namespace CapaControladorERP
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();

        //Andrea Corado  0901-20-2841
        public DataTable llenarTablas(string tabla)
        {
            OdbcDataAdapter dt = sn.CargarDatos(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        //Andrea Corado 0901-20-2841
        public DataTable BuscarProv(string tabla, string columna, string dato, string columna2, string dato2, string columna3, string dato3)
        {
            OdbcDataAdapter dt = sn.BuscarProv(tabla, columna, dato, columna2, dato2, columna3, dato3);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        //Andrea Corado 0901-20-2841  
        public DataTable filtrardatosp(string tabla, string columna, string dato, string columna2, string dato2)
        {
            OdbcDataAdapter dt = sn.filtrarDatosp(tabla, columna, dato, columna2, dato2);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        //Andrea Corado 0901-20-2841
        public void Guardarmovpro(string idp, string fechamov, string totalmov, string nofact, string banmov, string tipomov, string numov, string conceptomov)
        {
            sn.guardarDatos( nofact, banmov, tipomov, numov, conceptomov);
        }

        //Andrea Corado 0901-20-2841
        public DataTable Actualizap(string tabla, string columna, string dato1, string columna2, int igualA)
        {
            return sn.ActualizarDatos(tabla, columna, dato1, columna2, igualA);
        }

        //Andrea Corado 0901-20-2841
        public DateTime ObtenerFechaV(string nofactu)
        {
            var dt1 = sn.ObtenerFechaV(nofactu);
            return dt1;
        }
        public (DateTime, decimal) ObtenerFechaVYTotal(string dato)
        {
            return sn.ObtenerFechaVYTotal(dato);
        }
        public List<string> ComboFillfactura(string columna, string tabla, string nit, string dato, string estadofact)
        {
            return sn.ComboFillfactura(columna, tabla,nit,dato,estadofact);
        }

        //Andrea Corado 0901-20-2841
        public void InsertarOperacion(int id, string fechaabono, double totalapa)
        {
            sn.InsertarOperacion(id, fechaabono, totalapa);
        }
        //Andrea Corado 0901-20-2841
        public void InsertarDetalleOperacionPro(int numfact, string banco, string tipomov, string numdoc, string concepto)
        {
            sn.InsertarDetalleOperacionPro(numfact, banco, tipomov, numdoc, concepto);
        }


        //David Carrillo 0901-20-3201 
        public List<string> ComboFill(string columna, string tabla)
        {
            return sn.ComboFill(columna, tabla);
        }
        //David Carrillo 0901-20-3201 
        public double GetPrecio(string nombreProducto)
        {
            double precio = sn.GetPrecio(nombreProducto);
            return precio;
        }
        //David Carrillo 0901-20-3201 
        public void insertarCliente(string nombre_cl, string apellido_cl, string direccion_cl, string correo_cl, string telefono_cl)
        {
            sn.InsertarCliente(nombre_cl, apellido_cl, direccion_cl, correo_cl, telefono_cl);
        }
        //David Carrillo 0901-20-3201 
        public void INSVentasPedido(int id_vendedor, int tbl_detalle_cotizacion_id)
        {
            sn.INSVentasPedido(id_vendedor, tbl_detalle_cotizacion_id);
        }
        //David Carrillo 0901-20-3201 
        public string obtenerCliente(string nombreCliente)
        {

            string nombrecl = sn.ObtenerCliente(nombreCliente);
            return nombrecl;
        }
        //David Carrillo 0901-20-3201 
        public void InsertarCoti(int No_Cotizacion, string fecha_coti, string fechaFinal_coti, string Solicitud)
        {
            sn.InsertarCoti(No_Cotizacion, fecha_coti, fechaFinal_coti, Solicitud);
        }
        //David Carrillo 0901-20-3201 
        public void InsertarDetalleCoti(int id_cliente, int cantidad_coti, int No_Cotizacion, int cod_producto, double total_detCoti)
        {
            sn.InsertarDetalleCoti(id_cliente, cantidad_coti, No_Cotizacion, cod_producto, total_detCoti);
        }
        //David Carrillo 0901-20-3201 
        public void ActCoti(int No_Cotizacion)
        {
            sn.ActCoti(No_Cotizacion);
        }
        //David Carrillo 0901-20-3201
        public DataTable ObtenerPagosPorFecha(int año, string tipoFiltro)
        {
            DateTime fechaPago;

            if (tipoFiltro == "Diario")
            {
                fechaPago = DateTime.Today;
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaPago = DateTime.Today.AddDays(-numDiaSemana);
            }
            else // Mensual
            {
                if (año == 0)
                {
                    MessageBox.Show("Por favor, seleccione un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }


                fechaPago = new DateTime(año, 1, 1);
            }

            return sn.ObtenerPagosPorFecha(fechaPago);
        }
        //David Carrillo 0901-20-3201 

        public string ObtenerUltimoDato(string dato, string tabla, string dato2)
        {
            return sn.ObtenerUltimoDato(dato, tabla, dato2);
        }

        //David Carrillo
        public void InsertarFactura(double total_facxcob, string tiempoPago_facxcob, string estado_facxcob, int tbl_Ventas_detalle_id_ventas_det, int tbl_Clientes_id_cliente, string fecha_factura, double faltante_pago)
        {
            sn.InsertarFactura(total_facxcob, tiempoPago_facxcob, estado_facxcob, tbl_Ventas_detalle_id_ventas_det, tbl_Clientes_id_cliente, fecha_factura, faltante_pago);
        }

        //David Carrillo
        public void InsertarPagoFacXCobrar(string noFactura, int cliente, string banco, string concepto, double monto_pago, double extra_pago, string fecha_pago, string NIT, string num_recibo)
        {
            sn.InsertarPagoFacXCobrar(noFactura, cliente, banco, concepto, monto_pago, extra_pago, fecha_pago, NIT, num_recibo);
        }

        public double CalcularPorPagar(string noFactura)
        {
            return sn.CalcularPorPagar(noFactura);
        }
        public bool FacturaExiste(string noFactura)
        {
            return sn.FacturaExiste(noFactura);
        }

        //David Carrillo 0901-20-3201 
        public int ObtenerCodigoProducto(string nombreProducto)
        {
            return sn.ObtenerCodigoProducto(nombreProducto);
        }
        //David Carrillo 0901-20-3201 
        public DataTable BuscarDato(string dato, string tabla, string DatoABuscar, int igualA)
        {
            return sn.BuscarDato(dato, tabla, DatoABuscar, igualA);
        }
        public void ActualizarFaltantePago(string noFactura, double faltantePago)
        {
            sn.ActualizarFaltantePago(noFactura,faltantePago);
        }
        public void ActualizarExistencias(int idProducto, int cantidad)
        {
            sn.ActualizarExistencias(idProducto, cantidad);
        }
        // carlos enrique modulo bancos
        public List<string> llenarCombo(string columna1, string tabla)
        {
            return sn.llenarCombo(columna1, tabla);
        }
        // Otto Adrian Lopez Ventura
        public DataTable BuscarVende(string tabla, string columna, string dato)
        {
            return sn.BuscarVendedor(tabla, columna, dato);

        }
        // Otto Adrian Lopez Ventura
        public DataTable BuscarCotizacion(string tabla, string columna, string dato)
        {
            return sn.BuscarVendedor(tabla, columna, dato);

        }

        // carlos enrique modulo bancos
        public bool ActualizarReservaOrdenCompra(int idCuenta, double monto, string estado)
        {
            if (estado == "Aprobado")
            {
                return sn.ActualizarReservaCuentaBancaria(idCuenta, monto);
            }
            return false;
        }

        // carlos enrique modulo bancos
        public DataTable Buscar(string tabla, string columna, string dato)
        {
            return sn.Buscar(tabla, columna, dato);

        }
        // carlos enrique modulo bancos
        public bool GuardarDatos(string tabla, Dictionary<string, object> valores)
        {
            return sn.Guardar(tabla, valores);
        }
        public bool ActualizarDatosC(string tabla, Dictionary<string, object> valores, string condicion)
        {
            return sn.ActualizarC(tabla, valores, condicion);
        }

        // carlos enrique modulo bancos
        public bool ActualizarSaldoCuentaBancaria(int idCuenta, double monto, bool esDeposito)
        {
            return sn.ActualizarSaldoCuentaBancaria(idCuenta, monto, esDeposito);
        }
        // carlos enrique guzman cabrera
        public DataTable llenartablabitacoraMB(string consulta)
        {
            OdbcDataAdapter dt = sn.llenartablabitacoraMB(consulta);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        // carlos enrique guzman cabrera
        public DataTable BuscarMB(string strfiltro)
        {
            return sn.BuscarMB(strfiltro);
        }

        // carlos enrique guzman cabrera
        public bool EliminarMovimiento(int idMovimiento)
        {
            return sn.EliminarMovimiento(idMovimiento);
        }
        // carlos enrique guzman cabrera
        public bool EliminarRegistroAO(int idRegistro)
        {
            return sn.EliminarRegistroAO(idRegistro);
        }
        // carlos enrique guzman cabrera
        public DataTable FiltrarRegistrosPorFecha(int año, string tipoFiltro)
        {


            DateTime fechaInicio, fechaFin;

            if (tipoFiltro == "Diario")
            {
                fechaInicio = DateTime.Today;
                fechaFin = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaInicio = DateTime.Today.AddDays(-numDiaSemana);
                fechaFin = fechaInicio.AddDays(7).AddSeconds(-1);
            }
            else // Mensual
            {
                if (año == 0)
                {
                    MessageBox.Show("Por favor, seleccione un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }


                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }

            return sn.ObtenerRegistrosPorFecha(fechaInicio, fechaFin);
        }

        // carlos enrique guzman cabrera
        public DataTable FiltrarRegistrosPorFechaAO(int año, string tipoFiltro)
        {


            DateTime fechaInicio, fechaFin;

            if (tipoFiltro == "Diario")
            {
                fechaInicio = DateTime.Today;
                fechaFin = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaInicio = DateTime.Today.AddDays(-numDiaSemana);
                fechaFin = fechaInicio.AddDays(7).AddSeconds(-1);
            }
            else // Mensual
            {
                if (año == 0)
                {
                    MessageBox.Show("Por favor, seleccione un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }


                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }

            return sn.ObtenerRegistrosPorFechaAO(fechaInicio, fechaFin);
        }

        //Carol Chuy Modulo Compras
        public string[] itemsprod()
        {
            string[] Items = sn.llenarCmbprod();
            return Items;
        }

        //Carol Chuy Modulo Compras
        public DataTable enviarprod()
        {

            var dt1 = sn.obtenerprod();
            return dt1;
        }

        //Carol Chuy Modulo Compras
        public void CargarOpcionesOrden(ComboBox combo)
        {
            // Aquí proporciona las opciones al ComboBox
            combo.Items.Add("Directa");
            combo.Items.Add("Relacionada");
        }

        //Carol Chuy Modulo Compras
        public int ObtenerUltimoNumeroOrden(String campoid, String tabla)
        {
            return sn.ObtenerUltimoNumeroOrden(campoid, tabla);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerDescripcion(string productId)
        {
            return sn.ObtenerDescripcion(productId);
        }

        //Carol Chuy Modulo Compras
        public decimal ObtenerPrecioUnitario(string productId)
        {
            return sn.ObtenerPrecioUnitario(productId);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerNombreProveedor(string proveedorID)
        {
            return sn.ObtenerNombreProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerDomicilioProveedor(string proveedorID)
        {
            return sn.ObtenerDomicilioProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerTelefonoProveedor(string proveedorID)
        {
            return sn.ObtenerTelefonoProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerNitProveedor(string proveedorID)
        {
            return sn.ObtenerNitProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public DataTable llenarTablasCondicion(String tabla)
        {
            OdbcDataAdapter dt = sn.llenarTablasCondicion(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        // Diego Antonio modulo de banco 

        public void InsertarTipoMoneda(string TipoMoneda, string ValorMoneda, string estado)
        {
            sn.InsertarTipoMoneda(TipoMoneda, ValorMoneda, estado);
        }

        public DataTable LlenarTablaMoneda(string tabla)
        {
            return sn.LlenarTablaMoneda(tabla);
        }

        public void InsertarMovimiento(string valorMovimiento, string descripcionMovimiento, string numCuenta, string tipoTransaccion, string estado, string valorTrans, string estadoConciliacion)
        {
            sn.InsertarMovimiento(valorMovimiento, descripcionMovimiento, numCuenta, tipoTransaccion, estado, valorTrans, estadoConciliacion);
        }

        public DataTable ObtenerCuentas()
        {
            return sn.ObtenerCuentas();
        }

        public decimal ObtenerSaldoTotal()
        {
            return sn.CalcularSaldoTotal();
        }

        public DataTable ObtenerTipoDeTransacciones()
        {
            return sn.TipoTransaccionBancaria();
        }

        public DataTable ObtenerTiposMoneda()
        {
            return sn.ObtenerTiposMoneda();
        }

        public DataTable ObtenerBancos()
        {
            return sn.ObtenerBancos();
        }

        public DataTable ObtenerTipoCuenta()
        {
            return sn.ObtenerTipoCuenta();
        }


        public DataTable valorTrans()
        {
            return sn.valorTransaccion();
        }
        public DataTable llenarTbl(string tabla)
        {
            return sn.LlenarTabla(tabla);
        }
        public int ObtenerValorTransaccion(string tipoTransaccion)
        {
            return sn.ObtenerValorTransaccion(tipoTransaccion);
        }
        // public DataTable ObtenerMonedaBanco()
        // {
        // Crea un DataTable para almacenar los datos de la tabla de moneda de banco
        //  DataTable tablaMoneda = new DataTable();

        // Realiza la conexión y la consulta
        //using (OdbcConnection connection = new OdbcConnection("Dsn=HotelSConexion"))
        //  {
        // Abre la conexión
        //  connection.Open();

        // Define la consulta SQL para obtener la moneda de banco
        //  string queryMoneda = "SELECT * FROM tbl_monedabanco";

        // Crea un OdbcDataAdapter para ejecutar la consulta y llenar el DataTable
        // using (OdbcDataAdapter adapterMoneda = new OdbcDataAdapter(queryMoneda, connection))
        // {
        //  adapterMoneda.Fill(tablaMoneda); // Llena el DataTable con los datos obtenidos de la consulta
        //}
        // }

        // Retorna el DataTable con los datos de la moneda de banco
        //  return tablaMoneda;
        // }

        //Carol Chuy Modulo Compras
        public DataTable ObtenerProveedorPorID(int id)
        {
            return sn.ObtenerProveedorPorID(id);
        }
        //Carol Chuy Modulo Compras
        public void InsertarOrdenCompra(int codigo, string fechasolicitud, string fechaentrega, string depa, double subtotal, double iva, double total, string notas, int codProv)
        {
            sn.InsertarOrdenCompra(codigo, fechasolicitud, fechaentrega, depa, subtotal, iva, total, notas, codProv);
        }
        //Carol Chuy Modulo Compras
        public void InsertarDetalleOrdenCompra(int codDetalle, int codigo, int cantidad, double totalfila, int idproducto)
        {
            sn.InsertarDetalleOrdenCompra(codDetalle, codigo, cantidad, totalfila, idproducto);
        }
        //Carol Chuy Modulo Compras
        public DataTable llenarTablasCondicionFactura(int codigo)
        {
            OdbcDataAdapter dt = sn.llenarTablasCondicionFactura(codigo);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        //Carol Chuy Modulo Compras
        public string ObtenerNombre(string productId)
        {
            return sn.ObtenerNombre(productId);
        }

        //Diego Marroquin DISPONIBLILIDAD DIARIA 
        public DataTable BuscarBanco(string nombreBanco, string estadoBanco)
        {
            OdbcDataAdapter adapter = sn.BuscarBanco(nombreBanco, estadoBanco);
            DataTable dt = new DataTable();

            try
            {
                adapter.Fill(dt);
            }
            catch (OdbcException ex)
            {
                // Manejar excepciones de ODBC
                Console.WriteLine("Error al buscar en la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción
                Console.WriteLine("Error general: " + ex.Message);
            }
            finally
            {
                adapter.Dispose();
            }

            return dt;
        }

        // Jimena Tobías - Logística
        public ProductoM ObtenerProducto(string codigo)
        {
            List<ProductoM> productos = new List<ProductoM>();

            if (productos == null || codigo.Length == 0) return null;

            productos = sn.ObtenerProductos();

            foreach (ProductoM prd in productos)
            {
                Console.WriteLine(prd.codigo + "--" + codigo);
                if (Convert.ToInt32(prd.codigo) == Convert.ToInt32(codigo))
                {
                    return prd;
                }
            }
            return null;
        }

        // Jimena Tobías - Logística
        public void llenarComboSucursal(ComboBox cmb)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            sucursales = sn.ObtenerSucursales();
            foreach (Sucursal suc in sucursales)
            {
                cmb.Items.Add(suc.nombre);
            }
        }

        // Jimena Tobías - Logística
        public void llenarComboProducto(ComboBox cmb)
        {
            List<ProductoM> productos = new List<ProductoM>();
            productos = sn.ObtenerProductos();
            foreach (ProductoM prd in productos)
            {
                cmb.Items.Add(prd.nombre);
            }
        }

        // Jimena Tobías - Logística
        public void TrasladoProducto(int idOrigen, int idDestino, int idProducto, int cantidad)
        {
            sn.TrasladoProducto(idOrigen, idDestino, idProducto, cantidad);
        }

        //Carol Chuy Compras
        public DataTable ObtenerOrdenPorID(int id)
        {
            return sn.ObtenerOrdenPorID(id);
        }
        //Carol Chuy Compras
        public void InsertarCompra(int codigo, string fechas, string fechae, string depa, double subtotal, double iva, double totalCompra, string notas, int codigoprov, int estadoCompra, string fechap, int codorden)
        {
            sn.InsertarCompra(codigo, fechas, fechae, depa, subtotal, iva, totalCompra, notas, codigoprov, estadoCompra, fechap, codorden);
        }
        //Carol Chuy Compras
        public void InsertarDetalleCompra(int codDetalle, int cantidad, double totalfila, int idprod, int codigo)
        {
            sn.InsertarDetalleCompra(codDetalle, cantidad, totalfila, idprod, codigo);
        }
        //Carol Chuy Compras
        public void InsertarFactura(int codigo, string nombrep, string nitp, string fechaV, string fechaA, double subtotal, double iva, double totalCompra, int estado, string notas, int codcompra)
        {
            sn.InsertarFactura(codigo, nombrep, nitp, fechaV, fechaA, subtotal, iva, totalCompra, estado, notas, codcompra);
        }
        //Carol Chuy Compras
        public DataTable filtrardatos(string tabla, string columna, string dato)
        {
            OdbcDataAdapter dt = sn.filtrarDatos(tabla, columna, dato);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public void InsertarDetalleFactura(int codDetalle, int cantidad, double totalfila, int codigo, int idprod)
        {
            sn.InsertarDetalleFactura(codDetalle, cantidad, totalfila, codigo, idprod);
        }
        //Carol Chuy Compras
        public DataTable ObtenerFactPorID(int id)
        {
            return sn.ObtenerFactPorID(id);
        }


        //Diego Marroquin 

        public DataTable llenartablabitacoradispodiaria(string tabla)
        {
            OdbcDataAdapter dt = sn.llenartablabitacoradispodiaria(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public DataTable llenartablatipodecambio(string tabla)
        {
            OdbcDataAdapter dt = sn.llenartablatipodecambio(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }






        public bool EliminarDisponibilidadDiaria(int idMovimiento)
        {
            return sn.EliminarDisponibilidadDiaria(idMovimiento);
        }
        //Carol Chuy Compras
        public DataTable ObtenerOrdenesCompraPorFecha(int año, string tipoFiltro)
        {
            DateTime fechaInicio, fechaFin;

            if (tipoFiltro == "Diario")
            {
                fechaInicio = DateTime.Today;
                fechaFin = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaInicio = DateTime.Today.AddDays(-numDiaSemana);
                fechaFin = fechaInicio.AddDays(7).AddSeconds(-1);
            }
            else // Mensual
            {
                if (año == 0)
                {
                    MessageBox.Show("Por favor, seleccione un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }


                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }

            return sn.ObtenerOrdenesCompraPorFecha(fechaInicio, fechaFin);
        }

        //Carol Chuy Compras
        public DataTable ObtenerComprasPorFecha(int año, string tipoFiltro)
        {
            DateTime fechaInicio, fechaFin;

            if (tipoFiltro == "Diario")
            {
                fechaInicio = DateTime.Today;
                fechaFin = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaInicio = DateTime.Today.AddDays(-numDiaSemana);
                fechaFin = fechaInicio.AddDays(7).AddSeconds(-1);
            }
            else // Mensual
            {
                if (año == 0)
                {
                    MessageBox.Show("Por favor, seleccione un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }


                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }

            return sn.ObtenerComprasPorFecha(fechaInicio, fechaFin);
        }

        //Carol Chuy Compras
        public DataTable ObtenerFacturasPorFecha(int año, string tipoFiltro)
        {
            DateTime fechaInicio, fechaFin;

            if (tipoFiltro == "Diario")
            {
                fechaInicio = DateTime.Today;
                fechaFin = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaInicio = DateTime.Today.AddDays(-numDiaSemana);
                fechaFin = fechaInicio.AddDays(7).AddSeconds(-1);
            }
            else // Mensual
            {
                if (año == 0)
                {
                    MessageBox.Show("Por favor, seleccione un año.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }


                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }

            return sn.ObtenerFacturasPorFecha(fechaInicio, fechaFin);
        }
        //Carol Chuy Modulo Compras
        public void EliminarOrdenCompra(int codigo)
        {
            sn.EliminarOrdenCompra(codigo);
        }
        //Carol Chuy Modulo Compras
        public void EliminarDetalleOrdenCompra(int codDetalle)
        {
            sn.EliminarDetalleOrdenCompra(codDetalle);
        }
        public void EliminarCompra(int codigo)
        {
            sn.EliminarCompra(codigo);
        }
        //Carol Chuy Modulo Compras
        public void EliminarDetalleCompra(int codDetalle)
        {
            sn.EliminarDetalleCompra(codDetalle);
        }
        public void EliminarFactura(int codigo)
        {
            sn.EliminarFactura(codigo);
        }
        //Carol Chuy Modulo Compras
        public void EliminarDetalleFactura(int codDetalle)
        {
            sn.EliminarDetalleFactura(codDetalle);
        }
        public string ObtenerIdProd(string nit)
        {
            string nitr = sn.ObtenerIdProd(nit);
            return nitr;
        }
        public void ActualizarOrdenCompra(int codigo, string fechasolicitud, string fechaentrega, string depa, double subtotal, double iva, double total, string notas, int codProv)
        {
            sn.ActualizarOrdenCompra(codigo, fechasolicitud, fechaentrega, depa, subtotal, iva, total, notas, codProv);
        }
        //Carol Chuy Modulo Compras
        public void ActualizarDetalleOrdenCompra(int codigodetalle, int codigo, int cantidad, double totalfila, int idprod)
        {
            sn.ActualizarDetalleOrdenCompra(codigodetalle, codigo, cantidad, totalfila, idprod);
        }
        public void ActualizarCompra(int codigo, string fechasolicitud, string fechaentrega, string depa, double subtotal, double iva, double total, string notas, int codProv, int recibidoigual, string fechav, int idorden)
        {
            sn.ActualizarCompra(codigo, fechasolicitud, fechaentrega, depa, subtotal, iva, total, notas, codProv, recibidoigual, fechav, idorden);
        }
        //Carol Chuy Modulo Compras
        public void ActualizarDetalleCompra(int codigodetalle, int cantidad, double totalfila, int idprod, int codigo)
        {
            sn.ActualizarDetalleCompra(codigodetalle, cantidad, totalfila, idprod, codigo);
        }
        public void ActualizarFactura(int codigo, string nombrep, string nitp, string fechaV, string fechaA, double subtotal, double iva, double totalCompra, string notas, int codcompra)
        {
            sn.ActualizarFactura(codigo, nombrep, nitp, fechaV, fechaA, subtotal, iva, totalCompra, notas, codcompra);
        }
        //Carol Chuy Compras
        public void ActualizarDetalleFactura(int codDetalle, int cantidad, double totalfila, int codigo, int idprod)
        {
            sn.ActualizarDetalleFactura(codDetalle, cantidad, totalfila, codigo, idprod);
        }

        public DataTable ObtenerCotizaciones()
        {
            return sn.selectTable("", "SELECT * FROM tbl_cotizaciones WHERE No_Cotizacion NOT IN (SELECT tbl_cotizaciones_No_Cotizacion FROM tbl_ventaspedido)");
        }

        public DataTable ObtenerProductosPorCotizacion(int Id)
        {
            string sql = "SELECT cod_producto, nombre_prod, descripcion_prod, precioUnitario_prod FROM tbl_detalle_cotizacion ";
            sql+= "inner join tbl_cotizaciones on No_Cotizacion = tbl_cotizaciones_No_Cotizacion ";
            sql += "inner join tbl_producto on tbl_producto_cod_producto = cod_producto where tbl_cotizaciones_No_Cotizacion = '"+Id+"';";
            return this.sn.selectTable("", sql);
        }

        // DIEGO MARROQUIN 
        public void InsertarTipoCambio(DateTime fecha, string monedaOrigen, string monedaDestino, double cantidad, double valorCalculado, double totalCalculado)
        {
            sn.InsertarTipoCambio(fecha, monedaOrigen, monedaDestino, cantidad, valorCalculado, totalCalculado);

        }

        public void InsertarTipoCambio2(DateTime fecha, string moneda, double venta, double compra)
        {
            sn.InsertarTipoCambio2(fecha, moneda, venta, compra);

        }
        public bool EliminarTipodecambio(int idTipodeCambio)
        {
            return sn.EliminarTipodecambio(idTipodeCambio);
        }
        public void ActualizarExistenciasCompras(int idProducto, int cantidad)
        {
            sn.ActualizarExistenciasCompras(idProducto, cantidad);
        }
    }
}
 




