using AwesomeAssertions;

namespace Cosmos.Mob.Katas;

public class CelulasTests
{
    [Fact]
    public void Si_CreoUnaCelulaSuEstadoInicial_Debe_EstarMuerta()
    {
        var celula = new Celula();

        var estadoCelula = celula.EstaViva;

        estadoCelula.Should().BeFalse();
    }

    [Fact]
    public void Si_HayUnaCelulaMuertaYLaVivo_Debe_EstarViva()
    {
        var celula = new Celula();

        celula.Vivir();
        var estadoCelula = celula.EstaViva;

        estadoCelula.Should().BeTrue();
    }

    [Fact]
    public void Si_HayUnaCelulaVivaYLaAsesino_Debe_EstarMuerta()
    {
        var celula = new Celula();
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
        var celula = new Celula();
        celula.Vivir();

        //Act
        celula.CalcularSiguienteEstado(vecinosVivos);

        //Assert

        celula.EstaViva.Should().BeTrue();
    }

    [Fact]
    public void Si_HayUnaCelulaMuertaConTresVecinasVivas_Debe_Vivir()
    {
        var celula = new Celula();
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
        var celula = new Celula();
        celula.Vivir();

        celula.CalcularSiguienteEstado(vecinosVivos);

        celula.EstaViva.Should().BeFalse();
    }
}

public class Celula
{
    public bool EstaViva { get; private set; }

    public void Vivir() => EstaViva = true;

    public void Asesinar() => EstaViva = false;

    public void CalcularSiguienteEstado(int vecinosVivos)
    {
        if (EstaViva && vecinosVivos is 2 or 3)
            return;

        if (EstaMuerta() && vecinosVivos == 3)
        {
            Vivir();
            return;
        }

        Asesinar();
    }

    private bool EstaMuerta() => EstaViva is false;
}