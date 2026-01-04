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
        leagueRecords {
          ...LeagueRecordCardFragment
        }
        seasonalRecords {
          value
          year
          member {
            fullName
          }
        }
        weeklyRecords {
          value
          year
          week
          member {
            fullName
          }
        }
        playerRecords {
          value
          year
          week
          member {
            fullName
          }
        }
      }
    }
  }
`;

export function LeagueDashboard() {
  const leagueId = useParams({ from: "/demo/_layout/$leagueId" }).leagueId;
  const league = useLazyLoadQuery<LeagueDashboardQuery>(dashboardQuery, {
    leagueId: leagueId,
  }).league;

  if (!league.recordSummary) return;

  return (
    <div>
      <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
      <p className="text-muted-foreground">{league.currentLeagueName}</p>
      <div className="mt-6 w-full">
        <h3 className="text-xl font-medium">League records</h3>
        <div className="grid grid-cols-1 md:grid-cols-2 2xl:grid-cols-4 gap-8 py-4 w-full">
          {league.recordSummary.leagueRecords.map((leagueRecord) => (
            <LeagueRecordCard recordKey={leagueRecord} />
          ))}
        </div>
      </div>
    </div>
  );
}
