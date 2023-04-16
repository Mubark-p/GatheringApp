namespace GatheringApp.Domain.Execptions;

internal class GatheringMaximumNmerOfAttendeeIsNullExecption : DomainExecption
{
    public GatheringMaximumNmerOfAttendeeIsNullExecption(string? message) : base(message)
    {
    }
}
