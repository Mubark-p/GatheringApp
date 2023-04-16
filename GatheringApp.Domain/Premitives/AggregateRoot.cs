

namespace GatheringApp.Domain.Premitives;

public abstract class AggregateRoot : Entity
{
    public AggregateRoot(Guid id) : base(id)
    {
    }
}
