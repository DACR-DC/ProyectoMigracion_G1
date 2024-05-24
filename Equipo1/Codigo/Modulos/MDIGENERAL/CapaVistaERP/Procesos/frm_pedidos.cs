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
//Otto Adrian Lopez Ventura
namespace CapaVistaERP.Procesos
{
    public partial class frm_pedidos : Form

    {
        Controlador cn = new Controlador();
        public frm_pedidos()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            DateTime fechaSeleccionada = dateTimePicker1.Value;
            DateTime nuevaFecha = fechaSeleccionada.AddDays(15);
            dateTimePicker2.Value = nuevaFecha;
            UltimaVenta();
            this.fillData();
           
        }

        private void frm_pedidos_Load(object sender, EventArgs e)
        {

        }
        private void UltimaVenta()
        {
            string idVenta = cn.ObtenerUltimoDato("id_ventas_ped", "tbl_ventaspedido", "id_ventas_ped");
            if (idVenta == "No hay dato registrado")
            {
                idVenta = "0";
                txt_venta.Text = idVenta;
            }
            else
            {
                int venta = Convert.ToInt32(idVenta) + 1;
                Console.WriteLine("Ncoti1 " + venta);
                txt_venta.Text = venta.ToString();
                Console.WriteLine("id ultima venta " + idVenta);
            }
        }
        
        private void buscarVendedor(int idVendedor)
        {

            DataTable dtVendedor = cn.BuscarVende("tbl_vendedor", "id_vendedor", idVendedor.ToString());

            if (dtVendedor.Rows.Count > 0)
            {
                DataRow row = dtVendedor.Rows[0];
                MessageBox.Show($"Nombre del vendedor: {row["nombre_vend"]}, Apellido: {row["apellido_vend"]}, Teléfono: {row["telefono_vend"]}");

                txt_nombre_vendedor.Text = row["nombre_vend"].ToString();
                txt_idCliente.Text = row["nombre_vend"].ToString();
                txt_apellido_vendedor.Text = row["apellido_vend"].ToString();
                txt_telefono_vendedor.Text = row["telefono_vend"].ToString();
                txt_estado_vendedor.Text = row["estado_vend"].ToString();
            }
            else
            {
                MessageBox.Show("Vendedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscarCotizacion(int idCotizacion)
        {


            DataTable dtCotizacion = cn.BuscarCotizacion("tbl_detalle_cotizacion", "tbl_cotizaciones_No_Cotizacion", idCotizacion.ToString());

            if (dtCotizacion.Rows.Count > 0)
            {

                DataRow row = dtCotizacion.Rows[0];
                MessageBox.Show($"Nombre del vendedor: {row["id_detalle_cotizacion"]}, Cliente: {row["tbl_clientes_id_cliente"]}, Cantidad: {row["cantidad_coti"]}, Numero: {row["tbl_cotizaciones_No_Cotizacion"]}, Producto: {row["tbl_producto_cod_producto"]}, Total: {row["total_detCoti"]}");

                txt_nombre.Text = row["tbl_clientes_id_cliente"].ToString();
                txt_cantidad.Text = row["cantidad_coti"].ToString();
                txt_precio.Text = row["tbl_cotizaciones_No_Cotizacion"].ToString();
                txt_descripcion.Text = row["tbl_producto_cod_producto"].ToString();
                txt_total.Text = row["total_detCoti"].ToString();
            }
            else
            {
                MessageBox.Show("Vendedor no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int idVendedor;
            if (!int.TryParse(txt_id_vendedor.Text, out idVendedor))
            {
                MessageBox.Show("Ingrese un ID de vendedor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"ID del vendedor: {idVendedor}");

            buscarVendedor(idVendedor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idCotizacion;
            if (!int.TryParse(txt_id_cotizacion.Text, out idCotizacion))
            {
                MessageBox.Show("Ingrese un ID de cotizacion valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show($"ID de cotizacion: {idCotizacion}");

            buscarCotizacion(idCotizacion);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Creditos a David Carrillo 0901-20-3201 
            int idVendedor = Convert.ToInt32(txt_id_vendedor.Text);
            int idCotizacion= Convert.ToInt32(txt_id_cotizacion.Text);
            


            cn.INSVentasPedido(idVendedor, idCotizacion);
            MessageBox.Show("idVendedor" + idVendedor + "idCoti" + idCotizacion);
            double total = Convert.ToDouble(txt_total.Text);
            string limite = dateTimePicker2.Text;
            string estado = "Por Pagar";
            int idVenta = Convert.ToInt32(txt_venta.Text);
            MessageBox.Show("idVenta" + idVenta);
            MessageBox.Show("idCliente" + txt_nombre.Text);
            int cl= Convert.ToInt32(txt_nombre.Text);



           // cn.InsertarFactura(total, limite, estado, idVenta, cl);
            // MessageBox.Show("Datos a guarddar"+total+limite+estado+idVenta+cl);
            MessageBox.Show("Datos Guardados Correctamente");

        }

        public void fillData()
        {
            this.data_cotizaciones.DataSource = this.cn.ObtenerCotizaciones();
        }

        public void updateProductTable(int Id)
        {
            this.data_products.DataSource = this.cn.ObtenerProductosPorCotizacion(Id);
        }

        private void data_cotizaciones_Click(object sender, EventArgs e)
        {
            int Selected = Convert.ToInt32(data_cotizaciones.SelectedRows[0].Cells[0].Value);
            this.updateProductTable(Selected);
        }

        private void txt_venta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

    

