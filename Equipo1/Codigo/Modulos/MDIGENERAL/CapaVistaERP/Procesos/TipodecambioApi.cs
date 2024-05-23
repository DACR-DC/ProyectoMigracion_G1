using CapaVistaERP.Banguat;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaControladorERP;
using System.Web.Services.Description;
using System.Xml;


namespace CapaVistaERP.Procesos
{
    public partial class TipodecambioApi : Form
    {
        private Banguat.TipoCambio service = new Banguat.TipoCambio();
        public TipodecambioApi()
        {
            InitializeComponent();
            CargarMonedas();
        }

        public class Moneda
        {
            public int Codigo { get; set; }
            public string Descripcion { get; set; }
            public override string ToString()
            {
                return Descripcion;
            }
        }


        private void CargarMonedas()
        {
            try
            {
                // Llamar al método del servicio web para obtener las variables disponibles
                Banguat.InfoVariable infoVariables = service.VariablesDisponibles();

                // Limpiar ComboBox antes de agregar nuevas monedas
                cbMonedas.Items.Clear();

                // Agregar cada moneda al ComboBox
                foreach (var variable in infoVariables.Variables)
                {
                    // Crear objeto Moneda con código y descripción
                    Moneda moneda = new Moneda { Codigo = variable.moneda, Descripcion = variable.descripcion };
                    // Agregar la moneda al ComboBox, mostrando solo la descripción
                    cbMonedas.Items.Add(moneda);
                }

                // Mostrar un mensaje si no hay variables disponibles
                if (cbMonedas.Items.Count == 0)
                {
                    MessageBox.Show("No hay monedas disponibles.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las monedas disponibles: " + ex.Message);
            }
        }

        private void btn_nueva_Click(object sender, EventArgs e)
        {
            try
            {
                string dia = txtDia.Text;
                string mes = txtMes.Text;
                string anio = txtAnio.Text;

                string fechaInicial = $"{dia}/{mes}/{anio}";

                // Obtener el código de moneda seleccionado en el ComboBox
                int codigoMoneda = ObtenerCodigoMoneda();

                // Verificar si el código de moneda es válido
                if (codigoMoneda != -1)
                {
                    // Llamar al método del servicio web para obtener el tipo de cambio
                    Banguat.DataVariable data = service.TipoCambioFechaInicialMoneda(fechaInicial, codigoMoneda);

                    // Crear un nuevo DataTable para almacenar los resultados
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Fecha", typeof(string));
                    dt.Columns.Add("Venta", typeof(decimal)); // Asumiendo que "Venta" es el campo de tipo de cambio en Var
                    dt.Columns.Add("Compra", typeof(decimal)); // Asumiendo que "Compra" es el campo de tipo de cambio en Var

                    // Procesar los datos obtenidos del servicio web
                    foreach (var varItem in data.Vars)
                    {
                        string fecha = varItem.fecha; // Suponiendo que "Fecha" es el campo de fecha en Var
                        decimal tipoCambioVenta = (decimal)varItem.venta; // Convertir explícitamente float a decimal
                        decimal tipoCambioCompra = (decimal)varItem.compra; // Convertir explícitamente float a decimal

                        dt.Rows.Add(fecha, tipoCambioVenta, tipoCambioCompra);
                    }

                    // Mostrar los resultados en el DataGridView
                    dgvTipoCambio.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el tipo de cambio: " + ex.Message);
            }
        }


        private int ObtenerCodigoMoneda()
        {
            if (cbMonedas.SelectedItem is Moneda selectedMoneda)
            {
                return selectedMoneda.Codigo;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una moneda válida.");
                return -1; // Valor por defecto en caso de error
            }
        }



        public void GuardarDatos()
        {
            // Crear una instancia del controlador
            Controlador cn = new Controlador();

            // Capturar el valor del ComboBox moneda
            string monedaSeleccionada = cbMonedas.SelectedItem.ToString();

            // Capturar los valores del día, mes y año de los TextBox
            int dia = int.Parse(txtDia.Text);
            int mes = int.Parse(txtMes.Text);
            int anio = int.Parse(txtAnio.Text);

            // Crear la fecha a partir de los valores capturados
            DateTime fecha = new DateTime(anio, mes, dia);

            // Capturar los valores de la primera fila del DataGridView
            DataGridViewRow primeraFila = dgvTipoCambio.Rows[0];
            double venta = double.Parse(primeraFila.Cells["venta"].Value.ToString());
            double compra = double.Parse(primeraFila.Cells["compra"].Value.ToString());

            // Llamar al método del controlador para guardar los datos de la primera fila
            cn.InsertarTipoCambio2(fecha, monedaSeleccionada, venta, compra);

            // Mostrar mensaje de éxito
            MessageBox.Show("Datos guardados exitosamente en la tabla tipo de cambio.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
    }
}
