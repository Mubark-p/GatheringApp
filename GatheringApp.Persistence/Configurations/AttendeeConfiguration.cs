using GatheringApp.Domain.Entities;
using GatheringApp.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatheringApp.Persistence.Configurations;

internal class AttendeeConfiguration : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
       builder.ToTable(TablesNames.Attendees);
        builder.HasKey(x => new { x.MemberID, x.GatheringID });

        builder.HasOne<Member>()
               .WithMany()
               .HasForeignKey(x=>x.MemberID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
