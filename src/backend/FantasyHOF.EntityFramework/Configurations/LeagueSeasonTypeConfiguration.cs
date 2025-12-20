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
    internal class LeagueSeasonTypeConfiguration : IEntityTypeConfiguration<LeagueSeason>
    {
        public void Configure(EntityTypeBuilder<LeagueSeason> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Settings)
                .WithOne()
                .HasForeignKey<LeagueSeasonSettings>(x => x.LeagueSeasonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Members)
                .WithOne()
                .HasForeignKey(x => x.LeagueSeasonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
