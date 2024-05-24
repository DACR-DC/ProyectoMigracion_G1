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
using CapaModelo_SisB.Templates;

namespace CapaVista_SisB
{
    public partial class MovimientosBancarios : Form
    {
        CapaControlador_SisB.AccountControler ctrl;
        public int accId;
        Controlador cn = new Controlador();
         Controlador con = new Controlador();
        string mov = "tbl_movimientosBancarios";
        public List<Cuenta> cuentas;



        public MovimientosBancarios()
        {
            InitializeComponent();
            this.ctrl = new CapaControlador_SisB.AccountControler();
            accId = Convert.ToInt32(Seguridad_Controlador.Controlador.GetHash(Seguridad_Controlador.Controlador.idUser));
            cuentas = this.ctrl.getAccountsFromUser(accId);
            fillCombo(cuentas, cmb_cuentaDebito);
            actualizardatagridView();
            cmb_cuentaDebito.SelectedIndex = -1;

            txt_cuentaDebito.Clear();
            txt_cuentaCredito.Clear();
            txt_valorTransferencia.Clear();
            txt_descripcionTransferencia.Clear();
            txt_estado.Clear();

            dgv_vistaTransacciones.Columns[0].HeaderText = "ID";
            dgv_vistaTransacciones.Columns[1].HeaderText = "Valor";
            dgv_vistaTransacciones.Columns[2].HeaderText = "Descripcion";
            dgv_vistaTransacciones.Columns[3].HeaderText = "Cuenta a debitar";
            dgv_vistaTransacciones.Columns[4].HeaderText = "Cuenta a acreditar";
            dgv_vistaTransacciones.Columns[5].HeaderText = "Estatus";
            dgv_vistaTransacciones.Columns[6].HeaderText = "Fecha de ingreso";

            cmb_cuentaDebito.SelectedIndexChanged += cmb_cuentaDebito_SelectedIndexChanged;


    }
        private void CargarCuentasEnCombobox()
        {
            DataTable dtCuentas = cn.ObtenerCuentas();
            cmb_cuentaDebito.DataSource = dtCuentas;
            cmb_cuentaDebito.DisplayMember = "cue_numero";
            cmb_cuentaDebito.ValueMember = "cue_id";

        }

        public void fillCombo(List<Cuenta> _cuentas, ComboBox cmb)
        {
            foreach (Cuenta cuenta in _cuentas)
            {
                cmb.Items.Add(cuenta.nombre + "--" + cuenta.numero);
            }

        }
        public void actualizardatagridView()
        {
            DataTable dt = cn.llenarTbl(mov);
            dgv_vistaTransacciones.DataSource = dt;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Mov_bancarios_Load(object sender, EventArgs e)
        {


        }

        private void txt_estado_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                ((TextBox)sender).Text = "1";
            }
        }

        private void btn_cancelarTransaccion_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("¿Desea cancelar la transacción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cmb_cuentaDebito.SelectedIndex = -1;

                txt_cuentaDebito.Clear();
                txt_cuentaCredito.Clear();
                txt_valorTransferencia.Clear();
                txt_descripcionTransferencia.Clear();
                txt_estado.Clear();

                // Mostrar un mensaje de éxito
                MessageBox.Show("Transacción cancelada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se canceló la transaccion.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_rtrans_Click(object sender, EventArgs e)
        {

            string estado = "1";
            DialogResult result = MessageBox.Show("¿Desea guardar la transacción?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 

            if (result == DialogResult.Yes)
            {
                double monto = Convert.ToDouble(txt_valorTransferencia.Text);
                bool canPay = TransactionController.accountCanPay(cuentas[cmb_cuentaDebito.SelectedIndex].id, monto);
                if (canPay)
                {
                    TransactionController.makeTransaction(cuentas[cmb_cuentaDebito.SelectedIndex].numero, monto, -1);
                    MessageBox.Show("Transaccion Realizada con Exito");
                }
                else
                {
                    MessageBox.Show("Saldo insuficiente para la transaccion");
                }
                //LUIS ALBERTO FRANCO MORAN 0901-20-23979
                // Llamar al Controlador para insertar el movimiento en la base de datos
                cn.InsertarMovimiento(txt_valorTransferencia.Text, txt_descripcionTransferencia.Text, cuentas[cmb_cuentaDebito.SelectedIndex].id.ToString(), txt_cuentaCredito.Text, estado);


                // Actualizar el DataGridView con los datos actualizados
                actualizardatagridView();

                // Limpiar los TextBox
                cmb_cuentaDebito.SelectedIndex = -1;

                txt_cuentaDebito.Clear();
                txt_cuentaCredito.Clear();
                txt_valorTransferencia.Clear();
                txt_descripcionTransferencia.Clear();
                txt_estado.Clear();


                // Mostrar un mensaje de éxito
                MessageBox.Show("Movimiento realizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //LUIS ALBERTO FRANCO MORAN 0901-20-23979
                // Limpiar los TextBox si el usuario elige "No"
                cmb_cuentaDebito.SelectedIndex = -1;

                txt_cuentaDebito.Clear();
                txt_cuentaCredito.Clear();
                txt_valorTransferencia.Clear();
                txt_descripcionTransferencia.Clear();
                txt_estado.Clear();

                // Mostrar un mensaje informativo
                MessageBox.Show("No se guardó el archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);//OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
            }
        }

        private void cmb_cuentaDebito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_cuentaDebito.SelectedIndex;
        }

        private void cmb_cuentaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
