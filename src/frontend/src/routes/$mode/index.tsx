import { ModeDemoLeaguesQuery } from "@/__generated__/ModeDemoLeaguesQuery.graphql";
import { ModeUserLeaguesQuery } from "@/__generated__/ModeUserLeaguesQuery.graphql";
import { RelayEnvironment } from "@/relay/RelayEnvironment";
import { createFileRoute, redirect } from "@tanstack/react-router";
import { graphql, fetchQuery } from "relay-runtime";
import { Route as dashboardRoute } from "@/routes/$mode/$leagueId/dashboard";
import { Route as myLeaguesRoute } from "@/routes/$mode/my-leagues";

const demoLeaguesQuery = graphql`
  query ModeDemoLeaguesQuery {
    demoLeagues {
      id
    }
  }
`;

const userLeaguesQuery = graphql`
  query ModeUserLeaguesQuery {
    me {
      leagues(first: 50) {
        nodes {
          id
        }
      }
    }
  }
`;

export const Route = createFileRoute("/$mode/")({
  beforeLoad: async ({ params, context }) => {
    if (params.mode === "me" && !context.auth.isSignedIn) {
      throw redirect({ to: "/" });
    }

    const firstLeagueId = await getFirstLeagueIdForMode(params.mode);
    if (!firstLeagueId) {
      throw redirect({ from: Route.fullPath, to: myLeaguesRoute.to }); // We will  make this an add team page soon
    }

    throw redirect({
      to: dashboardRoute.to,
      params: { mode: params.mode, leagueId: firstLeagueId },
    });
  },
});

async function getFirstLeagueIdForMode(
  mode: "me" | "demo",
): Promise<string | undefined> {
  if (mode === "demo") {
    const data = await fetchQuery<ModeDemoLeaguesQuery>(
      RelayEnvironment,
      demoLeaguesQuery,
      {},
    ).toPromise();

    return data?.demoLeagues.at(0)?.id ?? undefined;
  } else {
    const data = await fetchQuery<ModeUserLeaguesQuery>(
      RelayEnvironment,
      userLeaguesQuery,
      {},
    ).toPromise();

    return data?.me.leagues?.nodes?.at(0)?.id ?? undefined;
  }
}
