using System.Xml.Serialization;

namespace Cosmos.Mob.Katas;

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

    public Coordenada ObtenerVecinoArriba(Coordenada celdaSeleccionada) => celdaSeleccionada with { Y = celdaSeleccionada.Y + 1 };
    public Coordenada ObtenerVecinoArribaDerecha(Coordenada celdaSeleccionada) => new(celdaSeleccionada.X + 1, celdaSeleccionada.Y + 1);
    public Coordenada ObtenerVecinoDerecha(Coordenada celdaSeleccionada) => celdaSeleccionada with { X = celdaSeleccionada.X + 1 };
    public Coordenada ObtenerVecinoAbajoDerecha(Coordenada celdaSeleccionada) => new(celdaSeleccionada.X + 1, celdaSeleccionada.Y - 1);
    public Coordenada ObtenerVecinoAbajo(Coordenada celdaSeleccionada) => celdaSeleccionada with { Y = celdaSeleccionada.Y - 1 };
    public Coordenada ObtenerVecinoAbajoIzquierda(Coordenada celdaSeleccionada) => new(celdaSeleccionada.X - 1, celdaSeleccionada.Y - 1);
    public Coordenada ObtenerVecinoIzquierda(Coordenada celdaSeleccionada) => celdaSeleccionada with { X = celdaSeleccionada.X - 1 };
    public Coordenada ObtenerVecinoArribaIzquierda(Coordenada celdaSeleccionada) => new(celdaSeleccionada.X - 1, celdaSeleccionada.Y + 1);
}

public record Coordenada(int X, int Y);

public enum Direccion
{
    Arriba,
    Abajo,
    Derecha,
    Izquierda
}