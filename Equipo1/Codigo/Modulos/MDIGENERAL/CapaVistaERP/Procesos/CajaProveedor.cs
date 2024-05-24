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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaVistaERP.Procesos
{
    //Andrea Corado 0901-20-2841
    public partial class CajaProveedor : Form
    {
        private Controlador cn;
        string tabla1 = "tbl_facturaxpagar";
        private OperacionesProvMaestro OperacionesProvMaest;
        public CajaProveedor(OperacionesProvMaestro operacionesProv)
        {
            InitializeComponent();
            OperacionesProvMaest = operacionesProv;
            cn = new Controlador();
            Combo();
            Combo2();
            txt_nit.TextChanged += txt_nombre_TextChanged;
            
        }

        public void tabla()
        {
            DataTable dt = cn.llenarTablas(tabla1);
            dgv_pagoproveedor.DataSource = dt;
        }


        /*public void filtrodata()
        {
            string filtro = txt_nit.Text;
            string data = "0";
            DataTable dt = cn.filtrardatosp(tabla1, "nitprov_facxpag", filtro, "estado_facxpag", data);
            dgv_pagoproveedor.DataSource = dt;
        }*/

        public void Combo()
        {
            try
            {
                List<string> producto = cn.ComboFill("nombre_banco", "tbl_banco");
                cmb_banco.Items.Clear();
                cmb_banco.Items.AddRange(producto.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("error" + e);
            }
        }

        public void Combo2()
        {
            try
            {
                List<string> producto = cn.ComboFill("nombre_transprov", "tbl_transprov");
                cb_tipotransa.Items.Clear();
                cb_tipotransa.Items.AddRange(producto.ToArray());
            }
            catch (Exception e)
            {
                MessageBox.Show("error" + e);
            }
        }

        public void Combodefacturas()
        {
            try
            {
                List<string> producto = cn.ComboFillfactura("NoFactura", "tbl_facturaxpagar", "nitprov_facxpag", txt_nit.Text, "estado_facxpag");
                cb_nofact.Items.Clear();
                cb_nofact.Items.AddRange(producto.ToArray());

                // Suscribir el evento SelectedIndexChanged del ComboBox
                cb_nofact.SelectedIndexChanged += (sender, e) => {
                    // Obtener el número de factura seleccionado
                    string noFacturaSeleccionada = cb_nofact.SelectedItem.ToString();
                    // Obtener los datos de la factura seleccionada y llenar los campos
                    LlenarCamposFactura(noFacturaSeleccionada);
                };

            }
            catch (Exception e)
            {
                MessageBox.Show("error" + e);
            }
        }

        public void LlenarCamposFactura(string noFactura)
        {
            
            try
            {
                (DateTime fechaVencimiento, decimal total) = cn.ObtenerFechaVYTotal(noFactura);
                // Llenar los campos de texto con los datos obtenidos
                txt_FechaV.Text = fechaVencimiento.ToString(); // Ajusta el formato según sea necesario
                txt_factotal.Text = total.ToString(); // Ajusta el formato según sea necesario
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al llenar los campos de la factura: " + e.Message);
            }
        }

        private void cmb_banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_bancos.Text = cmb_banco.SelectedItem.ToString();
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            //ActualizarComboBoxFacturas(txt_nit.Text);
        }

       
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            MovimientoProveedores proveedor = new MovimientoProveedores(this);
            proveedor.Show();
        }


        public void datosProv (string idprov,string nombreprov,string nitprov)
        {
            txt_idprov.Text = idprov;
            txt_nombreprov.Text = nombreprov;
            txt_nitprov.Text = nitprov;
            txt_nit.Text= nitprov;
        }

        private void btn_buscarFactura_Click(object sender, EventArgs e)
        {
            //filtrodata();
            Combodefacturas();
        }

        double sumaTotal = 0;
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número de factura seleccionado
                string noFacturaSeleccionada = cb_nofact.SelectedItem.ToString();

                // Obtener los datos de la factura seleccionada
                (DateTime fechaVencimiento, decimal total) = cn.ObtenerFechaVYTotal(noFacturaSeleccionada);

                // Agregar una nueva fila al DataGridView
                dgv_pagoproveedor.Rows.Add(noFacturaSeleccionada, fechaVencimiento.ToString(), total.ToString());

                if (double.TryParse(txt_factotal.Text, out double valor))
                {
                    // Sumar el valor al total acumulado
                    sumaTotal += valor;

                    // Mostrar la suma total en el otro TextBox
                    txt_totalapagar.Text = sumaTotal.ToString();

                    //txtNoFactura.Text = "";
                    txt_FechaV.Text = "";
                    txt_factotal.Text = "";

                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la factura al DataGridView: " + ex.Message);
            }


        }

        private void dgv_pagoproveedor_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_pagoproveedor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv_pagoproveedor_SelectionChanged(object sender, EventArgs e)
        {

        }


        private double totalFacturasAcumulado = 0;
        private void ActualizarSubtotal()
        {
            double subtotal = 0.0;
            foreach (DataGridViewRow row in dgv_pagoproveedor.Rows)
            {
                subtotal += Convert.ToDouble(row.Cells["Totalfacturas"].Value);
            }
            txt_totalapagar.Text = subtotal.ToString();
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_pagoproveedor.SelectedRows.Count > 0)
            {
                DataGridViewRow DGVfila = dgv_pagoproveedor.SelectedRows[0];
                dgv_pagoproveedor.Rows.Remove(DGVfila);
                ActualizarSubtotal();
            }
            else
            {
                MessageBox.Show("Seleccione una fila valida para eliminar");
            }

        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos de la interfaz de usuario
                string idpTexto = txt_idprov.Text;
                int idp;
                if (!int.TryParse(idpTexto, out idp))
                {
                    MessageBox.Show("El ID del proveedor no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string totalmovTexto = txt_Sumadefacturas.Text;
                double totalmov;
                if (!double.TryParse(totalmovTexto, out totalmov))
                {
                    MessageBox.Show("El total del movimiento no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime fechaAbono = dt_fechaabono.Value;
                string fechas = fechaAbono.ToString("yyyy-MM-dd");

                // Confirmar con el usuario antes de enviar el pago
                DialogResult resultado = MessageBox.Show("¿Está seguro de hacer el pago?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Insertar la operación principal en la base de datos
                    cn.InsertarOperacion(idp, fechas, totalmov);

                    // Recorrer las filas del DataGridView para insertar detalles y actualizar estados
                    foreach (DataGridViewRow fila in dgv_pagoproveedor.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            string nofactura = fila.Cells[0].Value?.ToString();

                            // Obtener valores de los TextBoxes (asumo que estos valores no cambian por fila)
                            string banco = txt_bancos.Text;
                            string tipo = txt_tipomovpro.Text;
                            string numero = txt_numero.Text;
                            string concepto = txt_concepto.Text;

                            // Validar y convertir el número de factura
                            if (!string.IsNullOrEmpty(nofactura) && int.TryParse(nofactura, out int numfact))
                            {
                                // Insertar detalle de la operación en la base de datos
                                cn.InsertarDetalleOperacionPro(numfact, banco, tipo, numero, concepto);

                                // Actualizar estado de la factura en la base de datos
                                string dato = "1"; // Supongo que este es el valor que deseas asignar al estado de la factura
                                cn.Actualizap(tabla1, "estado_facxpag", dato, "NoFactura", numfact);
                            }
                            else
                            {
                                MessageBox.Show("La factura en la fila " + fila.Index + " no es un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    MessageBox.Show("Pago realizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar el pago: " + ex.Message);
                MessageBox.Show("Ocurrió un error al realizar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarCampos()
        {
            txt_idprov.Clear();
            txt_nombreprov.Clear();
            txt_nitprov.Clear();
            txt_nit.Clear();
            //txtNoFactura.Clear();
            txt_Sumadefacturas.Clear();
            txt_totalapagar.Clear();
            txt_bancos.Clear();
            txt_tipomovpro.Clear();
            txt_numero.Clear();
            dt_fechaabono.Value = DateTime.Now; // Restablece la fecha actual
            txt_concepto.Clear();
            sumaTotal = 0;
            totalFacturasAcumulado = 0;
            dgv_pagoproveedor.Enabled = true;
            cb_nofact.Enabled = true;
            dgv_pagoproveedor.Rows.Clear();
            cb_nofact.Items.Clear();
            cb_nofact.Text = "";
            cmb_banco.Text = "";
            cb_tipotransa.Text = "";
            txt_FechaV.Clear();
            txt_factotal.Clear();
            //cmb_banco.Items.Clear();
            //cb_tipotransa.Items.Clear();
        }

        private void txt_tipomovpro_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_tipotransa_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tipomovpro.Text = cb_tipotransa.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void brn_confirmar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea confirmar las facturas a pagar?", "Confirmación de pago", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dgv_pagoproveedor.Enabled = false;
                cb_nofact.Enabled = false;

                double subtotal = 0;

                foreach (DataGridViewRow fila in dgv_pagoproveedor.Rows)
                {
                    // Verifica que la fila no sea la nueva fila (que sería el encabezado).
                    if (!fila.IsNewRow)
                    {
                        // Obtiene el valor de la última celda de la fila.
                        double valorCelda;
                        if (double.TryParse(fila.Cells[dgv_pagoproveedor.ColumnCount - 1].Value.ToString(), out valorCelda))
                        {
                            // Suma el valor al subtotal.
                            subtotal += valorCelda;
                        }
                    }
                }

                // Asigna el subtotal al TextBox txt_Sumadefacturas
                txt_Sumadefacturas.Text = subtotal.ToString("F2");

                // Obtén el valor del TextBox txt_totalapagar
                string totalText = txt_totalapagar.Text;

                // Asigna ese valor al TextBox txt_Sumadefacturas
                txt_totalapagar.Text = subtotal.ToString("F2");


                List<int> facturasSeleccionadas = new List<int>();

                // Recorre el DataGridView para obtener las facturas seleccionadas desde el ComboBox
                foreach (DataGridViewRow row in dgv_pagoproveedor.Rows)
                {
                    // Suponiendo que el ComboBox está en la columna "NoFactura"
                    if (row.Cells["NoFacturas"] is DataGridViewComboBoxCell comboBoxCell && comboBoxCell.Value != null)
                    {
                        int noFactura = Convert.ToInt32(comboBoxCell.Value);
                        facturasSeleccionadas.Add(noFactura);
                    }
                }

            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            OperacionesProvMaestro estado = new OperacionesProvMaestro(txt_idprov.Text,txt_nombreprov.Text,txt_nitprov.Text);
            estado.Show();
        }

        private void CajaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
