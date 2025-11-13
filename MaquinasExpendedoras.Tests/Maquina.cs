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


    private List<Moneda> _monedero = [];
    private int _inventario = 1;
    private int Saldo => _monedero.Sum(moneda => moneda.Valor);

    public void IngresarMoneda(Moneda moneda)
    {
        if (EsMonedaInvalida(moneda))
        {
            _bandejaDeMonedas.Add(moneda);
            return;
        }

        _monedero.Add(moneda);
        Pantalla = Saldo.ToString();
    }

    public void DevolverMonedas()
    {
        Pantalla = EstadoInicialPantalla;
        _bandejaDeMonedas.AddRange(_monedero);
    }

    public void SeleccionarProducto(Producto producto)
    {
        if (_inventario == 0)
        {
            Pantalla = "Agotado";
            return;
        }

        if (EsSaldoSuficiente(producto.Precio))
        {
            Despachar(producto);
            _inventario--;
        }

        else
            Pantalla = MostrarPrecioDelProducto(producto);
    }

    private static string MostrarPrecioDelProducto(Producto producto) => $"Precio {producto.Precio / 100:N}US";

    private static bool EsMonedaInvalida(Moneda moneda) => moneda is Penny;

    private void Despachar(Producto producto)
    {
        DarVueltas(producto);
        if (Saldo > producto.Precio && !_bandejaDeMonedas.Any())
            Pantalla = "Solo cambio exacto";
        else
        {
            ProductoDespachado = producto;
            Pantalla = "Gracias";

            _monedero = [];
        }
    }

    private void DarVueltas(Producto producto)
    {
        var valorDevolver = Saldo - producto.Precio;

        foreach (var monedaInsertada in _monedero.OrderByDescending(m => m.Valor))
        {
            if (valorDevolver == 0) break;

            if (monedaInsertada.Valor <= valorDevolver)
            {
                _bandejaDeMonedas.Add(monedaInsertada);
                valorDevolver -= monedaInsertada.Valor;
            }
        }
    }

    private bool EsSaldoSuficiente(decimal productoPrecio) => Saldo >= productoPrecio;
}