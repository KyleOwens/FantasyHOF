using FantasyHOF.Domain.Types.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.EntityFramework.Configurations.Views
{
    internal class LeagueSeasonMemberAggregatedStatsTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonMemberAggregatedStats>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonMemberAggregatedStats> builder)
        {
            builder.HasNoKey().ToView("vw_league_season_member_aggregated_stats");

            builder.HasOne(x => x.MemberDetails)
                .WithMany()
                .HasForeignKey(x => new { x.LeagueId, x.MemberId });
        }
    }
}
