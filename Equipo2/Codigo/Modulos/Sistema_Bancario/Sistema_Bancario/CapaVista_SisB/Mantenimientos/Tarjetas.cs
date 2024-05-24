using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_SisB;

namespace CapaVista_SisB.Mantenimientos
{
    public partial class frmTarjetas : Form
    {
        public frmTarjetas()
        {
            InitializeComponent();
        }

        public string GenerateRandomNumber(int length = 16)
        {
            Random random = new Random();
            string result = "";

            for (int i = 0; i < length; i++)
            {
                result += random.Next(0, 10).ToString();
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cvvCode = this.GenerateRandomNumber(3);
            string cardNumber = this.GenerateRandomNumber();
            txt_cvv.Text = cvvCode;
            txt_numero.Text = cardNumber;
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

        private void txt_cuenta2_Click(object sender, EventArgs e)
        {
            txt_cuenta2.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void txt_saldo_crediticio_Click(object sender, EventArgs e)
        {
            txt_saldo_crediticio.Text = "";
        }

        private void btn_cobro2_Click(object sender, EventArgs e)
        {
            DateTime fechaHora = date_v.Value;
            if (ch_credito.Checked)
            {
                bool state = CardController.createCreditCard(txt_numero.Text, txt_cvv.Text, fechaHora.ToString("yyyy-MM-dd"), txt_cuenta2.Text, Convert.ToDouble(txt_saldo_crediticio.Text));
                string msg = state ? "Tarjeta de credito creada correctamente" : "Error al crear la tarjeta, revise los datos del cliente";
                MessageBox.Show(msg);
            }
            else
            {
                bool state = CardController.createDebitCard(txt_numero.Text, txt_cvv.Text, fechaHora.ToString("yyyy-MM-dd"), textBox1.Text);
                string msg = state ? "Tarjeta de debito creada correctamente" : "Error al crear la tarjeta, revise los datos de la cuenta";
                MessageBox.Show(msg);
            }
        }
    }
}




