namespace ElJuegoDeLaVida;

public class Tablero
{
    private int _indiceXMaximo;
    private int _indiceYMaximo;
    public bool[,] Celdas { get; private set; }

    public Tablero(int ancho, int alto)
    {
        ValidarDimensionDe(ancho, nameof(ancho));
        ValidarDimensionDe(alto, nameof(alto));

        Celdas = new bool[ancho, alto];
        CalcularIndiceMaximo(ancho, alto);
    }

    public int[] ObtenerVecinos(int x, int y)
    {
        ValidarCoordenadaExistente(x, y);
        return [];
    }

    private void ValidarCoordenadaExistente(int x, int y)
    {
        if (x > _indiceXMaximo || y > _indiceYMaximo)
            throw new ArgumentOutOfRangeException();
    }

    private void CalcularIndiceMaximo(int ancho, int alto)
    {
        _indiceXMaximo = ancho - 1;
        _indiceYMaximo = alto - 1;
    }

    private void ValidarDimensionDe(int parametro, string nombreParametro)
    {
        if (parametro <= 0)
            throw new ArgumentOutOfRangeException(nombreParametro, "Las dimensiones son erroneas");
    }

    public List<Coordenada> ObtenerVecinosDentroDelLimite(Coordenada coordenada )
    {
        var vecinos = coordenada.ObtenerVecinos();

        return vecinos.Where(vecino => vecino is { X: >= 0, Y: >= 0 }).ToList();
    }
}