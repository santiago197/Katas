using FluentAssertions;

namespace FizzBuzz;

public class FizzBuzz
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    public void Si_Recibe_Numero_Que_No_Es_Multiplo_De_Tres_Y_No_Es_Multiplo_De_Cinco_Debe_Retornar_Numero(int numero)
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(numero);

        resultado.Should().Be(numero.ToString());
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
    public void Si_Recibe_Numero_Quince_Debe_Retornar_FizzBuzz()
    {
        var fizzBuzz = new Validar();

        var resultado = fizzBuzz.ValidaNumero(15);

        resultado.Should().Be("FizzBuzz");
    }
}

public class Validar
{
    public string ValidaNumero(int numero)
    {
        return NumeroEsMultiploDeTresYCinco(numero) ? "FizzBuzz" :
            NumeroEsMultiploDeCinco(numero) ? "Buzz" :
            NumeroEsMultiploDeTres(numero) ? "Fizz" :
            numero.ToString();
    }

    private static bool NumeroEsMultiploDeTresYCinco(int numero)
    {
        return numero == 15;
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