using FluentAssertions;

namespace Katas.Tests;

public class LeapYears
{
    [Theory]
    [InlineData(1900, true)]
    [InlineData(2001, false)]
    [InlineData(1996, true)]
    [InlineData(2000, true)]
    public void Si_Recibe_Un_Anio_Bisiesto_Debe_Retornar_True(int anio, bool esperado)
    {
        var calcular = new Calcular();

        var resultado = calcular.CalculaAnioBisiesto(anio);

        resultado.Should().Be(esperado);
    }
}

public class Calcular
{
    public bool CalculaAnioBisiesto(int anio)
    {
        return CalcularAnioBisiesto(anio);
    }

    private static bool CalcularAnioBisiesto(int anio)
    {
        return Anio_Divisible_En_Cuatro(anio) || Anio_No_Es_Divisible_En_100(anio) && Anio_Divisible_En_400(anio);
    }

    private static bool Anio_Divisible_En_400(int anio)
    {
        return anio % 400 == 0;
    }

    private static bool Anio_No_Es_Divisible_En_100(int anio)
    {
        return anio % 100 != 0;
    }

    private static bool Anio_Divisible_En_Cuatro(int anio)
    {
        return anio % 4 == 0;
    }
}