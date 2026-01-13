using FantasyHOF.Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations.Views
{
    internal class WeeklyAggregationDataTypeConfiguration : IEntityTypeConfiguration<WeeklyAggregationData>
    {
        public void Configure(EntityTypeBuilder<WeeklyAggregationData> builder)
        {
            builder.HasNoKey().ToView("vw_weekly_aggregation_data");

            builder.HasOne(x => x.MemberDetails)
                .WithMany()
                .HasForeignKey(x => new { x.LeagueId, x.MemberId });
        }
    }
}
