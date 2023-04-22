

using GatheringApp.Domain.DomainEvents;
using GatheringApp.Domain.Enums;
using GatheringApp.Domain.Execptions;
using GatheringApp.Domain.Premitives;
using GatheringApp.Domain.Repositories;
using GatheringApp.Domain.Shareds;
using MediatR;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static GatheringApp.Domain.Errors.DomainErrors;
using System.Threading;

namespace GatheringApp.Domain.Entities;

public sealed  class Gathering: AggregateRoot
{

    private readonly List<Invitation> _invitations = new();
    private readonly List<Attendee> _attends = new();
    private Gathering(
        Guid Id,
        Member creator,
        DateTime sechdulaAt,
        GatheringType type,
        string? location
        
        ):base(Id)
    { 
       
        this.Creator= creator;
        this.SchedualAt= sechdulaAt;
        this.Type= type;
        this.Location= location;

    
    
    
    }

    
    public Member Creator { get; set; }
    public GatheringType Type { get; set; }
    public DateTime SchedualAt { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }


    public IReadOnlyCollection<Attendee> AttendeeList => _attends;
    public IReadOnlyCollection<Invitation> InvitationList => _invitations;
public int? MaximumNumberOfAttendee { get;  private set; }

    public DateTime? ExpireDateOfInvitaionUtc { get;  private set; }

    public int NumberOfAttendee { get; private set; }




    public static Gathering Create
        (
         Guid Id,
        Member creator,
        DateTime sechdulaAt,
        GatheringType type,
        string? location,
        int? maxmumNumerOfAttendee,
        int? invitationValidBeforeInHours
        )
    {
        var gathering = new Gathering
            (
            Id,
            creator,
            sechdulaAt,
            type,
            location
            );

        gathering.CalcualteGatheringTypeDetials(maxmumNumerOfAttendee, invitationValidBeforeInHours);
        return gathering;

    }
    private void CalcualteGatheringTypeDetials(int? MaximumNmerOfAttendee,int? InvitationValidBeforInHours)
    {
        switch (this.Type)
        {
            case GatheringType.WithFixedNumberOfAttendees:
                if (MaximumNmerOfAttendee is null)
                {
                    throw new GatheringMaximumNmerOfAttendeeIsNullExecption($"{nameof(MaximumNmerOfAttendee)}  can not be null");

                };
                this.MaximumNumberOfAttendee = MaximumNmerOfAttendee;

                break;

            case GatheringType.WithExpirationForInvitations:
                if (InvitationValidBeforInHours is null)
                {
                    throw new GatheringInvitationValidBeforInHoursIsNullExeption($"{nameof(InvitationValidBeforInHours)} can not be null ");

                }
                this.ExpireDateOfInvitaionUtc =
                    this.SchedualAt.AddHours(-InvitationValidBeforInHours.Value);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(GatheringType));


        }

       

        
    }

    public Result<Invitation> SendInvitaion(Member member )
    {
        if (member.Id == this.Creator.Id)
        {
            Result.Failure(new Error(
                "GAthering.SendInvitaion",
                "Cannot Send Invitation to the Memebr Whoe Create The Gathering "
                ));
            
        }

        if (this.SchedualAt < DateTime.UtcNow)
        {
            throw new Exception
               (" Cannot Sending Invitation cause gatherin is  in past");

        }
        var invitation = new Invitation
       (
              Guid.NewGuid(),
           member,
           this
           
        );
        this._invitations.Add(invitation);
        return invitation;
    }


    public Result<Attendee> AcceptInvitation(Invitation invitation)
    {
        var isExpire = (this.Type == GatheringType.WithFixedNumberOfAttendees &&
                      this.NumberOfAttendee > this.MaximumNumberOfAttendee) ||
                      (this.Type == GatheringType.WithExpirationForInvitations &&
                        this.ExpireDateOfInvitaionUtc < DateTime.UtcNow);



        if (isExpire)
        {
            invitation.Expire();
           
            return Result.Failure<Attendee>(new(
            "Gathering.Expired",
            "Can't accept invitation for expired gathering."));


        }

        Attendee attendee = invitation.Accept();

        RisedDomainEvent(new InvitationAcceptedDomainEvent(invitation.Id, Id));
        this._attends.Add(attendee);
        ++this.NumberOfAttendee;

        return attendee;

    }
}
