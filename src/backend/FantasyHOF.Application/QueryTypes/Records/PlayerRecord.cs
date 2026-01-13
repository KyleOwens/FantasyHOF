using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public class PlayerRecord : WeeklyRecord
    {
        public Player Player { get; private set; } = null!;

        public PlayerRecord(FantasyMember member, RecordTypeId type, Player player, int year, int week, RecordMetric metric)
            : base(member, type, year, week, metric)
        {
            Player = player;
        }
    }
}
