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
using CrystalDecisions.Shared;

namespace CapaVistaERP.Reportes
{
    public partial class frmReporteOrdenesdeCompra : Form
    {
        // Cargar el informe desde la ruta especificada
        ReporteOrdenesdeCompra reporte = new ReporteOrdenesdeCompra();
        public frmReporteOrdenesdeCompra()
        {
            InitializeComponent();
        }

        private void frmReporteOrdenesdeCompra_Load(object sender, EventArgs e)
        {

        }

        public void MostrarReporte(string tipoFiltro, int año)
        {
            DateTime fechaInicio, fechaFin;

            if (tipoFiltro == "Diario")
            {
                fechaInicio = DateTime.Today;
                fechaFin = DateTime.Today.AddDays(1).AddSeconds(-1);
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaInicio = DateTime.Today.AddDays(-numDiaSemana);
                fechaFin = fechaInicio.AddDays(7).AddSeconds(-1);
            }
            else if (tipoFiltro == "Mensual")
            {
                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }
            else
            {
                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31).AddDays(1).AddSeconds(-1);
            }

            // Configurar los parámetros de fecha en el informe
            reporte.SetParameterValue("FechaInicio", fechaInicio);
            reporte.SetParameterValue("FechaFin", fechaFin);

            crystalReportViewer1.ReportSource = reporte;
        }


    }
}
