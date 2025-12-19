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
    internal class TeamMatchupTypeConfiguration : IEntityTypeConfiguration<TeamMatchup>
    {
        public void Configure(EntityTypeBuilder<TeamMatchup> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Opponent)
                .WithMany()
                .HasForeignKey(x => x.OpponentTeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.MatchupOutcome)
                .WithMany()
                .HasForeignKey(x => x.MatchupOutcomeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.MatchupType)
                .WithMany()
                .HasForeignKey(x => x.MatchupTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.MatchupRosterSpots)
                .WithOne()
                .HasForeignKey(x => x.MatchupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
