using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModelo_SisB.Templates;
using CapaControlador_SisB;

namespace CapaVista_SisB
{
    public partial class frmNotas : Form
    {
        Controlador cn = new Controlador();
        public List<Innvoice> invoices;
        public frmNotas()
        {
            InitializeComponent();
        }

        public void fillCombo()
        {
            string accountNumber = txt_Cuenta.Text;
            invoices = Controlador.GetFactura(accountNumber);
            foreach (Innvoice inv in invoices)
            {
                this.cmb_facturas.Items.Add(inv.Id + "--" + inv.FacServicio);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.fillCombo();
        }

        private void ch_credito_CheckedChanged(object sender, EventArgs e)
        {
            this.groupB_credito.Enabled = true;
            this.groupB_debito.Enabled = false;
            ch_debito.Checked = false;
        }

        private void ch_debito_CheckedChanged(object sender, EventArgs e)
        {
            this.groupB_credito.Enabled = false;
            this.groupB_debito.Enabled = true;
            ch_credito.Checked = false;
        }

        public void creditMethod(string number)
        {
            double monto = Convert.ToDouble(txt_descuento.Text);
            if (monto > Convert.ToDouble(this.invoices[cmb_facturas.SelectedIndex].FacMonto))
            {
                MessageBox.Show("No puede acreditar un monto mayor al de la factura");
                return;
            }
            TransactionController.makeTransaction(number, monto, -1);
            InvoiceController.creditarFactura(this.invoices[cmb_facturas.SelectedIndex], monto);
            MessageBox.Show("Accion realizada");
        }

        public void debitMethod(string number)
        {
            double monto = Convert.ToDouble(txt_aumento.Text);
            TransactionController.makeTransaction(number, monto, -1);
            InvoiceController.debitarFactura(this.invoices[cmb_facturas.SelectedIndex], monto);
            MessageBox.Show("Accion realizada");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = txt_Cuenta.Text;
            if (ch_debito.CheckState == CheckState.Checked) this.debitMethod(number);
            if (ch_credito.CheckState == CheckState.Checked) this.creditMethod(number);
            int index = cmb_facturas.SelectedIndex;
            this.fillCombo();
            cmb_facturas.SelectedIndex = index;
            lbl_monto.Text = "Q." + this.invoices[cmb_facturas.SelectedIndex].FacMonto.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string monto = ch_credito.Checked ? txt_aumento.Text : "-" + txt_descuento.Text;
            DocumentController.makeTransactionDocument(txt_Cuenta.Text, monto);
        }

        private void cmb_facturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_monto.Text = "Q." + this.invoices[cmb_facturas.SelectedIndex].FacMonto.ToString();
        }

        private void txt_descuento_Click(object sender, EventArgs e)
        {
            txt_descuento.Text = "";
        }

        private void txt_aumento_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void txt_aumento_Click(object sender, EventArgs e)
        {
            txt_aumento.Text = "";
        }

        private void txt_Cuenta_Click(object sender, EventArgs e)
        {
            txt_Cuenta.Text = "";
        }
    }
}
