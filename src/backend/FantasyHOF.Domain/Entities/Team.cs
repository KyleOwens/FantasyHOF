using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities
{
    public class Team
    {
        public int Id { get; private set; }
        public int LeagueSeasonId { get; private set; }

        public required int ProviderTeamId { get; init; }
        public required int SeasonRank { get; init; }
        public required string Abbreviation { get; init; }
        public required string? LogoURL { get; init; }
        public required string Name { get; init; }

        public LeagueSeason Season { get; private set; } = null!;
        public List<LeagueSeasonMemberTeam> MemberTeams { get; private set; } = null!;
        public TeamSeasonStats SeasonStats { get; private set; } = null!;
        public List<TeamMatchup> Matchups { get; private set; } = null!;

        public void SetLeagueSeason(LeagueSeason season)
        {
            Season = season;
        }

        public void SetSeasonStats(TeamSeasonStats seasonStats)
        {
            SeasonStats = seasonStats;
        }

        public void SetMatchups(List<TeamMatchup> matchups)
        {
            Matchups = matchups;
        }
    }
}
