using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Interfaces;

namespace FantasyHOF.Domain.Entities
{
    public class League : ITimestamped
    {
        public int Id { get; private set; }
        public Guid UserId { get; private set; }

        public required FantasyProviderId FantasyProviderId { get; init; }
        public required string ProviderLeagueId { get; init; }
        public required SportId SportId { get; init; }

        public string CurrentLeagueName { get; private set; } = null!;
        public int CurrentLeagueYear { get; private set; }

        public List<LeagueSeason> Seasons { get; set; } = [];
        public List<LeagueMember> Members { get; private set; } = [];
        public FantasyProvider FantasyProvider { get; private set; } = null!;
        public Sport Sport { get; private set; } = null!;

        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }

        public void AddSeason(LeagueSeason season)
        {
            Seasons.Add(season);

            if (season.Year <= CurrentLeagueYear) return;

            CurrentLeagueName = season.Settings.LeagueName;
            CurrentLeagueYear = season.Year;
        }

        public void SetLeagueMembers(LeagueMember member)
        {
            if (Members.Any(x => x.MemberId == member.MemberId)) return;
            
            Members.Add(member);
        }
    }
}
