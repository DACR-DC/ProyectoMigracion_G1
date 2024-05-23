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

namespace CapaVistaERP.Procesos
{//carlos enrique guzman cabrera
    public partial class frmBitacoraAutorizacionOrdenesCompra : Form
    {
        Controlador cn = new Controlador();
        public frmBitacoraAutorizacionOrdenesCompra()
        {
            InitializeComponent();
            actualizardatagriew();
            dtTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        string sql = "SELECT ao.id_numeroDeAutorizacion AS ID, " +
           "ao.tbl_OrdenesCompra_id_OrdComp AS Codigo_orden, " +
           "ao.estadoOrden AS Estado, " +
           "ao.conceptoDeAutorizacion AS Observaciones, " +
           "ao.fechaAutorizacion AS Fecha, " +
           "ao.subTotal AS Subtotal, " +
           "ao.iva AS IVA, " +
           "ao.totalOrden AS Total, " +
           "cb.nombre_empresa AS Cuenta_asociada " +
           "FROM tbl_AutorizacionOrdenesCompra ao " +
           "INNER JOIN tbl_cuentaBancaria cb ON ao.cuentaAsociada = cb.id_cuentaBancaria";

        public void actualizardatagriew()
        {
            DataTable dt = cn.llenartablabitacoraMB(sql);
            dtTabla.DataSource = dt;

        }

        private void dtTabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener los datos de la fila seleccionada
            DataGridViewRow filaSeleccionada = dtTabla.Rows[e.RowIndex];

            // Crear una instancia de Form2
            AutorizacionOrdenDeCompra form2 = new AutorizacionOrdenDeCompra();

            // Pasar los datos a los controles en Form2
            form2.txt_IDAOC.Text = filaSeleccionada.Cells["ID"].Value.ToString();
            form2.cb_numeroOrden.Text = filaSeleccionada.Cells["Codigo_orden"].Value.ToString();
            form2.cb_cuenta.Text = filaSeleccionada.Cells["Cuenta_asociada"].Value.ToString();
            form2.txt_Descripcion.Text = filaSeleccionada.Cells["Observaciones"].Value.ToString();
            form2.cb_estado.Text = filaSeleccionada.Cells["Estado"].Value.ToString();
            form2.dtp_fechaAutorizacion.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value);

            //inabilita los controles de la form 2

            form2.cb_numeroOrden.Enabled = false;
            form2.cb_cuenta.Enabled = false;
            form2.txt_Descripcion.Enabled = false;
            form2.cb_estado.Enabled = false;
            form2.dtp_fechaAutorizacion.Enabled = false;

            form2.btn_guardar.Enabled = false;
            form2.btn_modificar.Enabled = true;
            form2.btn_verificar.Enabled = false;
            form2.panel2.Visible = false;

            form2.StartPosition = FormStartPosition.CenterScreen;
            // Mostrar Form2
            form2.ShowDialog();
        }

        private async void btn_nueva_Click(object sender, EventArgs e)
        {
            await Task.Delay(500);
            AutorizacionOrdenDeCompra ventana = new AutorizacionOrdenDeCompra();
            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.Show();
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dtTabla.SelectedRows.Count > 0)
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Verificar la respuesta del usuario
                if (resultado == DialogResult.Yes)
                {
                    // Obtener el ID de la fila seleccionada
                    int idSeleccionado = Convert.ToInt32(dtTabla.SelectedRows[0].Cells["ID"].Value);

                    // Llamar al método EliminarMovimiento del controlador con el ID seleccionado
                    bool eliminado = cn.EliminarRegistroAO(idSeleccionado);

                    if (eliminado)
                    {
                        MessageBox.Show("Registro eliminado correctamente.");
                        // Actualizar el DataGridView después de la eliminación
                        actualizardatagriew();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el registro. Verifique el ID del movimiento.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.frmReporteDeAutorizacionOrdenDeCompra Reporte = new Reportes.frmReporteDeAutorizacionOrdenDeCompra();
            Reporte.ShowDialog();
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "AutorizacionesCompra.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);
            DataTable dtRegistros = cn.FiltrarRegistrosPorFechaAO(añoSeleccionado, "Diario");
            // Asignar el DataTable al DataGridView para mostrar los registros filtrados
            dtTabla.DataSource = dtRegistros;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);
            DataTable dtRegistros = cn.FiltrarRegistrosPorFechaAO(añoSeleccionado, "Semanal");
            // Asignar el DataTable al DataGridView para mostrar los registros filtrados
            dtTabla.DataSource = dtRegistros;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);
            DataTable dtRegistros = cn.FiltrarRegistrosPorFechaAO(añoSeleccionado, "Mensual");
            // Asignar el DataTable al DataGridView para mostrar los registros filtrados
            dtTabla.DataSource = dtRegistros;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
