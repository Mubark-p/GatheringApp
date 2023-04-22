

namespace GatheringApp.Domain.Premitives;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public AggregateRoot(Guid id) : base(id)
    {
    }

    protected void RisedDomainEvent(IDomainEvent domainEveent)
    {

        _domainEvents.Add(domainEveent);
    }


}
