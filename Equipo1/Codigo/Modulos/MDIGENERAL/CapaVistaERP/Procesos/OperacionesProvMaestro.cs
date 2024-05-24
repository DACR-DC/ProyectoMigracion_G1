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
    public partial class OperacionesProvMaestro : Form
    {
        Controlador cn = new Controlador();
        string tabla1 = "tbl_facturaxpagar";
        public OperacionesProvMaestro(string idprove, string nombreprov, string nitprove)
        {
            InitializeComponent();
            tabla();


        }
        public void tabla()
        {
            DataTable dt = cn.llenarTablas(tabla1);
            dg_facturasprove.DataSource = dt;
        }
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "OperacionesProveedores.html");
        }

        private void cb_filtrado_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            Reportes.frmReporteTodasLasFacturas todasLasFacturas = new Reportes.frmReporteTodasLasFacturas();
            todasLasFacturas.Show();

            Reportes.ReportedeFacturasPagadas facturasPagadas = new Reportes.ReportedeFacturasPagadas();
            facturasPagadas.Show();

            Reportes.frmReportesFacturasNoPagadas facturasNoPagadas = new Reportes.frmReportesFacturasNoPagadas();
            facturasNoPagadas.Show();

        }

        private void dg_facturasprove_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
   
}
