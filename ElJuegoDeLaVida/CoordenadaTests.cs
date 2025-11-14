using AwesomeAssertions;

namespace ElJuegoDeLaVida;

public class CoordenadaTests
{
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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoArriba();

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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoAbajo();

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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoIzquierda();

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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoDerecha();

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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoArribaDerecha();

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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoAbajoDerecha();

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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoAbajoIzquierda();
        
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
        var celdaVecino = celdaSeleccionada.ObtenerVecinoArribaIzquierda();
        
        celdaVecino.X.Should().Be(valorX);
        celdaVecino.Y.Should().Be(valorY);
    }

    [Fact]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosUnaCelda_Debe_ObtenerLaListaDeCoordenadasVecinas()
    {
        var coordenada = new Coordenada(1, 1);
        
        var vecinosEsperados = new List<Coordenada>()
        {
            new(0,2),
            new(1,2),
            new(2,2),
            new(2,1),
            new(2,0),
            new(1,0),
            new(0,0),
            new(0,1)
        };

        var coordenadasVecinas = coordenada.ObtenerVecinos();

        coordenadasVecinas.Should().NotBeNull();
        coordenadasVecinas.Should().BeEquivalentTo(vecinosEsperados);
    }
}
