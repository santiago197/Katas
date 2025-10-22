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
    public void Si_Tumbo_Mas_De_Diez_Pines_En_Un_Lanzamiento_Debe_Retornar_Excepcion_De_Tipo_ArgumentOutOfRange(
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

        linea.ObtenerTurno(0).Puntaje.Should().Be(18);
    }
}

public class Linea
{
    private Turno TurnoActual => _turnos[^1];
    private readonly List<Turno> _turnos = [new()];


    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarMediaChuzaEnTurnoAnterior(pinesDerribados);
        RegistrarLanzamientoEnTurnoActual(pinesDerribados);
        ValidarEstadoTurnoActual();
    }
    
    private void ValidarMediaChuzaEnTurnoAnterior(int pinesDerribados)
    {
        if (_turnos.Count > 1 && _turnos[^2].EsMediaChuza)
            _turnos[^2].AsignarPuntosExtra(pinesDerribados);
    }

    private void ValidarEstadoTurnoActual()
    {
        if (!TurnoActual.Completo) return;

        _turnos.Add(new Turno());
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
    public bool EsMediaChuza => _lanzamiento1 + _lanzamiento2 is 10;
    public bool Completo => _lanzamiento1.HasValue && _lanzamiento2.HasValue;

    private int? _lanzamiento1;
    private int? _lanzamiento2;
    
    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarPinesDerribados(pinesDerribados);
        AsignarLanzamientos(pinesDerribados);
        CalcularPuntaje(pinesDerribados);
    }
    
    private static void ValidarPinesDerribados(int pinesDerribados)
    {
        if (pinesDerribados is > 10 or < 0)
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
        if (!Completo || EsMediaChuza) return;
        Puntaje = pinesDerribados + _lanzamiento1;
    }

    public void AsignarPuntosExtra(int puntosExtra)
    {
        Puntaje = _lanzamiento1 + _lanzamiento2 + puntosExtra;
    }

    public int?[] ObtenerLanzamientos()
    {
        return [_lanzamiento1, _lanzamiento2];
    }
}