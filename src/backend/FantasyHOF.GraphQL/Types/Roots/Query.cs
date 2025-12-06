using FantasyHOF.ESPN;

namespace FantasyHOF.GraphQL.Types.Roots;

[QueryType]
public static class Query
{
    public static async Task<List<string>> LoadESPNLeague(string leagueID, string swid, string espn2id, IESPNHTTPService espnClient)
    { 
        return espnClient.LoadLeague(leagueID, swid, espn2id);
    }

    public static string GetTest2() => "Second test messagea";
}
