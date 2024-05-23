using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorERP;
namespace CapaVistaERP.Procesos
{// carlos enrique guzman cabrera
    public partial class frmMovimientoDeBancos : Form
    {
        Controlador cn = new Controlador();
        public frmMovimientoDeBancos()
        {
            InitializeComponent();
            LlenarComboTipoMovimiento();
            LlenarComboCuentaBancaria();
        }

        public void LlenarComboTipoMovimiento()
        {
            List<string> concepto = cn.llenarCombo("concepto_movimientoBanco", "tbl_conceptomovimientodebancos");
            cb_movimiento.Items.Clear();
            cb_movimiento.Items.AddRange(concepto.ToArray());
        }

        public void LlenarComboCuentaBancaria()
        {
            List<string> concepto = cn.llenarCombo("nombre_empresa", "tbl_cuentabancaria");
            cb_cuenta.Items.Clear();
            cb_cuenta.Items.AddRange(concepto.ToArray());
        }


        public void BuscarDetalleMovimientos()
        {
            string tabla = "tbl_conceptomovimientodebancos";

            string columna = "concepto_movimientoBanco";
            // string dato = cb_pasaporte.SelectedItem.ToString();
            string dato = (cb_movimiento.SelectedItem != null) ? cb_movimiento.SelectedItem.ToString() : string.Empty;

            DataTable dt = cn.Buscar(tabla, columna, dato);

            if (dt.Rows.Count > 0)
            {

              //  MessageBox.Show("Datos Encontrados");
                DataRow row = dt.Rows[0]; // Tomamos la primera fila (si hay resultados)

                // Llenamos los controles con los valores del resultado
                txt_IDmovimiento.Text = row["id_conceptoMovimiento"].ToString();
                txt_concepto.Text = row["concepto_movimientoBanco"].ToString();
                txt_efecto.Text = row["efecto_movimientoBanco"].ToString();

            }
            else
            {

            }
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

            }
            else
            {

            }
        }

        public void GuardarDatos()
        {
            string tabla = "tbl_movimientodebancos";
            Dictionary<string, object> valores = new Dictionary<string, object>();

            valores.Add("tipo_movimientoBanco", int.Parse(txt_IDmovimiento.Text));
            valores.Add("fecha_movimientoBanco", dtp_fecha.Value);
            valores.Add("monto_movimientoBanco", int.Parse(txt_monto.Text));
            valores.Add("cuenta_movimientoBanco", int.Parse(txt_IDCUENTAB.Text));
            valores.Add("efecto_movimientoBanco", txt_efecto.Text);


            cn.GuardarDatos(tabla, valores);

            //MessageBox.Show("Datos guardados");
        }

        public void ActualizarSaldoCuentaBancaria()
        {
            double monto = double.Parse(txt_monto.Text);
            bool esDeposito = (txt_efecto.Text == "+"); // Verificar si el texto es "+"
            int idCuenta = int.Parse(txt_IDCUENTAB.Text);
            bool resultado = cn.ActualizarSaldoCuentaBancaria(idCuenta, monto, esDeposito);

            //if (resultado)
            //{
                //MessageBox.Show("Saldo actualizado correctamente");
            //}
            //else
            //{
                //MessageBox.Show("Error al actualizar el saldo");
            //}
        }

        private void cb_movimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDetalleMovimientos();
        }

        private void cb_cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDetalleCuentas();
        }

        private void btn_realizarMovimiento_Click(object sender, EventArgs e)
        {
            GuardarDatos();
            ActualizarSaldoCuentaBancaria();
            MessageBox.Show("Datos guadaddos y saldos actualizados exitosamente");
        }

        private void btn_cancelarMovimiento_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación
            DialogResult result = MessageBox.Show("Se limpiaran todas las casillas. ¿Desea limpiar?", "Confirmación", MessageBoxButtons.YesNo);

            // Si el usuario elige "Sí", cerrar la ventana; de lo contrario, mantenerla abierta.
            if (result == DialogResult.Yes)
            {
                txt_concepto.Text = "";
                txt_efecto.Text = "";
                txt_IDmovimiento.Text = "";
                txt_IDCUENTAB.Text = "";
                txt_monto.Text = "";
                txt_nombreCuenta.Text = "";
                txt_tipoCuenta.Text = "";
                txt_noCuenta.Text = "";
                txt_estadoCuenta.Text = "";
                cb_cuenta.SelectedIndex = -1;
                cb_movimiento.SelectedIndex = -1;

            }else if (result == DialogResult.No){

                MessageBox.Show("no se limpiaron las casillas");

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Delay(500);
            this.Close();

        }

        private void frmMovimientoDeBancos_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancelarMovimiento_Click_1(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación
            DialogResult result = MessageBox.Show("Se limpiaran todas las casillas. ¿Desea limpiar?", "Confirmación", MessageBoxButtons.YesNo);

            // Si el usuario elige "Sí", cerrar la ventana; de lo contrario, mantenerla abierta.
            if (result == DialogResult.Yes)
            {
                txt_concepto.Text = "";
                txt_efecto.Text = "";
                txt_IDmovimiento.Text = "";
                txt_IDCUENTAB.Text = "";
                txt_monto.Text = "";
                txt_nombreCuenta.Text = "";
                txt_tipoCuenta.Text = "";
                txt_noCuenta.Text = "";
                txt_estadoCuenta.Text = "";
                cb_cuenta.SelectedIndex = -1;
                cb_movimiento.SelectedIndex = -1;

            }
            else if (result == DialogResult.No)
            {

                MessageBox.Show("no se limpiaron las casillas");

            }
        }

        private void btn_realizarMovimiento_Click_1(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas continuar, verifica antes los datos ingresados?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (resultado == DialogResult.Yes)
            {
                // El usuario confirmó, ejecutar el código
                GuardarDatos();
                ActualizarSaldoCuentaBancaria();
                MessageBox.Show("Datos guadaddos y saldos actualizados exitosamente");
            }
            else
            {
                // El usuario canceló, mostrar un mensaje
                MessageBox.Show("Operación cancelada por el usuario");
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ayudas_Click(object sender, EventArgs e)
        {
            string rutaAyuda = @"..\..\..\..\..\..\..\Ayuda\Modulos\Ayudas\AyudasByTech.chm";
            Help.ShowHelp(this, rutaAyuda, "Bancos.html");
        }
    }
}
