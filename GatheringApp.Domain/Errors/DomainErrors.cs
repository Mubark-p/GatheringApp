

using GatheringApp.Domain.Shareds;

namespace GatheringApp.Domain.Errors;

public static class DomainErrors
{

    public static class Gathering
    { 
      //public static Error error
    
    }

    public static class FirstName
    {
        public static readonly Error Empty = new("FirstName.ISEmpty"

            ,
            "Cannot Add First Name when it is  Empty"

            );

        public static readonly Error MaxValue = new("FirstName.MaXValue"

           ,
           "Cannot Add First Name when the entering string  Length is more than the max of fist Name"

           );



    }
}
