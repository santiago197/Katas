using FluentAssertions;

namespace FizzBuzz;

public class FizzBuzz
{
    [Fact]
    public void Si_Recibe_El_Numero_Uno_Debe_Retornar_Uno()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(1);

        resultado.Should().Be("1");
    }

    [Fact]
    public void Si_Recibe_El_Numero_Dos_Debe_Retornar_Dos()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(2);

        resultado.Should().Be("2");
    }

    [Fact]
    public void Si_Recibe_El_Numero_Tres_Debe_Retornar_Fizz()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(3);

        resultado.Should().Be("Fizz");
    }

    [Fact]
    public void Si_Recibe_El_Numero_Cuatro_Debe_Retornar_Cuatro()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(4);

        resultado.Should().Be("4");
    }
}

public class Validar
{
    public string ValidaNumero(int numero)
    {
        return numero == 3 ? "Fizz" : numero.ToString();
    }
}