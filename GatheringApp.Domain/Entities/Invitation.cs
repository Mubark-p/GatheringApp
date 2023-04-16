

using GatheringApp.Domain.Enums;
using GatheringApp.Domain.Premitives;

namespace GatheringApp.Domain.Entities;

public sealed class Invitation:Entity
{
    internal Invitation(Guid id,Member member ,Gathering gatering) : base(id)
    {
        MemberId= member.Id;
        GatheringId= gatering.Id;
        Status = InvitationStatus.Pending;
        CreatedOnUtc = DateTime.UtcNow;
    }

    
    public Guid MemberId { get; private set; }
    public Guid GatheringId { get;private  set; }
    public InvitationStatus Status { get; private set; }


    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? LastUpdatedOnUtc { get;private set; }


    public void Expire()
    {
        this.Status = InvitationStatus.Expired;
        this.LastUpdatedOnUtc = DateTime.UtcNow;
    }

    public Attendee Accept()
    {
        this.Status = InvitationStatus.Accepted;
        this.LastUpdatedOnUtc = DateTime.UtcNow;

        var attendee = new Attendee
        (
              this.MemberId,
             this.GatheringId
             


        );


        return attendee;
    }
}
