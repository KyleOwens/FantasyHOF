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
    internal class LeagueSeasonScheduleSettingsTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonScheduleSettings>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonScheduleSettings> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
