using System;
using System.Linq;
using Xunit;
using CapaControlador_SisB;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Sentences;
namespace PruebaDeposito
{
    public class UnitTest1
    {
        [Fact]


        public void TestMethod1()
        {


        }
        private Sentencias sentencias;
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
    }
}
