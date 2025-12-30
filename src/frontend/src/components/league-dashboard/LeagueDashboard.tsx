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

const dashboardQuery = graphql`
  query LeagueDashboardQuery($leagueId: ID!) {
    league(id: $leagueId) {
      id
      currentLeagueName
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
    </div>
  );
}
