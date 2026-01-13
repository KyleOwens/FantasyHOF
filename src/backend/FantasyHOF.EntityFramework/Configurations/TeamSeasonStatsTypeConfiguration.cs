using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class TeamSeasonStatsTypeConfiguration : IEntityTypeConfiguration<TeamSeasonStats>
    {
        public void Configure(EntityTypeBuilder<TeamSeasonStats> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
