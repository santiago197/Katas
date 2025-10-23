using System.Data;
using AwesomeAssertions;

namespace Katas.Tests;

public class JuegoTests
{
    //Si_Condicion_Debe_Consecuencia
    //Si_CondicionAlgo_Debe_ConsecuenciaAlgo
    //Si_Lanzo20_000Bolos_Debe_Sumar
    [Fact]
    public void Si_AgregoUnJugador_Debe_ExistirUnJugadorConUnaLinea()
    {
        var juego = new Juego();

        juego.AgregarJugador("Diego");

        var jugador = juego.ObtenerJugador(0);

        jugador.Should().NotBeNull();
        jugador.Linea.Should().NotBeNull();
    }

    [Fact]
    public void Si_NombreJugadorExiste_Debe_LanzarExcepcion()
    {
        var juego = new Juego();

        juego.AgregarJugador("Diego");
        var caller = () => juego.AgregarJugador("Diego");

        caller.Should().ThrowExactly<DuplicateNameException>().WithMessage("Ya existe jugador.");
    }

    [Fact]
    public void Si_AgregoMasDe6Jugadores_Debe_LanzarExcepcion()
    {
        var juego = new Juego();

        juego.AgregarJugador("Diego");
        juego.AgregarJugador("Jaime");
        juego.AgregarJugador("Kevin");
        juego.AgregarJugador("Nestor Chicken");
        juego.AgregarJugador("Santiago");
        juego.AgregarJugador("Harold");
        var caller = () => juego.AgregarJugador("Diego7");

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>()
            .WithMessage("No es posible agregar un nuevo jugador. (Parameter '_jugadores')");
    }

    [Fact]
    public void Si_DosJugadoresJueganElPrimerTurno_Debe_RetornarElPuntajeAcumulado()
    {
        var juego = new Juego();

        juego.AgregarJugador("Diego");
        juego.AgregarJugador("Kevin");

        juego.RegistrarLanzamiento(3);
        juego.RegistrarLanzamiento(2);
        juego.RegistrarLanzamiento(4);
        juego.RegistrarLanzamiento(5);

        var jugador1 = juego.ObtenerJugador(0);
        var jugador2 = juego.ObtenerJugador(1);

        jugador1.Linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(5);
        jugador2.Linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(9);
    }

    [Fact]
    public void Si_LosJugadoresFinalizaronSuPrimerTurno_Debe_CambiarDeTurno()
    {
        var juego = new Juego();

        juego.AgregarJugador("Diego");
        juego.AgregarJugador("Kevin");

        juego.RegistrarLanzamiento(3);
        juego.RegistrarLanzamiento(2);
        juego.RegistrarLanzamiento(4);
        juego.RegistrarLanzamiento(5);
        juego.RegistrarLanzamiento(2);
        juego.RegistrarLanzamiento(6);

        var jugador1 = juego.ObtenerJugador(0);
        var jugador2 = juego.ObtenerJugador(1);

        jugador1.Linea.ObtenerTurno(1).ObtenerPuntaje().Should().Be(13);
        jugador2.Linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(9);
    }
}

public class Juego
{
    private const int CantidadJugadoresPermitidos = 6;
    private List<Jugador> _jugadores = [];
    private int _indiceJugadorActual = 0;
    private int _indiceTurnoGlobal = 0;

    public void AgregarJugador(string nombre)
    {
        ValidarJugadorRepetido(nombre);
        ValidarCantidadJugadoresPermitidos();
        _jugadores.Add(new Jugador(nombre));
    }

    public Jugador ObtenerJugador(int indice) => _jugadores[indice];

    private void ValidarCantidadJugadoresPermitidos()
    {
        if (_jugadores.Count == CantidadJugadoresPermitidos)
            throw new ArgumentOutOfRangeException(nameof(_jugadores), "No es posible agregar un nuevo jugador.");
    }

    private void ValidarJugadorRepetido(string nombre)
    {
        if (_jugadores.Any(jugador => jugador.Nombre == nombre))
            throw new DuplicateNameException("Ya existe jugador.");
    }

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        EsTurnoJugadorFinalizado();
        EsTurnoGlobalFinalizado();
        RegistraLanzamientoJugador(pinesDerribados);
    }

    private void RegistraLanzamientoJugador(int pinesDerribados)
    {
        _jugadores[_indiceJugadorActual].Linea.RegistrarLanzamiento(pinesDerribados);
    }

    private void EsTurnoGlobalFinalizado()
    {
        if (_jugadores.Count == _jugadores.Count(j => j.Linea.ObtenerTurno(_indiceTurnoGlobal).EstaFinalizado))
        {
            _indiceTurnoGlobal++;
            _indiceJugadorActual = 0;
        }
    }

    private void EsTurnoJugadorFinalizado()
    {
        if (_jugadores[_indiceJugadorActual].Linea.ObtenerTurno(_indiceTurnoGlobal).EstaFinalizado)
            _indiceJugadorActual++;
    }
}

public class Jugador(string nombre)
{
    public string Nombre { get; set; } = nombre;
    public Linea Linea { get; set; } = new();
}