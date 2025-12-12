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
    internal class LeagueSeasonScoringItemTypeConfiguration : IEntityTypeConfiguration<LeagueSeasonScoringItem>
    {
        public void Configure(EntityTypeBuilder<LeagueSeasonScoringItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Stat)
                .WithMany()
                .HasForeignKey(x => x.StatId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
