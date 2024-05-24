using System.Data.Odbc;
namespace ApiERP.Models
{
    public class Connection
    {
        public OdbcConnection myconn;
        public Connection()
        {
            this.myconn = new OdbcConnection("Dsn=HotelSConexion");
        }


        public OdbcConnection connection()
        {
            try
            {
                this.myconn = new OdbcConnection("Dsn=HotelSConexion");
                myconn.Open();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
            return myconn;
        }


        public void disconnect(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException)
            {
                Console.WriteLine("No Conectó");
            }
        }
    }
}
