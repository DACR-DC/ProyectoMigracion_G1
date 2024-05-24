using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaModelo_SisB.Sentences
{
    public class ClienteSentence
    {
        static Conexion conn = new Conexion();

        public static int getClientIdByDPI(string dpi)
        {
            string sql = "select cli_id from tbl_cliente where cli_dpi='" + dpi + "'";
            OdbcCommand cmd = new OdbcCommand(sql, conn.connection());
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.IsDBNull(0)) return -1;
                return reader.GetInt32(0);
            }
            return -1;
        }
    }
}
