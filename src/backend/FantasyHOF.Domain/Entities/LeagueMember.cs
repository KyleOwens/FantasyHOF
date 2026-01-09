using FantasyHOF.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueMember
    {
        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }

        public required int Firstyear { get; init; }
        public required int LearYear { get; init; }
        public required int Tenure { get; init; }

        public League League { get; init; } = null!;
        public FantasyMember Member { get; init; } = null!;
    }
}
