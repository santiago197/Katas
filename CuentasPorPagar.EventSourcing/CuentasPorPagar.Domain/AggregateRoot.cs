namespace CuentasPorPagar.EventSourcing;

public abstract class AggregateRoot
{
    public readonly List<object> _uncommittedEvents = new();

    protected void RaiseEvent(object @event)
    {
        Apply(@event);
        _uncommittedEvents.Add(@event);
    }
    public IReadOnlyList<object> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

    protected abstract void Apply(object @event);
}