using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModelo_SisB.Sentences
{
    public class CardSentence
    {
        public static Conexion conn = new Conexion();

        public static void createCreditCard(string number, string cvv, string date, int clientId, double balance)
        {
            string sql = "insert into tbl_tarjeta_credito(tarc_numero, tarc_cvv, tarc_fecha_vencimiento, tarc_cliente, tarc_saldo_crediticio, tarc_saldo)values ";
            sql += "('" + number + "', '" + cvv + "', '" + date + "', '" + clientId + "', '" + balance + "', '" + 0 + "')";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            cmd.ExecuteNonQuery();
        }
        public static void createDebitCard(string number, string cvv, string date, int accountId)
        {
            string sql = "insert into tbl_tarjeta_debito(tard_numero, tard_cvv, tard_fecha_vencimiento, tard_cuenta)values ";
            sql += "('" + number + "', '" + cvv + "', '" + date + "', '" + accountId + "')";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            cmd.ExecuteNonQuery();
        }
    }
}
