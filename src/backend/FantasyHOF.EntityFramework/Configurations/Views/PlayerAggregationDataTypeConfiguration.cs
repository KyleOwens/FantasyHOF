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
    internal class PlayerAggregationDataTypeConfiguration : IEntityTypeConfiguration<PlayerAggregationData>
    {
        public void Configure(EntityTypeBuilder<PlayerAggregationData> builder)
        {
            builder.HasNoKey().ToView("vw_player_aggregation_data");

            builder.HasOne(x => x.MemberDetails)
                .WithMany()
                .HasForeignKey(x => new { x.LeagueId, x.MemberId });

            builder.HasOne(x => x.Player)
                .WithMany()
                .HasForeignKey(x => x.PlayerId);
        }
    }
}
