using System;
using System.Linq;
using Xunit;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Sentences;
using System.Data;
namespace PruebaTransacciones
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {

        }

        public static void makeTransaction(string accountNo, double amount, int sign = 1)
        {
            Sentencias sn = new Sentencias();
            Cuenta account = sn.getAccountByNumber(accountNo);
            TransactionSentences.updateBalanceFromAccount(account.id, amount * sign);
            HistorySentence.saveTransactionOnHistory(account.id, sign == 1 ? "Deposito" : "Retiro", amount);
            CapaModelo_SisB.Sentencias sns = new CapaModelo_SisB.Sentencias();
            sns.saveInBitacora(account.idUsuario, 8000, sign == 1 ? "Deposito" : "Retiro");
        }

        public static bool accountCanPay(int accountId, double amount)
        {
            return TransactionSentences.canPay(accountId, amount);
        }
    }
}
