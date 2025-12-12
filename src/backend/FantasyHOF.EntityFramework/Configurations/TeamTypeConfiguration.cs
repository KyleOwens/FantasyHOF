using FantasyHOF.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class TeamTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Abbreviation).HasMaxLength(10);
            builder.Property(x => x.Name).HasMaxLength(200);

            builder.HasOne(x => x.SeasonStats)
                .WithOne()
                .HasForeignKey<TeamSeasonStats>(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Matchups)
                .WithOne()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
