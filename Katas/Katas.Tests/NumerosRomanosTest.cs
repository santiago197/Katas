using FluentAssertions;

namespace Katas.Tests;

public class NumerosRomanosTest
{
    [Fact]
    public void Si_RecibeNumeroUno_Debe_Retornar_I()
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.Convertir(1);

        resultado.Should().Be("I");
    }
    [Fact]
    public void Si_RecibeNumeroDos_Debe_Retornar_II()
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.Convertir(2);

        resultado.Should().Be("II");
    } [Fact]
    public void Si_RecibeNumeroTres_Debe_Retornar_III()
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.Convertir(3);

        resultado.Should().Be("III");
    }
    
}

public class NumerosRomanos
{
    public string Convertir(int numero)
    {
        return NumeroRomano(numero);
    }

    private static string NumeroRomano(int numero)
    {
        return numero switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            _ => ""
        };
    }
}