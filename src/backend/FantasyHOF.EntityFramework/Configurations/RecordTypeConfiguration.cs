using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.EntityFramework.Configurations
{
    public class RecordTypeConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasDiscriminator(x => x.RecordType)
                .HasValue<LeagueValueRecord>(RecordType.LeagueValue)
                .HasValue<SeasonalValueRecord>(RecordType.SeasonalValue)
                .HasValue<WeeklyValueRecord>(RecordType.WeeklyValue)
                .HasValue<PlayerValueRecord>(RecordType.PlayerValue);


            builder.HasOne(x => x.Member)
                .WithMany()
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
