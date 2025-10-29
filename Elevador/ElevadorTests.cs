using AwesomeAssertions;

namespace Elevador;

public class ElevadorTests
{
    [Fact]
    public void Si_InicioElevador_Debe_EstarEnPiso1()
    {
        var elevador = new Elevador();

        var piso = elevador.PisoActual;

        piso.Should().Be(1);
    }

    [Fact]
    public void Si_ElevadorEstaEnElPiso1YMuevoAlPiso2_Debe_ElPisoActualSer2()
    {
        var elevador = new Elevador();
        byte pisoDestino = 2;

        elevador.Mover(pisoDestino);

        elevador.PisoActual.Should().Be(pisoDestino);
    }

    [Fact]
    public void
        Si_ElevadorEstaEnElPiso1YLlamoElevadorDesdeElPiso2YDireccionSolicitadaEsArriba_Debe_ElPisoActualSer2YDireccionSerArriba()
    {
        var elevador = new Elevador();

        byte pisoSolicitado = 2;
        elevador.Llamar(pisoSolicitado, Direccion.Arriba);

        elevador.PisoActual.Should().Be(pisoSolicitado);
        elevador.Direccion.Should().Be(Direccion.Arriba);
    }

    [Fact]
    public void
        Si_ElevadorEstaEnElPiso3YLlamoElevadorDesdeElPiso2YDireccionSolicitadaEsAbajo_Debe_ElPisoActualSer2YDireccionSerAbajo()
    {
        var elevador = new Elevador();
        byte pisoInicial = 3;
        byte pisoSolicitado = 2;
        elevador.Mover(pisoInicial);

        elevador.Llamar(pisoSolicitado, Direccion.Abajo);

        elevador.PisoActual.Should().Be(pisoSolicitado);
        elevador.Direccion.Should().Be(Direccion.Abajo);
    }

    [Fact]
    public void Si_ElevadorEstaEnElPisoLimiteInferiorYLaDireccionLlamadaEsAbajo_Debe_LanzarExcepcion()
    {
        var elevador = new Elevador();

        Action caller = () => elevador.Llamar(1, Direccion.Abajo);

        caller.Should().Throw<InvalidOperationException>()
            .WithMessage("El elevador ya se encuentra en el límite inferior.");
    }

    [Fact]
    public void Si_ElevadorEstaEnElPisoLimiteSuperiorYLaDireccionLlamadaEsArriba_Debe_LanzarExcepcion()
    {
        var elevador = new Elevador();

        Action caller = () => elevador.Llamar(10, Direccion.Arriba);

        caller.Should().Throw<InvalidOperationException>()
            .WithMessage("El elevador ya se encuentra en el límite superior.");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Si_ElevadorEsLlamadoEnElMismoPisoAlActual_Debe_AbrirPuerta(byte pisoSolicitado)
    {
        var elevador = new Elevador();
        elevador.Mover(pisoSolicitado);

        elevador.Llamar(pisoSolicitado, Direccion.Arriba);

        elevador.ConsultarPuertaAbierta().Should().BeTrue();
    }


    [Fact]
    public void Si_ElevadorEstaEnElPiso1YEsLlamadoEnElPiso2_Debe_PisoActualSer2YAbrirPuerta()
    {
        var elevador = new Elevador();

        elevador.Llamar(2, Direccion.Arriba);

        elevador.PisoActual.Should().Be(2);
        elevador.ConsultarPuertaAbierta().Should().BeTrue();
    }

    [Fact]
    public void
        Si_ElevadorEstaEnPiso1YEsLlamadoAPiso2YDespuesDeLlegarEsLlamadoAPiso3AntesDeMoverseAPiso3_Debe_CerrarPuerta()
    {
        var elevador = new Elevador();
        
        elevador.Mover(2);

        Action caller = () => elevador.Mover(3);

        caller.Should().ThrowExactly<InvalidOperationException>().WithMessage("La puerta esta abierta");
    }
}

public enum Direccion
{
    Arriba,
    Abajo
}

public class Elevador(byte pisoLimiteInferior = 1, byte pisoLimiteSuperior = 10)
{
    private byte _pisoActual = 1;
    private Direccion _direccion;
    private bool _puertaAbierta;

    public byte PisoActual => _pisoActual;
    public Direccion Direccion => _direccion;


    public void Mover(byte pisoDestino)
    {
        if (_puertaAbierta)
            throw new InvalidOperationException("La puerta esta abierta");
        
        _pisoActual = pisoDestino;
        _puertaAbierta = true;
    }

    public void Llamar(byte pisoSolicitado, Direccion direccion)
    {
        ValidarDireccionSegunLimite(pisoSolicitado, direccion);
        
        if (pisoSolicitado == _pisoActual)
        {
            _puertaAbierta = true;
            return;
        }

        Mover(pisoSolicitado);

        _direccion = direccion;
    }

    public bool ConsultarPuertaAbierta()
        => _puertaAbierta;

    private void ValidarDireccionSegunLimite(byte pisoSolicitado, Direccion direccion)
    {
        if (pisoSolicitado == pisoLimiteInferior && direccion == Direccion.Abajo)
            throw new InvalidOperationException("El elevador ya se encuentra en el límite inferior.");

        if (pisoSolicitado == pisoLimiteSuperior && direccion == Direccion.Arriba)
            throw new InvalidOperationException("El elevador ya se encuentra en el límite superior.");
    }
}