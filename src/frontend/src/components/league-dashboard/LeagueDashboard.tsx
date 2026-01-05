import { LeagueDashboardQuery } from "@/__generated__/LeagueDashboardQuery.graphql";
import { useParams } from "@tanstack/react-router";
import { graphql, useLazyLoadQuery } from "react-relay";
import { RecordSection } from "./RecordSection";

const dashboardQuery = graphql`
  query LeagueDashboardQuery($leagueId: ID!) {
    league(id: $leagueId) {
      currentLeagueName
      recordSummary {
        leagueRecords {
          ...RecordSectionFragment
        }
        seasonalRecords {
          ...RecordSectionFragment
        }
        weeklyRecords {
          ...RecordSectionFragment
        }
        playerRecords {
          ...RecordSectionFragment
        }
        playerRecords {
          value
          year
          week
          sentiment
          member {
            fullName
          }
        }
      }
    }
  }
`;

export function LeagueDashboard() {
  const leagueId = useParams({ from: "/demo/$leagueId" }).leagueId;
  const league = useLazyLoadQuery<LeagueDashboardQuery>(dashboardQuery, {
    leagueId: leagueId,
  }).league;

  if (!league.recordSummary) return;

  return (
    <div>
      <h1 className="text-3xl font-bold tracking-tight">Dashboard</h1>
      <span className="text-muted-foreground">{league.currentLeagueName}</span>
      <div className="mt-6 w-full">
        <RecordSection
          title={"League records"}
          recordKey={league.recordSummary.leagueRecords}
        />
        <RecordSection
          title={"Seasonal records"}
          recordKey={league.recordSummary.seasonalRecords}
        />
        <RecordSection
          title={"Weekly records"}
          recordKey={league.recordSummary.weeklyRecords}
        />
        <RecordSection
          title={"Player records"}
          recordKey={league.recordSummary.playerRecords}
        />
      </div>
    </div>
  );
}
