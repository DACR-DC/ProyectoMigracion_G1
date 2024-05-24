using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

using CapaControladorERP;
namespace CapaVistaERP.Procesos
{
    public partial class Dispo_Diaria : Form
    {
        Controlador cn = new Controlador();
        public Dispo_Diaria()
        {
            InitializeComponent();
            LlenarComboCuentaBancaria();
            LlenarComboCuentaBancaria2();
            actualizardatagriew();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        string emp = "tbl_movimientodebancos";
        string sql = "SELECT mb.id_movimientoBanco AS ID, " +
         "cm.concepto_movimientoBanco AS Concepto, " +
         "cb.nombre_empresa AS Cuenta, " +
         "mb.fecha_movimientoBanco AS Fecha, " +
         "mb.monto_movimientoBanco AS Monto, " +
         "mb.efecto_movimientoBanco AS Efecto, " +
         "mb.tipo_movimientoBanco AS Codigo_movimiento, " +
         "mb.cuenta_movimientoBanco AS Codigo_de_cuenta " +
         "FROM " + "tbl_movimientodebancos" + " mb " + // Agregamos un espacio después de tabla
         "INNER JOIN tbl_conceptoMovimientoDeBancos cm ON mb.tipo_movimientoBanco = cm.id_conceptoMovimiento " +
         "INNER JOIN tbl_cuentaBancaria cb ON mb.cuenta_movimientoBanco = cb.id_cuentaBancaria";
        public void actualizardatagriew()
        {
            DataTable dt = cn.llenartablabitacoraMB(sql);
            dataGridView1.DataSource = dt;

        }
        public void LlenarComboCuentaBancaria()
        {
            List<string> concepto = cn.llenarCombo("nombre_empresa", "tbl_cuentabancaria");
            cb_cuenta.Items.Clear();
            cb_cuenta.Items.AddRange(concepto.ToArray());
        }
        public void LlenarComboCuentaBancaria2()
        {
            List<string> concepto = cn.llenarCombo("nombre_banco", "tbl_banco");
            txtIdBanco.Items.Clear();
            txtIdBanco.Items.AddRange(concepto.ToArray());
        }

        public void BuscarDetalleCuentas()
        {
            string tabla = "tbl_cuentabancaria";

            string columna = "nombre_empresa";
            // string dato = cb_pasaporte.SelectedItem.ToString();
            string dato = (cb_cuenta.SelectedItem != null) ? cb_cuenta.SelectedItem.ToString() : string.Empty;

            DataTable dt = cn.Buscar(tabla, columna, dato);

            if (dt.Rows.Count > 0)
            {

                // MessageBox.Show("Datos Encontrados");
                DataRow row = dt.Rows[0]; // Tomamos la primera fila (si hay resultados)

                // Llenamos los controles con los valores del resultado
                txt_IDCUENTAB.Text = row["id_cuentaBancaria"].ToString();
                txt_nombreCuenta.Text = row["nombre_empresa"].ToString();
                txt_noCuenta.Text = row["numero_cuenta"].ToString();
                txt_tipoCuenta.Text = row["tipo_cuenta"].ToString();
                txt_estadoCuenta.Text = row["estado_cuenta"].ToString();
                textsaldoactual.Text = row["saldoDisponible"].ToString();
            }
            else
            {

            }


            //codigo del saldo 

            Decimal saldoActual;
            if (!decimal.TryParse(textsaldoactual.Text, out saldoActual))
            {
                MessageBox.Show("El valor de Saldo Actual no es un número válido.");
                return;
            }

            decimal fondosIngresados = 0;
            decimal fondoRetiro = 0;

            // Procesar cada movimiento y aplicar al saldo actual según el efecto del movimiento
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Monto"].Value != null &&
                    row.Cells["Efecto"].Value != null)
                {
                    decimal monto;
                    if (decimal.TryParse(row.Cells["Monto"].Value.ToString(), out monto))
                    {
                        string efectoMovimiento = row.Cells["Efecto"].Value.ToString();

                        if (efectoMovimiento == "+") // Suma al saldo actual
                        {
                            fondosIngresados += monto;
                        }
                        else if (efectoMovimiento == "-") // Resta al saldo actual
                        {
                            fondoRetiro += monto;
                        }
                    }
                }
            }

