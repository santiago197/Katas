using AwesomeAssertions;

namespace MaquinasExpendedoras.Tests;

public class MaquinaExpendedoraTests
{
    [Fact]
    public void Si_Ingreso1MonedaDe5_Debe_MostrarEnPantalla5()
    {
        //Arrange
        var maquina = new Maquina();

        //Act
        maquina.IngresarMoneda(5);

        //Assert
        maquina.Pantalla.Should().Be(5);
    }

    [Fact]
    public void Si_Ingreso2MonedasDe5_Debe_MostrarEnPantalla10()
    {
        // Arrange
        var maquina = new Maquina();
        maquina.IngresarMoneda(5);

        // Act
        maquina.IngresarMoneda(5);
     
        // Assert 
        maquina.Pantalla.Should().Be(10);

    }
}

public class Maquina
{
    public int Pantalla { get; private set; } 

    public void IngresarMoneda(int moneda)
    {
        Pantalla += moneda;
    }
}