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
    internal class LeagueMemberAggregatedStatsTypeConfiguration : IEntityTypeConfiguration<LeagueMemberAggregatedStats>
    {
        public void Configure(EntityTypeBuilder<LeagueMemberAggregatedStats> builder)
        {
            builder.HasNoKey().ToView("vw_league_member_aggregated_stats");

            builder.HasOne(x => x.MemberDetails)
                .WithMany()
                .HasForeignKey(x => new { x.LeagueId, x.MemberId });
        }
    }
}
