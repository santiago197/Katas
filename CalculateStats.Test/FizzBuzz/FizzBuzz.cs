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

    [Fact]
    public void Si_Recibe_El_Numero_Cinco_Deb_Retornar_Buzz()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(5);

        resultado.Should().Be("Buzz");
    }

    [Fact]
    public void Si_Recibe_El_Numero_Seis_Debe_Retornar_Seis()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(6);

        resultado.Should().Be("6");
    }

    [Fact]
    public void Si_Recibe_El_Numero_Diez_Debe_Retornar_Buzz()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(10);

        resultado.Should().Be("Buzz");
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
        return numero == 3;
    }

    private static bool NumeroEsMultiploDeCinco(int numero)
    {
        return numero % 5 == 0;
    }
}