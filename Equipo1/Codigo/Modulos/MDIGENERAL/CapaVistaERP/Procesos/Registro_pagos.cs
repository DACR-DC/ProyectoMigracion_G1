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
    public partial class Registro_pagos : Form
    { Controlador cn = new Controlador();
        Reportes.frm_ReportePagos report = new Reportes.frm_ReportePagos();
        public Registro_pagos()
        {
            InitializeComponent();
            actualizardatagridview();
        }

        public void actualizardatagridview()
        {
            DataTable dt = cn.llenarTablas("tbl_pagofact");
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
            
        }
        private void btn_reporte_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_reporte_Click_1(object sender, EventArgs e)
        {

                Reportes.frm_ReportePagos repo = new Reportes.frm_ReportePagos();
                repo.ShowDialog();

        }

        private void btn_ayudas_Click_1(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "Ventas 2.html");
        }


        /*
        private void cb_filtro_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            // Obtener el índice de la opción seleccionada
            int seleccion = cb_filtro.SelectedIndex;
            string tipoFiltro = "";
            int añoSeleccionado = Convert.ToInt32(cb_año.SelectedItem);

            // Ejecutar diferentes acciones según el índice seleccionado
            switch (seleccion)
            {
                case 0:
                    tipoFiltro = "Diario";
                    DataTable dtRegistros = cn.ObtenerPagosPorFecha(añoSeleccionado, "Diario");
                    // Asignar el DataTable al DataGridView para mostrar los registros filtrados
                    dt_datos.DataSource = dtRegistros;
                    break;
                case 1:
                    tipoFiltro = "Semanal";
                    DataTable dtRegistros1 = cn.ObtenerPagosPorFecha(añoSeleccionado, "Semanal");
                    // Asignar el DataTable al DataGridView para mostrar los registros filtrados
                    dt_datos.DataSource = dtRegistros1;
                    break;
                case 2:
                    tipoFiltro = "Mensual";
                    DataTable dtRegistros2 = cn.ObtenerPagosPorFecha(añoSeleccionado, "Mensual");
                    // Asignar el DataTable al DataGridView para mostrar los registros filtrados
                    dt_datos.DataSource = dtRegistros2;
                    break;
                default:
                    break;
            }
            report.MostrarReporte(tipoFiltro, añoSeleccionado);
        }

        private void cb_año_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        */
    }
}
