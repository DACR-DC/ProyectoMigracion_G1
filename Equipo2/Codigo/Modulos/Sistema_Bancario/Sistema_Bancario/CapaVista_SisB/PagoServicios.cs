using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using CapaModelo_SisB;
using Seguridad_Controlador;

namespace CapaVista_SisB
{
    public partial class PagoServicios : Form
    {
        Seguridad_Controlador.Controlador ctrl;
        private AccountSentence accountSentence;
        private InvoiceSentence invoiceSentence;

        public PagoServicios()
        {
            this.ctrl = new Seguridad_Controlador.Controlador();
            InitializeComponent();

            txt_comboComplemento.Visible = false;

            this.accountSentence = new AccountSentence();
            this.invoiceSentence = new InvoiceSentence();

            CargarTiposDeCuenta();
        }

        private void label3_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // FUNCIONES PARA EL BOTON BUSCAR
            // Busqueda en Base a Número de Cliente
            string accountNit = txt_noCliente.Text;

            // Función para llamar las facturas no pagadas con el Número especifico
            List<Invoice> invoices = invoiceSentence.GetUnpaidInvoicesByAccountNit(accountNit);

            if (invoices.Count == 0)
            {
                MessageBox.Show("No se encontraron facturas pendientes para el número de cliente proporcionado.");
            }
            else
            {
                dataGridView1.DataSource = invoices;
                dataGridView1.Columns["status"].Visible = false; // Ocultar la columna de estado
                dataGridView1.Columns["idService"].Visible = false; // Ocultar la columna de idService

                // Permitir la selección múltiple
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = true;
            }
        }

        public string GenerateSecureRandomNumber(int length)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[length];
                rng.GetBytes(randomNumber);

                // Convert to a number string
                string result = "";
                foreach (byte b in randomNumber)
                {
                    result += (b % 10).ToString();
                }

                return result;
            }
        }

        public void executeTransaction()
        {
            try
            {

                string accountNit = txt_noCliente.Text;
                double amountToPay = ObtenerMontoAPagar();
                int tipoCuentaSeleccionado = Convert.ToInt32(txt_comboComplemento.Text);

                // Verificar si el tipo de cuenta es de débito o crédito
                if (tipoCuentaSeleccionado == 1) // Asumiendo que 1 es débito y 2 es crédito
                {
                    // Verificar si el pago es viable
                    bool paymentViability = accountSentence.checkPaymentViability(accountNit, amountToPay);
                    if (!paymentViability)
                    {
                        MessageBox.Show("El pago no es viable. Saldo insuficiente en la cuenta.");
                        return;
                    }

                    // Realizar el pago del servicio
                    accountSentence.makeServicePayment(accountNit, amountToPay);
                }

                // Cambiar el estado de las facturas seleccionadas
                List<int> facturasPagadas = new List<int>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int facturaId = Convert.ToInt32(row.Cells["id"].Value);
                    invoiceSentence.changeInvoiceStatus(facturaId);
                    facturasPagadas.Add(facturaId);
                }

                MessageBox.Show("Pago realizado exitosamente.");

                // Actualizar la interfaz de usuario o realizar otras acciones necesarias
                ActualizarDataGridView(accountNit, facturasPagadas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pago: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // FUNCIONES PARA EL BOTON PAGAR
            // Llamar a Códigos de Seguridad
            string _code = this.GenerateSecureRandomNumber(5);
            lbl_code.Text = _code;
            frmCodigoSeguridad frm = new frmCodigoSeguridad();
            frm.setRefCode(_code);
            frm.setMethod(this.executeTransaction);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Confirmar las facturas seleccionadas y calcular el total
            CalcularTotal();
        }

        private void ActualizarDataGridView(string accountNit, List<int> facturasPagadas)
        {
            // Recargar el DataGridView excluyendo las facturas pagadas
            List<Invoice> invoices = invoiceSentence.GetUnpaidInvoicesByAccountNit(accountNit);
            dataGridView1.DataSource = invoices.Where(invoice => !facturasPagadas.Contains(invoice.id)).ToList();
        }

        private double ObtenerMontoAPagar()
        {
            // Verificar si el TextBox tiene un valor válido
            if (!double.TryParse(txt_totalPagar.Text, out double monto))
            {
                // Mostrar un mensaje de error si el valor ingresado no es válido
                MessageBox.Show("Por favor, ingrese un monto válido.");
                // En caso de no ser válido
                return 0.0;
            }

            return monto;
        }

        private void CalcularTotal()
        {
            double total = 0.0;

            // Recorre todas las filas seleccionadas del DataGridView
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                // Verifica si la celda no está vacía y si el valor puede ser convertido a double
                if (row.Cells["amount"].Value != null &&
                    double.TryParse(row.Cells["amount"].Value.ToString(), out double valor))
                {
                    // Suma el valor a la variable total
                    total += valor;
                }
            }

            // Muestra el total en el TextBox
            txt_totalPagar.Text = total.ToString();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                DataPropertyName = "id",
                HeaderText = "ID"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ServiceID",
                DataPropertyName = "idService",
                HeaderText = "Service ID"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ServiceName",
                DataPropertyName = "serviceName",
                HeaderText = "Service Name"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ClientNit",
                DataPropertyName = "clientNit",
                HeaderText = "Client NIT"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                DataPropertyName = "amount",
                HeaderText = "Amount"
            });
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Status",
                DataPropertyName = "status",
                HeaderText = "Status"
            });
        }

        private void PagoServicios_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            CargarTiposDeCuenta();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoCuenta.SelectedIndex == 0) // Ahorro
            {
                txt_comboComplemento.Text = "1";
            }
            else if (comboBoxTipoCuenta.SelectedIndex == 1) // Monetario
            {
                txt_comboComplemento.Text = "2";
            }
        }

        private void CargarTiposDeCuenta()
        {
            // Añadir las opciones directamente al ComboBox
            comboBoxTipoCuenta.Items.Add("1 - Ahorro");
            comboBoxTipoCuenta.Items.Add("2 - Monetario");
        }
    }
}