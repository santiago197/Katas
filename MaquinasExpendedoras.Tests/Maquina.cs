using System.Collections.ObjectModel;

namespace MaquinasExpendedoras.Tests;

public class Maquina
{
    private const string EstadoInicialPantalla = "Insertar Monedas";

    public string Pantalla { get; private set; } = EstadoInicialPantalla;
    private readonly List<Moneda> _bandejaDeMonedas = [];
    public ReadOnlyCollection<Moneda> BandejaDeMonedas => _bandejaDeMonedas.AsReadOnly();
    public object ProductoDespachado { get; set; }

    private int _montoActual;
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
        _montoActual += moneda.Valor;
        Pantalla = _montoActual.ToString();
    }

    private static bool EsMonedaInvalida(Moneda moneda)
    {
        return moneda is Penny;
    }

    public void DevolverMonedas()
    {
        Pantalla = EstadoInicialPantalla;
        _bandejaDeMonedas.AddRange(_bandejaEntrada);
    }

    public void SeleccionarProducto(Producto producto)
    {
        if (EsSaldoIgualAValorProducto(producto))
        {
            ProductoDespachado = producto;
            Pantalla = "Gracias";
            _bandejaEntrada = [];
        }
        else
            Pantalla = $"Precio {producto.Precio / 100:N}US";
    }

    private bool EsSaldoIgualAValorProducto(Producto producto) => Saldo == producto.Precio;
}