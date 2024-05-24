using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorERP;
using Seguridad_Controlador;
//Programado por: Carol Chuy

namespace CapaVistaERP.Procesos
{
    public partial class OrdenesdeCompra : Form
    {
        private CapaControladorERP.Controlador controller;
        public Seguridad_Controlador.Controlador ctrl_seguridad = new Seguridad_Controlador.Controlador();
        public OrdenesdeCompra(string id, string nombre, string domicilio, string telefono)
        {
            InitializeComponent();
            controller = new CapaControladorERP.Controlador();
            llenarprod();
            iniciarcombodepartamento();
            txt_idProv.Text = id;
            txt_nombreProv.Text = nombre;
            txt_domicilioProv.Text = domicilio;
            txt_telefonoProv.Text = telefono;
        }
        public void iniciarcombodepartamento()
        {
            cmb_deptosolicitante.Items.Add("Compras");
            cmb_deptosolicitante.Items.Add("Inventario");
            cmb_deptosolicitante.Items.Add("Logística");
        }
        //Llena el combobox de productos
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

        private void OrdenesdeCompra_Load(object sender, EventArgs e)
        {
            string tabla = "tbl_ordenescompra";
            string campoid = "id_OrdComp";
            btn_buscarProveedor.Enabled = true;
            txt_idProv.Enabled = false;
            txt_nombreProv.Enabled = false;
            txt_telefonoProv.Enabled = false;
            txt_domicilioProv.Enabled = false;
            cmb_deptosolicitante.Enabled = true;
            dateTimePickerEntrega.Enabled = true;
            dateTimePickerPedido.Enabled = true;
            txt_numeroorden.Enabled = false;
            int ultimoNumeroOrden = controller.ObtenerUltimoNumeroOrden(campoid, tabla);
            txt_numeroorden.Text = ultimoNumeroOrden.ToString();
        }

        private void btn_buscarProveedor_Click(object sender, EventArgs e)
        {
            //instrucciones para mostrar un formulario que esta dentro de la misma carpeta que este form
            OrdendeCompraModi ordendeCompraModi = new OrdendeCompraModi();
            BuscarProveedor BuscarProveedor = new BuscarProveedor(this, ordendeCompraModi);
            BuscarProveedor.Show();
        }

        public void RecibirDatosDesdeBuscarProveedor(string id, string nombre, string domicilio, string telefono)
        {
            // Actualiza los textbox en del formulario con los datos recibidos
            txt_idProv.Text = id;
            txt_nombreProv.Text = nombre;
            txt_domicilioProv.Text = domicilio;
            txt_telefonoProv.Text = telefono;
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
                    // Sirve para asegurarse de que la fila no sea la fila de encabezado.
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

        private void button4_Click(object sender, EventArgs e)
        {
            string tabla = "tbl_detalleordenescompra";
            string campoid = "id_detalle";

            // Verifica si los campos opcionales son válidos, si no, se establecen en 0
            double subtotal, iva, totalOrden;
            if (!double.TryParse(txt_subtotal.Text, out subtotal) || !double.TryParse(txt_iva.Text, out iva) || !double.TryParse(txt_total.Text, out totalOrden))
            {
                MessageBox.Show("Ingrese los campos del total, confirme la órden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica que los campos de número de orden y código de proveedor sean válidos
            if (!int.TryParse(txt_numeroorden.Text, out int codigo) || string.IsNullOrEmpty(txt_idProv.Text) || !int.TryParse(txt_idProv.Text, out int codigoprov))
            {
                MessageBox.Show("Ingrese un número de orden válido y un código de proveedor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verifica que el código de proveedor sea válido
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

            // Resto del código para enviar la orden de compra
            DateTime fechaSolicitud = dateTimePickerPedido.Value;
            DateTime fechaEntrega = dateTimePickerEntrega.Value;
            string fechas = fechaSolicitud.ToString("yyyy-MM-dd");
            string fechae = fechaEntrega.ToString("yyyy-MM-dd");

            // Confirmar con el usuario antes de enviar la orden de compra
            DialogResult resultado = MessageBox.Show("¿Está seguro de enviar la orden de compra?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Intenta realizar la inserción de la orden y el detalle dentro de una transacción
                try
                {
                    controller.InsertarOrdenCompra(codigo, fechas, fechae, cmb_deptosolicitante.Text, subtotal, iva, totalOrden, txt_nota.Text, codigoprov);
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
                                controller.InsertarDetalleOrdenCompra(ultimoNumeroCompra, codigo, cantidad, totalfila, idproducto);
                            }
                        }
                    }

                    MessageBox.Show("Orden de compra enviada correctamente.");
                    this.ctrl_seguridad.setBtitacora("8010", "Se ingresó una órden de compra");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al enviar la orden de compra: " + ex.Message);
                    MessageBox.Show("Error al enviar la orden de compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            string tabla = "tbl_ordenescompra";
            string campoid = "id_OrdComp";
            int ultimoNumeroOrden = controller.ObtenerUltimoNumeroOrden(campoid, tabla);
            txt_numeroorden.Text = ultimoNumeroOrden.ToString();
            txt_idProv.Clear();
            txt_nombreProv.Clear();
            txt_domicilioProv.Clear();
            txt_telefonoProv.Clear();
            cmb_deptosolicitante.SelectedIndex = -1;
            dateTimePickerPedido.Value = DateTime.Now; // Restablece la fecha actual
            dateTimePickerEntrega.Value = DateTime.Now; // Restablece la fecha actual
            txt_subtotal.Clear();
            txt_iva.Clear();
            txt_total.Clear();
            txt_nota.Clear();
            cmb_productos.SelectedIndex = -1;
            dgv_detalle.Rows.Clear();
            txt_numeroorden.Enabled = false;
            txt_idProv.Enabled = false;
            btn_buscarProveedor.Enabled = false;
            txt_nombreProv.Enabled = false;
            txt_domicilioProv.Enabled = false;
            cmb_deptosolicitante.Enabled = false;
            txt_telefonoProv.Enabled = false;
            dateTimePickerEntrega.Enabled = false;
            dateTimePickerPedido.Enabled = false;
            dgv_detalle.Enabled = true;
            txt_cantidad.Enabled = true;
            txt_descripcion.Enabled = true;
            cmb_productos.Enabled = true;
            txt_totalfila.Enabled = true;
            txt_preciou.Enabled = true;
        }

        private bool ValidarProveedor()
        {
            if (int.TryParse(txt_idProv.Text, out int idProveedor))
            {
                DataTable proveedorData = controller.ObtenerProveedorPorID(idProveedor);

                if (proveedorData.Rows.Count > 0)
                {
                    string nombreProveedor = proveedorData.Rows[0]["nombre_prov"].ToString();
                    string domicilioProveedor = proveedorData.Rows[0]["domicilio_prov"].ToString();
                    string telefonoProveedor = proveedorData.Rows[0]["telefono_prov"].ToString();

                    string nombreIngresado = txt_nombreProv.Text;
                    string domicilioIngresado = txt_domicilioProv.Text;
                    string telefonoIngresado = txt_telefonoProv.Text;

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
