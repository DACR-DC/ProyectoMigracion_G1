﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using CapaModeloERP;
using System.Windows.Forms;

namespace CapaControladorERP
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();

        public DataTable llenarTablas(string tabla)
        {
            OdbcDataAdapter dt = sn.CargarDatos(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        //David Carrillo 0901-20-3201 
        public List<string> ComboFill(string columna, string tabla)
        {
            return sn.ComboFill(columna, tabla);
        }
        //David Carrillo 0901-20-3201 
        public double GetPrecio(string nombreProducto)
        {
            double precio = sn.GetPrecio(nombreProducto);
            return precio;
        }
        //David Carrillo 0901-20-3201 
        public void insertarCliente(string nombre_cl, string apellido_cl, string direccion_cl, string correo_cl, string telefono_cl)
        {
            sn.InsertarCliente(nombre_cl, apellido_cl, direccion_cl, correo_cl, telefono_cl);
        }
        //David Carrillo 0901-20-3201 
        public string obtenerCliente(string nombreCliente)
        {
           
            string nombrecl = sn.ObtenerCliente(nombreCliente);
            return nombrecl;
        }
        //David Carrillo 0901-20-3201 
        public void InsertarCoti(int No_Cotizacion, string fecha_coti, string fechaFinal_coti)
        {
            sn.InsertarCoti(No_Cotizacion,fecha_coti,fechaFinal_coti);
        }
        //David Carrillo 0901-20-3201 
        public void InsertarDetalleCoti(int id_cliente, int cantidad_coti, int No_Cotizacion, int cod_producto, double total_detCoti)
        {
            sn.InsertarDetalleCoti(id_cliente,cantidad_coti,No_Cotizacion,cod_producto,total_detCoti);
        }
        //David Carrillo 0901-20-3201 
        public string ObtenerUltimoIdCoti()
        {
          return  sn.ObtenerUltimoIdCoti();
        }
        //David Carrillo 0901-20-3201 
        public int ObtenerCodigoProducto(string nombreProducto)
        {
            return sn.ObtenerCodigoProducto(nombreProducto);
        }

        // carlos enrique modulo bancos
        public List<string> llenarCombo(string columna1, string tabla)
        {
            return sn.llenarCombo(columna1, tabla);
        }

        // carlos enrique modulo bancos
        public DataTable Buscar(string tabla, string columna, string dato)
        {
            return sn.Buscar(tabla, columna, dato);

        }
        // carlos enrique modulo bancos
        public bool GuardarDatos(string tabla, Dictionary<string, object> valores)
        {
            return sn.Guardar(tabla, valores);
        }
        // carlos enrique modulo bancos
        public bool ActualizarSaldoCuentaBancaria(int idCuenta, double monto, bool esDeposito)
        {
            return sn.ActualizarSaldoCuentaBancaria(idCuenta, monto, esDeposito);
        }

        //Carol Chuy Modulo Compras
        public string[] itemsprod()
        {
            string[] Items = sn.llenarCmbprod();
            return Items;
        }

        //Carol Chuy Modulo Compras
        public DataTable enviarprod()
        {

            var dt1 = sn.obtenerprod();
            return dt1;
        }

        //Carol Chuy Modulo Compras
        public void CargarOpcionesOrden(ComboBox combo)
        {
            // Aquí proporciona las opciones al ComboBox
            combo.Items.Add("Directa");
            combo.Items.Add("Relacionada");
        }

        //Carol Chuy Modulo Compras
        public int ObtenerUltimoNumeroOrden(String campoid, String tabla)
        {
            return sn.ObtenerUltimoNumeroOrden(campoid, tabla);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerDescripcion(string productId)
        {
            return sn.ObtenerDescripcion(productId);
        }

        //Carol Chuy Modulo Compras
        public decimal ObtenerPrecioUnitario(string productId)
        {
            return sn.ObtenerPrecioUnitario(productId);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerNombreProveedor(string proveedorID)
        {
            return sn.ObtenerNombreProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerDomicilioProveedor(string proveedorID)
        {
            return sn.ObtenerDomicilioProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerTelefonoProveedor(string proveedorID)
        {
            return sn.ObtenerTelefonoProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public string ObtenerNitProveedor(string proveedorID)
        {
            return sn.ObtenerNitProveedor(proveedorID);
        }

        //Carol Chuy Modulo Compras
        public DataTable llenarTablasCondicion(String tabla)
        {
            OdbcDataAdapter dt = sn.llenarTablasCondicion(tabla);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }


    }
}
