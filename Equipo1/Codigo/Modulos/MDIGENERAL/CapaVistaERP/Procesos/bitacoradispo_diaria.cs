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
{
    public partial class bitacoradispo_diaria : Form
    {
        Controlador cn = new Controlador();
        public bitacoradispo_diaria()
        {
            InitializeComponent();
            actualizardatagriew();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        string emp = "tbl_disponibilidaddiaria";
        public void actualizardatagriew()
        {
            DataTable dt = cn.llenartablabitacoradispodiaria(emp);
            dataGridView1.DataSource = dt;

        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            actualizardatagriew();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                int idSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);

                // Llamar al método EliminarMovimiento del controlador con el ID seleccionado
                bool eliminado = cn.EliminarDisponibilidadDiaria(idSeleccionado);

                if (eliminado)
                {
                    MessageBox.Show("Registro eliminado correctamente.");
                    // Actualizar el DataGridView después de la eliminación
                    actualizardatagriew();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el registro. Verifique el ID .");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private async void btn_nueva_Click(object sender, EventArgs e)
        {
            await Task.Delay(500);
            Dispo_Diaria form2 = new Dispo_Diaria();
            form2.StartPosition = FormStartPosition.CenterScreen;
            form2.Show();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.frnsReporteDispoDiaria Reporte = new Reportes.frnsReporteDispoDiaria();
            Reporte.ShowDialog();
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "Ayuda en el uso del proceso Disponibilidad Diaria.html");
        }
    }
}
