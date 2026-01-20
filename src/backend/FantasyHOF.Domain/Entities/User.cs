using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class User(string clerkId)
    {
        public string Id { get; private set; } = clerkId;

        public List<League> Leagues { get; private set; } = [];

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
    }
}
