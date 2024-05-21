﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModelo_SisB
{
    public class InvoiceSentence : Conexion
    {
        public Conexion con;
        private static string baseDatos = "";

        public InvoiceSentence()
        {
            this.con = new Conexion();
            this.con.myconn.Open();
            baseDatos = this.con.myconn.Database;
            this.con.myconn.Close();
        }

        public Invoice createInvoice(Invoice invoice)
        {
            string sql = "insert into tbl_factura(fac_fecha, cli_nit, fac_monto, fac_estado, fac_servicio)values(CURRENT_DATE(), '" + invoice.clientNit + "', '" + invoice.amount + "', '" + 0 + "', '" + invoice.serviceName + "')";
            Console.WriteLine(sql);
            OdbcCommand cmd = new OdbcCommand(sql, this.con.connection());
            invoice.status = false;
            try
            {
                cmd.ExecuteNonQuery();
                return invoice;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void changeInvoiceStatus(int InvoiceId)
        {
            string sql = "update tbl_factura set fac_estado=1 where fac_id = '" + InvoiceId + "'";
            try
            {
                OdbcCommand cmd = new OdbcCommand(sql, this.con.connection());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Invoice> GetUnpaidInvoicesByAccountNit(string accountNit)
        {
            List<Invoice> invoices = new List<Invoice>();

            string sql = "SELECT * FROM tbl_factura WHERE cli_nit = ? AND fac_estado = 0";
            using (OdbcCommand cmd = new OdbcCommand(sql, this.con.connection()))
            {
                cmd.Parameters.AddWithValue("@AccountNit", accountNit);
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Invoice invoice = new Invoice(
                            reader.GetInt32(0),  // id
                            reader.GetInt32(1),  // idService
                            "EmpresaX",          // serviceName - Asignamos un valor predeterminado ya que no está en la consulta
                            reader.GetString(2), // clientNit
                            reader.GetDouble(3)  // amount
                        );
                        invoice.status = reader.GetBoolean(4); // status
                        invoices.Add(invoice);
                    }
                }
            }

            return invoices;
        }
    }

   
}