            // Mostrar el total de la suma en el TextBox fondosIngresados
            fondosIgresados.Text = fondosIngresados.ToString();

            // Mostrar el total de la resta en el TextBox txtFondoRetiro
            txtFondoRetiro.Text = fondoRetiro.ToString();

            // Calcular el saldo disponible
            decimal saldoDisponible = saldoActual + fondosIngresados - fondoRetiro;

            // Mostrar el saldo disponible en el TextBox txtSaldoDisponible
            txtSaldoDisponible.Text = saldoDisponible.ToString();






        }

        private void cb_cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb_cuenta.SelectedItem != null)
            {
                // Si se selecciona algo en el ComboBox, habilita el Label y el botón
                label4.Visible = true;
                verdispo.Visible = true;
                Registrar.Visible = true;
                Cancelar.Visible = true;
            }
            else
            {
                // Si no se selecciona nada en el ComboBox, deshabilita el Label y el botón
                label4.Visible = false;

                Registrar.Visible = false;
                Cancelar.Visible = false;
                verdispo.Visible = false;
            }

            BuscarDetalleCuentas();
        }
        public void BuscarDetalleBanco()
        {
            // Obtener el valor del ID del banco desde el TextBox correspondiente

            string tabla = "tbl_banco";

            string columna = "nombre_banco";

            string dato = (txtIdBanco.SelectedItem != null) ? txtIdBanco.SelectedItem.ToString() : string.Empty;

            // Realizar la búsqueda en la base de datos
            DataTable dt = cn.Buscar(tabla, columna, dato);

            // Verificar si se encontraron resultados
            if (dt.Rows.Count > 0)
            {
                // Mostrar los detalles del banco encontrados en los TextBox correspondientes
                txt_IDBanco.Text = dt.Rows[0]["id_banco"].ToString();
                txtNombreBanco.Text = dt.Rows[0]["nombre_banco"].ToString();

                txtEstadoBanco.Text = dt.Rows[0]["estado_banco"].ToString();

            }
            else
            {
                MessageBox.Show("No se encontraron resultados.");
            }
        }

        

        
        
        public void GuardarDatos()
            {
                string tabla = "tbl_disponibilidaddiaria";
                Dictionary<string, object> valores = new Dictionary<string, object>();

                valores.Add("id_cuentaDisponibilidad", int.Parse(txt_IDCUENTAB.Text));
                valores.Add("id_bancoActual", int.Parse(txt_IDBanco.Text));
                valores.Add("saldo_disponible", double.Parse(txtSaldoDisponible.Text));
                valores.Add("saldo_consumido", double.Parse(txtFondoRetiro.Text));
                valores.Add("saldo_actual", double.Parse(textsaldoactual.Text));
                valores.Add("fecha_DisponibilidadDiaria", dtp_fecha.Value);

                cn.GuardarDatos(tabla, valores);

                MessageBox.Show("Datos guardados");
            }

        private void Registrar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
        private void LimpiarCampos()
        {
            txt_IDCUENTAB.Clear();
            txt_nombreCuenta.Clear();
            txt_noCuenta.Clear();
            txt_tipoCuenta.Clear();
            txt_estadoCuenta.Clear();
            textsaldoactual.Clear();
            txt_IDBanco.Clear();
            txtNombreBanco.Clear();
            txtEstadoBanco.Clear();
            txtFondoRetiro.Clear();
            txtSaldoDisponible.Clear();

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            MessageBox.Show("Se han cancelado los registros.", "Cancelación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtIdBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDetalleBanco();
        }

        private void verdispo_Click(object sender, EventArgs e)
        {
            bitacoradispo_diaria segundoForm = new bitacoradispo_diaria();
            segundoForm.Show();
        }
    }

    
}



