using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;

namespace Reporteador
{
    public partial class Vista_de_Reportes : Form
    {
        public string RutaInformeSeleccionado { get; set; }
        public Vista_de_Reportes()
        {
            InitializeComponent();
        }

        private void lbl_titulo_Click(object sender, EventArgs e)
        {

        }

        private void Vista_de_Reportes_Load(object sender, EventArgs e)
        {
            // Verificar si se proporcionó una ruta de informe
            if (!string.IsNullOrEmpty(RutaInformeSeleccionado))
            {
                // Cargar el informe en el CrystalReportViewer
                ReportDocument reporte = new ReportDocument();
                reporte.Load(RutaInformeSeleccionado); // Carga el informe desde la ruta proporcionada

                // Asignar el informe al CrystalReportViewer
                crystalReportViewer1.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("No se proporcionó una ruta de informe válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cerrar el formulario si no se proporcionó una ruta válida
            }
        }
        
    }
}
