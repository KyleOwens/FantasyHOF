using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.EntityFramework.Configurations
{
    public class MatchupTypeTypeConfiguration : IEntityTypeConfiguration<MatchupType>
    {
        public void Configure(EntityTypeBuilder<MatchupType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.SeedFromEnum<MatchupTypeId, MatchupType>(x => new MatchupType(x, x.GetDisplayName()));
        }
    }
}
