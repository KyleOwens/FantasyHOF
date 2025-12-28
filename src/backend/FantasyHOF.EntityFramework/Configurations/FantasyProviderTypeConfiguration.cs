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
    internal class FantasyProviderTypeConfiguration : IEntityTypeConfiguration<FantasyProvider>
    {
        public void Configure(EntityTypeBuilder<FantasyProvider> builder)
        {
            builder.HasKey(x => x.Id);

            builder.SeedFromEnum<FantasyProviderId, FantasyProvider>(id => new FantasyProvider(id, id.ToString(), GetProviderLogoURL(id)));

            builder.Property(x => x.Name).HasMaxLength(256);
        }

        public string GetProviderLogoURL(FantasyProviderId providerId)
        {
            switch(providerId)
            {
                case FantasyProviderId.ESPN:
                    return "/espn-logo.png";
                default:
                    throw new ArgumentOutOfRangeException(nameof(providerId), providerId, null);
            }
        }
    }
}
