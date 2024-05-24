using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_SisB.Templates;
using System.Data.Odbc;

namespace CapaModelo_SisB.Sentences
{

    public class InnvoiceSentences
    {
        public static Conexion conn = new Conexion();

        public InnvoiceSentences()
        {


        }

        // Metodo estatico para obtener facturas de unn cliente por su numero de cuenta

        public static List<Innvoice> getClientInnvoices(string accountNumber)
        {
            string sql = " SELECT fac_id, fac_fecha, tbl_factura.cli_nit, fac_monto, fac_estado, fac_servicio from tbl_factura inner join tbl_cliente on tbl_cliente.cli_nit = tbl_factura.cli_nit inner join tbl_cuenta on tbl_cuenta.cue_cliente = tbl_cliente.cli_id " +
                          " WHERE tbl_cuenta.cue_numero = '" + accountNumber + "';";

            List<Innvoice> invoices = new List<Innvoice>();
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                invoices.Add(new Innvoice(reader.GetInt32(0), reader.GetDate(1), reader.GetString(2), reader.GetDecimal(3), reader.GetString(4), reader.GetString(5)));
            }
            return invoices;
        }

        public static void modifyInnvoice(int invoiceId, double monto, int estado)
        {
            string sql = "update tbl_factura set fac_monto='" + monto + "', fac_estado='" + estado + "' where fac_id='" + invoiceId + "'";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            cmd.ExecuteNonQuery();
        }


    }
}
