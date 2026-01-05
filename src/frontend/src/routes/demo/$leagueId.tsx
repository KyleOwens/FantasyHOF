import { LeagueDashboard } from "@/components/league-dashboard/LeagueDashboard";
import { Spinner } from "@/components/ui/spinner";
import { createFileRoute } from "@tanstack/react-router";
import { Suspense } from "react";

export const Route = createFileRoute("/demo/$leagueId")({
  component: RouteComponent,
});

function RouteComponent() {
  return (
    <Suspense fallback={<Spinner className="m-auto size-20 text-primary" />}>
      <LeagueDashboard />
    </Suspense>
  );
}
