using CapaVistaERP.Procesos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaERP.Reportes
{
    public partial class frm_ReportePagos : Form
    {
        ReportedePagos pagos = new ReportedePagos();
        public frm_ReportePagos()
        {
            InitializeComponent();
        }

        public void MostrarReporte(string tipoFiltro, int año)
        {
            DateTime fechaPago;

            if (tipoFiltro == "Diario")
            {
                fechaPago = DateTime.Today;
            }
            else if (tipoFiltro == "Semanal")
            {
                int numDiaSemana = (int)DateTime.Today.DayOfWeek;
                fechaPago = DateTime.Today.AddDays(-numDiaSemana);
            }
            else if (tipoFiltro == "Mensual")
            {
                fechaPago = new DateTime(año, 1, 1);

            }
            else
            {
                fechaPago = new DateTime(año, 1, 1);

            }

            // Configurar los parámetros de fecha en el informe
            pagos.SetParameterValue("fechaPago", fechaPago);

            crystalReportViewer1.ReportSource = pagos;
        }
    }
}
