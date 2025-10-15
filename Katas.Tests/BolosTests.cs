using AwesomeAssertions;

namespace Katas.Tests;

public class BolosTests
{
    //Si_Condicion_Debe_RetornarValorEsperado
    [Fact]
    public void Si_IniciaPartida_Debe_PuntajeSerCero()
    {
        //Arrange
        var partida = new Marcador();
        
        //Assert
        partida.Puntaje.Should().Be(0);
    }

    [Fact]
    public void Si_TumboCeroPinesPrimerRollYCeroPinesSegundoRoll_Debe_PuntajeSerCero()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
}

public class Marcador
{
    public int Puntaje { get; private set; } = 0;
}