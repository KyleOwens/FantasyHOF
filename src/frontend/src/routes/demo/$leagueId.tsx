import { LeagueDashboardQuery } from "@/__generated__/LeagueDashboardQuery.graphql";
import {
  leagueDashboardQuery,
  LeagueDashboard,
} from "@/components/league-dashboard/LeagueDashboard";
import { Spinner } from "@/components/ui/spinner";
import { preloadQuery } from "@/relay/helpers";
import { RecordCategory, RecordSentiment } from "@/types/enums";
import { createFileRoute } from "@tanstack/react-router";

export type DashboardSearch = {
  recordCategory: RecordCategory;
  recordSentiment: RecordSentiment;
};

export const Route = createFileRoute("/demo/$leagueId")({
  component: RouteComponent,
  loader: ({ params }) => {
    return preloadQuery<LeagueDashboardQuery>(leagueDashboardQuery, {
      leagueId: params.leagueId,
    });
  },
  validateSearch: (search: Record<string, unknown>): DashboardSearch => {
    return {
      recordCategory: (search.recordCategory as RecordCategory) || "LEAGUE",
      recordSentiment: (search.recordSentiment as RecordSentiment) || "FAME",
    };
  },
  onLeave: ({ loaderData }) => {
    loaderData?.dispose();
  },
  pendingComponent: () => <Spinner className="m-auto size-20 text-primary" />,
});

function RouteComponent() {
  const queryRef = Route.useLoaderData();

  return <LeagueDashboard queryRef={queryRef} />;
}
