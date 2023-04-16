
namespace GatheringApp.Domain.Entities;

public sealed class Attendee
{


    internal Attendee
        ( Guid memeberId,
        Guid gatherinId
        )
    {
        MemberID = memeberId;
        GatheringID = gatherinId;
        CreatedOnUtc = DateTime.UtcNow;


    }
    public Guid  MemberID { get;  private set; }

    public Guid GatheringID { get; private set; }   

    public DateTime CreatedOnUtc { get; private set; }

}
