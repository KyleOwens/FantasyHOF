using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueSeasonScoringItemTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonScoringItem>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonScoringItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Stat)
                .WithMany()
                .HasForeignKey(x => x.StatId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
