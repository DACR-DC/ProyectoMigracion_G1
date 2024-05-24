using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorERP;
using Seguridad_Controlador;

namespace CapaVistaERP.Procesos
{ 
    //Programado por: Carol Chuy
    public partial class FacturaporPagar : Form
    {
        private CapaControladorERP.Controlador controller;
        public Seguridad_Controlador.Controlador ctrl_seguridad = new Seguridad_Controlador.Controlador();
        public FacturaporPagar(string idcompra, string fechaV, string proveedorfact)
        {
            InitializeComponent();
            controller = new CapaControladorERP.Controlador();
            txt_numcompra.Text = idcompra;
            dateTimePickerVencimiento.Text = fechaV;
            txt_Idprov.Text = proveedorfact;
        }
        private void FacturaporPagar_Load(object sender, EventArgs e)
        {
            btn_numorden.Enabled = true;
            txt_numcompra.Enabled = false;
            txt_Idprov.Enabled = false;
            txt_nombreprov.Enabled = false;
            txt_domicilio.Enabled = false;
            txt_telefonoprov.Enabled = false;
            txt_nitprov.Enabled = false;
            dateTimePickerVencimiento.Enabled = false;
            dateTimePickerAbono.Enabled = true;
            button4.Enabled = true;
            dgv_detalle.Columns.Clear();
        }
        public void RecibirDatosDesdeBuscarOrdenes(string idcompra, string fechaV, string proveedorfact, string subtotal, string iva, string total)
        {
            // Actualiza los textbox en del formulario con los datos recibidos
            txt_numcompra.Text = idcompra;
            int numero = int.Parse(idcompra);
            dateTimePickerVencimiento.Text = fechaV;
            txt_Idprov.Text = proveedorfact;
            txt_subtotal.Text = subtotal;
            txt_iva.Text = iva;
            txt_total.Text = total;
            ObtenerDatosProveedor(proveedorfact);
            actualizardatagridviewFactura(numero);
        }
        public void actualizardatagridviewFactura(int codigo)
        {
            DataTable dt = controller.llenarTablasCondicionFactura(codigo);
            // Filtras los datos que deseas mostrar en el DataGridView
            DataTable filteredTable = FiltrarDatos(dt);
            // Asignas el DataTable filtrado como origen de datos del DataGridView
            dgv_detalle.DataSource = filteredTable;
        }
        private DataTable FiltrarDatos(DataTable dt)
        {
            DataTable filteredTable = new DataTable();

            // Agregar las columnas necesarias al DataTable filtrado
            filteredTable.Columns.Add("Cantidad", typeof(int));
            filteredTable.Columns.Add("ID_Producto", typeof(int));
            filteredTable.Columns.Add("Nombre", typeof(string));
            filteredTable.Columns.Add("Descripción", typeof(string));
            filteredTable.Columns.Add("Precio_Unitario", typeof(decimal));
            filteredTable.Columns.Add("Total", typeof(double));

            // Iterar sobre cada fila en el DataTable original
            foreach (DataRow row in dt.Rows)
            {
                string codigoProducto = row["tbl_Producto_cod_producto"].ToString();
                string nombre = controller.ObtenerNombre(codigoProducto);
                string descripcion = controller.ObtenerDescripcion(codigoProducto);
                decimal precioUnitario = controller.ObtenerPrecioUnitario(codigoProducto);

                // Si se encontraron datos del producto, llenamos las columnas correspondientes en el DataTable filtrado
                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(descripcion))
                {
                    // Creamos una nueva fila en el DataTable filtrado
                    DataRow newRow = filteredTable.NewRow();
                    // Asignamos los valores a las columnas correspondientes en la nueva fila
                    newRow["Cantidad"] = row["cantidad_compra_det"];
                    newRow["ID_Producto"] = row["tbl_Producto_cod_producto"];
                    newRow["Nombre"] = nombre;
                    newRow["Descripción"] = descripcion;
                    newRow["Precio_Unitario"] = precioUnitario;
                    newRow["Total"] = row["totalPorProducto_det"];
                    // Agregamos la nueva fila al DataTable filtrado
                    filteredTable.Rows.Add(newRow);
                }
            }
            // Devolvemos el DataTable filtrado
            return filteredTable;
        }
        private void ObtenerDatosProveedor(string proveedorId)
        {
            string nombreProveedor = controller.ObtenerNombreProveedor(proveedorId);
            string domicilioProveedor = controller.ObtenerDomicilioProveedor(proveedorId);
            string telefonoProveedor = controller.ObtenerTelefonoProveedor(proveedorId);
            string nitProveedor = controller.ObtenerNitProveedor(proveedorId);

            txt_Idprov.Text = proveedorId;
            txt_nombreprov.Text = nombreProveedor;
            txt_domicilio.Text = domicilioProveedor;
            txt_telefonoprov.Text = telefonoProveedor;
            txt_nitprov.Text = nitProveedor;
        }

