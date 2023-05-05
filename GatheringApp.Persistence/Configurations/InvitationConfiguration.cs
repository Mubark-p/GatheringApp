using GatheringApp.Domain.Entities;
using GatheringApp.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatheringApp.Persistence.Configurations
{
    public sealed class InvitationConfiguration : IEntityTypeConfiguration<Invitation>

    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable(TablesNames.Invitations);

            builder.HasKey(t => t.Id);

            builder
                .HasOne<Member>()
                .WithMany()
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
