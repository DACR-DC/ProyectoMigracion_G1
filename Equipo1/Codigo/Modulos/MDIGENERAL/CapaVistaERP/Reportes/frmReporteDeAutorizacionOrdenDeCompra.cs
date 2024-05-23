using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace CapaVistaERP.Reportes
{// carlos enrique guzman cabrera
    public partial class frmReporteDeAutorizacionOrdenDeCompra : Form
    {
        public frmReporteDeAutorizacionOrdenDeCompra()
        {
            InitializeComponent();
            CargarReporte();
        }

        public void CargarReporte()
        {
            try
            {
                // PASO 1: Obtener la ruta actual de la solución
                string currentPath = AppDomain.CurrentDomain.BaseDirectory;

                // PASO 2: Retroceder hasta llegar a la carpeta "Equipo1"
                DirectoryInfo directoryInfo = new DirectoryInfo(currentPath);
                while (directoryInfo != null && directoryInfo.Name != "Equipo1")
                {
                    directoryInfo = directoryInfo.Parent;
                }

                if (directoryInfo == null)
                {
                    MessageBox.Show("No se encontró la carpeta 'Equipo1'. Ruta actual: " + currentPath);
                    return;
                }

                // PASO 3: Construir la ruta del archivo y verificar su existencia
                string reportPath = Path.Combine(directoryInfo.FullName, "Reportes", "Modulos", "Bancos", "ReporteAutorizacionOrdenesCompra.rpt");

                if (File.Exists(reportPath))
                {
                    MessageBox.Show("Archivo encontrado en: " + reportPath);

                    // Cargar el reporte
                    ReportDocument reportDocument = new ReportDocument();
                    reportDocument.Load(reportPath);

                    // Establecer el reporte en el CrystalReportViewer
                    crystalReportViewer1.ReportSource = reportDocument;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("Archivo no encontrado. Ruta buscada: " + reportPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }

        }
    }
}

