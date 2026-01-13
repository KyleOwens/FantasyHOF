using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class AccumulatedStatTypeConfiguration : IEntityTypeConfiguration<AccumulatedStat>
    {
        public void Configure(EntityTypeBuilder<AccumulatedStat> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Stat)
                .WithMany()
                .HasForeignKey(x => x.StatId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
