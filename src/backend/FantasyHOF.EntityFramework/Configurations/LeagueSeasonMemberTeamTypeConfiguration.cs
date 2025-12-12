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
    internal class LeagueSeasonMemberTeamTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonMemberTeam>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonMemberTeam> builder)
        {
            builder.HasKey(x => new { x.LeagueSeasonId, x.MemberId, x.TeamId });

            builder.HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
