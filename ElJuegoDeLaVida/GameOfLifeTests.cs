using AwesomeAssertions;

namespace ElJuegoDeLaVida;

public class GameOfLifeTests
{
    [Fact]
    public void Si_InicializoUnJuego_Debe_ExistirUnTablero()
    {
        int ancho = 3, alto = 1;
        var gameOfLife = new GameOfLife(ancho,alto, new List<Coordenada>());

        gameOfLife.Should().NotBeNull();
    }

    [Fact]
    public void Si_TenemosTablero3x3YLeDamosVidaAUnaCelula_Debe_EnSiguienteGeneracionEstarCelulaMuerta()
    {
        var coordenada = new Coordenada(1, 1);
        var gameOfLife = new GameOfLife(3,3, [coordenada]);

        gameOfLife.SiguienteGeneracion();
        var tableroActual = gameOfLife.ObtenerTableroActual();
        var celula = tableroActual.ObtenerCelulaPorCoordenada(coordenada);

        celula.EstaViva.Should().BeFalse();
    }

    [Fact]
    public void Si_TenemosTablero3x3YLeDamosVidaATresCelulas_Debe_EnSiguienteGeneracionMatarDosYVivirDos()
    {
        var coordenada2 = new Coordenada(1, 2);
        var coordenada = new Coordenada(1, 1);
        var coordenada1 = new Coordenada(1, 0);
        
        var gameOfLife = new GameOfLife(3,3, [
            coordenada2,
            coordenada,
            coordenada1
        ]);

        gameOfLife.SiguienteGeneracion();

        var tableroActual = gameOfLife.ObtenerTableroActual();
        var celula = tableroActual.ObtenerCelulaPorCoordenada(coordenada);
        var celula1 = tableroActual.ObtenerCelulaPorCoordenada(coordenada1);
        var celula2 = tableroActual.ObtenerCelulaPorCoordenada(coordenada2);

        celula.EstaViva.Should().BeTrue();
        celula1.EstaViva.Should().BeFalse();
        celula2.EstaViva.Should().BeFalse();
    }
}