namespace ElJuegoDeLaVida;

public class Celula(Coordenada coordenada)
{
    public bool EstaViva { get; private set; }
    public Coordenada Coordenadas { get; set; } = coordenada;

    public void Vivir() => EstaViva = true;

    public void Asesinar() => EstaViva = false;

    public void CalcularSiguienteEstado(int vecinosVivos)
    {
        if (EstaViva && vecinosVivos is 2 or 3)
            return;

        if (EstaMuerta() && vecinosVivos == 3)
        {
            Vivir();
            return;
        }

        Asesinar();
    }

    private bool EstaMuerta() => EstaViva is false;
}