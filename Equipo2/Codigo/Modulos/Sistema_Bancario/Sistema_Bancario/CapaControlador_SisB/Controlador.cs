using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_SisB;
using CapaModelo_SisB.Templates;
using System.Data;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Sentences;

namespace CapaControlador_SisB
{
    public class Controlador
    {

        private Sentencias sentencias;

        public void InsertarMovimiento(string valorMovimiento, string descripcionMovimiento, string numCuentaDeb, string numCuentaCred, string estado)
        {
            sentencias.InsertarMovimiento(valorMovimiento, descripcionMovimiento, numCuentaDeb, numCuentaCred, estado);
        }
        public DataTable llenarTbl(string tabla)
        {
            return sentencias.llenarTblMov(tabla);
        }

        public DataTable llenarHistorial(string tabla, int id)
        {
            return sentencias.llenarHistorial(tabla, id);


        }
        public Controlador()
        {
            sentencias = new Sentencias();

        }

        public string[] items(string tabla, string campo1, string campo2, int id)
        {
            string[] Items = sentencias.llenarCmb(tabla, campo1, campo2, id);

            return Items;


        }
        public string[] items1(string tabla, string campo1, string campo2)
        {
            string[] Items = sentencias.llenarCmb1(tabla, campo1, campo2);

            return Items;


        }
        public string[] items2(string tabla, string campo1, string campo2)
        {
            string[] Items = sentencias.llenarCmb2(tabla, campo1, campo2);

            return Items;


        }

        ///Controlador 2///

        public DataTable enviar(string tabla, string campo1, string campo2, int id)
        {



            var dt1 = sentencias.obtener(tabla, campo1, campo2, id);

            return dt1;
        }

        public DataTable enviar1(string tabla, string campo1, string campo2)
        {



            var dt1 = sentencias.obtener1(tabla, campo1, campo2);

            return dt1;
        }

        public DataTable enviar2(string tabla, string campo1, string campo2)
        {



            var dt1 = sentencias.obtener2(tabla, campo1, campo2);

            return dt1;
        }

        public DataTable ObtenerTipoDeTransacciones()
        {
            return sentencias.TipoTransaccionBancaria();

        }

        public DataTable valorTrans()
        {
            return sentencias.valorTransaccion();

        }

        public int ObtenerValorTransaccion(string tipoTransaccion)
        {
            return sentencias.ObtenerValorTransaccion(tipoTransaccion);
        }

        public bool MakeDeposit(string numeroCuenta, double amount)
        {
            Cuenta cuenta = sentencias.getAccountByNumber(numeroCuenta);
            if (cuenta == null) return false;
            TransactionSentences.updateBalanceFromAccount(cuenta.id, amount);
            HistorySentence.saveTransactionOnHistory(cuenta.id, "Deposito", amount);
            CapaModelo_SisB.Sentencias sns = new CapaModelo_SisB.Sentencias();
            sns.saveInBitacora(cuenta.idUsuario, 8000, "Deposito");
            return true;
        }


        public int getUserProfile(int userId)
        {
            return this.sentencias.getUserProfileById(userId);
        }

        public static List<Cuenta> GetUserFriendAccount(Cuenta cuenta)
        {
            AccountTransactions ac = new AccountTransactions(cuenta.id, cuenta.nombre, cuenta.numero, cuenta.saldo);
            return ac.friend_accounts;

        }


        public DataTable ObtenerCuentas()
        {
            return sentencias.ObtenerCuentas();
        }

        public static List<Innvoice> GetFactura(string accountNumber)
        {
            return InnvoiceSentences.getClientInnvoices(accountNumber);
        }
        }
}
