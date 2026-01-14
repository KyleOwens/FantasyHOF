using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ClerkId { get; private set; } = null!;

        public List<League> Leagues { get; private set; } = [];

        public User(string clerkId)
        {
            ClerkId = clerkId;
        }

        public bool RemoveLeagueIfExists(int leagueId)
        {
            League? leagueToRemove = Leagues.SingleOrDefault(
                league => league.Id == leagueId);

            if (leagueToRemove == null) return false;

            Leagues.Remove(leagueToRemove);

            return true;
        }

        public bool RemoveLeagueIfExists(FantasyProviderId providerId, string providerLeagueId)
        {
            League? leagueToRemove = Leagues.SingleOrDefault(
                league => league.ProviderLeagueId == providerLeagueId &&
                    league.FantasyProviderId == providerId);

            if (leagueToRemove == null) return false;

            Leagues.Remove(leagueToRemove);

            return true;
        }

        public void AddLeague(League league)
        {
            if (!Leagues.Any(l => l.Id == league.Id))
            {
                Leagues.Add(league);
            }
        }
    }
}
