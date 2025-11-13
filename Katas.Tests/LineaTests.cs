using AwesomeAssertions;

namespace Katas.Tests;

public class LineaTests
{
    [Fact]
    public void
        Si_derrumbo_1_pin_en_el_primer_lanzamiento_y_1_pin_en_el_segundo_lanzamiento_Debe_el_puntaje_del_primer_turno_ser_2()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(1);
        linea.RegistrarLanzamiento(1);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(2);
    }

    [Fact]
    public void Si_Derrumbo_Tres_Pines_Y_Luego_Dos_Debe_El_Puntaje_Del_Turno_Ser_5()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(3);
        linea.RegistrarLanzamiento(2);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(5);
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
        linea.ObtenerTurno(0).ObtenerLanzamientos().Should().BeEmpty();
    }

    [Fact]
    public void Si_realizo_un_spare_el_puntaje_debe_ser_null()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().BeNull();
    }

    [Fact]
    public void Si_RealizoDosLanzamiento_Debe_ElTurnoEstarCompleto()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(5);
        linea.RegistrarLanzamiento(3);

        var turno = linea.ObtenerTurno(0);

        turno.ObtenerPuntaje().Should().Be(8);
        turno.EstaFinalizado.Should().BeTrue();
    }

    [Fact]
    public void Si_Un_Spare_Debe_En_El_Siguiente_Lanzamiento_Asignar_Bonus()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(2);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(18);
    }

    [Fact]
    public void Si_Hago_Chuza_Debe_Sumar_los_Siguientes_Dos_Lanzamientos()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(5);
        linea.RegistrarLanzamiento(5);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(20);
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

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(8);
        linea.ObtenerTurno(1).ObtenerPuntaje().Should().Be(15);
    }

    [Fact]
    public void Si_Hago_3_Chuzas_Debe_Retornar_30_En_El_Primer_Turno_Y_Null_Para_Los_Turnos_1_Y_2()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(30);
        linea.ObtenerTurno(1).ObtenerPuntaje().Should().BeNull();
        linea.ObtenerTurno(2).ObtenerPuntaje().Should().BeNull();
    }

    [Fact]
    public void Si_Hago_Tres_Chuzas_Y_Un_Lanzamiento_Simple_Debe_Calcular_Los_Dos_Primeros_Turnos()
    {
        var linea = new Linea();

        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(8);

        linea.ObtenerTurno(0).ObtenerPuntaje().Should().Be(30);
        linea.ObtenerTurno(1).ObtenerPuntaje().Should().Be(58);
        linea.ObtenerTurno(2).ObtenerPuntaje().Should().BeNull();
        linea.ObtenerTurno(3).ObtenerPuntaje().Should().BeNull();
    }

    [Fact]
    public void Si_Hay_Un_Spare_Y_Hay_Lanzamiento_No_Valido_Debe_Lanzar_Excepcion_Y_No_Agregar_Bonos()
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(2);

        var caller = () => linea.RegistrarLanzamiento(12);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>();
        linea.ObtenerTurno(0).ObtenerPuntaje().Should().BeNull();
    }

    [Fact]
    public void Si_Juego_Bien_Debe_Totalizar_Bien()
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(4);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(10);

        linea.ObtenerTurno(9).ObtenerLanzamientos().Should().HaveCount(3);
        linea.ObtenerTurno(9).ObtenerPuntaje().Should().Be(198);
    }

    [Fact]
    public void Si_En_El_Ultimo_Turno_No_Hago_Chuza_Ni_Media_Chuza_Debe_Tener_2_Lanzamientos()
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(4);
        linea.RegistrarLanzamiento(2);

        var caller = () => linea.RegistrarLanzamiento(4);

        caller.Should().ThrowExactly<InvalidOperationException>().WithMessage("Juego finalizado");
        linea.ObtenerTurno(9).ObtenerLanzamientos().Should().HaveCount(2);
    }

    [Fact]
    public void Si_Hago_Un_Juego_Perfecto_Debe_Retornar_300()
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        
        linea.ObtenerTurno(9).ObtenerPuntaje().Should().Be(300);
    }
    [Fact]
    public void Si_No_Registra_Puntaje_Debe_Retornar_0()
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.RegistrarLanzamiento(0);
        linea.ObtenerTurno(9).ObtenerPuntaje().Should().Be(0);
    }

    [Fact]
    public void Si_En_El_Ultimo_Turno_Registro_Un_Lanzamiento_Fuera_Del_Rango_Debe_Lanzar_Error()
    {
        var linea = new Linea();
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(8);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(2);
        linea.RegistrarLanzamiento(4);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(10);
        linea.RegistrarLanzamiento(2);
        var caller = () => linea.RegistrarLanzamiento(12);

        caller.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
    
    
}