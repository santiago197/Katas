namespace ElJuegoDeLaVida;

public class Tablero
{
    private readonly int _indiceXMaximo;
    private readonly int _indiceYMaximo;
    public Celula[,] Celdas { get; private set; }

    public Tablero(int ancho, int alto)
    {
        LanzarErrorCuandoDimensionNoEsValida(ancho, nameof(ancho));
        LanzarErrorCuandoDimensionNoEsValida(alto, nameof(alto));

        var indicesMaximos = CalcularIndiceMaximo(ancho, alto);
        _indiceXMaximo = indicesMaximos.x;
        _indiceYMaximo = indicesMaximos.y;
        Celdas = GenerarCelulas(ancho, alto);
    }

    private Celula[,] GenerarCelulas(int ancho, int alto)
    {
        Celula[,] celulasTablero = new Celula[ancho, alto];

        for (int row = 0; row < ancho; row++)
        {
            for (int cell = 0; cell < alto; cell++)
            {
                celulasTablero[row, cell] = new Celula(new Coordenada(row, cell));
            }
        }

        return celulasTablero;
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

    private (int x, int y) CalcularIndiceMaximo(int ancho, int alto)
    {
        var indiceXMaximo = ancho - 1;
        var indiceYMaximo = alto - 1;

        return (indiceXMaximo, indiceYMaximo);
    }

    private void LanzarErrorCuandoDimensionNoEsValida(int parametro, string nombreParametro)
    {
        if (parametro <= 0)
            throw new ArgumentOutOfRangeException(nombreParametro, "Las dimensiones son erroneas");
    }

    public List<Coordenada> ObtenerVecinosDentroDelLimite(Coordenada coordenada)
    {
        var vecinos = coordenada.ObtenerVecinos();

        return vecinos.Where(vecino => vecino is { X: >= 0, Y: >= 0 }).ToList();
    }

    public void GenerarCelulasIniciales()
    {
        throw new NotImplementedException();
    }
}