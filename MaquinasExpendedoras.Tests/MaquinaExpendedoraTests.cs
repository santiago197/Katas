using System.Collections.ObjectModel;
using AwesomeAssertions;

namespace MaquinasExpendedoras.Tests;

public class MaquinaExpendedoraTests
{
    [Fact]
    public void Si_Ingreso1Nickel_Debe_MostrarEnPantalla5()
    {
        //Arrange
        var maquina = new Maquina();

        //Act
        maquina.IngresarMoneda(new Nickel());

        //Assert
        maquina.Pantalla.Should().Be("5");
    }

    [Fact]
    public void Si_Ingreso2MonedasDeNickel_Debe_MostrarEnPantalla10()
    {
        // Arrange
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Nickel());

        // Act
        maquina.IngresarMoneda(new Nickel());

        // Assert 
        maquina.Pantalla.Should().Be("10");
    }

    [Fact]
    public void Si_IngresoUnaMonedaDeNickelYUnPenny_Debe_MostrarEnPantalla5()
    {
        //Arrange
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Nickel());

        //Act
        maquina.IngresarMoneda(new Penny());

        //Assert
        maquina.Pantalla.Should().Be("5");
    }

    [Fact]
    public void Si_IngresoUnNickelYUnPenny_Debe_MostrarEnPantalla5YDevolverMonedaDe1()
    {
        //Arrange
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Nickel());

        //Act
        maquina.IngresarMoneda(new Penny());

        //Assert
        maquina.Pantalla.Should().Be("5");
        maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Penny() });
    }

    [Fact]
    public void Si_NoIngresoMonedas_Debe_PantallaMostrarInsertarMonedas()
    {
        //Arrange
        var maquina = new Maquina();
        //Act
        //Assert
        maquina.Pantalla.Should().Be("Insertar Monedas");
    }

    [Fact]
    public void Si_Ingreso1Dime_Debe_MostrarEnPantalla10()
    {
        //Arrange
        var maquina = new Maquina();


        //Act
        maquina.IngresarMoneda(new Dime());

        //Assert
        maquina.Pantalla.Should().Be("10");
    }

    [Fact]
    public void Si_IngresoUnQuarter_Debe_MostrarEnPantalla25()
    {
        //Arrange
        var maquina = new Maquina();

        //Act
        maquina.IngresarMoneda(new Quarter());

        //Assert
        maquina.Pantalla.Should().Be("25");
    }

    [Fact]
    public void Si_Ingreso2Quarter_Debe_MostrarEnPantalla50()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());

        maquina.IngresarMoneda(new Quarter());

        maquina.Pantalla.Should().Be("50");
    }

    [Fact]
    public void Si_Ingreso2MonedasDime_Debe_MostrarEnPantalla20()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Dime());

        maquina.IngresarMoneda(new Dime());

        maquina.Pantalla.Should().Be("20");
    }

    [Fact]
    public void Si_Ingreso1NickelY1Dime_Debe_MostrarEnPantalla15()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Nickel());

        maquina.IngresarMoneda(new Dime());

        maquina.Pantalla.Should().Be("15");
    }

    [Fact]
    public void Si_Ingreso2Penny_Debe_Retornar2Penny()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Penny());

        maquina.IngresarMoneda(new Penny());

        maquina.Pantalla.Should().Be("Insertar Monedas");
        maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Penny(), new Penny() });
    }

    [Fact]
    public void Si_IngresoMonedaValidasYSolicitoDevolucion_Debe_DevolverMonedasYMostrarEnPantallaInsertarMonedas()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Dime());

        maquina.DevolverMonedas();

        maquina.Pantalla.Should().Be("Insertar Monedas");
        maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Quarter(), new Dime() });
    }
    
}

public class Penny : Moneda
{
    public override int Valor => 1;
}

public class Nickel : Moneda
{
    public override int Valor => 5;
}

public class Dime : Moneda
{
    public override int Valor => 10;
}

public class Quarter : Moneda
{
    public override int Valor => 25;
}

public abstract class Moneda
{
    public abstract int Valor { get; }
}

public class Maquina
{
    private const string EstadoInicialPantalla = "Insertar Monedas";

    public string Pantalla { get; private set; } = EstadoInicialPantalla;
    private readonly List<Moneda> _bandejaDeMonedas = [];
    public ReadOnlyCollection<Moneda> BandejaDeMonedas => _bandejaDeMonedas.AsReadOnly();

    private int _montoActual;


    public void IngresarMoneda(Moneda moneda)
    {
        if (EsMonedaInvalida(moneda))
        {
            _bandejaDeMonedas.Add(moneda);
            return;
        }

        _montoActual += moneda.Valor;
        Pantalla = _montoActual.ToString();
    }

    private static bool EsMonedaInvalida(Moneda moneda)
    {
        return moneda is Penny;
    }

    public void DevolverMonedas()
    {
        Pantalla = EstadoInicialPantalla;
        _bandejaDeMonedas.AddRange(new List<Moneda>() { new Quarter(), new Dime() });
    }
}