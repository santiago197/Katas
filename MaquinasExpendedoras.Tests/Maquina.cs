using System.Collections.ObjectModel;
using System.Reflection;

namespace MaquinasExpendedoras.Tests;

public class Maquina
{
    private const string EstadoInicialPantalla = "Insertar Monedas";

    public string Pantalla { get; private set; } = EstadoInicialPantalla;
    private readonly List<Moneda> _bandejaDeMonedas = [];
    public ReadOnlyCollection<Moneda> BandejaDeMonedas => _bandejaDeMonedas.AsReadOnly();
    public Producto ProductoDespachado { get; private set; }


    private List<Moneda> _bandejaEntrada = [];
    private int Saldo => _bandejaEntrada.Sum(moneda => moneda.Valor);

    public void IngresarMoneda(Moneda moneda)
    {
        if (EsMonedaInvalida(moneda))
        {
            _bandejaDeMonedas.Add(moneda);
            return;
        }

        _bandejaEntrada.Add(moneda);
        Pantalla = Saldo.ToString();
    }

    public void DevolverMonedas()
    {
        Pantalla = EstadoInicialPantalla;
        _bandejaDeMonedas.AddRange(_bandejaEntrada);
    }

    public void SeleccionarProducto(Producto producto)
    {
        if (EsSaldoSuficiente(producto.Precio))
            Despachar(producto);
        else
            Pantalla = MostrarPrecioDelProducto(producto);
    }

    private static string MostrarPrecioDelProducto(Producto producto) => $"Precio {producto.Precio / 100:N}US";

    private static bool EsMonedaInvalida(Moneda moneda) => moneda is Penny;

    private void Despachar(Producto producto)
    {
        ProductoDespachado = producto;
        Pantalla = "Gracias";

        DarVueltas(producto);

        _bandejaEntrada = [];
    }

    private void DarVueltas(Producto producto)
    {
        var contarDinero = 0;

        foreach (var monedaInsertada in _bandejaEntrada)
        {
            if (contarDinero < producto.Precio)
            {
                contarDinero += monedaInsertada.Valor;
            }
            else
            {
                _bandejaDeMonedas.Add(monedaInsertada);
            }
        }
    }

    private bool EsSaldoSuficiente(decimal productoPrecio) => Saldo >= productoPrecio;
}