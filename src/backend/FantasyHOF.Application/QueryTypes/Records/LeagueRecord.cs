using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class LeagueRecord : Record
    {
        public LeagueRecord(FantasyMember member, RecordType type) 
            : base(member, type) { }
    }
}
