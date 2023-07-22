namespace LibrarySystem.Domain.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    protected AggregateRoot(TId id)
        : base(id) { }

    protected AggregateRoot() { }

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public virtual IReadOnlyList<DomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();

    public virtual void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
