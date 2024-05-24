using System;
using System.Linq;
using Xunit;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;
using CapaModelo_SisB.Libraries;
using CapaModelo_SisB.Sentences;
using System.Data;

namespace PruebaPagoDeServicios
{
    public class UnitTest1
    {
        CapaControlador_SisB.Controlador cn = new CapaControlador_SisB.Controlador();
        [Fact]
        public void InsertarMovimiento()
        {
            // Arrange
            string valorMovimiento = "a";
            string descripcionMovimiento = "a";
            string numCuentaDeb = "a";
            string numCuentaCred = "a";
            string estado = "a";

            // Act
            bool guardadoExitoso;
            try
            {
                cn.InsertarMovimiento(valorMovimiento, descripcionMovimiento, numCuentaDeb, numCuentaCred, estado);
                guardadoExitoso = true;
            }
            catch
            {
                guardadoExitoso = false;
            }

            // Assert
            Assert.True(guardadoExitoso); // Verificar que el guardado fue exitoso
        }
    }
}
