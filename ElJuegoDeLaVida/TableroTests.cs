using AwesomeAssertions;

namespace Cosmos.Mob.Katas;

public class TableroTests
{
    [Theory]
    [InlineData(2, -1, "alto")]
    [InlineData(-1, 2, "ancho")]
    public void Si_LasDimensionesDadasAlTableroSonNegativas_Debe_LanzarExcepcion(int ancho, int alto,
        string parametro)
    {
        var caller = () => new Tablero(ancho, alto);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage($"Las dimensiones son erroneas (Parameter '{parametro}')");
    }

    //Calcular vecinos 
    [Fact]
    public void Si_InicializoUnTableroDeUnoXUno_Debe_NoExistirVecinoEnLaCordenadaCeroCero()
    {
        var tablero = new Tablero(1, 1);

        int[] vecinos = tablero.ObtenerVecinos(0, 0);

        vecinos.Should().HaveCount(0);
    }

    //Debe intentar obtener vecinos de una coordenada que no existe
    [Fact]
    public void Si_InicializoUnTableroDeUnoXUnoYObtengoVecinosDeCoordenadaDosDos_Debe_LanzarExcepcion()
    {
        var tablero = new Tablero(1, 1);

        Action caller = () => tablero.ObtenerVecinos(2, 2);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    public static TheoryData<Coordenada, int, int> DatosTestVecinoArriba = new()
    {
        { new Coordenada(1, 1), 1, 2 },
        { new Coordenada(0, 1), 0, 2 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoArriba))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeArriba(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoArriba(celdaSeleccionada);

        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }

    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeAbajo = new()
    {
        { new Coordenada(1, 1), 1, 0 },
        { new Coordenada(0, 1), 0, 0 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeAbajo))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeAbajo(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoAbajo(celdaSeleccionada);

        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }

    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeIzquierda = new()
    {
        { new Coordenada(1, 1), 0, 1 },
        { new Coordenada(2, 2), 1, 2 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeIzquierda))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeIzquierda(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoIzquierda(celdaSeleccionada);

        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }

    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeDerecha = new()
    {
        { new Coordenada(0, 1), 1, 1 },
        { new Coordenada(1, 0), 2, 0 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeDerecha))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeDerecha(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoDerecha(celdaSeleccionada);

        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }

    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeArribaDerecha = new()
    {
        { new Coordenada(1, 1), 2, 2 },
        { new Coordenada(0, 0), 1, 1 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeArribaDerecha))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeArribaDerecha(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoArribaDerecha(celdaSeleccionada);

        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }


    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeAbajoDerecha = new()
    {
        { new Coordenada(1, 1), 2, 0 },
        { new Coordenada(0, 1), 1, 0 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeAbajoDerecha))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeAbajoDerecha(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoAbajoDerecha(celdaSeleccionada);

        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }
    
    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeAbajoIzquierda = new()
    {
        { new Coordenada(1, 1), 0, 0 },
        { new Coordenada(2, 1), 1, 0 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeAbajoIzquierda))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeAbajoIzquierda(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoAbajoIzquierda(celdaSeleccionada);
        
        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }
    
    public static TheoryData<Coordenada, int, int> DatosTestVecinoDeArribaIzquierda = new()
    {
        { new Coordenada(1, 1), 0, 2 },
        { new Coordenada(1, 0), 0, 1 },
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeArribaIzquierda))]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerSuVecinoDeArribaIzquierda(
        Coordenada celdaSeleccionada, int valorX, int valorY)
    {
        var tablero = new Tablero(3, 3);

        var celdaVecino = tablero.ObtenerVecinoArribaIzquierda(celdaSeleccionada);
        
        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }
}