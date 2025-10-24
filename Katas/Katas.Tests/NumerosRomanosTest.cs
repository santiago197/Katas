using FluentAssertions;

namespace Katas.Tests;

public class NumerosRomanosTest
{
    [Fact]
    public void Si_RecibeNumeroUno_Debe_Retornar_I()
    {
        var romanos = new NumerosRomanos();

        var resultado = romanos.Convertir(1);

        resultado.Should
            ().Be("I");
    }
}

public class NumerosRomanos
{
    public object Convertir(int i)
    {
        throw new NotImplementedException();
    }
}