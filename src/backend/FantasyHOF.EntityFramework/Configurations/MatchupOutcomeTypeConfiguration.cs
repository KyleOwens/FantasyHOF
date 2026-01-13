using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class MatchupOutcomeTypeConfiguration : IEntityTypeConfiguration<MatchupOutcome>
    {
        public void Configure(EntityTypeBuilder<MatchupOutcome> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.SeedFromEnum<MatchupOutcomeId, MatchupOutcome>(x => new MatchupOutcome(x, x.GetDisplayName()));
        }
    }
}