        private void btn_numorden_Click(object sender, EventArgs e)
        {
            FacturaporPagarModi facturaporPagarModi = new FacturaporPagarModi();
            BuscarCompras BuscarCompras = new BuscarCompras(this, facturaporPagarModi);
            BuscarCompras.Show();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_detalle.SelectedRows.Count > 0)
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la fila seleccionada?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Obtiene la fila seleccionada del dgv_detalle (datagrid)
                    DataGridViewRow filaSeleccionada = dgv_detalle.SelectedRows[0];

                    // Elimina la fila seleccionada por el usuario
                    dgv_detalle.Rows.Remove(filaSeleccionada);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tabla = "tbl_detallefacturaxpagar";
            string campoid = "id_detalleFac";

            // Verifica que los campos de número de compra, código de proveedor y número de orden sean válidos
            if (int.TryParse(txt_numfactura.Text, out int codigo) &&
                int.TryParse(txt_numcompra.Text, out int codcompra))
            {
                // Verifica que el código de proveedor sea válido
                if (!ValidarCompra())
                {
                    MessageBox.Show("Los datos de la órden no coinciden con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidarProveedor())
                {
                    MessageBox.Show("Los datos del proveedor no coinciden con la base de datos o el código de proveedor no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica si la descripción de la orden de compra está vacía
                if (dgv_detalle.RowCount < 2)
                {
                    MessageBox.Show("Por favor, llene la descripción de la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica los campos opcionales (subtotal, IVA y total)
                double subtotal, iva, totalOrden;
                if (double.TryParse(txt_subtotal.Text, out subtotal) &&
                    double.TryParse(txt_iva.Text, out iva) &&
                    double.TryParse(txt_total.Text, out totalOrden))
                {
                    // Resto del código para insertar la compra
                    DateTime fechaVencimiento = dateTimePickerVencimiento.Value;
                    DateTime fechaAbono = dateTimePickerAbono.Value;
                    string fechaV = fechaVencimiento.ToString("yyyy-MM-dd");
                    string fechaA = fechaAbono.ToString("yyyy-MM-dd");
                    int estado = 0;
                    // Confirmar con el usuario antes de enviar la orden de compra
                    DialogResult resultado = MessageBox.Show("¿Está seguro de enviar la factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Intenta realizar la inserción de la orden y el detalle dentro de una transacción
                        try
                        {
                            controller.InsertarFactura(codigo, txt_nombreprov.Text, txt_nitprov.Text, fechaV, fechaA, subtotal, iva, totalOrden, estado, txt_notas.Text, codcompra);
                            foreach (DataGridViewRow fila in dgv_detalle.Rows)
                            {
                                if (!fila.IsNewRow)
                                {
                                    int ultimoNumeroFactura = controller.ObtenerUltimoNumeroOrden(campoid, tabla);
                                    string cantd = fila.Cells[0].Value.ToString();
                                    string idprod = fila.Cells[1].Value.ToString();
                                    string totfil = fila.Cells[5].Value.ToString();

                                    if (int.TryParse(cantd, out int cantidad) && int.TryParse(idprod, out int idproducto) && double.TryParse(totfil, out double totalfila))
                                    {
                                        controller.InsertarDetalleFactura(ultimoNumeroFactura, cantidad, totalfila, codigo, idproducto);
                                    }
                                }
                            }

                            MessageBox.Show("Factura registrada correctamente.");
                            this.ctrl_seguridad.setBtitacora("8012", "Se ingresó una factura");
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Eror esss: " + ex.Message);
                            MessageBox.Show("ErrorRRR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }

        private void LimpiarCampos()
        {
            txt_numcompra.Clear();
            txt_Idprov.Clear();
            txt_nombreprov.Clear();
            txt_domicilio.Clear();
            txt_telefonoprov.Clear();
            txt_nitprov.Clear();
            txt_numfactura.Clear();
            dateTimePickerAbono.Value = DateTime.Now; // Restablece la fecha actual
            dateTimePickerVencimiento.Value = DateTime.Now; // Restablece la fecha actual
            txt_subtotal.Clear();
            txt_iva.Clear();
            txt_total.Clear();
            txt_notas.Clear();
            txt_numcompra.Enabled = false;
            txt_Idprov.Enabled = false;
            btn_numorden.Enabled = false;
            txt_nombreprov.Enabled = false;
            txt_domicilio.Enabled = false;
            txt_telefonoprov.Enabled = false;
            dateTimePickerVencimiento.Enabled = false;
            dateTimePickerAbono.Enabled = false;
            dgv_detalle.Enabled = false;
            DataGridViewColumn Cant = dgv_detalle.Columns["Cantidad"];
            DataGridViewColumn Nom = dgv_detalle.Columns["Nombre"];
            DataGridViewColumn des = dgv_detalle.Columns["Descripción"];
            DataGridViewColumn pre = dgv_detalle.Columns["Precio_Unitario"];
            DataGridViewColumn to = dgv_detalle.Columns["Total"];
            DataGridViewColumn id = dgv_detalle.Columns["ID_Producto"];
            dgv_detalle.Columns.Remove(Cant);
            dgv_detalle.Columns.Remove(Nom);
            dgv_detalle.Columns.Remove(des);
            dgv_detalle.Columns.Remove(pre);
            dgv_detalle.Columns.Remove(to);
            dgv_detalle.Columns.Remove(id);
        }

        private bool ValidarCompra()
        {
            if (int.TryParse(txt_numcompra.Text, out int idCompra))
            {
                DataTable ordenData = controller.ObtenerFactPorID(idCompra);

                if (ordenData.Rows.Count > 0)
                {
                    DateTime fechaVencimientoBD = (DateTime)ordenData.Rows[0]["fechaVencimientoPago_EncComp"];
                    string fechaV = dateTimePickerVencimiento.Value.ToString("yyyy-MM-dd");

                    DateTime fechaVencimientoIngresada = DateTime.ParseExact(fechaV, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    if (fechaVencimientoBD == fechaVencimientoIngresada)
                    {
                        return true;
                    }
                    else
                    {
                        // Los datos ingresados no coinciden con los datos de la orden.
                        MessageBox.Show("Los datos ingresados no coinciden con los de la compra en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    // La orden no se encontró en la base de datos.
                    MessageBox.Show("El código de compra no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código de compra válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidarProveedor()
        {
            if (int.TryParse(txt_Idprov.Text, out int idProveedor))
            {
                DataTable proveedorData = controller.ObtenerProveedorPorID(idProveedor);

                if (proveedorData.Rows.Count > 0)
                {
                    string nombreProveedor = proveedorData.Rows[0]["nombre_prov"].ToString();
                    string domicilioProveedor = proveedorData.Rows[0]["domicilio_prov"].ToString();
                    string telefonoProveedor = proveedorData.Rows[0]["telefono_prov"].ToString();

                    string nombreIngresado = txt_nombreprov.Text;
                    string domicilioIngresado = txt_domicilio.Text;
                    string telefonoIngresado = txt_telefonoprov.Text;

                    if (nombreProveedor == nombreIngresado && domicilioProveedor == domicilioIngresado && telefonoProveedor == telefonoIngresado)
                    {
                        return true;
                    }
                    else
                    {
                        // Los datos ingresados no coinciden con los datos del proveedor.
                        MessageBox.Show("Los datos ingresados no coinciden con los del proveedor en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    // El proveedor no se encontró en la base de datos.
                    MessageBox.Show("El código de proveedor no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código de proveedor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
