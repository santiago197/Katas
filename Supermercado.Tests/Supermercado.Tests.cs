using AwesomeAssertions;

namespace Supermercado.Tests;

public class SupermercadoTests
{
    [Fact]
    public void Si_NoAgreagoProductos_Debe_SerReciboEnBlanco()
    {
        var supermercado = new Supermercado();
        var reciboEsperado = "--------------------------------------------\r\n" +
                             "| Producto     | Total  | Descuento |\r\n" +
                             "| Cepillo de dientes     | 0.99  | 0 |\r\n" +
                             "| Precio total: 0                    |";

        supermercado.Recibo.Should().Be(reciboEsperado);
    }

    [Fact]
    public void Si_Agrego1CepilloDeDientes_Debe_SerReciboConDetalle()
    {
        var supermercado = new Supermercado();
        var reciboEsperado = "--------------------------------------------\r\n" +
                             "| Producto     | Total  | Descuento |\r\n" +
                             "| Cepillo de dientes     | 0.99  | 0 |\r\n" +
                             "| Precio total: 0                    |";

        supermercado.AgregarProducto(new CepilloDientes());

        supermercado.Recibo.Should().Be(reciboEsperado);
    }

    [Fact]
    public void X()
    {
        var supermercado = new Supermercado();

        supermercado.AgregarProducto(new TomatesCherry());
    }
}

public record TomatesCherry : Producto
{
}

public record CepilloDientes : Producto
{
}

public class Supermercado
{
    public void AgregarProducto(Producto producto)
    {
    }

    public string Recibo { get; set; } = "--------------------------------------------\r\n" +
                                         "| Producto     | Total  | Descuento |\r\n" +
                                         "| Cepillo de dientes     | 0.99  | 0 |\r\n" +
                                         "| Precio total: 0                    |";
}

public record Producto
{
    public int Valor { get; set; }
};