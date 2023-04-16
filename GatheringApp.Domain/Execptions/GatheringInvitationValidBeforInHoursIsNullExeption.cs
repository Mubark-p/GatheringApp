 

namespace GatheringApp.Domain.Execptions;

internal class GatheringInvitationValidBeforInHoursIsNullExeption : DomainExecption
{
    public GatheringInvitationValidBeforInHoursIsNullExeption(string? message) : base(message)
    {
    }
}
