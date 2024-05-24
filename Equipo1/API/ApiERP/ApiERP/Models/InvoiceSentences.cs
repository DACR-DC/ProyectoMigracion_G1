using ApiERP.Models.Templates;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.Data.Odbc;
using System.Data.SqlTypes;

namespace ApiERP.Models
{
    public class InvoiceSentences
    {
        public Connection conn;

        public InvoiceSentences()
        {
            this.conn = new Connection();
        }


        public List<FacturaPorCobrar> getInvoicesByClient(string dpi)
        {
            List<FacturaPorCobrar> invoices = new List<FacturaPorCobrar>();
            string sql = "SELECT NoFactura, total_facxcob, tiempoPago_facxcob, estado_facxcob, tbl_Ventas_detalle_id_ventas_det, tbl_Clientes_id_cliente, fecha_factura, faltante_pago FROM tbl_facturaxcobrar inner join tbl_clientes on tbl_clientes.id_cliente = tbl_facturaxcobrar.tbl_clientes_id_cliente where tbl_clientes.id_cliente = '" + dpi + "'";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                invoices.Add(new FacturaPorCobrar(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDate(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetDate(6), reader.GetDecimal(7)));
            }
            return invoices;
        }

        public List<FacturaPorCobrar> getAllInvoicesX()
        {
            List<FacturaPorCobrar> invoices = new List<FacturaPorCobrar>();
            string sql = "select * from tbl_facturaxcobrar";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                invoices.Add(new FacturaPorCobrar(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDate(2), reader.GetString(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetDate(6), reader.GetDecimal(7)));
            }
            return invoices;
        }

        public bool UpdateInvoiceStatus(int invoiceNumber, string newStatus)
        {
            string sql = "UPDATE tbl_facturaxcobrar SET estado_facxcob = ? WHERE NoFactura = ?";
            using (OdbcCommand cmd = new OdbcCommand(sql, conn.connection()))
            {
                cmd.Parameters.AddWithValue("estado_facxcob", newStatus);
                cmd.Parameters.AddWithValue("NoFactura", invoiceNumber);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Devuelve true si se actualizó alguna fila, false si no
            }

        }
    }
}

        
