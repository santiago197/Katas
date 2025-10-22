namespace Katas;

public class Linea
{
    private Turno TurnoActual => _turnos[^1];
    private readonly List<Turno> _turnos = [Turno.PrimerTurno()];

    public Turno ObtenerTurno(int indexTurno) => _turnos[indexTurno];

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        TurnoActual.RegistrarLanzamiento(pinesDerribados);
        AgregarBonificaciones(pinesDerribados);
        CambiarDeTurnoSiEsNecesario();
    }

    private void AgregarBonificaciones(int pinesDerribados)
    {
        if (EsPrimerTurno()) return;

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
        if (!TurnoActual.EstaFinalizado) return;

        _turnos.Add(EsUltimoTurno() ? Turno.UltimoTurno(TurnoActual) : Turno.TurnoIntermedio(TurnoActual));
    }

    private bool EsUltimoTurno() => _turnos.Count == 9;
}