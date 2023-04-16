
using GatheringApp.Domain.Premitives;
using GatheringApp.Domain.ValueObjects;

namespace GatheringApp.Domain.Entities;

public sealed class Member : Entity
{
   
    

    public Member(Guid id,FirstName firstName, string? lastName, string? email):base(id) 
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get;  private set; }
    public string? LastName { get; private set; }
    public string? Email  { get;private  set; }
}
