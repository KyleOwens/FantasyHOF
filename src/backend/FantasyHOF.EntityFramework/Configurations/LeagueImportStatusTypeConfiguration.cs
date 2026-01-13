using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueImportStatusTypeConfiguration : IEntityTypeConfiguration<LeagueImportStatus>
    {
        public void Configure(EntityTypeBuilder<LeagueImportStatus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.SeedFromEnum<LeagueImportStatusId, LeagueImportStatus>(id => new LeagueImportStatus(id, id.GetDisplayName()));
        }
    }
}
