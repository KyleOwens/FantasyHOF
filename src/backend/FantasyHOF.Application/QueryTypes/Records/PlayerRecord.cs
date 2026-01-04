using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class PlayerRecord : WeeklyRecord
    {
        public Player Player { get; private set; } = null!;

        public PlayerRecord(FantasyMember member, RecordType type, Player player, int year, int week)
            : base(member, type, year, week)
        {
            Player = player;
        }
    }
}
