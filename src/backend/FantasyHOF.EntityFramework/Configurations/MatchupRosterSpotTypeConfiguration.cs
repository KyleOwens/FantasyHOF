using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class MatchupRosterSpotTypeConfiguration : IEntityTypeConfiguration<MatchupRosterSpot>
    {
        public void Configure(EntityTypeBuilder<MatchupRosterSpot> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Player)
                .WithMany()
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AccumulatedStats)
                .WithOne()
                .HasForeignKey(x => x.MatchupRosterSpotId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
