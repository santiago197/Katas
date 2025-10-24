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
}

public class NumerosRomanos
{
    public string Convertir(int numero)
    {
        return NumeroRomano(numero);
    }

    public string RomanosEstandar(int numero)
    {
        var numeroRomano = "";
        switch (numero)
        {
            case 1:
                numeroRomano = "I";
                break;
            case 5:
                numeroRomano = "V";
                break;
            case 10:
                numeroRomano = "X";
                break;
            case 50:
                numeroRomano = "L";
                break;
            case 100:
                numeroRomano = "C";
                break;
            case 500:
                numeroRomano = "D";
                break;
            case 1000:
                numeroRomano = "M";
                break;
        }

        return numeroRomano;
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