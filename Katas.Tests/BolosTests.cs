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
    public void X()
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
    private int _cantidadLanzamientos = 0;
    private List<Turno> _turnos = [];

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarPinesDerribados(pinesDerribados);


        if (_cantidadLanzamientos % 2 == 0)
        {
            _turnos.Add(new Turno());
        }

        var turno = _turnos.LastOrDefault(new Turno());
        turno.RegistrarLanzamiento(pinesDerribados);

//        _turnos;
        _cantidadLanzamientos++;


        if (turno.EsSpare)
        {
            turno.AsignarPuntosExtra(pinesDerribados);
        }
    }

    private static void ValidarPinesDerribados(int pinesDerribados)
    {
        if (pinesDerribados > 10 || pinesDerribados < 0)
            throw new ArgumentOutOfRangeException(nameof(pinesDerribados), "No");
    }


    public Turno ObtenerTurno(int indexTurno)
    {
        return _turnos[0];
    }
}

public class Turno
{
    private int? _lanzamiento1;
    private int? _lanzamiento2;
    public int? Puntaje { get; set; }
    public bool EsSpare { get; set; }


    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarSpare(pinesDerribados);

        AsignarLanzamiento(pinesDerribados);

        CalcularPuntaje();
    }


    private void ValidarSpare(int pinesDerribados)
    {
        EsSpare = _lanzamiento1.HasValue && _lanzamiento1 + pinesDerribados == 10;
    }

    private void AsignarLanzamiento(int pinesDerribados)
    {
        if (_lanzamiento1.HasValue)
            _lanzamiento2 = pinesDerribados;
        else
            _lanzamiento1 = pinesDerribados;
    }

    private void CalcularPuntaje()
    {
        var puntaje = _lanzamiento1 + _lanzamiento2;

        if (puntaje == 10)
            Puntaje = null;
        else
            Puntaje = puntaje;
    }

    public void AsignarPuntosExtra(int puntos)
    {
        if (EsSpare)
            Puntaje += 10;
        Puntaje += puntos;
    }
}