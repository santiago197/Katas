using AwesomeAssertions;

namespace Supermercado.Tests;

public class SupermercadoTests
{
    [Fact]
    public void Si_ImprimoSinAgregarProductos_Debe_ImprimirReciboEnBlanco()
    {
        var supermercado = new Supermercado();
        var reciboEsperado = "--------------------------------------------\r\n" +
                             "| Producto     | Total  | Descuento |\r\n" +
                             "| Precio total: 0                     |";

        supermercado.AgregarProducto();

        supermercado.Recibo.Should().Be(reciboEsperado);
    }
}

public class Supermercado
{
    public void AgregarProducto()
    {
    }

    public string Recibo { get; set; } = "--------------------------------------------\r\n" +
                                         "| Producto     | Total  | Descuento |\r\n" +
                                         "| Precio total: 0                     |";
}