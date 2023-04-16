 

namespace GatheringApp.Domain.Execptions;

public abstract class DomainExecption : Exception
{
    protected DomainExecption(string? message) : base(message)
    {
    }
}
