using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Repositories;

namespace GatheringApp.Persistence.Repositories;

public sealed class AttendeeRepository : IAttendeeRepository
{
    public void Add(Attendee newAttendee)
    {
        throw new NotImplementedException();
    }

    public Task<Attendee?> GetAttendeeByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
