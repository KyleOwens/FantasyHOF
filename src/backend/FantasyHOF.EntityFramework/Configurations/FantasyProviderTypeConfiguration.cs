using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            string folder = "/provider-logos/";

            switch (providerId)
            {
                case FantasyProviderId.ESPN:
                    return folder + "/espn-logo.webp";
                case FantasyProviderId.Sleeper:
                    return folder + "/sleeper-logo.webp";
                case FantasyProviderId.Yahoo:
                    return folder + "/yahoo-logo.webp";
                case FantasyProviderId.NFL:
                    return folder + "/nfl-logo.webp";
                default:
                    throw new ArgumentOutOfRangeException(nameof(providerId), providerId, null);
            }
        }
    }
}
