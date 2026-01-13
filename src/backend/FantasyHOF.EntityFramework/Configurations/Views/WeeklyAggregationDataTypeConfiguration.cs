using FantasyHOF.Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
