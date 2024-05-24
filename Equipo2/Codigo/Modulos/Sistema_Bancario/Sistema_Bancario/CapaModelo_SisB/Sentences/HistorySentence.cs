using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;
using System.Data.Odbc;

namespace CapaModelo_SisB.Sentences
{

    public class HistorySentence
    {

        public static Conexion conn = new Conexion();

        public static void saveTransactionOnHistory(int accountId, string type, double amount)
        {
            string sql = "insert into tbl_historial_transacciones(htr_cuenta, htr_tipo, htr_monto, htr_fecha)values(";
            sql += "'" + accountId + "', '" + type + "', '" + amount + "', CURDATE())";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            cmd.ExecuteNonQuery();
        }

        public static double getAccountInitialBalance(int accountId)
        {
            string sql = "SELECT  cue_saldo - SUM(CASE WHEN htr_tipo = 'Deposito' THEN htr_monto ELSE -htr_monto END) " +
                "AS saldo_inicial FROM  tbl_cuenta JOIN tbl_historial_transacciones" +
                " ON tbl_cuenta.cue_id = tbl_historial_transacciones.htr_cuenta WHERE  tbl_cuenta.cue_id ='" + accountId + "';";
            Console.WriteLine(sql);
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.IsDBNull(0)) { 
                    
                    return 0;
                }else if (reader.Read()) { 
                return reader.GetInt32(0);
                }
            }
            return 0;
        }
    }
}
