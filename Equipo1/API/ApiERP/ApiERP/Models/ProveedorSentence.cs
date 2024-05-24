using ApiERP.Models.Templates;
using System.Data.Odbc;
using ApiERP.Models;

namespace ApiERP.Models
{
    public class ProveedorSentence
    {
        public Connection conn;

        public ProveedorSentence()
        {
            this.conn = new Connection();
        }


        public List<Proveedor> getAllProvs()
        {
            List<Proveedor> provs = new List<Proveedor>();
            string sql = "select * from tbl_proveedor";
            OdbcCommand cmd = new OdbcCommand(sql, this.conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                provs.Add(new Proveedor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            }
            return provs;
        }

        public Proveedor getProvByNit(string nit)
        {
            string sql = "select * from tbl_proveedor where nit_prov='" + nit + "'";
            OdbcCommand cmd = new OdbcCommand(sql, this.conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Proveedor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }
            return new Proveedor(0, "", "", "", "", "");
        }

        public InvoiceP getInvoiceP(string nit)
        {
            string sql = "SELECT * FROM tbl_facturaxpagar where nitprov_facxpag='" + nit + "';";
            OdbcCommand cmd = new OdbcCommand(sql, this.conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new InvoiceP(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDate(3), reader.GetDate(4), reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetInt32(8), reader.GetString(9), reader.GetInt32(10));
            }
            return null;
        }

        public List<InvoiceP> getAllInvoices()
        {
            List<InvoiceP> invoices = new List<InvoiceP>();
            string sql = "select * from tbl_facturaxpagar";
            OdbcCommand cmd = new OdbcCommand(sql, this.conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                InvoiceP inv = new InvoiceP(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDate(3), reader.GetDate(4), reader.GetDouble(5), reader.GetDouble(6), reader.GetDouble(7), reader.GetInt32(8), reader.GetString(9), reader.GetInt32(10));
                invoices.Add(inv);
            }
            return invoices;
        }


    }
}
