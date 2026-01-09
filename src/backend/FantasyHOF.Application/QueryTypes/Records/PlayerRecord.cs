using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class PlayerRecord : WeeklyRecord
    {
        public Player Player { get; private set; } = null!;

        public PlayerRecord(FantasyMember member, RecordTypeId type, Player player, int year, int week, decimal value)
            : base(member, type, year, week, value)
        {
            Player = player;
        }
    }
}
