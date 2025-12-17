using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class Team
    {
        public int Id { get; init; }

        public required int ProviderTeamId { get; init; }
        public required string Abbreviation { get; init; }
        public required string? LogoURL { get; init; }
        public required string Name { get; init; }

        public TeamSeasonStats SeasonStats { get; set; } = null!;
        public List<TeamMatchup> Matchups { get; set; } = null!;
    }
}
