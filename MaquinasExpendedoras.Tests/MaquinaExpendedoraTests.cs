using AwesomeAssertions;

namespace MaquinasExpendedoras.Tests;

public class MaquinaExpendedoraTests
{
    private readonly Maquina _maquina = new();

    [Fact]
    public void Si_Ingreso1Nickel_Debe_MostrarEnPantalla5()
    {
        //Act
        _maquina.IngresarMoneda(new Nickel());

        //Assert
        _maquina.Pantalla.Should().Be("5");
    }

    [Fact]
    public void Si_Ingreso2MonedasDeNickel_Debe_MostrarEnPantalla10()
    {
        // Arrange
        _maquina.IngresarMoneda(new Nickel());

        // Act
        _maquina.IngresarMoneda(new Nickel());

        // Assert 
        _maquina.Pantalla.Should().Be("10");
    }

    [Fact]
    public void Si_IngresoUnaMonedaDeNickelYUnPenny_Debe_MostrarEnPantalla5()
    {
        //Arrange
        _maquina.IngresarMoneda(new Nickel());

        //Act
        _maquina.IngresarMoneda(new Penny());

        //Assert
        _maquina.Pantalla.Should().Be("5");
    }

    [Fact]
    public void Si_IngresoUnNickelYUnPenny_Debe_MostrarEnPantalla5YDevolverMonedaDe1()
    {
        //Arrange
        _maquina.IngresarMoneda(new Nickel());

        //Act
        _maquina.IngresarMoneda(new Penny());

        //Assert
        _maquina.Pantalla.Should().Be("5");
        _maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Penny() });
    }

    [Fact]
    public void Si_NoIngresoMonedas_Debe_PantallaMostrarInsertarMonedas()
    {
        //Arrange
        //Act
        //Assert
        _maquina.Pantalla.Should().Be("Insertar Monedas");
    }

    [Fact]
    public void Si_Ingreso1Dime_Debe_MostrarEnPantalla10()
    {
        //Act
        _maquina.IngresarMoneda(new Dime());

        //Assert
        _maquina.Pantalla.Should().Be("10");
    }

    [Fact]
    public void Si_IngresoUnQuarter_Debe_MostrarEnPantalla25()
    {
        //Act
        _maquina.IngresarMoneda(new Quarter());

        //Assert
        _maquina.Pantalla.Should().Be("25");
    }

    [Fact]
    public void Si_Ingreso2Quarter_Debe_MostrarEnPantalla50()
    {
        _maquina.IngresarMoneda(new Quarter());

        _maquina.IngresarMoneda(new Quarter());

        _maquina.Pantalla.Should().Be("50");
    }

    [Fact]
    public void Si_Ingreso2MonedasDime_Debe_MostrarEnPantalla20()
    {
        _maquina.IngresarMoneda(new Dime());

        _maquina.IngresarMoneda(new Dime());

        _maquina.Pantalla.Should().Be("20");
    }

    [Fact]
    public void Si_Ingreso1NickelY1Dime_Debe_MostrarEnPantalla15()
    {
        _maquina.IngresarMoneda(new Nickel());

        _maquina.IngresarMoneda(new Dime());

        _maquina.Pantalla.Should().Be("15");
    }

    [Fact]
    public void Si_Ingreso2Penny_Debe_Retornar2Penny()
    {
        _maquina.IngresarMoneda(new Penny());

        _maquina.IngresarMoneda(new Penny());

        _maquina.Pantalla.Should().Be("Insertar Monedas");
        _maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Penny(), new Penny() });
    }

    [Fact]
    public void
        Si_Ingreso1MonedaQuarterY1MonedaDimeYSolicitoDevolucion_Debe_Devolver1MonedaQuarter1MonedaDimeYMostrarEnPantallaInsertarMonedas()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Dime());

        _maquina.DevolverMonedas();

        _maquina.Pantalla.Should().Be("Insertar Monedas");
        _maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Quarter(), new Dime() });
    }

    [Fact]
    public void
        Si_Ingreso1QuarterY1DimeY1NickelYSolicitoDevolucion_Debe_Devolver1Quarter1Dime1NickelYMostrarEnPantallaInsertarMonedas()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Nickel());

        _maquina.DevolverMonedas();

        _maquina.Pantalla.Should().Be("Insertar Monedas");
        _maquina.BandejaDeMonedas.Should()
            .BeEquivalentTo(new List<Moneda>() { new Quarter(), new Dime(), new Nickel() });
    }

    [Fact]
    public void Si_SeleccionoElProductoCocaCola_Debe_MostrarEnPantallaPrecio1US()
    {
        _maquina.SeleccionarProducto(new CocaCola());

        _maquina.Pantalla.Should().Be("Precio 1.00US");
    }

    [Fact]
    public void Si_SeleccionoElProductoChips_Debe_MostrarEnPantallaPrecio0_50US()
    {
        _maquina.SeleccionarProducto(new Chips());

        _maquina.Pantalla.Should().Be("Precio 0.50US");
    }

    [Fact]
    public void Si_SeleccionoElProductoCaramelo_Debe_MostrarEnPantallaPrecio0_65US()
    {
        _maquina.SeleccionarProducto(new Caramelo());

        _maquina.Pantalla.Should().Be("Precio 0.65US");
    }

    [Fact]
    public void Si_Inserto2QuartersYSeleccionoUnChips_Debe_EntregarChipsYMostrarEnPantallaGracias()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.Pantalla.Should().Be("Gracias");
        _maquina.ProductoDespachado.Should().BeOfType<Chips>();
    }

    [Fact]
    public void Si_DespuesDeComprarUnProductoYSeleccionoUnProducto_Debe_MostrarEnPantallaPrecioProducto()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.SeleccionarProducto(new Chips());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.Pantalla.Should().Be("Precio 0.50US");
    }

    [Fact]
    public void Si_ComproUnProductoConSaldoInsuficiente_Debe_MostrarEnPantallaElPrecioProducto()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.SeleccionarProducto(new CocaCola());

        _maquina.Pantalla.Should().Be("Precio 1.00US");
        _maquina.BandejaDeMonedas.Should().BeEmpty();
    }


    [Fact]
    public void Si_Ingreso3QuarterYCompro1Chips_Debe_EntregarChipYDevolver1Quarter()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.ProductoDespachado.Should().BeOfType<Chips>();
        _maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Quarter() });
    }

    [Fact]
    public void Si_Ingreso4QuarterYCompro1Chips_Debe_EntregarChipYDevolver2Quarter()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.ProductoDespachado.Should().BeOfType<Chips>();
        _maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Quarter(), new Quarter() });
    }

    [Fact]
    public void Si_Ingreso6DimeYCompro1Chips_Debe_EntregarChipYDevolver1Dime()
    {
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Dime());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.ProductoDespachado.Should().BeOfType<Chips>();
        _maquina.BandejaDeMonedas.Should().BeEquivalentTo(new List<Moneda>() { new Dime() });
    }

    [Fact]
    public void Si_Ingreso3QuarterYCompro1Caramelo_Debe_MostrarEnPantallaSoloCambioExacto()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());

        _maquina.SeleccionarProducto(new Caramelo());

        _maquina.Pantalla.Should().Be("Solo cambio exacto");
    }

    [Fact]
    public void Si_Ingreso2Quarter2Dime1NickelYComproUnCaramelo_Debe_Retornar1Dime()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Nickel());

        _maquina.SeleccionarProducto(new Caramelo());

        _maquina.BandejaDeMonedas.Should().BeEquivalentTo([new Dime()]);
    }

    [Fact]
    public void Si_SeleccionoCocaColaYNoHayDisponible_Debe_MostrarPantallaAgotado()
    {
        ComprarCocaColaConDineroExacto(_maquina);
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());

        _maquina.SeleccionarProducto(new CocaCola());

        _maquina.Pantalla.Should().Be("Agotado");
    }


    [Fact]
    public void Si_SeleccionoCocaColaYChips_Debe_MostrarEnLaPantallaGracias()
    {
        ComprarCocaColaConDineroExacto(_maquina);
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Nickel());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.Pantalla.Should().Be("Gracias");
    }

    [Fact]
    public void Si_SeleccionoCarameloYNoHayDisponible_Debe_MostrarPantallaAgotado()
    {
        ComprarCarameloConDineroExacto();
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Nickel());

        _maquina.SeleccionarProducto(new Caramelo());

        _maquina.Pantalla.Should().Be("Agotado");
    }


    [Fact]
    public void Si_SeleccionoChipsYNoHayDisponible_Debe_MostrarPantallaAgotado()
    {
        ComprarChipsConDineroExacto();
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());

        _maquina.SeleccionarProducto(new Chips());

        _maquina.Pantalla.Should().Be("Agotado");
    }

    private static void ComprarCocaColaConDineroExacto(Maquina maquina)
    {
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Quarter());
        maquina.IngresarMoneda(new Quarter());
        maquina.SeleccionarProducto(new CocaCola());
    }

    private void ComprarCarameloConDineroExacto()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Dime());
        _maquina.IngresarMoneda(new Nickel());

        _maquina.SeleccionarProducto(new Caramelo());
    }

    private void ComprarChipsConDineroExacto()
    {
        _maquina.IngresarMoneda(new Quarter());
        _maquina.IngresarMoneda(new Quarter());
        _maquina.SeleccionarProducto(new Chips());
    }
}