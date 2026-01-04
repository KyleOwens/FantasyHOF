using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class PlayerValueRecord : PlayerRecord, IValueRecord
    {
        public decimal Value { get; private set; }

        public PlayerValueRecord(FantasyMember member, Player player, int year, int week, decimal value)
            : base(member, player, year, week)
        {
            Value = value;
        }
    }
}
