using System.Diagnostics.CodeAnalysis;
using AwesomeAssertions;

namespace Katas.Tests;

public class BolosTests
{
    [Fact]
    public void
        Si_derrumbo_1_pin_en_el_primer_lanzamiento_y_1_pin_en_el_segundo_lanzamiento_Debe_el_puntaje_del_primer_turno_ser_2()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(1);
        linea.RegistrarLanzamiento(1);

        linea.ObtenerTurno(0).Puntaje.Should().Be(2);
    }

    [Fact]
    public void Si_Derrumbo_Tres_Pines_Y_Luego_Dos_Debe_El_Puntaje_Del_Turno_Ser_5()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(3);
        linea.RegistrarLanzamiento(2);

        linea.ObtenerTurno(0).Puntaje.Should().Be(5);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(11)]
    public void
        Si_Tumbo_Mas_De_Diez_Pines_En_El_Primer_Lanzamiento_O_Menor_A_0_Debe_Retornar_Excepcion_De_Tipo_ArgumentOutOfRange(
            int pinesDerribados)
    {
        var linea = new Linea();

        var caller = () => linea.RegistrarLanzamiento(pinesDerribados);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("No (Parameter 'pinesDerribados')");
        linea.ObtenerTurno(0).ObtenerLanzamientos().Should().BeEquivalentTo((int?[])[null, null]);
    }

    [Fact]
    public void Si_realizo_un_spare_el_puntaje_debe_ser_null()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);

        linea.ObtenerTurno(0).Puntaje.Should().BeNull();
    }

    [Fact]
    public void Si_RealizoDosLanzamiento_Debe_ElTurnoEstarCompleto()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(5);
        linea.RegistrarLanzamiento(3);

        var turno = linea.ObtenerTurno(0);

        turno.Puntaje.Should().Be(8);
        turno.Completo.Should().BeTrue();
    }

    [Fact]
    public void Si_Un_Spare_Debe_En_El_Siguiente_Lanzamiento_Asignar_Bonus()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(2);

        linea.ObtenerTurno(0).Puntaje.Should().Be(18);
    }

    [Fact]
    public void Si_Hago_Chuza_Debe_Sumar_los_Siguientes_Dos_Lanzamientos()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(5);
        linea.RegistrarLanzamiento(5);

        linea.ObtenerTurno(0).Puntaje.Should().Be(20);
    }

    [Theory]
    [InlineData(9, 2)]
    [InlineData(0, 11)]
    public void Si_Entre_Los_Dos_Lanzamientos_Suma_Mas_De_Diez_Y_Menos_De_0_Debe_Arrojar_Error(int lanzamiento1,
        int lanzamiento2)
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(lanzamiento1);

        var caller = () => linea.RegistrarLanzamiento(lanzamiento2);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("No (Parameter 'pinesDerribados')");
    }

    [Theory]
    [InlineData(2, -2)]
    public void
        Si_Tumbo_Mas_De_Diez_O_Menos_De_0_Pines_En_El_Segundo_Lanzamiento_Debe_Retornar_Excepcion_De_Tipo_ArgumentOutOfRange(
            int lanzamiento1, int lanzamiento2)
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(lanzamiento1);

        var caller = () => linea.RegistrarLanzamiento(lanzamiento2);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>().WithMessage("No (Parameter 'pinesDerribados')");
    }

    [Fact]
    public void Si_Envio6y2_Y_Luego_4y3_Debe_Obtener8_En_El_Primer_Turno_Y15_En_El_Segundo_Turno()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(6);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(4);
        linea.RegistrarLanzamiento(3);

        linea.ObtenerTurno(0).Puntaje.Should().Be(8);
        linea.ObtenerTurno(1).Puntaje.Should().Be(15);
    }

    [Fact]
    public void Si_Hago_3_Chuzas_Debe_Retornar_30_En_El_Primer_Turno_Y_Null_Para_Los_Turnos_1_Y_2()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);

        linea.ObtenerTurno(0).Puntaje.Should().Be(30);
        linea.ObtenerTurno(1).Puntaje.Should().BeNull();
        linea.ObtenerTurno(2).Puntaje.Should().BeNull();
    }

    [Fact]
    public void Si_Hago_Tres_Chuzas_Y_Un_Lanzamiento_Simple_Debe_Calcular_Los_Dos_Primeros_Turnos()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(8);

        linea.ObtenerTurno(0).Puntaje.Should().Be(30);
        linea.ObtenerTurno(1).Puntaje.Should().Be(58);
        linea.ObtenerTurno(2).Puntaje.Should().BeNull();
        linea.ObtenerTurno(3).Puntaje.Should().BeNull();
    }
}

