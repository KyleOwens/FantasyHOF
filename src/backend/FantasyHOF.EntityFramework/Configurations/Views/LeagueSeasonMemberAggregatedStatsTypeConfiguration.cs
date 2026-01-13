using FantasyHOF.Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
