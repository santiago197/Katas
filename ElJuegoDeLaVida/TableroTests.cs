using AwesomeAssertions;

namespace ElJuegoDeLaVida;

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

    [Fact]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosLaCelda00Tablero_Debe_ValidarVecinosDentroDeLosLimites()
    {
        var tablero = new Tablero(3, 3);

        var vecinosEsperados = new List<Coordenada>()
        {
            new(0, 1),
            new(1, 1),
            new(1, 0)
        };

        var vecinosValidos = tablero.ObtenerVecinosDentroDelLimite(new Coordenada(0, 0));

        vecinosValidos.Should().BeEquivalentTo(vecinosEsperados);
    }

    [Fact]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosLaCelda22Tablero_Debe_ValidarVecinosDentroDeLosLimites()
    {
        var tablero = new Tablero(3, 3);

        var vecinosEsperados = new List<Coordenada>()
        {
            new(2, 1),
            new(1, 1),
            new(1, 2),
        };

        var vecinosValidos = tablero.ObtenerVecinosDentroDelLimite(new Coordenada(2, 2));

        vecinosValidos.Should().BeEquivalentTo(vecinosEsperados);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(1, 0)]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 0)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    public void SI_TenemosUnTablero3x3D_Debe_PorCadaCeldaDelTableroCrearUnaCelula(int x, int y)
    {
        var tablero = new Tablero(3, 3);

        tablero.Celdas[x, y].Should().NotBeNull();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(1, 0)]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 0)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    public void SI_TenemosUnTablero3x3_Debe_PorCadaCeldaDelTableroLaCelulaDebeEstarMuerta(int x, int y)
    {
        var tablero = new Tablero(3, 3);

        tablero.ObtenerCelulaPorCoordenada(new Coordenada(x, y)).EstaViva.Should().BeFalse();
    }


    public static TheoryData<Coordenada, int> DatosTestVecinoDeArribaIzquierda = new()
    {
        { new Coordenada(0, 0), 3 },
        { new Coordenada(0, 1), 5 },
        { new Coordenada(1, 1), 8 }
    };

    [Theory]
    [MemberData(nameof(DatosTestVecinoDeArribaIzquierda))]
    public void Si_TenemosUnTableroDe3X3YSeleccionoUnaCelula_Debe_SaberCualesSonSusCelulasVecinas(Coordenada coordenada,
        int vecinosEsperados)
    {
        var tablero = new Tablero(3, 3);

        var celulas = tablero.ObtenerCelulasPorCoordenada(coordenada);

        celulas.Should().HaveCount(vecinosEsperados);
    }

    [Fact]
    public void Si_TenemosTablero3x3YLeDamosVidaATresCelulas_DebeRetornarTresCelulasVivasCuandoLaCoordenadaEsUnoUno()
    {
        var tablero = new Tablero(3, 3);
        tablero.DarVida(new Coordenada(0, 0));
        tablero.DarVida(new Coordenada(1, 0));
        tablero.DarVida(new Coordenada(2, 0));

        var celulasVivas = tablero.ObtenerCelulasVivasPorCoordenada(new Coordenada(1, 1));

        celulasVivas.Should().HaveCount(3);
    }
}