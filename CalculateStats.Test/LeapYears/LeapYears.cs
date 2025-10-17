namespace LeapYears;

public class LeapYears
{
    [Fact]
    public void Si_Recibe_Un_Anio_Bisiesto_Debe_Retornar_True()
    {
        var calcular = new Calcular();
        var anio = 1996;
        var resultado = calcular.CalculaAnioBisiesto();
        resultado.Should().Be(true);
    }
}

public class Calcular
{
    public object CalculaAnioBisiesto()
    {
        throw new NotImplementedException();
    }
}