namespace CuentasPorPagar.EventSourcing;

public class CuentaPorPagar : AggregateRoot
{
    private bool _tieneFacturaRegistrada;

    public void RegistrarFactura(int monto)
    {
        RaiseEvent(new FacturaRegistrada(monto));
    }

    protected override void Apply(object @event)
    {
        switch (@event)
        {
            case FacturaRegistrada e:
                _tieneFacturaRegistrada = true;
                // Lógica para aplicar el evento FacturaRegistrada
                break;
            case CuentaAprobada e:
                // Lógica para aplicar el evento CuentaAprobada
                break;
        }
    }

    public void Aprobar()
    {
        if (!_tieneFacturaRegistrada)
            throw new InvalidOperationException("No se puede aprobar una cuenta sin factura registrada.");
        RaiseEvent(new CuentaAprobada());
    }
}

public record FacturaRegistrada(int Monto);

public record CuentaAprobada();