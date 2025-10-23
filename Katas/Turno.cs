namespace Katas;

public class Turno
{
    protected virtual int MaximaCantidadDePines => 10;
    private const int MinimaCantidadDePines = 0;

    public virtual bool EstaFinalizado => EsChuza || LanzamientosCompletos;
    private bool EsMediaChuza => Lanzamientos.Sum() == MaximaCantidadDePines && Lanzamientos.Count == 2;
    private bool EsChuza => Lanzamientos.Count == 1 && Lanzamientos[0] == MaximaCantidadDePines;
    protected virtual bool LanzamientosCompletos => Lanzamientos.Count == 2;
    protected readonly List<int> Lanzamientos = [];

    private readonly List<int> _puntajesExtra = [];
    private readonly Turno? _turnoAnterior;

    private Turno()
    {
    }

    protected Turno(Turno turnoAnterior)
    {
        _turnoAnterior = turnoAnterior;
    }

    public IReadOnlyList<int> ObtenerLanzamientos() => Lanzamientos.AsReadOnly();

    public bool NoTienePuntaje() => ObtenerPuntaje() is null;

    public int? ObtenerPuntaje()
    {
        if (EsChuzaIncompleta() || MediaChuzaIncompleta() || !EstaFinalizado) return null;

        return Lanzamientos.Sum() + _puntajesExtra.Sum() + (_turnoAnterior?.ObtenerPuntaje() ?? 0);
    }

    private bool MediaChuzaIncompleta() => EsMediaChuza && _puntajesExtra.Count < 1;
    private bool EsChuzaIncompleta() => EsChuza && _puntajesExtra.Count < 2;

    public void RegistrarLanzamiento(int pinesDerribados)
    {
        ValidarPinesDerribados(pinesDerribados);
        Lanzamientos.Add(pinesDerribados);
    }

    public void AgregarPuntosExtra(int puntosExtra)
    {
        if (EsChuza && _puntajesExtra.Count == 2) return;
        if (EsMediaChuza && _puntajesExtra.Count == 1) return;

        _puntajesExtra.Add(puntosExtra);
    }

    private void ValidarPinesDerribados(int pinesDerribados)
    {
        if (EsLanzamientoFueraDeRango(pinesDerribados) || EsTotalDePinesFueraDeRango(pinesDerribados))
            throw new ArgumentOutOfRangeException(nameof(pinesDerribados), "No");
    }

    private static bool EsLanzamientoFueraDeRango(int pinesDerribados)
    {
        return pinesDerribados is < 0 or > 10;
    }

    private bool EsTotalDePinesFueraDeRango(int pinesDerribados)
    {
        var total = Lanzamientos.Sum() + pinesDerribados;
        return total > MaximaCantidadDePines || total < MinimaCantidadDePines;
    }

    public static Turno PrimerTurno()
    {
        return new Turno();
    }

    public static Turno TurnoIntermedio(Turno turnoAnterior)
    {
        return new Turno(turnoAnterior);
    }

    public static Turno UltimoTurno(Turno turnoAnterior)
    {
        return new UltimoTurno(turnoAnterior);
    }
}

public class UltimoTurno(Turno turnoAnterior) : Turno(turnoAnterior)
{
    protected override bool LanzamientosCompletos => Lanzamientos.Count == 3;
    protected override int MaximaCantidadDePines => 30;
    private bool NoEsMediaChuza => Lanzamientos.Count == 2 && Lanzamientos.Sum() < 10;
    public override bool EstaFinalizado => NoEsMediaChuza || LanzamientosCompletos;
}