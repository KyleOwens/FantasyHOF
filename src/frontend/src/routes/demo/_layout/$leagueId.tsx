import { LeagueDashboard } from "@/components/league-dashboard/LeagueDashboard";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/demo/_layout/$leagueId")({
  component: RouteComponent,
});

function RouteComponent() {
  return <LeagueDashboard />;
}
