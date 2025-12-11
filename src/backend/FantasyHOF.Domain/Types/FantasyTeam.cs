using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyTeam
    {
        public required int Id { get; init; }
        public required string Abbreviation { get; init; }
        public required string LogoURL { get; init; }
        public required string Name { get; init; }
        public required FantasyTeamSeasonStats SeasonStats { get; init; }
        public required List<FantasyMatchup> Matchups { get; init; }
        public required List<string> OwnerIds { get; init; }
    }
}
