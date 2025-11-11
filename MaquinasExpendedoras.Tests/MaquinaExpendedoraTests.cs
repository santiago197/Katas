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

    [Fact]
    public void Si_IngresoUnaMonedaDe5YUnCentavo_Debe_MostrarEnPantalla5()
    {
        //Arrange
        var maquina = new Maquina();
        maquina.IngresarMoneda(5);
        
        //Act
        maquina.IngresarMoneda(1);
        
        //Assert
        maquina.Pantalla.Should().Be(5);
    }
    
    [Fact]
    public void Si_IngresoUnaMonedaDe5YUnCentavo_Debe_MostrarEnPantalla5YDevolverMonedaDe1()
    {
        //Arrange
        var maquina = new Maquina();
        maquina.IngresarMoneda(5);
        
        //Act
        maquina.IngresarMoneda(1);
        
        //Assert
        maquina.Pantalla.Should().Be(5);
        maquina.ValorDevuelto.Should().Be(1);
    }
    
    
    
    
}

public class Maquina
{
    public int Pantalla { get; private set; }
    public int ValorDevuelto { get; private set; } 

    public void IngresarMoneda(int moneda)
    {
        if (EsMonedaInvalida(moneda))
        {
            ValorDevuelto = moneda;
            return;
        }
        
        Pantalla += moneda;
    }

    private static bool EsMonedaInvalida(int moneda) => moneda == 1;
}