using FluentAssertions;

namespace Katas.Tests;

public class NumerosRomanosTest
{
    [Fact]
    public void Si_RecibeNumeroUno_Debe_Retornar_I()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 1;

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be("I");
    }

    [Fact]
    public void Si_RecibeNumeroDos_Debe_Retornar_II()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 2;

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be("II");
    }

    [Fact]
    public void Si_RecibeNumeroTres_Debe_Retornar_III()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 3;

        var resultado = romanos.Convertir(numeroArabigo);
        resultado.Should().Be("III");
    }

    [Fact]
    public void Si_RecibeNumeroCuatro_Debe_Retornar_IV()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 4;

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be("IV");
    }

    [Fact]
    public void Si_RecibeNumeroCinco_Debe_Retornar_V()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 5;

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be("V");
    }

    [Fact]
    public void Si_ReciboNumeroSeis_Debe_Retornar_VI()
    {
        var romanos = new NumerosRomanos();
        var numeroArabigo = 6;

        var resultado = romanos.Convertir(numeroArabigo);

        resultado.Should().Be("VI");
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
        numeroRomano = NumeroRomanoSeis(numero, numeroRomano);

        return numeroRomano;
    }

    private static string NumeroRomanoCuatro(int numero, string numeroRomano)
    {
        if (numero == 4)
            numeroRomano = "IV";
        return numeroRomano;
    }

    private static string NumeroRomanoCinco(int numero, string numeroRomano)
    {
        if (numero == 5)
            numeroRomano = "V";
        return numeroRomano;
    }

    private static string NumeroRomanoSeis(int numero, string numeroRomano)
    {
        if (numero == 6)
            numeroRomano = "VI";
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
}