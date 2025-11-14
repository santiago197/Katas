using AwesomeAssertions;

namespace ElJuegoDeLaVida;

public class CelulasTests
{
    [Fact]
    public void Si_CreoUnaCelulaSuEstadoInicial_Debe_EstarMuerta()
    {
        var celula = new Celula(new Coordenada(1,1));

        var estadoCelula = celula.EstaViva;

        estadoCelula.Should().BeFalse();
    }

    [Fact]
    public void Si_HayUnaCelulaMuertaYLaVivo_Debe_EstarViva()
    {
        var celula = new Celula(new Coordenada(1,1));

        celula.Vivir();
        var estadoCelula = celula.EstaViva;

        estadoCelula.Should().BeTrue();
    }

    [Fact]
    public void Si_HayUnaCelulaVivaYLaAsesino_Debe_EstarMuerta()
    {
        var celula = new Celula(new Coordenada(1,1));
        celula.Vivir();

        celula.Asesinar();

        celula.EstaViva.Should().BeFalse();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void Si_LaCelulaEstaVivaYTieneDosOTresVecinasVivas_Debe_EstarViva(int vecinosVivos)
    {
        //Arrange
        var celula = new Celula(new Coordenada(1,1));
        celula.Vivir();

        //Act
        celula.CalcularSiguienteEstado(vecinosVivos);

        //Assert

        celula.EstaViva.Should().BeTrue();
    }

    [Fact]
    public void Si_HayUnaCelulaMuertaConTresVecinasVivas_Debe_Vivir()
    {
        var celula = new Celula(new Coordenada(1,1));
        celula.CalcularSiguienteEstado(3);

        celula.EstaViva.Should().BeTrue();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public void Si_HayUnaCelulaVivaConMasDeTresVecinasVivas_Debe_Morir(int vecinosVivos)
    {
        var celula = new Celula(new Coordenada(1,1));
        celula.Vivir();

        celula.CalcularSiguienteEstado(vecinosVivos);

        celula.EstaViva.Should().BeFalse();
    }

    [Fact]
    public void CuandoCreeUnaCelula_Debe_TenerUnaCoordenada()
    {
        var celula = new Celula(new Coordenada(1,1));

        celula.Coordenadas.Should().NotBeNull();
        celula.Coordenadas.X.Should().Be(1);
        celula.Coordenadas.Y.Should().Be(1);
    }
}