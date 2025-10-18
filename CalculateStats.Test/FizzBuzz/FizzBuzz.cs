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

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    public void Si_Recibe_Numero_Multiplo_De_Tres_Debe_Retornar_Fizz(int numero)
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(numero);

        resultado.Should().Be("Fizz");
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void Si_RecibeNumero_Multiplo_De_Cinco_Debe_Retornar_Buzz(int numero)
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(numero);

        resultado.Should().Be("Buzz");
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
        return NumeroEsMultiploDeCinco(numero) ? "Buzz" : NumeroEsMultiploDeTres(numero) ? "Fizz" : numero.ToString();
    }

    private static bool NumeroEsMultiploDeTres(int numero)
    {
        return numero % 3 == 0;
    }

    private static bool NumeroEsMultiploDeCinco(int numero)
    {
        return numero % 5 == 0;
    }
}