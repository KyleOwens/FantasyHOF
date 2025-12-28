using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Types
{
    public class League
    {
        public int Id { get; private set; }
        public Guid? UserId { get; private set; }

        public required FantasyProviderId FantasyProviderId { get; init; }
        public required string ProviderLeagueId { get; init; }
        public required SportId SportId { get; init; }

        public string CurrentLeagueName { get; private set; } = null!;
        public int CurrentLeagueYear { get; private set; }

        public List<LeagueSeason> Seasons { get; set; } = [];
        public FantasyProvider FantasyProvider { get; private set; } = null!;
        public Sport Sport { get; private set; } = null!;

        public void AddSeason(LeagueSeason season)
        {
            Seasons.Add(season);

            if (season.Year <= CurrentLeagueYear) return;

            CurrentLeagueName = season.Settings.LeagueName;
            CurrentLeagueYear = season.Year;
        }
    }
}
