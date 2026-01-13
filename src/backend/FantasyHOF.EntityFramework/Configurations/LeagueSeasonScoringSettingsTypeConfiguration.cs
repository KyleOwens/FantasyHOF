using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueSeasonScoringSettingsTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonScoringSettings>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonScoringSettings> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ScoringItems)
                .WithOne()
                .HasForeignKey(x => x.LeagueSeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
