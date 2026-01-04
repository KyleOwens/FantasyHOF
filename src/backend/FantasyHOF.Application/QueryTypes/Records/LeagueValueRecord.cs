using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class LeagueValueRecord : LeagueRecord, IValueRecord
    {
        public decimal Value { get; private set; }

        public LeagueValueRecord(FantasyMember member, RecordType type, decimal value)
            : base(member, type)
        {
            Value = value;
        }
    }
}
