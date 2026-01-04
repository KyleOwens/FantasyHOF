import { LeagueDashboardQuery } from "@/__generated__/LeagueDashboardQuery.graphql";
import { useParams } from "@tanstack/react-router";
import { graphql, useLazyLoadQuery } from "react-relay";
import {
  Item,
  ItemActions,
  ItemContent,
  ItemDescription,
  ItemMedia,
  ItemTitle,
} from "../ui/item";
import { Button } from "../ui/button";
import { LeagueRecordCard } from "../LeagueRecordCard";

const dashboardQuery = graphql`
  query LeagueDashboardQuery($leagueId: ID!) {
    league(id: $leagueId) {
      currentLeagueName
      recordSummary {
        mostPointsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostAveragePointsPerWeekLeagueHistory {
          ...LeagueRecordCardFragment
        }
        leastPointsAllowedLeagueHistory {
          ...LeagueRecordCardFragment
        }
        leastAveragePointsAllowedPerWeekLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostWinsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        leastLossesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestWinPercentageLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostTopWeeklyScoresLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestPercentageTopWeeklyScoresLeagueHisotry {
          ...LeagueRecordCardFragment
        }
        mostBlowoutWinsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostNarrowWinsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostChampionshipsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestChampionshipPercentageLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostSeasonsWinningRecordLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestWinningRecordPercentageLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostOutstandingPerformancesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        leastPointsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        leastAveragePointsPerWeekLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostPointsAllowedLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostAveragePointsAllowedPerWeekLeagueHistory {
          ...LeagueRecordCardFragment
        }
        leastWinsLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostLossesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        lowestWinPercentageLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostLowestWeeklyScoresLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestPercentageLowestWeeklyScoresLeagueHisotry {
          ...LeagueRecordCardFragment
        }
        mostBlowoutLossesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostNarrowLossesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostLastPlacesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestLastPlacePercentageLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostSeasonsLosingRecordLeagueHistory {
          ...LeagueRecordCardFragment
        }
        highestLosingRecordPercentageLeagueHistory {
          ...LeagueRecordCardFragment
        }
        mostPoorPerformancesLeagueHistory {
          ...LeagueRecordCardFragment
        }
        # mostPointsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostPointsPerWeekSingleSeason {
        #   ...seasonRecordDetails
        # }
        # leastPointsAllowedSingleSeason {
        #   ...seasonRecordDetails
        # }
        # leastPointsAllowedPerWeekSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostWinsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostHighestScoringWeeksSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostBlowoutWinsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostNarrowWinsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostOutstandingPerformancesSingleSeason {
        #   ...seasonRecordDetails
        # }
        # leastPointsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # leastPointsPerWeekSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostPointsAllowedSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostPointsAllowedPerWeekSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostLossesSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostLowestScoringWeeksSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostBlowoutWinsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostNarrowWinsSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostPoorPerformancesSingleSeason {
        #   ...seasonRecordDetails
        # }
        # mostPointsSingleWeek {
        #   ...weeklyRecordDetails
        # }
        # mostPointsSinglePlayoffWeek {
        #   ...weeklyRecordDetails
        # }
        # largestMarginOfVictorySingleWeek {
        #   ...weeklyRecordDetails
        # }
        # largestMarginOfVictorySinglePlayoffWeek {
        #   ...weeklyRecordDetails
        # }
        # lowestScoringWinSingleWeek {
        #   ...weeklyRecordDetails
        # }
        # leastPointsSingleWeek {
        #   ...weeklyRecordDetails
        # }
        # leastPointsSinglePlayoffWeek {
        #   ...weeklyRecordDetails
        # }
        # lowestMarginOfVictorySingleWeek {
        #   ...weeklyRecordDetails
        # }
        # lowestMarginOfVictorySinglePlayoffWeek {
        #   ...weeklyRecordDetails
        # }
        # highestScoringLossSingleWeek {
        #   ...weeklyRecordDetails
        # }
        # mostPointsScoredSinglePlayer {
        #   ...playerRecordDetails
        # }
        # mostPointsScoredSingleNonQBPlayer {
        #   ...playerRecordDetails
        # }
        # leastPointsScoredSinglePlayer {
        #   ...playerRecordDetails
        # }
        # leastPointsScoredSingleNonDefensePlayer {
        #   ...playerRecordDetails
        # }
      }
    }
  }
`;

export function LeagueDashboard() {
  const leagueId = useParams({ from: "/demo/_layout/$leagueId" }).leagueId;
  const league = useLazyLoadQuery<LeagueDashboardQuery>(dashboardQuery, {
    leagueId: leagueId,
  }).league;

  return (
    <div>
      <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
      <p className="text-muted-foreground">{league.currentLeagueName}</p>
      <div className="mt-6 w-full">
        <h3 className="text-xl font-medium">League records</h3>
        <div className="grid grid-cols-1 md:grid-cols-2 2xl:grid-cols-4 gap-8 py-4 w-full">
          {league.recordSummary && (
            <>
              <LeagueRecordCard
                title="Most championships"
                recordKey={league.recordSummary.mostChampionshipsLeagueHistory}
              />
              <LeagueRecordCard
                title="Most wins"
                recordKey={league.recordSummary.mostWinsLeagueHistory}
              />
              <LeagueRecordCard
                title="Best win percentage"
                recordKey={
                  league.recordSummary.highestWinPercentageLeagueHistory
                }
                isPercentage
              />
              <LeagueRecordCard
                title="Most points"
                recordKey={league.recordSummary.mostPointsLeagueHistory}
              />
              <LeagueRecordCard
                title="Most points per week"
                recordKey={
                  league.recordSummary.mostAveragePointsPerWeekLeagueHistory
                }
              />
              <LeagueRecordCard
                title="Least points allowed per week"
                recordKey={
                  league.recordSummary
                    .leastAveragePointsAllowedPerWeekLeagueHistory
                }
              />
              <LeagueRecordCard
                title="Most top weekly scores"
                recordKey={
                  league.recordSummary.mostTopWeeklyScoresLeagueHistory
                }
              />
              <LeagueRecordCard
                title="Best percentage top weekly scores"
                recordKey={
                  league.recordSummary
                    .highestPercentageTopWeeklyScoresLeagueHisotry
                }
                isPercentage
              />
              <LeagueRecordCard
                title="Most blowout wins"
                recordKey={league.recordSummary.mostBlowoutLossesLeagueHistory}
              />
              <LeagueRecordCard
                title="Most narrow wins"
                recordKey={league.recordSummary.mostNarrowWinsLeagueHistory}
              />
              <LeagueRecordCard
                title="Least losses"
                recordKey={league.recordSummary.leastLossesLeagueHistory}
              />
              <LeagueRecordCard
                title="Least points allowed"
                recordKey={league.recordSummary.leastPointsAllowedLeagueHistory}
              />
            </>
          )}
        </div>
      </div>
    </div>
  );
}
