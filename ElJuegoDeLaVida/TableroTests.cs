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

    [Fact]
    public void Si_TenemosUnTableroDeTresXTresYSeleccionamosLaCelda00Tablero_Debe_ValidarVecinosDentroDeLosLimites()
    {
        var tablero = new Tablero(3, 3);
        
        var vecinosEsperados = new List<Coordenada>()
        {
            new(0,1),
            new(1,1),
            new(1,0)
        };
        
        var vecinosValidos = tablero.ObtenerVecinosDentroDelLimite(new Coordenada(0,0));
        
        vecinosValidos.Should().BeEquivalentTo(vecinosEsperados);
    }
}