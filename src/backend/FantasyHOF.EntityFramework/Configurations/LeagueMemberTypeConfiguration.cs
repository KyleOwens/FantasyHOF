using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueMemberTypeConfiguration : IEntityTypeConfiguration<LeagueMember>
    {
        public void Configure(EntityTypeBuilder<LeagueMember> builder)
        {
            builder.HasKey(x => new { x.LeagueId, x.MemberId });

            builder.HasOne(x => x.League)
                .WithMany(x => x.LeagueMembers)
                .HasForeignKey(x => x.LeagueId);

            builder.HasOne(x => x.Member)
                .WithMany()
                .HasForeignKey(x => x.MemberId);

            builder.Ignore(x => x.Id);
        }
    }
}
