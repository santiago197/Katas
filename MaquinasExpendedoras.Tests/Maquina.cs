using System.Collections.ObjectModel;
using System.Reflection;

namespace MaquinasExpendedoras.Tests;

public class Maquina
{
    public string Pantalla { get; private set; } = EstadoInicialPantalla;

    public ReadOnlyCollection<Moneda> BandejaDeMonedas => _bandejaDeMonedas.AsReadOnly();
    public Producto ProductoDespachado { get; private set; }

    private List<Moneda> _monedero = [];
    private List<Moneda> _bandejaDeMonedas = [];
    private const string EstadoInicialPantalla = "Insertar Monedas";
    private List<Moneda> _inventarioMonedas = [];

    private int MontoIngresado => _monedero.Sum(moneda => moneda.Valor);

    public void IngresarMoneda(Moneda moneda)
    {
        if (EsMonedaInvalida(moneda))
            DevuelveABandeja(moneda);
        else
            AgregaAMonederoYMuestraEnPantalla(moneda);
    }

    public void DevolverMonedas()
    {
        ActualizarPantalla(EstadoInicialPantalla);
        _bandejaDeMonedas.AddRange(_monedero);
    }


    public void SeleccionarProducto(Producto producto)
    {
        var inventarioProducto = _inventarioProductos[producto.GetType().Name];

        if (inventarioProducto == 0 && MontoIngresado > 0)
            ActualizarPantalla("Agotado");
        else if (EsSaldoSuficiente(producto.Precio))
        {
            _inventarioMonedas.AddRange(_monedero);
            Despachar(producto);
            _inventarioProductos[producto.GetType().Name]--;
        }
        else
            Pantalla = MostrarPrecioDelProducto(producto);
    }

    private void ActualizarPantalla(string mensaje) => Pantalla = mensaje;

    private void DevuelveABandeja(Moneda moneda) => _bandejaDeMonedas.Add(moneda);

    private void AgregaAMonederoYMuestraEnPantalla(Moneda moneda)
    {
        _monedero.Add(moneda);
        ActualizarPantalla(MontoIngresado.ToString());
    }

    private static string MostrarPrecioDelProducto(Producto producto) => $"Precio {producto.Precio / 100:N}US";

    private static bool EsMonedaInvalida(Moneda moneda) => moneda is Moneda.Penny;

    private void Despachar(Producto producto)
    {
        CalcularCambio(producto);
        if (MontoIngresado > producto.Precio && !_bandejaDeMonedas.Any())
            ActualizarPantalla("Solo cambio exacto");
        else
        {
            ProductoDespachado = producto;
            ActualizarPantalla("Gracias");
            _monedero = [];
        }
    }

    private void CalcularCambio(Producto producto)
    {
        _bandejaDeMonedas = [];
        var valorDevolver = MontoIngresado - producto.Precio;

        var x = _inventarioMonedas.Concat(_monedero);
        var monedasDeMayorAMenorValor = x.OrderByDescending(m => m.Valor);
        foreach (var monedaIngresada in monedasDeMayorAMenorValor)
        {
            if (valorDevolver == 0) break;

            if (monedaIngresada.Valor > valorDevolver) continue;
            DevuelveABandeja(monedaIngresada);
            var index = _inventarioMonedas.FindIndex(i => i == monedaIngresada);
            if(index != -1)
                _inventarioMonedas.RemoveAt(index);
            valorDevolver -= monedaIngresada.Valor;
        }
    }

    private bool EsSaldoSuficiente(decimal productoPrecio) => MontoIngresado >= productoPrecio;

    private readonly Dictionary<string, int> _inventarioProductos = new()
    {
        { nameof(CocaCola), 1 },
        { nameof(Chips), 1 },
        { nameof(Caramelo), 1 }
    };
}