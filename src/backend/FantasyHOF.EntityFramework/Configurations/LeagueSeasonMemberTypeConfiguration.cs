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
    internal class LeagueSeasonMemberTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonMember>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonMember> builder)
        {
            builder.HasKey(x => new { x.LeagueSeasonId, x.MemberId });

            builder.Ignore(x => x.Id);

            builder.HasOne(x => x.Member)
                .WithMany()
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Teams)
                .WithOne()
                .HasForeignKey(x => new { x.LeagueSeasonId, x.MemberId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
