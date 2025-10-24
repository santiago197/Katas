using FluentAssertions;

namespace Katas.Tests;

public class NumerosRomanosTest
{
    [Fact]
    public void Si_RecibeNumeroUno_Debe_RetornarI()
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.Convertir(1);

        resultado.Should().Be("I");
    }
}

public class NumerosRomanos
{
    public string Convertir(int numero)
    {
        return numero switch
        {
            1 => "I",
            _ => ""
        };
    }
}