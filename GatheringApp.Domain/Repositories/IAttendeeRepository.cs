

using GatheringApp.Domain.Entities;

namespace GatheringApp.Domain.Repositories;

public interface IAttendeeRepository
{
    Task<Attendee?> GetAttendeeByIdAsync(Guid id, CancellationToken cancellationToken);
    void Add(Attendee newAttendee); 
}
