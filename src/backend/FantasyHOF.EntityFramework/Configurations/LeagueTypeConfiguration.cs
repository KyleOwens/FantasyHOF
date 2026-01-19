using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueTypeConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProviderLeagueId).HasMaxLength(100);

            builder.HasOne(x => x.FantasyProvider)
                .WithMany()
                .HasForeignKey(x => x.FantasyProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Sport)
                .WithMany()
                .HasForeignKey(x => x.SportId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Seasons)
                .WithOne()
                .HasForeignKey(x => x.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.LeagueMembers)
                .WithOne(x => x.League)
                .HasForeignKey(x => x.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
