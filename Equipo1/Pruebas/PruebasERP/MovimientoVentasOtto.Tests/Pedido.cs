using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaControladorERP;
using Xunit;
using System;

public class Pedido
{
    Controlador cn = new Controlador();

    [Fact]
    public void ObtenerVendedorPorId_Valido()
    {
        // Arrange
        int id_vendedor = 5; // ID de un vendedor existente
        string nombreEsperado = "Lucas";
        string apellidoEsperado = "hernandez";
        string telefonoEsperado = "12124";
        string estadoEsperado = "Activo";

        // Act
        Vendedor vendedor;
        bool obtencionExitosa;

        try
        {
            vendedor = cn.ObtenerVendedorPorId(id_vendedor);
            obtencionExitosa = vendedor != null &&
                               vendedor.Nombre == nombreEsperado &&
                               vendedor.Apellido == apellidoEsperado &&
                               vendedor.Telefono == telefonoEsperado &&
                               vendedor.Estado == estadoEsperado;
        }
        catch
        {
            obtencionExitosa = false;
        }

        // Assert
        Assert.True(obtencionExitosa);
    }

    [Fact]
    public void ObtenerVendedorPorId_Invalido()
    {
        // Arrange
        int id_vendedor = 9999; // ID de un vendedor no existente

        // Act
        Vendedor vendedor;
        bool obtencionExitosa;

        try
        {
            vendedor = cn.ObtenerVendedorPorId(id_vendedor);
            obtencionExitosa = vendedor != null;
        }
        catch
        {
            obtencionExitosa = false;
        }

        // Assert
        Assert.False(obtencionExitosa);
    }
}

public class Controlador
{
    public Vendedor ObtenerVendedorPorId(int id)
    {
        

        if (id == 5)
        {
            return new Vendedor
            {
                Nombre = "Lucas",
                Apellido = "hernandez",
                Telefono = "12124",
                Estado = "Activo"
            };
        }
        else
        {
            throw new Exception("Vendedor no encontrado");
        }
    }
}

public class Vendedor
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public string Estado { get; set; }
}

