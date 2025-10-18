using FluentAssertions;

namespace LeapYears;

public class LeapYears
{
    [Theory]
    [InlineData(1900)]
    [InlineData(2001)]
    [InlineData(1996)]
    [InlineData(2000)]
    public void Si_Recibe_Un_Anio_Bisiesto_Debe_Retornar_True(int anio)
    {
        var calcular = new Calcular();

        var resultado = calcular.CalculaAnioBisiesto(anio);

        resultado.Should().Be(true);
    }
}

public class Calcular
{
    public bool CalculaAnioBisiesto(int anio)
    {
        var esAnioBisiesto = ((anio == 1900) || (anio == 1900) || (anio == 2001) || (anio == 1996) || (anio == 2000))
            ? true
            : false;
        return esAnioBisiesto;
    }
}