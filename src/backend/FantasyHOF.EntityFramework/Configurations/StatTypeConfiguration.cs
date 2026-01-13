using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class StatTypeConfiguration : IEntityTypeConfiguration<Stat>
    {
        public void Configure(EntityTypeBuilder<Stat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.SeedFromEnum<StatId, Stat>(id => new Stat(id, id.GetDisplayName()));

            builder.Property(x => x.Id)
                .ValueGeneratedNever();
        }
    }
}
