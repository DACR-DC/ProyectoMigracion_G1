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
using Seguridad_Controlador;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Templates;
using System.IO;

namespace CapaVista_SisB
{
    public partial class frmDeposito : Form
    {
        CapaControlador_SisB.Controlador ctrl = new CapaControlador_SisB.Controlador();
        double monto = 0;
        public frmDeposito()
        {
            InitializeComponent();
        }




        public void fillCmb()
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txt_cuenta_Enter(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool result = ctrl.MakeDeposit(txt_cuenta.Text, Convert.ToDouble(textBox1.Text));
            if (result)
            {
                MessageBox.Show("Desposito realizado");
                monto = Convert.ToDouble(textBox1.Text);
                return;
            }
            MessageBox.Show("Cuenta no encontrada, intente de nuevo");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DocumentController.makeTransactionDocument(txt_cuenta.Text, textBox1.Text);
        }


    }
}
