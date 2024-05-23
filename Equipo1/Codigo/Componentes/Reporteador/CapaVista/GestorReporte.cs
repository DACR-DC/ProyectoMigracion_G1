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
using CrystalDecisions.CrystalReports.Engine;

namespace CapaVista
{
    public partial class GestorReporte : Form
    {
        public DataTable _table;
        public GestorReporte(DataTable tb)
        {
            this._table = tb;
            InitializeComponent();
        }

        public void generateReport()
        {
            ReportDocument report = new ReportDocument();
            report.SetDataSource(this._table);

            using (MemoryStream memoryStream = (MemoryStream)report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.CrystalReport))
            {
                using (FileStream fileStream = new FileStream("informe.rpt", FileMode.Create))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
            report.Close();
        }
        private void btn_generar_Click(object sender, EventArgs e)
        {
            this.generateReport();
        }
    }
}
