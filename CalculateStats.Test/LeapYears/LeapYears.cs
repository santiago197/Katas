using FluentAssertions;

namespace LeapYears;

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
        return anio % 4 == 0 || (anio % 100 != 0) && (anio % 400 == 0);
    }
}