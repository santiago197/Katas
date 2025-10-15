using AwesomeAssertions;

namespace Katas.Tests;

public class BolosTests
{
    //Si_Condicion_Debe_RetornarValorEsperado
    [Fact]
    public void Si_IniciaPartida_Debe_PuntajeSerCero()
    {
        //Arrange
        var marcador = new Marcador();
        
        //Assert
        marcador.Puntaje.Should().Be(0);
    }

    [Fact]
    public void Si_TumboCeroPinesEnElTurno_Debe_PuntajeSerCero()
    {
        //Arrange
        var marcador = new Marcador();
        
        //Act
        marcador.RegistrarPuntaje(0,0);
        
        //Assert
        marcador.Puntaje.Should().Be(0);
    }

    [Fact]
    public void Si_TumboUnPinEnElPrimerRollYDosPinesEnElSegundoRoll_Debe_PuntajeSerTres()
    {
        // Arrange
        
        //Act
        
        // Assert
    }
}


public class Marcador
{
    public int Puntaje { get; private set; } = 0;
    
    public void RegistrarPuntaje(int rollUno, int rollDos)
    {
        Puntaje = rollUno + rollDos;
    }
}