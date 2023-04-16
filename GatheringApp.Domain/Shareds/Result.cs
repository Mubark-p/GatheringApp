using System.Runtime.InteropServices;

namespace GatheringApp.Domain.Shareds;

public  class Result
{
    

    public Result(bool isSucces, Error error)
    {
         
        if(!isSucces && error==Error.None)
        {

            throw new InvalidOperationException();

        }
        if(isSucces && error!=Error.None)
        {
            throw new InvalidOperationException();
        }

        this.IsSuccess= isSucces;
        this.Error= error;  

    }

    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;

    public Error Error { get; }


    public static Result Success() => new Result(true, Error.None);

    public static Result<T> Success<T>(T value) => new(value, true, Error.None);
    public static Result Failure(Error error)=>new Result(false, error);

    public static Result<T> Failure<T>(Error error) =>
        new(default, false, error);

    public static Result<T> Create<T>(T? value) => value is not null ?
        Success(value) : Failure<T>(Error.NullVAlue);
        
    
}
