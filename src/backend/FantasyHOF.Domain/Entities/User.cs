using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
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

        public void RemoveLeagueIfExists(FantasyProviderId providerId, string providerLeagueId)
        {
            League? leagueToRemove = Leagues.SingleOrDefault(
                league => league.ProviderLeagueId == providerLeagueId &&
                    league.FantasyProviderId == providerId);

            if (leagueToRemove == null) return;

            Leagues.Remove(leagueToRemove);
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
