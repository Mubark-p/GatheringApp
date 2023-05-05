using GatheringApp.Domain.Entities;
using GatheringApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GatheringApp.Persistence.Repositories;

public sealed class MemberRepository : IMemberRepository
{

    private readonly ApplicationDbContext _dbContext;

    public MemberRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public   void Add(Member member)
    {
           _dbContext.Set<Member>().Add(member);
    }

    public async Task<Member?> GetByIDAsync(Guid id, CancellationToken cancellationToken)
    {
       return  await  _dbContext
                          .Set<Member>()
                          .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
