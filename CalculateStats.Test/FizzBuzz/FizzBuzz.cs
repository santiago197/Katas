using FluentAssertions;

namespace FizzBuzz;

public class FizzBuzz
{
    [Fact]
    public void Si_Recibe_El_Numero_Uno_Debe_Retornar_Uno()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero();

        resultado.Should().Be(1);
    }

    [Fact]
    public void Si_Recibe_El_Numero_Dos_Debe_Retornar_Dos()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero();
        
        resultado.Should().Be(2);
    }
}

public class Validar
{
    public int ValidaNumero()
    {
        return 1;
    }


}