using AwesomeAssertions;

namespace Katas.Tests;

public class FizzBuzzTests
{
    [Fact]
    public void Si_Envio_1_Debe_Retornar_1()
    {
        //arrange
        var esperado = "1";
        //act
        var resultado = FizzBuzz.Calcular(1);
        //assert
        resultado.Should().Be(esperado);
    }

    [Fact]
    public void Si_Envio_2_Retornar_2()
    {
        //arrange
        var esperado = "2";
        // act
        var resultado = FizzBuzz.Calcular(2);
        //assert
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    public void Si_Envio_Multiplo_De_3_Retorno_Fizz(int multiploDe3)
    {
        //arrange
        var esperado = "Fizz";
        //act
        var resultado = FizzBuzz.Calcular(multiploDe3);
        //assert
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Si_Envio_Multiplo_De_5_Retorno_Buzz(int multiploDe5)
    {
        // Arrange
        var esperado = "Buzz";
        // Act
        var resultado = FizzBuzz.Calcular(multiploDe5);

        // Assert
        resultado.Should().Be(esperado);
    }

    [Theory]
    [InlineData(15)]
    [InlineData(30)]
    [InlineData(45)]
    public void Si_Envio_Multiplo_De_3_Y_De_5_Retorno_FizzBuzz(int multiplosDe3YDe5)
    {
        // Arrange
        var esperado = "FizzBuzz";

        // Act
        var resultado = FizzBuzz.Calcular(multiplosDe3YDe5);

        // Assert
        resultado.Should().Be(esperado);
    }
}