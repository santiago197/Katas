namespace ElJuegoDeLaVida;

public class Coordenada(int x , int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    
    public Coordenada ObtenerVecinoArriba() => new(X, Y + 1); 
    public Coordenada ObtenerVecinoArribaDerecha() => new(X + 1, Y + 1);
    public Coordenada ObtenerVecinoDerecha() => new(X + 1, Y); 
    public Coordenada ObtenerVecinoAbajoDerecha() => new(X + 1, Y - 1);
    public Coordenada ObtenerVecinoAbajo() => new(X, Y - 1);
    public Coordenada ObtenerVecinoAbajoIzquierda() => new(X - 1, Y - 1);
    public Coordenada ObtenerVecinoIzquierda() => new(X - 1, Y) ;
    public Coordenada ObtenerVecinoArribaIzquierda() => new(X - 1, Y + 1);

    public List<Coordenada> ObtenerVecinos()
    {
        List<Coordenada> coordenadas =
        [
            ObtenerVecinoArribaIzquierda(),
            ObtenerVecinoArriba(),
            ObtenerVecinoArribaDerecha(),
            ObtenerVecinoDerecha(),
            ObtenerVecinoAbajoDerecha(),
            ObtenerVecinoAbajo(),
            ObtenerVecinoAbajoIzquierda(),
            ObtenerVecinoIzquierda()
        ];

        return coordenadas;
    }
}