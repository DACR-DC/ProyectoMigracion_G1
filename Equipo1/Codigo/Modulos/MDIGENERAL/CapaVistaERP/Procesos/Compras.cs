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
    public partial class Compras : Form
    {
        private CapaControladorERP.Controlador controller;
        public Seguridad_Controlador.Controlador ctrl_seguridad = new Seguridad_Controlador.Controlador();
        int estadoCompra;
        public Compras(string idord, string fechaS, string fechaE, string solicitante, string proveedor)
        {
            InitializeComponent();
            controller = new CapaControladorERP.Controlador();
            llenarprod();
            cmb_igualsolicitado.Items.Add("Completa");
            cmb_igualsolicitado.Items.Add("Incompleta");
            txt_numorden.Text = idord;
            dateTimePickerEntrega.Text = fechaE;
            dateTimePickerPedido.Text = fechaS;
            txt_departamentos.Text = solicitante;
            txt_Idprov.Text = proveedor;
        }

        public void llenarprod()
        {
            cmb_productos.ValueMember = "numero";
            cmb_productos.DisplayMember = "nombre";

            string[] items = controller.itemsprod();

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cmb_productos.Items.Add(items[i]);
                    }
                }

            }
            //Funciona para buscar en el combobox
            var dt2 = controller.enviarprod();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row["cod_producto"]) + "-" + Convert.ToString(row["nombre_prod"]));
                coleccion.Add(Convert.ToString(row["nombre_prod"]) + "-" + Convert.ToString(row["cod_producto"]));
            }
            cmb_productos.AutoCompleteCustomSource = coleccion;
            cmb_productos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_productos.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            string tabla = "tbl_compras";
            string campoid = "id_EncComp";
            btn_numorden.Enabled = true;
            txt_numorden.Enabled = false;
            txt_Idprov.Enabled = false;
            txt_nombreprov.Enabled = false;
            txt_domicilio.Enabled = false;
            txt_telefonoprov.Enabled = false;
            txt_departamentos.Enabled = false;
            txt_numcompra.Enabled = false;
            dateTimePickerEntrega.Enabled = false;
            dateTimePickerPedido.Enabled = false;
            dateTimePickerVencimiento.Enabled = true;    
            int ultimoNumeroOrden = controller.ObtenerUltimoNumeroOrden(campoid, tabla);
            txt_numcompra.Text = ultimoNumeroOrden.ToString();
        }
        public void RecibirDatosDesdeBuscarOrdenes(string idord, string fechaS, string fechaE, string solicitante, string proveedor)
        {
            // Actualiza los textbox en del formulario con los datos recibidos
            txt_numorden.Text = idord;
            dateTimePickerEntrega.Text = fechaE;
            dateTimePickerPedido.Text = fechaS;
            txt_departamentos.Text = solicitante;
            txt_Idprov.Text = proveedor;
            ObtenerDatosProveedor(proveedor);
        }
        private void ObtenerDatosProveedor(string proveedorId)
        {
            string nombreProveedor = controller.ObtenerNombreProveedor(proveedorId);
            string domicilioProveedor = controller.ObtenerDomicilioProveedor(proveedorId);
            string telefonoProveedor = controller.ObtenerTelefonoProveedor(proveedorId);

            txt_Idprov.Text = proveedorId;
            txt_nombreprov.Text = nombreProveedor;
            txt_domicilio.Text = domicilioProveedor;
            txt_telefonoprov.Text = telefonoProveedor;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            double precioU = 0;
            double cantidad = 0;
            double totalprod = 0;

            // Obtener el precio unitario desde el textbox
            if (double.TryParse(txt_preciou.Text, out precioU))
            {
                // Obtener la cantidad desde el textbox
                if (double.TryParse(txt_cantidad.Text, out cantidad))
                {
                    // Calcular el total del producto
                    totalprod = precioU * cantidad;

                    // Obtener el ID del producto seleccionado en el ComboBox
                    string productoSeleccionado = cmb_productos.SelectedItem.ToString();
                    string[] parts = productoSeleccionado.Split('-');
                    string idProducto = parts[0].Trim();
                    //Obtener el nombre del producto
                    string nomProducto = parts[1].Trim();
                    //Obtener la descripcion del producto
                    string descripcion = txt_descripcion.Text;
                    // Agregar una fila al DataGridView con los detalles
                    dgv_detalle.Rows.Add(cantidad, idProducto, nomProducto, descripcion, precioU, totalprod);
                    //Limpiar los textbox para poder ingresar uno nuevo
                    txt_cantidad.Text = "";
                    cmb_productos.Text = "";
                    txt_descripcion.Text = "";
                    txt_preciou.Text = "";
                    txt_totalfila.Text = "";
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un precio unitario válido.");
            }
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
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila para eliminar.");
            }
        }

        private void btn_confirmar_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult result = MessageBox.Show("¿Está seguro que desea confirmar la orden?", "Confirmación de orden", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dgv_detalle.Enabled = false;
                txt_cantidad.Enabled = false;
                txt_descripcion.Enabled = false;
                cmb_productos.Enabled = false;
                txt_totalfila.Enabled = false;
                txt_preciou.Enabled = false;

                double subtotal = 0;
                double ivaPorcentaje = 0.12;

                foreach (DataGridViewRow fila in dgv_detalle.Rows)
                {
                    // Se asegura de que la fila no sea la fila de encabezado.
                    if (!fila.IsNewRow)
                    {
                        // Obtiene el valor de la última celda de la fila.
                        double valorCelda;
                        if (double.TryParse(fila.Cells[dgv_detalle.ColumnCount - 1].Value.ToString(), out valorCelda))
                        {
                            // Suma el valor al subtotal.
                            subtotal += valorCelda;
                        }
                    }
                }
                // Calcula el total con IVA.
                double totalIva = (subtotal * (1 + ivaPorcentaje)) - subtotal;
                double total = totalIva + subtotal;

                //Muestra los resultados en los textbox
                txt_subtotal.Text = subtotal.ToString();
                txt_iva.Text = totalIva.ToString();
                txt_total.Text = total.ToString();
            }
        }
        private void cmb_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_productos != null && cmb_productos.SelectedIndex >= 0)
            {
                // Obtener el ID del producto que seleccionó el usuario
                string selectedValue = cmb_productos.SelectedItem.ToString();

            // Divide la cadena para tener ambos campos
            string[] parts = selectedValue.Split('-');
            string selectedProductId = parts[0].Trim();

            // Llamar a la capa controlador a su método ObtenerDescripción y ObtenerPrecioUnitario
            string descripcion = controller.ObtenerDescripcion(selectedProductId);
            decimal precioUnitario = controller.ObtenerPrecioUnitario(selectedProductId);

            // Llena los TextBox con la descripción y el precio unitario
            txt_descripcion.Text = descripcion;
            txt_preciou.Text = precioUnitario.ToString();

            //Pasa lo que está dentro de los text box a double para poder sacar el total de la fila
            double precioU = double.TryParse(txt_preciou.Text, out double precio) ? precio : 0.0;
            int cantidad = int.TryParse(txt_cantidad.Text, out int cant) ? cant : 0;
            double totalprod = precioU * cantidad;
            txt_totalfila.Text = totalprod.ToString();
            }
        }

        private void btn_numorden_Click(object sender, EventArgs e)
        {
            ComprasModi comprasModi = new ComprasModi();
            BuscarOrdenCompra BuscarOrdenCompra = new BuscarOrdenCompra(this, comprasModi);
            BuscarOrdenCompra.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tabla = "tbl_detallecompras";
            string campoid = "id_detalleCompra";

            // Verifica que los campos de número de compra, código de proveedor y número de orden sean válidos
            if (int.TryParse(txt_numcompra.Text, out int codigo) &&
                int.TryParse(txt_Idprov.Text, out int codigoprov) &&
                int.TryParse(txt_numorden.Text, out int codorden))
            {
                // Verifica que el código de proveedor sea válido
                if (!ValidarOrden())
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
                    MessageBox.Show("Por favor, llene la descripción de la orden de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica los campos opcionales (subtotal, IVA y total)
                double subtotal, iva, totalOrden;
                if (double.TryParse(txt_subtotal.Text, out subtotal) &&
                    double.TryParse(txt_iva.Text, out iva) &&
                    double.TryParse(txt_total.Text, out totalOrden))
                {
                    // Resto del código para insertar la compra
                    DateTime fechaSolicitud = dateTimePickerPedido.Value;
                    DateTime fechaEntrega = dateTimePickerEntrega.Value;
                    DateTime fechaPago = dateTimePickerVencimiento.Value;
                    string fechas = fechaSolicitud.ToString("yyyy-MM-dd");
                    string fechae = fechaEntrega.ToString("yyyy-MM-dd");
                    string fechap = fechaPago.ToString("yyyy-MM-dd");
                    // Confirmar con el usuario antes de enviar la orden de compra
                    DialogResult resultado = MessageBox.Show("¿Está seguro de enviar la compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        // Intenta realizar la inserción de la orden y el detalle dentro de una transacción
                        try
                        {
                            controller.InsertarCompra(codigo, fechas, fechae, txt_departamentos.Text, subtotal, iva, totalOrden, txt_notas.Text, codigoprov, estadoCompra, fechap, codorden);
                            foreach (DataGridViewRow fila in dgv_detalle.Rows)
                            {
                                if (!fila.IsNewRow)
                                {
                                    int ultimoNumeroCompra = controller.ObtenerUltimoNumeroOrden(campoid, tabla);
                                    string cantd = fila.Cells[0].Value.ToString();
                                    string idprod = fila.Cells[1].Value.ToString();
                                    string totfil = fila.Cells[5].Value.ToString();

                                    if (int.TryParse(cantd, out int cantidad) && int.TryParse(idprod, out int idproducto) && double.TryParse(totfil, out double totalfila))
                                    {
                                        controller.InsertarDetalleCompra(ultimoNumeroCompra, cantidad, totalfila, idproducto, codigo);
                                        controller.ActualizarExistenciasCompras(idproducto, cantidad);
                                    }
                                }
                            }

                            MessageBox.Show("Compra registrada correctamente.");
                            this.ctrl_seguridad.setBtitacora("8011", "Se ingresó una compra");
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al enviar la compra: " + ex.Message);
                            MessageBox.Show("Error al enviar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            string tabla = "tbl_compras";
            string campoid = "id_EncComp";
            int ultimoNumeroOrden = controller.ObtenerUltimoNumeroOrden(campoid, tabla);
            txt_numcompra.Text = ultimoNumeroOrden.ToString();
            txt_Idprov.Clear();
            txt_nombreprov.Clear();
            txt_domicilio.Clear();
            txt_telefonoprov.Clear();
            txt_departamentos.Clear();
            dateTimePickerPedido.Value = DateTime.Now; // Restablece la fecha actual
            dateTimePickerEntrega.Value = DateTime.Now; // Restablece la fecha actual
            dateTimePickerVencimiento.Value = DateTime.Now; // Restablece la fecha actual
            txt_subtotal.Clear();
            txt_iva.Clear();
            txt_total.Clear();
            txt_notas.Clear();
            cmb_productos.SelectedIndex = -1;
            dgv_detalle.Rows.Clear();
            txt_numcompra.Enabled = false;
            txt_Idprov.Enabled = false;
            btn_numorden.Enabled = false;
            txt_nombreprov.Enabled = false;
            txt_domicilio.Enabled = false;
            txt_telefonoprov.Enabled = false;
            txt_departamentos.Enabled = false;
            dateTimePickerEntrega.Enabled = false;
            dateTimePickerPedido.Enabled = false;
            dateTimePickerVencimiento.Enabled = false;
            dgv_detalle.Enabled = true;
            txt_cantidad.Enabled = true;
            txt_descripcion.Enabled = true;
            cmb_productos.Enabled = true;
            txt_totalfila.Enabled = true;
            txt_preciou.Enabled = true;
            txt_numorden.Clear();
        }

        private bool ValidarOrden()
        {
            if (int.TryParse(txt_numorden.Text, out int idOrden))
            {
                DataTable ordenData = controller.ObtenerOrdenPorID(idOrden);

                if (ordenData.Rows.Count > 0)
                {
                    DateTime fechaSolicitudBD = (DateTime)ordenData.Rows[0]["fechaSolicitid_OrdComp"];
                    DateTime fechaEntregaBD = (DateTime)ordenData.Rows[0]["fechaEntrega_OrdComp"];
                    string deptoBD = ordenData.Rows[0]["deptoSolicitante_OrdComp"].ToString();
                    string proidBD = ordenData.Rows[0]["tbl_proveedor_id_prov"].ToString();

                    string fechapIngresado = dateTimePickerPedido.Value.ToString("yyyy-MM-dd");
                    string fechaeIngresado = dateTimePickerEntrega.Value.ToString("yyyy-MM-dd");

                    string deptoIngresado = txt_departamentos.Text;
                    string provIngresado = txt_Idprov.Text;

                    DateTime fechaSolicitudIngresada = DateTime.ParseExact(fechapIngresado, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime fechaEntregaIngresada = DateTime.ParseExact(fechaeIngresado, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    if (fechaSolicitudBD == fechaSolicitudIngresada && fechaEntregaBD == fechaEntregaIngresada && deptoIngresado == deptoBD && provIngresado == proidBD)
                    {
                        return true;
                    }
                    else
                    {
                        // Los datos ingresados no coinciden con los datos de la orden.
                        MessageBox.Show("Los datos ingresados no coinciden con los de la orden en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    // La orden no se encontró en la base de datos.
                    MessageBox.Show("El código de orden no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código de orden válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cmb_igualsolicitado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_igualsolicitado.SelectedItem != null)
            {
                if (cmb_igualsolicitado.SelectedItem.ToString() == "Completa")
                {
                    estadoCompra = 1;
                }
                else if (cmb_igualsolicitado.SelectedItem.ToString() == "Incompleta")
                {
                    estadoCompra = 0;
                }
            }
        }

    }
}
