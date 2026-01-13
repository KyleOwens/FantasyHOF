using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueSeasonTypeConfiguration : IEntityTypeConfiguration<LeagueSeason>
    {
        public void Configure(EntityTypeBuilder<LeagueSeason> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Settings)
                .WithOne()
                .HasForeignKey<LeagueSeasonSettings>(x => x.LeagueSeasonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Members)
                .WithOne()
                .HasForeignKey(x => x.LeagueSeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
