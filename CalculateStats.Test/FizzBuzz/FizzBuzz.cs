using FluentAssertions;

namespace FizzBuzz;

public class FizzBuzz
{
    [Fact]
    public void Si_Recibe_El_Numero_Uno_Debe_Retornar_Uno()
    {
        var fizzBuzz = new Validar();

        var resultado = Validar.ValidaNumero();

        resultado.Should().Be(1);
    }
}

public class Validar
{
    public static object ValidaNumero()
    {
        return 1;
    }
}