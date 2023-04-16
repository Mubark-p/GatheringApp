
namespace GatheringApp.Domain.Shareds;

public class Result<T>:Result
{
    private readonly T? _value;

    public Result(T? value,bool isSucces, Error error) : base(isSucces, error)
    {
        _value = value;
    }

    public T Vlaue => IsSuccess
        ? _value!
        : throw new InvalidOperationException("the Type Cannot be Access");


public static implicit operator Result<T>(T? value)=>
        Create<T>(value);
}
