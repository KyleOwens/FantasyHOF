using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueSeasonSettingsTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonSettings>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonSettings> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.LeagueSeasonId);

            builder.Property(x => x.LeagueName).HasMaxLength(500);

            builder.HasOne(x => x.ScheduleSettings)
                .WithOne()
                .HasForeignKey<LeagueSeasonScheduleSettings>(x => x.LeagueSeasonId)
                .HasPrincipalKey<LeagueSeasonSettings>(x => x.LeagueSeasonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ScoringSettings)
                .WithOne()
                .HasForeignKey<LeagueSeasonScoringSettings>(x => x.LeagueSeasonId)
                .HasPrincipalKey<LeagueSeasonSettings>(x => x.LeagueSeasonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
