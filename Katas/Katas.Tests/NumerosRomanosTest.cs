using FluentAssertions;

namespace Katas.Tests;

public class NumerosRomanosTest
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    public void Si_RecibeNumerosDelUnoAlNueve_Debe_Retornar_Romanos(int numeroArabigo, string numeroRomano)
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be(numeroRomano);
    }

    [Theory]
    [InlineData(1, "I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    public void Si_Recibo_CombinacionesIniciales_Debe_Retornar_LetrasEstandarDeRomanos(int numeroArabigo,
        string numeroRomano)
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.RomanosEstandar(numeroArabigo);

        resultado.Should().Be(numeroRomano);
    }

    [Fact]
    public void Si_ReciboNumeroDiez_Debe_Retornar_X()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 10;
        var numeroRomano = "X";

        var resultado = romanos.RomanosEstandar(numeroArabigo);

        resultado.Should().Be(numeroRomano);
    }

    [Fact]
    public void Si_ReciboNumeroVeinte_Debe_Retornar_XX()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 20;
        var numeroRomano = "XX";

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be(numeroRomano);
    }
}

public class NumerosRomanos
{
    private Dictionary<int, string> estandarRomanos = new Dictionary<int, string>()
    {
        { 1, "I" },
        { 5, "V" },
        { 10, "X" },
        { 50, "L" },
        { 100, "C" },
        { 500, "D" },
        { 1000, "M" },
    };

    public string Convertir(int numero)
    {
        return NumeroRomano(numero);
    }

    public string RomanosEstandar(int numero)
    {
        return estandarRomanos[numero];
    }

    private static string NumeroRomano(int numero)
    {
        var numeroRomano = "";
        numeroRomano = NumeroRomano(numero, numeroRomano);


        return numeroRomano;
    }


    private static string NumeroRomano(int numero, string numeroRomano)
    {
        for (int i = 0; i < numero; i++)
        {
            if (numero < 5)
            {
                numeroRomano += "I";
            }
        }

        numeroRomano = numero switch
        {
            4 => "IV",
            5 => "V",
            6 => "VI",
            7 => "VII",
            8 => "VIII",
            9 => "IX",
            20 => "XX",
            _ => numeroRomano
        };

        return numeroRomano;
    }
}