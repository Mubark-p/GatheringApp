using GatheringApp.Persistencel;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace GatheringApp.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReferrences.Assembly);
    }
}
