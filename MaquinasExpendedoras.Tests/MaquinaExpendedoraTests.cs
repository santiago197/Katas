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
        maquina.Pantalla.Should().Be("5");
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
        maquina.Pantalla.Should().Be("10");
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
        maquina.Pantalla.Should().Be("5");
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
        maquina.Pantalla.Should().Be("5");
        maquina.ValorDevuelto.Should().Be(1);
    }

    [Fact]
    public void Si_NoIngresoMonedas_Debe_PantallMostrarInsertarMonedas()
    {
        //Arrange
        var maquina = new Maquina();
        //Act
        //Assert
        maquina.Pantalla.Should().Be("Insertar Monedas");
    }

    [Fact]
    public void Si_IngresoMonedaDe10_Debe_MostranEnPantalla10()
    {
        //Arrange
        var maquina = new Maquina();


        //Act
        maquina.IngresarMoneda(10);

        //Assert
        maquina.Pantalla.Should().Be("10");
    }

    [Fact]
    public void Si_IngresoMonedaDe25_Debe_MostrarEnPantalla25()
    {
        //Arrange
        var maquina = new Maquina();

        //Act
        maquina.IngresarMoneda(25);

        //Assert
        maquina.Pantalla.Should().Be("25");
    }

    [Fact]
    public void Si_Ingreso2MonedasDe25_Debe_MostrarEnPantalla50()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(25);

        maquina.IngresarMoneda(25);

        maquina.Pantalla.Should().Be("50");
    }

    [Fact]
    public void Si_Ingreso2MonedasDe10_Debe_MostrarEnPantalla20()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(10);

        maquina.IngresarMoneda(10);

        maquina.Pantalla.Should().Be("20");
    }

    [Fact]
    public void Si_Ingreso1MonedaDe5Y1Moneda10_Debe_MostrarEnPantalla15()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(5);
        
        maquina.IngresarMoneda(10);

        maquina.Pantalla.Should().Be("15");

    }

    [Fact]
    public void Si_Ingreso2MonedasDe1_Debe_RetornarElSaldoDe2()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(1);
        
        maquina.IngresarMoneda(1);

        maquina.ValorDevuelto.Should().Be(2);

    }
}

public class Maquina
{
    public string Pantalla { get; private set; } = "Insertar Monedas";
    public int ValorDevuelto { get; private set; }

    private int _montoActual ;

   
    public void IngresarMoneda(int moneda)
    {
        if (EsMonedaInvalida(moneda))
        {
            ValorDevuelto += moneda;
            return;
        }

        _montoActual += moneda;
        Pantalla = _montoActual.ToString();
     
    }

    private static bool EsMonedaInvalida(int moneda) => moneda == 1;
}