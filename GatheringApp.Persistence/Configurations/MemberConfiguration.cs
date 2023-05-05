using GatheringApp.Domain.Entities;
using GatheringApp.Domain.ValueObjects;
using GatheringApp.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GatheringApp.Persistence.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable(TablesNames.Members);
        builder.HasKey(t => t.Id);
        builder.Property(x => x.FirstName).
            HasConversion(x => x.Value, t => FirstName.Create(t).Vlaue).
            HasMaxLength(FirstName.MaxLength);
        builder.HasIndex(x => x.Email);

    }
}
