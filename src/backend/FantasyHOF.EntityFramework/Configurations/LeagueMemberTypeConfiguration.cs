using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.EntityFramework.Configurations
{
    internal class LeagueMemberTypeConfiguration : IEntityTypeConfiguration<LeagueMember>
    {
        public void Configure(EntityTypeBuilder<LeagueMember> builder)
        {
            builder.HasKey(x => new { x.LeagueId, x.MemberId });

            builder.Ignore(x => x.Id);
        }
    }
}
