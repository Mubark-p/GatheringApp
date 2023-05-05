using GatheringApp.Domain.Entities;
using GatheringApp.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatheringApp.Persistence.Configurations;

public sealed class GatheringConfiguration : IEntityTypeConfiguration<Gathering>
{
    public void Configure(EntityTypeBuilder<Gathering> builder)
    {
        builder.ToTable(TablesNames.Gatherings);

        builder.HasKey(t => t.Id);

        builder
            .HasOne(x=>x.Creator)
            .WithMany();

        builder
            .HasMany(x => x.AttendeeList)
            .WithOne()
            .HasForeignKey(x => x.GatheringID);

        builder
            .HasMany(x=>x.InvitationList)
            .WithOne()
            .HasForeignKey(x=>x.GatheringId);


    }
}
