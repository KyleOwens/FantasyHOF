using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
