using GatheringApp.Domain.Errors;
using GatheringApp.Domain.Premitives;
using GatheringApp.Domain.Shareds;

namespace GatheringApp.Domain.ValueObjects;

public sealed class FirstName : ValueObject
{

    private const int MaxLength = 40;
    public string Value { get; init; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<FirstName>(DomainErrors.FirstName.Empty);
        }    

        if(firstName.Length > MaxLength)
        {
            return Result.Failure<FirstName>(DomainErrors.FirstName.MaxValue);
        }


        return Result.Success<FirstName>(new(firstName));
    
    
    }
    public override IEnumerable<object> GetAtomicValue()
    {
        yield return Value;
    }
}
