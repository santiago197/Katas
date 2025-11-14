namespace ElJuegoDeLaVida;

public class GameOfLife
{
    private readonly Tablero _tablero;

    public GameOfLife(int ancho, int alto, List<Coordenada> coordenadas)
    {
        _tablero = new Tablero(ancho, alto);
        AsignarCelulasVivas(coordenadas);
    }

    public void SiguienteGeneracion()
    {
        var ancho = _tablero.Celdas.GetLength(0);
        var alto = _tablero.Celdas.GetLength(1);
        
        var coordenadas = _tablero.ObtenerCelulasVivas();
        
        Celula[,] celdasNuevas = new Celula[ancho, alto];
        
        for (int fila = 0; fila < ancho; fila++)
        {
            for (int columna = 0; columna < alto; columna++)
            {
                var celula = _tablero.ObtenerCelulaPorCoordenada(new Coordenada(fila, columna));
                
                List<Coordenada> vecinos = celula.Coordenadas.ObtenerVecinos();

                var cantidadVecinosVivos = vecinos.Intersect(coordenadas).Count();
                
                celula.CalcularSiguienteEstado(cantidadVecinosVivos);

                celdasNuevas[fila, columna] = celula;
            }
        }

        _tablero.ActualizarCeldas(celdasNuevas);
    }

    public Tablero ObtenerTableroActual() => _tablero;
    
    private void AsignarCelulasVivas(List<Coordenada> coordenadas)
    {
        foreach (var coordenada in coordenadas)
        {
            _tablero.DarVida(coordenada);
        }
    }
}