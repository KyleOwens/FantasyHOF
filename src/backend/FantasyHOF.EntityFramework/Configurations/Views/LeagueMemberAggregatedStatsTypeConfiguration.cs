using FantasyHOF.Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
