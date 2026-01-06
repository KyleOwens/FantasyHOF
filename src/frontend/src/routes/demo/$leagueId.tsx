import { LeagueDashboard } from "@/components/league-dashboard/LeagueDashboard";
import { Spinner } from "@/components/ui/spinner";
import { RecordCategory, RecordSentiment } from "@/types/enums";
import { createFileRoute } from "@tanstack/react-router";
import { Suspense } from "react";

export type DashboardSearch = {
  recordCategory: RecordCategory;
  recordSentiment: RecordSentiment;
};

export const Route = createFileRoute("/demo/$leagueId")({
  component: RouteComponent,
  validateSearch: (search: Record<string, unknown>): DashboardSearch => {
    return {
      recordCategory: (search.recordCategory as RecordCategory) || "LEAGUE",
      recordSentiment: (search.recordSentiment as RecordSentiment) || "FAME",
    };
  },
});

function RouteComponent() {
  return (
    <Suspense fallback={<Spinner className="m-auto size-20 text-primary" />}>
      <LeagueDashboard />
    </Suspense>
  );
}
