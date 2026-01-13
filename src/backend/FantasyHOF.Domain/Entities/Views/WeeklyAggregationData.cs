using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities.Views
{
    public class WeeklyAggregationData
    {
        public int MemberId { get; private set; }
        public int TeamId { get; private set; }
        public int LeagueId { get; private set; }
        public int Year { get; private set; }
        public int Week { get; private set; }
        public MatchupTypeId MatchupTypeId { get; private set; }
        public decimal Score { get; private set; }
        public decimal OpponentScore { get; private set; }
        public decimal ScoreMargin { get; private set; }
        public MatchupOutcomeId MatchupOutcomeId { get; private set; }

        public LeagueMember MemberDetails { get; private set; } = null!;
    }
}
