using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class TeamMatchup
    {
        public int Id { get; private set; }
        public int TeamId { get; set; }
        public int OwnerMatchupDetailsId { get; set; }
        public int? OpponentMatchupDetailsId { get; set; }

        public required int Year { get; init; }
        public required int Week { get; init; }
        public required int? OpponentProviderTeamId { get; init; }
        public required MatchupTypeId MatchupTypeId { get; init; }

        public Team Team { get; private set; } = null!;
        public MatchupType MatchupType { get; private set; } = null!;
        public MatchupTeamDetails OwnerMatchupDetails { get; private set; } = null!;
        public MatchupTeamDetails? OpponentMatchupDetails { get; private set; } = null!;

        public decimal ScoreMargin =>
            OpponentMatchupDetails != null ?
            OwnerMatchupDetails.Score - OpponentMatchupDetails.Score :
            0;

        public void SetOwnerMathcupDetails(MatchupTeamDetails ownerMatchupDetails)
        {
            OwnerMatchupDetails = ownerMatchupDetails;
        }

        public void SetOpponentMathcupDetails(MatchupTeamDetails opponentMatchupDetails)
        {
            OpponentMatchupDetails = opponentMatchupDetails;
        }
    }
}