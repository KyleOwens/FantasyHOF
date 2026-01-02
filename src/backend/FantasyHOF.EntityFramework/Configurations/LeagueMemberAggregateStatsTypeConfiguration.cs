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
    internal class LeagueMemberAggregateStatsTypeConfiguration : IEntityTypeConfiguration<LeagueMemberAggregateStats>
    {
        public void Configure(EntityTypeBuilder<LeagueMemberAggregateStats> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.LeagueId, x.MemberId });

            builder.HasOne(x => x.League)
                .WithMany()
                .HasForeignKey(x => x.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Member)
                .WithMany()
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.TotalPointsFor).HasPrecision(12, 2);
            builder.Property(x => x.TotalPointsAgainst).HasPrecision(12, 2);
        }
    }
}