public class Linea
{
    private Turno TurnoActual => _turnos[^1];
    private readonly List<Turno> _turnos = [new()];

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        AgregarPuntosAdicionalesATurnosAnteriores(pinesDerribados);
        RegistrarLanzamientoEnTurnoActual(pinesDerribados);
        ValidarEstadoTurnoActual();
    }

    private void AgregarPuntosAdicionalesATurnosAnteriores(int pinesDerribados)
    {
        if (_turnos.Count <= 1) return;

        var turnoSinPuntaje = _turnos[..^1].Where(turno => turno.Puntaje is null).ToList();
        foreach (var turnoAnterior in turnoSinPuntaje)
            turnoAnterior.AsignarPuntosExtra(pinesDerribados);
    }

    private void ValidarEstadoTurnoActual()
    {
        if (!TurnoActual.Completo) return;

        _turnos.Add(new Turno(TurnoActual));
    }

    private void RegistrarLanzamientoEnTurnoActual(int pinesDerribados)
    {
        TurnoActual.RegistrarLanzamiento(pinesDerribados);
    }

    public Turno ObtenerTurno(int indexTurno)
    {
        return _turnos[indexTurno];
    }
}

public class Turno
{
    public int? Puntaje { get; private set; }
    public bool Completo => EsMediaChuza || EsChuza || (_lanzamiento1.HasValue && _lanzamiento2.HasValue);
    public bool EsMediaChuza => _lanzamiento1 + _lanzamiento2 is 10;
    public bool EsChuza => _lanzamiento1 == 10;

    private int? _lanzamiento1;
    private int? _lanzamiento2;
    private int _puntosAdicionales;
    private int _cantidadBonosEsperados;
    private readonly Turno? _turnoAnterior;

    public Turno()
    {
    }

    public Turno(Turno turnoAnterior)
    {
        _turnoAnterior = turnoAnterior;
    }

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarPinesDerribados(pinesDerribados);
        AsignarLanzamientos(pinesDerribados);
        CalcularPuntaje(pinesDerribados);
        if (EsMediaChuza) _cantidadBonosEsperados = 1;
        if (EsChuza) _cantidadBonosEsperados = 2;
    }

    private void ValidarPinesDerribados(int pinesDerribados)
    {
        if (pinesDerribados < 0 || (_lanzamiento1 ?? 0) + pinesDerribados is > 10 or < 0)
            throw new ArgumentOutOfRangeException(nameof(pinesDerribados), "No");
    }

    private void AsignarLanzamientos(int pinesDerribados)
    {
        if (_lanzamiento1 is null)
        {
            _lanzamiento1 = pinesDerribados;
            return;
        }

        _lanzamiento2 = pinesDerribados;
    }

    private void CalcularPuntaje(int pinesDerribados)
    {
        if (!Completo || EsMediaChuza || EsChuza) return;
        Puntaje = pinesDerribados + _lanzamiento1;
        AgregarPuntajeTurnoAnterior();
    }

    private void AgregarPuntajeTurnoAnterior()
    {
        if (_turnoAnterior is not null)
        {
            Puntaje += _turnoAnterior.Puntaje;
        }
    }

    public void AsignarPuntosExtra(int puntosExtra)
    {
        if (_cantidadBonosEsperados == 0) return;
        _puntosAdicionales += puntosExtra;
        _cantidadBonosEsperados--;
        if (_cantidadBonosEsperados != 0) return;
        Puntaje = _lanzamiento1 + (_lanzamiento2 ?? 0) + _puntosAdicionales;
        AgregarPuntajeTurnoAnterior();
    }

    public int?[] ObtenerLanzamientos()
    {
        return [_lanzamiento1, _lanzamiento2];
    }
}