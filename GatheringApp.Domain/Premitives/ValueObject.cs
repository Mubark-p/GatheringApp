 
namespace GatheringApp.Domain.Premitives;

public abstract class ValueObject : IEquatable<ValueObject>

{
    public abstract IEnumerable<object> GetAtomicValue();
    public bool Equals(ValueObject? other)
    {
        return  other is not null && this.IsEqualValue(other);
    }




    private bool IsEqualValue(ValueObject other)
    {

        return this.GetAtomicValue().SequenceEqual(other.GetAtomicValue());

    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject && Equals(valueObject);
    }

    public override int GetHashCode()
    {
        return this.GetAtomicValue().Aggregate(default(int), HashCode.Combine);
    }
}
