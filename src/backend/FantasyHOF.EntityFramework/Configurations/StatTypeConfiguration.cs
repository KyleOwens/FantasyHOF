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
    internal class StatTypeConfiguration : IEntityTypeConfiguration<Stat>
    {
        public void Configure(EntityTypeBuilder<Stat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.SeedFromEnum<StatId, Stat>(id => new Stat(id, id.ToString()));

            builder.Property(x => x.Id)
                .ValueGeneratedNever();
        }
    }
}
