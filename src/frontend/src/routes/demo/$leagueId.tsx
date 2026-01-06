import { LeagueDashboardQuery } from "@/__generated__/LeagueDashboardQuery.graphql";
import {
  dashboardQuery,
  LeagueDashboard,
} from "@/components/league-dashboard/LeagueDashboard";
import { Spinner } from "@/components/ui/spinner";
import { preloadQuery } from "@/relay/helpers";
import { RecordCategory, RecordSentiment } from "@/types/enums";
import { createFileRoute, useLoaderData } from "@tanstack/react-router";
import { Suspense } from "react";

export type DashboardSearch = {
  recordCategory: RecordCategory;
  recordSentiment: RecordSentiment;
};

export const Route = createFileRoute("/demo/$leagueId")({
  component: RouteComponent,
  loader: ({ params }) => {
    const queryRef = preloadQuery<LeagueDashboardQuery>(dashboardQuery, {
      leagueId: params.leagueId,
    });

    return { queryRef };
  },
  validateSearch: (search: Record<string, unknown>): DashboardSearch => {
    return {
      recordCategory: (search.recordCategory as RecordCategory) || "LEAGUE",
      recordSentiment: (search.recordSentiment as RecordSentiment) || "FAME",
    };
  },
  onLeave: ({ loaderData }) => {
    loaderData?.queryRef.dispose();
  },
  pendingComponent: () => <Spinner className="m-auto size-20 text-primary" />,
});

function RouteComponent() {
  const { queryRef } = Route.useLoaderData();

  return <LeagueDashboard queryRef={queryRef} />;
}
