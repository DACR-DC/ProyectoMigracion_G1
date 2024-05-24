using System;
using System.Linq;
using Xunit;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Sentences;
using System.Data;
namespace PruebaHistorial
{
    public class UnitTest1
    {

        private Sentencias sentencias;
        [Fact]
        public void TestMethod1()
        {


        }

        public DataTable llenarHistorial(string tabla, int id)
        {
            return sentencias.llenarHistorial(tabla, id);


        }
    }
}
