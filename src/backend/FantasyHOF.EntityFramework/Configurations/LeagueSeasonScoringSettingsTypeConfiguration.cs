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
    internal class LeagueSeasonScoringSettingsTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonScoringSettings>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonScoringSettings> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.ScoringItems)
                .WithOne()
                .HasForeignKey(x => x.LeagueSeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
