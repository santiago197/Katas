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
}

public class NumerosRomanos
{
    public string Convertir(int numero)
    {
        return NumeroRomano(numero);
    }

    private static string NumeroRomano(int numero)
    {
        var numeroRomano = "";
        numeroRomano = NumerosRomanosMenoresACinco(numero, numeroRomano);
        numeroRomano = NumeroRomanoCuatro(numero, numeroRomano);
        numeroRomano = NumeroRomanoCinco(numero, numeroRomano);
        numeroRomano = NumeroRomanoSeisAOcho(numero, numeroRomano);
        numeroRomano = NumeroRomanoNueve(numero, numeroRomano);

        return numeroRomano;
    }

    private static string NumeroRomanoCuatro(int numero, string numeroRomano)
    {
        if (numero == 4)
            numeroRomano = "IV";
        return numeroRomano;
    }


    private static string NumerosRomanosMenoresACinco(int numero, string numeroRomano)
    {
        for (int i = 0; i < numero; i++)
        {
            if (numero < 5)
            {
                numeroRomano += "I";
            }
        }

        return numeroRomano;
    }

    private static string NumeroRomanoCinco(int numero, string numeroRomano)
    {
        if (numero == 5)
            numeroRomano = "V";
        return numeroRomano;
    }

    private static string NumeroRomanoSeisAOcho(int numero, string numeroRomano)
    {
        switch (numero)
        {
            case 6:
                numeroRomano = "VI";
                break;
            case 7:
                numeroRomano = "VII";
                break;
            case 8:
                numeroRomano = "VIII";
                break;
        }

        return numeroRomano;
    }

    private static string NumeroRomanoNueve(int numero, string numeroRomano)
    {
        if (numero == 9)
            numeroRomano = "IX";
        return numeroRomano;
    }
}