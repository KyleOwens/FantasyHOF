import { LeagueDashboardQuery } from "@/__generated__/LeagueDashboardQuery.graphql";
import {
  LeagueDashboard,
  leagueDashboardQuery,
} from "@/components/league-dashboard/LeagueDashboard";
import { Spinner } from "@/components/ui/spinner";
import { preloadQuery } from "@/relay/helpers";
import { RecordCategory, RecordSentiment } from "@/types/enums";
import { createFileRoute } from "@tanstack/react-router";
import { z } from "zod";
import { fallback, zodValidator } from "@tanstack/zod-adapter";

const dashboardSearchSchema = z.object({
  recordCategory: fallback(
    z.nativeEnum(RecordCategory),
    RecordCategory.LEAGUE,
  ).default(RecordCategory.LEAGUE),
  recordSentiment: fallback(
    z.nativeEnum(RecordSentiment),
    RecordSentiment.FAME,
  ).default(RecordSentiment.FAME),
});

export const Route = createFileRoute("/demo/$leagueId/dashboard")({
  component: RouteComponent,
  loader: ({ params }) => {
    return preloadQuery<LeagueDashboardQuery>(leagueDashboardQuery, {
      leagueId: params.leagueId,
    });
  },
  validateSearch: zodValidator(dashboardSearchSchema),
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
  pendingComponent: () => <Spinner className="m-auto size-20 text-primary" />,
});

function RouteComponent() {
  const queryRef = Route.useLoaderData();

  return <LeagueDashboard queryRef={queryRef} />;
}
