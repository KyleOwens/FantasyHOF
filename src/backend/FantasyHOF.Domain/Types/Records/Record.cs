using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class Record
    {
        public int Id { get; private set; }
        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }

        public RecordType RecordType { get; init; }

        public FantasyMember Member { get; private set; } = null!;

        public void SetMember(FantasyMember member)
        {
            Member = member;
        }
    }
}
