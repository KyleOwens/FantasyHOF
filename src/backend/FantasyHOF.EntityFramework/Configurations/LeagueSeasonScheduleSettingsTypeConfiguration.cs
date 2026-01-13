using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueSeasonScheduleSettingsTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonScheduleSettings>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonScheduleSettings> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
