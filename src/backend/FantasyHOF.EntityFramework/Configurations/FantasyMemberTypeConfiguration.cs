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
    internal class FantasyMemberTypeConfiguration : IEntityTypeConfiguration<FantasyMember>
    {
        public void Configure(EntityTypeBuilder<FantasyMember> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProviderMemberId).HasMaxLength(200);
            builder.Property(x => x.DisplayName).HasMaxLength(200);
            builder.Property(x => x.FirstName).HasMaxLength(200);
            builder.Property(x => x.LastName).HasMaxLength(200);

            builder.HasOne(x => x.FantasyProvider)
                .WithMany()
                .HasForeignKey(x => x.FantasyProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
