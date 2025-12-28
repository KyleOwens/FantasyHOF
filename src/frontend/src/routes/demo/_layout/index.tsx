import { LayoutDemoLeaguesQuery as LayoutDemoLeaguesQueryType } from "@/__generated__/LayoutDemoLeaguesQuery.graphql";
import { RelayEnvironment } from "@/relay/RelayEnvironment";
import { createFileRoute, redirect } from "@tanstack/react-router";
import { fetchQuery, graphql } from "relay-runtime";
import { Route as demoLeagueIdRoute } from "./$leagueId.tsx";

const demoLeaguesQuery = graphql`
  query LayoutDemoLeaguesQuery {
    demoLeagues {
      id
    }
  }
`;

export const Route = createFileRoute("/demo/_layout/")({
  beforeLoad: async () => {
    const data = await fetchQuery<LayoutDemoLeaguesQueryType>(
      RelayEnvironment,
      demoLeaguesQuery,
      {},
    ).toPromise();

    const firstLeagueId = data?.demoLeagues?.[0]?.id;

    if (firstLeagueId) {
      throw redirect({
        to: demoLeagueIdRoute.to,
        params: { leagueId: firstLeagueId },
      });
    }

    // Handle no leagues case
    throw redirect({ to: "/" });
  },
});
