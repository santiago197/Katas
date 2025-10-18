namespace FizzBuzz;

public class FizzBuzz
{
    [Fact]
    public void Si_Recibe_El_Numero_Uno_Debe_Retornar_Uno()
    {
        var fizzBuzz = new FizzBuzz();

        var resultado = FizzBuzz.ValidarNumero();

        resultado.Should().Be(1);
    }
}