namespace FantasyHOF.Domain.Types
{
    public class FantasyLeague
    {
        public List<FantasyleagueSeason> Seasons { get; init; } = [];
        // Other league-wide, non yearly details (could potentially be methods or properties that aggregate yearly data
    }
}
