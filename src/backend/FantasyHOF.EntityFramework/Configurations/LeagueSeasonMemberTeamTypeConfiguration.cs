using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueSeasonMemberTeamTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonMemberTeam>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonMemberTeam> builder)
        {
            builder.HasKey(x => new { x.MemberId, x.TeamId });

            builder.Ignore(x => x.Id);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.MemberTeams)
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
