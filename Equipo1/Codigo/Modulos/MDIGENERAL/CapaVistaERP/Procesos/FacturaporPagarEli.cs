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

namespace CapaVistaERP.Procesos
{
    public partial class FacturaporPagarEli : Form
    {
        private CapaControladorERP.Controlador controller;
        public Seguridad_Controlador.Controlador ctrl_seguridad = new Seguridad_Controlador.Controlador();
        public FacturaporPagarEli()
        {
            InitializeComponent();
            controller = new CapaControladorERP.Controlador();
        }
        public void RecibirDatosDesdeFacturasEli(string id,bool boton)
        {
            string tabla = "tbl_facturaxpagar";
            string columna = "NoFactura";
            button4.Visible = boton;
            DataTable tablaMaestra = controller.filtrardatos(tabla, columna, id);
            MostrarDatosEnTextBox(tablaMaestra);
            this.Show();
        }
        public void MostrarDatosEnTextBox(DataTable tabla)
        {
            // Verifica si la tabla tiene al menos una fila
            if (tabla.Rows.Count > 0)
            {
                // Obtiene la primera fila de la tabla
                DataRow fila = tabla.Rows[0];

                // Obtén los valores de los campos y asígnalos a variables
                string id = fila["NoFactura"].ToString();
                string nomprov = fila["nombreprov_facxpag"].ToString();
                string nitprov = fila["nitprov_facxpag"].ToString();
                string fechaVenc = fila["fechavenc_facxpag"].ToString();
                string fechaAbo = fila["fecha_abono"].ToString();
                string subtotal = fila["subtotal_facxpag"].ToString();
                string iva = fila["iva_facxpag"].ToString();
                string total = fila["totalfac_facxpag"].ToString();
                string notas = fila["notas_facxpag"].ToString();
                string idcompra = fila["tbl_Encabezado_Compras_id_EncComp"].ToString();
                // Asigna los valores de las variables a los TextBox en tu formulario
                txt_numfactura.Text = id;
                txt_nombreprov.Text = nomprov;
                txt_nitprov.Text = nitprov;
                dateTimePickerVencimiento.Text = fechaVenc;
                dateTimePickerAbono.Text = fechaAbo;
                txt_subtotal.Text = subtotal;
                txt_iva.Text = iva;
                txt_total.Text = total;
                txt_nota.Text = notas;
                txt_numcompra.Text = idcompra;
                string idprov = controller.ObtenerIdProd(nitprov);
                ObtenerDatosProveedor(idprov);
                actualizardatagridviewFactura(id);
            }
            else
            {
                // Si la tabla está vacía, muestra un mensaje de error o realiza alguna otra acción
                MessageBox.Show("No se encontraron datos para mostrar.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ObtenerDatosProveedor(string proveedorId)
        {
            string nombreProveedor = controller.ObtenerNombreProveedor(proveedorId);
            string domicilioProveedor = controller.ObtenerDomicilioProveedor(proveedorId);
            string telefonoProveedor = controller.ObtenerTelefonoProveedor(proveedorId);
            txt_nombreprov.Text = nombreProveedor;
            txt_domicilio.Text = domicilioProveedor;
            txt_telefonoprov.Text = telefonoProveedor;
            txt_Idprov.Text = proveedorId;
        }
        public void actualizardatagridviewFactura(string codigo)
        {
            string tabla = "tbl_detallefacturaxpagar";
            string campo = "tbl_facturaXPagar_NoFactura";
            DataTable dt = controller.filtrardatos(tabla, campo, codigo);
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
                    newRow["Cantidad"] = row["cantidad_detalleFac"];
                    newRow["ID_Producto"] = row["tbl_Producto_cod_producto"];
                    newRow["Nombre"] = nombre;
                    newRow["Descripción"] = descripcion;
                    newRow["Precio_Unitario"] = precioUnitario;
                    newRow["Total"] = row["totalPorProducto_detalleFac"];
                    // Agregamos la nueva fila al DataTable filtrado
                    filteredTable.Rows.Add(newRow);
                }
            }
            // Devolvemos el DataTable filtrado
            return filteredTable;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string num = txt_numfactura.Text;
            int codigo = int.Parse(num);
            // Confirmar con el usuario antes de enviar la orden de compra
            DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar la factura?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Intenta realizar la inserción de la orden y el detalle dentro de una transacción
                try
                {
                    controller.EliminarDetalleFactura(codigo);
                    controller.EliminarFactura(codigo);
                    MessageBox.Show("Factura eliminada correctamente");
                    this.ctrl_seguridad.setBtitacora("8012", "Se eliminó una factura");
                    Limpiar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar la factura: " + ex.Message);
                    MessageBox.Show("Error al eliminar la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Limpiar()
            {
                txt_numcompra.Clear();
                txt_numfactura.Clear();
                dateTimePickerVencimiento.Value = DateTime.Now;
                dateTimePickerAbono.Value = DateTime.Now;
                txt_subtotal.Clear();
                txt_iva.Clear();
                txt_total.Clear();
                txt_nota.Clear();
                txt_Idprov.Clear();
                txt_nombreprov.Clear();
                txt_domicilio.Clear();
                txt_telefonoprov.Clear();
                txt_nitprov.Clear();
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

            private void FacturaporPagarEli_FormClosing(object sender, FormClosingEventArgs e)
            {
            // Si el usuario intenta cerrar el formulario, cancela el cierre y oculta el formulario en su lugar
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancela el cierre del formulario
                this.Hide();     // Oculta el formulario en lugar de cerrarlo
            }
            }
    }
}
