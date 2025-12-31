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
    internal class MatchupTeamDetailsTypeConfiguration : IEntityTypeConfiguration<MatchupTeamDetails>
    {
        public void Configure(EntityTypeBuilder<MatchupTeamDetails> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Outcome)
                .WithMany()
                .HasForeignKey(x => x.MatchupOutcomeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.MatchupRosterSpots)
                .WithOne()
                .HasForeignKey(x => x.MatchupTeamDetailsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
