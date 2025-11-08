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

    public void ActualizarCeldas(Celula[,] celulasActualizadas)
    {
        Celdas = celulasActualizadas;
    }

    public Celula ObtenerCelulaPorCoordenada(Coordenada coordenada) => Celdas[coordenada.X, coordenada.Y];

    // public List<Celula> ObtenerCelulasPorCoordenadas(List<Coordenada> coordenada) => Celdas[coordenada.X, coordenada.Y];
    public List<Coordenada> ObtenerVecinosDentroDelLimite(Coordenada coordenada)
    {
        var vecinos = coordenada.ObtenerVecinos();

        return vecinos.Where(vecino =>
                vecino.X >= 0 && vecino.X <= _indiceXMaximo && vecino.Y >= 0 && vecino.Y <= _indiceYMaximo)
            .ToList();
    }

    public void DarVida(Coordenada coordenada)
    {
        LanzarExcepcionCuandoExcedeLimite(coordenada);

        var celula = Celdas[coordenada.X, coordenada.Y];
        celula.Vivir();
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

    private (int x, int y) CalcularIndiceMaximo(int ancho, int alto)
    {
        var indiceXMaximo = ancho - 1;
        var indiceYMaximo = alto - 1;

        return (indiceXMaximo, indiceYMaximo);
    }

    private void LanzarExcepcionCuandoExcedeLimite(Coordenada coordenada)
    {
        if (coordenada.X > _indiceXMaximo || coordenada.Y > _indiceYMaximo)
            throw new ArgumentOutOfRangeException(nameof(coordenada),
                "La célula no se encuentra en la coordenada establecida");
    }

    private void LanzarErrorCuandoDimensionNoEsValida(int parametro, string nombreParametro)
    {
        if (parametro <= 0)
            throw new ArgumentOutOfRangeException(nombreParametro, "Las dimensiones son erroneas");
    }

    public List<Celula> ObtenerCelulasPorCoordenada(Coordenada coordenada)
    {
        return ObtenerVecinosDentroDelLimite(coordenada).Select(coordenadaVecino =>
            Celdas[coordenadaVecino.X, coordenadaVecino.Y]).ToList();
    }

    public List<Celula> ObtenerCelulasVivasPorCoordenada(Coordenada coordenada)
    {
        return ObtenerCelulasPorCoordenada(coordenada).Where(celula => celula.EstaViva).ToList();
    }

    public List<Coordenada> ObtenerCelulasVivas()
        => Celdas.Cast<Celula>().ToArray().Where(celula => celula.EstaViva).Select(celula => celula.Coordenadas).ToList();
    
}