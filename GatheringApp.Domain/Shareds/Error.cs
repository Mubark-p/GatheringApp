using System.Data;

namespace GatheringApp.Domain.Shareds;

public class Error : IEquatable<Error>

{ 
    public   static readonly Error None=new (string.Empty, string.Empty);
    public static readonly Error NullVAlue=
        new ("Error.NullValue", "The Speecific Result is Null Value");
       


  

        public string Code { get; init; }
    public string Message { get; init; }


    public static implicit operator string(Error error) => error.Code;
    public static bool operator ==(Error first, Error second)
    { 
      if(first is null || second is null) return false;
      return first.Equals(second);
    
    
    
    }

    public static bool operator !=(Error first, Error second)
    {
       return !(first==second);

    }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public bool Equals(Error? other)
    {
       if(other == null) return false;
       return this.Code==other.Code && this.Message==other.Message;
    }

    public override bool Equals(object? obj)
    {
        
        return obj is Error error && Equals(error);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Code, this.Message);
    }

    public override string? ToString()
    {
        return Code;
    }
}
