using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorERP;

//Programado por: Carol Chuy
namespace CapaVistaERP.Procesos
{
    public partial class OrdenesdeCompraMaestro : Form
    {
        Reportes.frmReporteOrdenesdeCompra report = new Reportes.frmReporteOrdenesdeCompra();
        private OrdendeCompraEli OrdendeCompraNav;
        private OrdendeCompraModi OrdendeCompraModi;
        private string id = "";
        private string nombre = "";
        private string domicilio = "";
        private string telefono = "";
        Controlador cn = new Controlador();
        public OrdenesdeCompraMaestro(OrdendeCompraEli ordendeCompraNav, OrdendeCompraModi ordendeCompraModi)
        {
            InitializeComponent();
            actualizardatagridview();
            OrdendeCompraNav = ordendeCompraNav;
            OrdendeCompraModi = ordendeCompraModi;
        }

        private void btn_nueva_Click(object sender, EventArgs e)
        {
            OrdenesdeCompra OrdenesdeCompra = new OrdenesdeCompra(id, nombre, domicilio, telefono);
            OrdenesdeCompra.Show();
        }
        public void actualizardatagridview()
        {
            DataTable dt = cn.llenarTablas("tbl_ordenescompra");
            dt_datos.DataSource = dt;
        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            actualizardatagridview();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la opción seleccionada
            int seleccion = cb_filtro.SelectedIndex;
            string tipoFiltro="";
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);

            // Ejecutar diferentes acciones según el índice seleccionado
            switch (seleccion)
            {
                case 0:
                    tipoFiltro = "Diario";
                    DataTable dtRegistros = cn.ObtenerOrdenesCompraPorFecha(añoSeleccionado, tipoFiltro);
                    // Asignar el DataTable al DataGridView para mostrar los registros filtrados
                    dt_datos.DataSource = dtRegistros;
                    break;
                case 1:
                    tipoFiltro = "Semanal";
                    DataTable dtRegistros1 = cn.ObtenerOrdenesCompraPorFecha(añoSeleccionado, tipoFiltro);
                    // Asignar el DataTable al DataGridView para mostrar los registros filtrados
                    dt_datos.DataSource = dtRegistros1;
                    break;
                case 2:
                    tipoFiltro = "Mensual";
                    DataTable dtRegistros2 = cn.ObtenerOrdenesCompraPorFecha(añoSeleccionado, tipoFiltro);
                    // Asignar el DataTable al DataGridView para mostrar los registros filtrados
                    dt_datos.DataSource = dtRegistros2;
                    break;
                default:
                    break;
            }
            report.MostrarReporte(tipoFiltro,añoSeleccionado);
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dt_datos.SelectedRows.Count > 0)
            {
                // Obtener la primera celda de la fila seleccionada (que corresponde a la primera columna)
                DataGridViewCell firstCell = dt_datos.SelectedRows[0].Cells[0];
                string valorPrimeraColumna = firstCell.Value.ToString();
                OrdendeCompraModi.RecibirDatosDesdeOrdenesCompraModi(valorPrimeraColumna);
            }
            else
            {
                MessageBox.Show("Seleccione una fila.", "Selcción Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dt_datos.SelectedRows.Count > 0)
            {
                // Obtener la primera celda de la fila seleccionada (que corresponde a la primera columna)
                DataGridViewCell firstCell = dt_datos.SelectedRows[0].Cells[0];
                string valorPrimeraColumna = firstCell.Value.ToString();
                OrdendeCompraNav.RecibirDatosDesdeOrdenesCompraNav(valorPrimeraColumna,true);
            }
            else
            {
                MessageBox.Show("Seleccione una fila.", "Selección de Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
                // Verificar si se ha seleccionado un año y un método de filtrado
                if (cb_año.SelectedItem == null || cb_filtro.SelectedItem == null)
                {
                    int añoActual = DateTime.Today.Year;
                    Reportes.frmReporteOrdenesdeCompra repo = new Reportes.frmReporteOrdenesdeCompra();
                    repo.MostrarReporte("Mensual", añoActual);
                    repo.ShowDialog();
                }
                else
                {
                    report.ShowDialog();
                }
        }

        private void dt_datos_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "OrdenesdeCompra.html");
        }


        private void dt_datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que esté seleccionada una fila
            if (dt_datos.SelectedRows.Count > 0)
            {
                // Obtener la primera celda de la fila seleccionada (que corresponde a la primera columna)
                DataGridViewCell firstCell = dt_datos.SelectedRows[0].Cells[0];
                string valorPrimeraColumna = firstCell.Value.ToString();
                OrdendeCompraNav.RecibirDatosDesdeOrdenesCompraNav(valorPrimeraColumna,false);
            }else
            {
                MessageBox.Show("Seleccione una fila y doble clic", "Selección de Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cb_año_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
