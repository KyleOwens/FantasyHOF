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
    internal class LeagueTypeConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProviderLeagueId).HasMaxLength(100);

            builder.HasOne(x => x.FantasyProvider)
                .WithMany()
                .HasForeignKey(x => x.FantasyProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(x => x.Seasons); //Fantasy League Seasons FK
        }
    }
}
