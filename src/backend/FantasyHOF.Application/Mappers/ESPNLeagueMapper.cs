using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mappers
{
    public interface IESPNLeagueMapper
    {
        FantasyLeague MapLeague(List<ESPNLeagueYearMemberDetails> leagueYears);
    }

    public class ESPNLeagueMapper : IESPNLeagueMapper
    {
        public FantasyLeague MapLeague(List<ESPNLeagueYearMemberDetails> espnSeasons)
        {
            List<FantasyleagueSeason> seasons = espnSeasons.Select(MapSeason).ToList();
            
            return new FantasyLeague() { Seasons = seasons };
        }

        private FantasyleagueSeason MapSeason(ESPNLeagueYearMemberDetails espnSeason)
        {
            List<FantasyTeam> teams = espnSeason.Teams.Select(MapTeam).ToList();

            var teamLookup = teams
                .SelectMany(team => team.OwnerIDs
                    .Select(ownerId => new { ownerId, team }))
                .ToLookup(x => x.ownerId, x => x.team);

            List<FantasyMember> members = espnSeason.Members.Select(member => MapMember(member, teamLookup)).ToList();

            return new FantasyleagueSeason
            {
                Members = members
            };
        }

        private FantasyTeam MapTeam(ESPNFantasyTeam espnTeam)
        {
            return new FantasyTeam
            {
                Id = espnTeam.Id,
                Name = espnTeam.Name,
                Abbreviation = espnTeam.Abbrev,
                LogoURL = espnTeam.Logo
            };
        }

        private FantasyMember MapMember(ESPNFantasyMember member, ILookup<string, FantasyTeam> teamLookup)
        {
            return new FantasyMember()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                DisplayName = member.DisplayName,
                IsLeagueCreator = member.IsLeagueCreator,
                IsLeagueManager = member.IsLeagueManager,
                Teams = teamLookup[member.Id].ToList()
            };
        }
    }
}
