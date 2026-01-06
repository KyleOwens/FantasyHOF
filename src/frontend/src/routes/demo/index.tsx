import { demoLeaguesQuery as LayoutDemoLeaguesQueryType } from "@/__generated__/demoLeaguesQuery.graphql";
import { RelayEnvironment } from "@/relay/RelayEnvironment";
import { createFileRoute, redirect } from "@tanstack/react-router";
import { fetchQuery, graphql } from "relay-runtime";
import { Route as demoDashboardRoute } from "@/routes/demo/$leagueId/dashboard";

const demoLeaguesQuery = graphql`
  query demoLeaguesQuery {
    demoLeagues {
      id
    }
  }
`;

export const Route = createFileRoute("/demo/")({
  beforeLoad: async () => {
    const data = await fetchQuery<LayoutDemoLeaguesQueryType>(
      RelayEnvironment,
      demoLeaguesQuery,
      {},
    ).toPromise();

    const firstLeagueId = data?.demoLeagues?.[0]?.id;

    if (firstLeagueId) {
      throw redirect({
        to: demoDashboardRoute.to,
        params: { leagueId: firstLeagueId },
      });
    }

    // Handle no leagues case
    throw redirect({ to: "/" });
  },
});
