using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;


namespace CapaVista
{
    public partial class VistaNav : Form
    {
        public VistaNav()
        {
            InitializeComponent();
        }

        private void VistaNav_Load(object sender, EventArgs e)
        {

        }

        public void CargarInforme(string rutaInforme)
        {
            if (!string.IsNullOrEmpty(rutaInforme))
            {
                // Cargar el informe en el CrystalReportViewer
                ReportDocument reporte = new ReportDocument();
                reporte.Load(rutaInforme);

                // Asignar el informe al CrystalReportViewer
                crystalReportViewer2.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("La ruta del informe no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
