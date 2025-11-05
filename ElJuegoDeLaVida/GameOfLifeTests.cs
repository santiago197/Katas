using AwesomeAssertions;

namespace ElJuegoDeLaVida;

public class GameOfLifeTests
{
    [Fact]
    public void Si_InicializoUnJuego_Debe_ExistirUnTablero()
    {
        int ancho = 3, alto = 1;

        var gameOfLife = new GameOfLife(new Tablero(ancho, alto));

        gameOfLife.Should().NotBeNull();
    }
}

public class GameOfLife(Tablero tablero)
{
    private Tablero _tablero = tablero;
}