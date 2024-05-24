using System;
using System.Linq;
using Xunit;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Sentences;
using System.Data;
namespace PruebaEstadoDeCuenta
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
        }

        public static double getAccountInitialBalance(int accountId)
        {
            return HistorySentence.getAccountInitialBalance(accountId);
        }
    }
}
