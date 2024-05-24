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
    //David Alejandro Carrillo de la Roca 0901-20-3201
    public partial class PagoFacturaxCobrar : Form
    {
        private CapaControladorERP.Controlador cn;
        public Seguridad_Controlador.Controlador ctrl_seguridad = new Seguridad_Controlador.Controlador();
        public PagoFacturaxCobrar()
        {
            cn = new CapaControladorERP.Controlador();
            InitializeComponent();
            dt_fechaPago.Format = DateTimePickerFormat.Custom;
            dt_fechaPago.CustomFormat = "dd/MM/yyy";
            Combo();
        }
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
        private void cmb_banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_bancos.Text = cmb_banco.SelectedItem.ToString();
        }
        public void PagoExtra()
        {
            DateTime fecha1 = dgvVencimiento.Value;
            DateTime fecha2 = dt_fechaPago.Value;

            double total = Convert.ToDouble(txt_total.Text);

            if (fecha1 < fecha2)
            {
                double pagoExtra = total * 0.15;
                txt_pagoExtra.Text = pagoExtra.ToString("F2");
            }
            else
            {
                txt_pagoExtra.Text = "0.00";
            }
        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            int idcoti;
            if (!int.TryParse(txt_numcoti.Text, out idcoti))
            {
                MessageBox.Show("Ingrese un ID  válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Creditos a Carlos Guzman
            buscar(idcoti);
        }

        private void buscar(int idcoti)
        {

            try
            {
                DataTable dt = cn.Buscar("tbl_ventaspedido", "tbl_cotizaciones_No_Cotizacion", idcoti.ToString());

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txt_numPedido.Text = row["id_ventas_ped"].ToString();
                }
                else
                {
                    MessageBox.Show("No encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string ped = txt_numPedido.Text;
                MessageBox.Show("Pedido " + ped);

                DataTable facno = cn.Buscar("tbl_facturaxcobrar", "tbl_Ventas_detalle_id_ventas_det", ped);
                if (facno.Rows.Count > 0)
                {
                    DataRow row = facno.Rows[0];
                    txt_numfactura.Text = row["NoFactura"].ToString();
                    dgvFactura.Text = row["fecha_factura"].ToString();
                    dgvVencimiento.Text = row["tiempoPago_facxcob"].ToString();
                    txt_porpagar.Text = row["faltante_pago"].ToString();
                    txt_estadofacxcob.Text = row["estado_facxcob"].ToString();
                    MessageBox.Show("NumFact", txt_numfactura.Text = row["NoFactura"].ToString());
                }
                else
                {
                    MessageBox.Show("No hay nada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error No encontrado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string idCoti = txt_numcoti.Text;
                DataTable detalleCoti = cn.Buscar("tbl_detalle_cotizacion", "tbl_cotizaciones_No_Cotizacion", idCoti);
                if (detalleCoti.Rows.Count > 0)
                {
                    DataRow row = detalleCoti.Rows[0];
                    txt_total.Text = row["total_detCoti"].ToString();
                    txt_nombrecl.Text = row["tbl_Clientes_id_cliente"].ToString();
                    txt_idcliente.Text = txt_nombrecl.Text;

                    DataTable nombre_cl = cn.BuscarDato("nombre_cl", "tbl_clientes", "id_cliente", Convert.ToInt32(txt_nombrecl.Text));
                    if (nombre_cl.Rows.Count > 0)
                    {
                        txt_nombrecl.Text = nombre_cl.Rows[0]["nombre_cl"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int idcl = Convert.ToInt32(txt_idcliente.Text);
                DataTable dt3 = cn.Buscar("tbl_clientes", "id_cliente", idcl.ToString());
                if (dt3.Rows.Count > 0)
                {
                    DataRow row = dt3.Rows[0];
                    txt_apellidocl.Text = row["apellido_cl"].ToString();
                    txt_direccioncl.Text = row["direccion_cl"].ToString();
                }
                else
                {
                    MessageBox.Show("No encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cotización o cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string coti = txt_numcoti.Text;
                DataTable detalleCotis = cn.Buscar("vista_detalle_cotizacion", "NoCotizacion", coti);

                dgv_detalle.Rows.Clear();

                if (dgv_detalle.Columns.Count == 0)
                {
                    foreach (DataColumn column in detalleCotis.Columns)
                    {
                        if (column.ColumnName != "NoDetalleCotizacion" &&
                            column.ColumnName != "ClienteID" &&
                            column.ColumnName != "NoCotizacion")
                        {
                            dgv_detalle.Columns.Add(column.ColumnName, column.ColumnName);
                        }
                    }
                }

                if (dataGridView1.Columns.Count == 0)
                {
                    foreach (DataColumn column in detalleCotis.Columns)
                    {
                        dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                    }
                }

                if (detalleCotis.Rows.Count > 0)
                {
                    foreach (DataRow row in detalleCotis.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray);
                    }

                    foreach (DataRow row in detalleCotis.Rows)
                    {
                        List<object> rowData = new List<object>();

                        foreach (DataColumn column in detalleCotis.Columns)
                        {
                            if (column.ColumnName != "NoDetalleCotizacion" &&
                            column.ColumnName != "ClienteID" &&
                            column.ColumnName != "NoCotizacion")
                            {
                                if (column.ColumnName == "TotalCotizacion")
                                {
                                    int productId = Convert.ToInt32(row["CodProducto"]);
                                    DataTable result = cn.BuscarDato("PrecioUnitario", "vista_producto", "CodProducto", productId);
                                    double precioUnitario = 0.0;

                                    if (result.Rows.Count > 0)
                                    {
                                        precioUnitario = Convert.ToDouble(result.Rows[0]["PrecioUnitario"]);
                                    }

                                    rowData.Add(precioUnitario);
                                }
                                else if (column.ColumnName == "CodProducto")
                                {
                                    int productId = Convert.ToInt32(row["CodProducto"]);
                                    DataTable result = cn.BuscarDato("Nombre", "vista_producto", "CodProducto", productId);
                                    string nombreProd = string.Empty;
                                    if (result.Rows.Count > 0)
                                    {
                                        nombreProd = result.Rows[0]["Nombre"].ToString();
                                    }

                                    rowData.Add(nombreProd);
                                }
                                else
                                {
                                    rowData.Add(row[column.ColumnName]);
                                }
                            }
                        }
                        dgv_detalle.Rows.Add(rowData.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar detalles de cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                PagoExtra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar PagoExtra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btn_pagar_Click(object sender, EventArgs e)
        {
            string noFactura = txt_numfactura.Text;
            int cliente = Convert.ToInt32(txt_idcliente.Text);
            string banco = cmb_banco.Text;
            string concepto = txt_concepto.Text;
            double monto_pago = Convert.ToDouble(txt_aPagar.Text);
            double extra_pago = Convert.ToDouble(txt_pagoExtra.Text);
            string fecha_pago = dt_fechaPago.Text;
            string NIT = txt_nit.Text;
            string num_recibo = txt_numero.Text;

            if (cn.FacturaExiste(noFactura))
            {
                double porPagar = cn.CalcularPorPagar(noFactura);

                if (porPagar >= 0)
                {
                    cn.InsertarPagoFacXCobrar(noFactura, cliente, banco, concepto, monto_pago, extra_pago, fecha_pago, NIT, num_recibo);
                    porPagar = cn.CalcularPorPagar(noFactura);
                    cn.ActualizarFaltantePago(noFactura, porPagar);
                    this.ctrl_seguridad.setBtitacora("8036", "Se hizo un pago de factura por cobrar");
                    MessageBox.Show($"Pago registrado con éxito. Monto pendiente por pagar: {porPagar}");

                    int idcoti;
                    if (!int.TryParse(txt_numcoti.Text, out idcoti))
                    {
                        MessageBox.Show("Ingrese un ID válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Créditos a Carlos Guzmán
                    buscar(idcoti);
                }
                else
                {
                    MessageBox.Show("La factura ya está completamente pagada.");
                    int idcoti;
                    if (!int.TryParse(txt_numcoti.Text, out idcoti))
                    {
                        MessageBox.Show("Ingrese un ID válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Créditos a Carlos Guzmán
                    buscar(idcoti);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow) 
                    {
                        int idProducto = Convert.ToInt32(row.Cells["CodProducto"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        cn.ActualizarExistencias(idProducto, cantidad);
                    }
                }
                cn.InsertarPagoFacXCobrar(noFactura, cliente, banco, concepto, monto_pago, extra_pago, fecha_pago, NIT, num_recibo);
                double porPagar = cn.CalcularPorPagar(noFactura);
                cn.ActualizarFaltantePago(noFactura, porPagar);

                MessageBox.Show($"Factura no encontrada. Pago registrado con éxito. Monto pendiente por pagar: {porPagar}");

                int idcoti;
                if (!int.TryParse(txt_numcoti.Text, out idcoti))
                {
                    MessageBox.Show("Ingrese un ID válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Créditos a Carlos Guzmán
                buscar(idcoti);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
