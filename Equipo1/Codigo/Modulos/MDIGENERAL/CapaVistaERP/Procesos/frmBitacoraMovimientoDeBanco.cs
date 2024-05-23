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
    public partial class frmBitacoraMovimientoDeBanco : Form
    {
        Controlador cn = new Controlador();
        public frmBitacoraMovimientoDeBanco()
        {
            InitializeComponent();
            actualizardatagriew();
            dtTabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        string sql = "SELECT mb.id_movimientoBanco AS ID, " +
          "cm.concepto_movimientoBanco AS Concepto, " +
          "cb.nombre_empresa AS Cuenta, " +
          "mb.fecha_movimientoBanco AS Fecha, " +
          "mb.monto_movimientoBanco AS Monto, " +
          "mb.efecto_movimientoBanco AS Efecto, " +
          "mb.tipo_movimientoBanco AS Codigo_movimiento, " +
          "mb.cuenta_movimientoBanco AS Codigo_de_cuenta " +
          "FROM " + "tbl_movimientodebancos" + " mb " + // Agregamos un espacio después de tabla
          "INNER JOIN tbl_conceptoMovimientoDeBancos cm ON mb.tipo_movimientoBanco = cm.id_conceptoMovimiento " +
          "INNER JOIN tbl_cuentaBancaria cb ON mb.cuenta_movimientoBanco = cb.id_cuentaBancaria";


        public void actualizardatagriew()
        {
            DataTable dt = cn.llenartablabitacoraMB(sql);
            dtTabla.DataSource = dt;

        }

        //public void BuscarPorFecha()
        //{
        //   DateTime fechaSeleccionada = dateTimePicker1.Value;
        //  string strfiltro = fechaSeleccionada.ToString("yyyy-MM-dd");
        // DataTable dt = cn.BuscarMB(strfiltro);
        //dtTabla.DataSource = dt;
        //}

        private void dtTabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener los datos de la fila seleccionada
            DataGridViewRow filaSeleccionada = dtTabla.Rows[e.RowIndex];

            // Crear una instancia de Form2
            frmMovimientoDeBancos form2 = new frmMovimientoDeBancos();

            // Pasar los datos a los controles en Form2
            form2.cb_movimiento.Text = filaSeleccionada.Cells["Concepto"].Value.ToString();
            form2.txt_concepto.Text = filaSeleccionada.Cells["Concepto"].Value.ToString();
            form2.txt_efecto.Text = filaSeleccionada.Cells["Efecto"].Value.ToString();
            form2.cb_cuenta.Text = filaSeleccionada.Cells["Cuenta"].Value.ToString();
            form2.txt_monto.Text = filaSeleccionada.Cells["Monto"].Value.ToString();
            form2.dtp_fecha.Value = Convert.ToDateTime(filaSeleccionada.Cells["Fecha"].Value);
            form2.txt_IDmovimiento.Text = filaSeleccionada.Cells["Codigo_movimiento"].Value.ToString();
            form2.txt_IDCUENTAB.Text = filaSeleccionada.Cells["Codigo_de_cuenta"].Value.ToString();

            //inabilita los controles de la form 2

            form2.cb_movimiento.Enabled = false;
            form2.cb_cuenta.Enabled = false;
            form2.txt_monto.Enabled = false;
            form2.dtp_fecha.Enabled = false;
            form2.txt_IDmovimiento.Enabled = false;
            form2.txt_IDCUENTAB.Enabled = false;
            form2.btn_realizarMovimiento.Enabled = false;
            form2.btn_cancelarMovimiento.Enabled = false;

            form2.StartPosition = FormStartPosition.CenterScreen;
            // Mostrar Form2
            form2.ShowDialog();
        }

        private async void btn_nueva_Click(object sender, EventArgs e)
        {
            await Task.Delay(500);
            frmMovimientoDeBancos form2 = new frmMovimientoDeBancos();
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
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
                    bool eliminado = cn.EliminarMovimiento(idSeleccionado);

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
            Reportes.frmReportesDeMovimientosDeBancos Reporte = new Reportes.frmReportesDeMovimientosDeBancos();
            Reporte.ShowDialog();
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "Bancos.html");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);
            DataTable dtRegistros = cn.FiltrarRegistrosPorFecha(añoSeleccionado, "Diario");
            // Asignar el DataTable al DataGridView para mostrar los registros filtrados
            dtTabla.DataSource = dtRegistros;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);
            DataTable dtRegistros = cn.FiltrarRegistrosPorFecha(añoSeleccionado, "Semanal");
            // Asignar el DataTable al DataGridView para mostrar los registros filtrados
            dtTabla.DataSource = dtRegistros;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);
            DataTable dtRegistros = cn.FiltrarRegistrosPorFecha(añoSeleccionado, "Mensual");
            // Asignar el DataTable al DataGridView para mostrar los registros filtrados
            dtTabla.DataSource = dtRegistros;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
