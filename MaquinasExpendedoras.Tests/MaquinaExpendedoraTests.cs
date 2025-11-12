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
    public void
        Si_Ingreso1MonedaQuarterY1MonedaDimeYSolicitoDevolucion_Debe_Devolver1MonedaQuarter1MonedaDimeYMostrarEnPantallaInsertarMonedas()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Dime());

        maquina.DevolverMonedas();

        maquina.Pantalla.Should().Be("Insertar Monedas");
        maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Quarter(), new Dime() });
    }

    [Fact]
    public void
        Si_Ingreso1QuarterY1DimeY1NickelYSolicitoDevolucion_Debe_Devolver1Quarter1Dime1NickelYMostrarEnPantallaInsertarMonedas()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Dime());
        maquina.IngresarMoneda(new Nickel());

        maquina.DevolverMonedas();

        maquina.Pantalla.Should().Be("Insertar Monedas");
        maquina.BandejaDeMonedas.Should()
            .BeEquivalentTo(new List<Moneda>() { new Quarter(), new Dime(), new Nickel() });
    }

    [Fact]
    public void Si_SeleccionoElProductoCocaCola_Debe_MostrarEnPantallaPrecio1US()
    {
        var maquina = new Maquina();

        maquina.SeleccionarProducto(new CocaCola());

        maquina.Pantalla.Should().Be("Precio 1.00US");
    }

    [Fact]
    public void Si_SeleccionoElProductoChips_Debe_MostrarEnPantallaPrecio0_50US()
    {
        var maquina = new Maquina();

        maquina.SeleccionarProducto(new Chips());

        maquina.Pantalla.Should().Be("Precio 0.50US");
    }

    [Fact]
    public void Si_SeleccionoElProductoCaramelo_Debe_MostrarEnPantallaPrecio0_65US()
    {
        var maquina = new Maquina();

        maquina.SeleccionarProducto(new Caramelo());

        maquina.Pantalla.Should().Be("Precio 0.65US");
    }

    [Fact]
    public void Si_Inserto2QuartersYSeleccionoUnChips_Debe_EntregarChipsYMostrarEnPantallaGracias()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Quarter());

        maquina.SeleccionarProducto(new Chips());

        maquina.Pantalla.Should().Be("Gracias");
        maquina.ProductoDespachado.Should().BeOfType<Chips>();
    }

    [Fact]
    public void Si_DespuesDeComprarUnProductoYSeleccionoUnProducto_Debe_MostrarEnPantallaPrecioProducto()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Quarter());
        maquina.SeleccionarProducto(new Chips());

        maquina.SeleccionarProducto(new Chips());

        maquina.Pantalla.Should().Be("Precio 0.50US");
    }

    [Fact]
    public void Si_ComproUnProductoConSaldoInsuficiente_Debe_MostrarEnPantallaElPrecioProducto()
    {
        var maquina = new Maquina();
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Quarter());
        maquina.SeleccionarProducto(new CocaCola());

        maquina.Pantalla.Should().Be("Precio 1.00US");
        maquina.BandejaDeMonedas.Should().BeEmpty();
    }
}