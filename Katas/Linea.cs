namespace Katas;

public class Linea
{
    private Turno TurnoActual => _turnos[^1];
    private readonly List<Turno> _turnos = [Turno.PrimerTurno()];

    public Turno ObtenerTurno(int indexTurno) => _turnos[indexTurno];

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarLineaFinalizada();
        TurnoActual.RegistrarLanzamiento(pinesDerribados);
        AgregarBonificaciones(pinesDerribados);
        CambiarDeTurnoSiEsNecesario();
    }

    private void ValidarLineaFinalizada()
    {
        if (TurnoActual is UltimoTurno && TurnoActual.EstaFinalizado)
            throw new InvalidOperationException("Juego finalizado");
    }

    private void AgregarBonificaciones(int pinesDerribados)
    {
        var turnosPasadosSinPuntaje = ObtenerTurnosPasadosSinPuntaje();

        foreach (var turno in turnosPasadosSinPuntaje)
            turno.AgregarPuntosExtra(pinesDerribados);
    }

    private List<Turno> ObtenerTurnosPasadosSinPuntaje() =>
        _turnos[..^1]
            .Where(turno => turno.NoTienePuntaje())
            .ToList();

    private bool EsPrimerTurno() => _turnos.Count == 1;

    private void CambiarDeTurnoSiEsNecesario()
    {
        if (!TurnoActual.EstaFinalizado || TurnoActual is UltimoTurno) return;

        _turnos.Add(EsUltimoTurno() ? Turno.UltimoTurno(TurnoActual) : Turno.TurnoIntermedio(TurnoActual));
    }

    private bool EsUltimoTurno() => _turnos.Count == 9;
}