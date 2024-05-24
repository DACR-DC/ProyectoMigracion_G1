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
    public partial class frmEstadoCuenta : Form
    {
        AccountControler ctrl = new AccountControler();
        public List<Cuenta> accounts = new List<Cuenta>();

        public frmEstadoCuenta()
        {
            InitializeComponent();
            int accId = Convert.ToInt32(Seguridad_Controlador.Controlador.GetHash(Seguridad_Controlador.Controlador.idUser));
            this.accounts = this.ctrl.getAccountsFromUser(accId);
            this.lbl_user.Text = this.accounts[0].nombre;
            this.fillCombo();
        }

        public void fillCombo()
        {
            foreach (Cuenta c in this.accounts)
            {
                this.cmb_accounts.Items.Add(c.nombre);
            }
        }

        public void fillDataGrid(double saldo_inicial)
        {
            this.data_grid.ColumnCount = 4;
            this.data_grid.Columns[0].Name = "Fecha";
            this.data_grid.Columns[1].Name = "Concepto";
            this.data_grid.Columns[2].Name = "Debito";
            this.data_grid.Columns[3].Name = "Credito";
            Controlador ctrl = new Controlador();
            DataTable mydata = ctrl.llenarHistorial("tbl_historial_transacciones", this.accounts[cmb_accounts.SelectedIndex].id);
            this.data_grid.Rows.Add("Saldo inicial", "", "", "Q." + saldo_inicial);
            foreach (DataRow row in mydata.Rows)
            {
                if (row["htr_tipo"].Equals("Retiro"))
                {
                    this.data_grid.Rows.Add(row["htr_fecha"].ToString(), row["htr_tipo"].ToString(), "", "Q." + row["htr_monto"]);
                }
                else
                {
                    this.data_grid.Rows.Add(row["htr_fecha"].ToString(), row["htr_tipo"].ToString(), "Q." + row["htr_monto"], "");
                }
            }
            this.data_grid.Rows.Add("Saldo Actual ", "", "", "Q." + this.accounts[cmb_accounts.SelectedIndex].saldo);
            this.customizeRows();
        }

        public void customizeRows()
        {
            foreach (DataGridViewRow row in this.data_grid.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals("Retiro"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(144, 161, 37);
                }
                else if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals("Deposito"))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(206, 213, 222);
                }
            }
        }


        private void cmb_accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            double balance = AccountControler.getAccountInitialBalance(this.accounts[cmb_accounts.SelectedIndex].id);
            this.fillDataGrid(balance);
        }
    }
}
