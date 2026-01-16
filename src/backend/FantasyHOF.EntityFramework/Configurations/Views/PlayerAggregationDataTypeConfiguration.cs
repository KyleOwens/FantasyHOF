using FantasyHOF.Domain.Entities.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.HasOne(x => x.Position)
                .WithMany()
                .HasForeignKey(x => x.PositionId);
        }
    }
}
