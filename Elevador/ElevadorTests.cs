using AwesomeAssertions;

namespace Elevador;

public class ElevadorTests
{
    [Fact]
    public void Si_InicializoElevador_Debe_PisoActualSerUno()
    {
        var elevador = new Elevador();

        var pisoActual = elevador.ObtenerPisoActual();

        pisoActual.Should().Be(1);
    }

    [Fact]
    public void Si_ElElevadorEsLlamadoDesdeElPiso1YDestinoSolicitadoEsDos_Debe_DestinoElevadorSerDos()
    {
        var elevador = new Elevador();

        byte pisoOrigen = 1;
        byte pisoDestino = 2;
        elevador.Llamar(pisoOrigen, pisoDestino);

        elevador.ObtenerPisoDestino().Should().Be(pisoDestino);
    }

    [Fact]
    public void Si_ElevadorEsLlamadoDesdeElPiso1YElPisoDestinoEs1_Debe_RetornarUnaExcepcion()
    {
        var elevador = new Elevador();
        byte pisoOrigen = 1;
        byte pisoDestino = 1;

        var caller = () => elevador.Llamar(pisoOrigen, pisoDestino);

        caller.Should().ThrowExactly<InvalidOperationException>().WithMessage("Estás en el mismo piso.");
    }

    [Fact]
    public void Si_ElElevadorEstaEnElPisoUnoYElPisoOrigenEsUno_Debe_AbrirLasPuertas()
    {
        var elevador = new Elevador();
        byte pisoOrigen = 1;
        byte pisoDestino = 2;

        elevador.Llamar(pisoOrigen, pisoDestino);

        elevador.PuertaAbierta.Should().BeTrue();
    }

    [Fact]
    public void Si_x()
    {
        var elevador = new Elevador();
        byte pisoOrigen = 2;
        byte pisoDestino = 5;

        elevador.Llamar(pisoOrigen, pisoDestino);
        elevador.Ir(pisoDestino);

        elevador.PuertaAbierta.Should().BeTrue();
    }
}

public class Elevador
{
    private byte _pisoActual { get; set; } = 1;
    private byte _pisoDestino { get; set; }
    public bool PuertaAbierta { get; set; }

    public byte ObtenerPisoActual()
    {
        return _pisoActual;
    }

    public void Ir(byte pisoDestino)
    {
        _pisoActual = pisoDestino;
    }

    public void Llamar(byte pisoOrigen, byte pisoDestino)
    {
        if (pisoOrigen == pisoDestino)
            throw new InvalidOperationException("Estás en el mismo piso.");

        _pisoDestino = pisoDestino;
        if (pisoOrigen == _pisoActual)
            PuertaAbierta = true;
    }

    public object ObtenerPisoDestino()
    {
        return _pisoDestino;
    }
}